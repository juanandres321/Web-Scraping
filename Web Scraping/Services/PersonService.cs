using AutoMapper;
using Due_Diligence.DTOs;
using Due_Diligence.Models;
using Due_Diligence.Repository;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using Web_Scraping.DTOs;
using Web_Scraping.Models;
using Microsoft.Extensions.Configuration;
namespace Due_Diligence.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        public PersonService(IPersonRepository personRepository,IMapper mapper, IConfiguration configuration)
        {
            _personRepository = personRepository;
            _mapper = mapper;
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }
        public async Task<(Response<bool?>, HttpStatusCode)> LogIn(PersonLoginDTO personLoginDTO)
        {
            try {
                Person person = _mapper.Map<Person>(personLoginDTO);
                person.IdPerson = 1;
                bool? result = await _personRepository.LogIn(person);
                if (result == false)
                    return (Response<bool?>.CreateResponse(true, "OK", result), HttpStatusCode.OK);
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim("IdPerson",personLoginDTO.UserName.ToString())
                };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:key"]));
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    _configuration["Jwt:Issuer"],
                    _configuration["Jwt:Audience"],
                    claims,
                    expires: DateTime.UtcNow.AddMinutes(60),
                    signingCredentials: signIn
                    );
                string tokenValue = new JwtSecurityTokenHandler().WriteToken(token);
                
                return (Response<bool?>.CreateResponse(true, "OK", result,tokenValue, DateTime.UtcNow.AddMinutes(60).ToString()), HttpStatusCode.OK);
            }
            catch (Exception ex)
            {

            }
            throw new NotImplementedException();
        }
    }
}
