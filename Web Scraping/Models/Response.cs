namespace Web_Scraping.Models
{
    public class Response<T>
    {
        public bool status { get; set; }
        public T? value { get; set; }
        public string? msg { get; set; }
        public string? token { get; set; }
        public string? tokenexpire { get; set; }
        public static Response<T> CreateResponse(bool status, string message, T value)
        {
            return new Response<T>
            {
                status = status,
                msg = message,
                value = value
            };
        }
        public static Response<T> CreateResponse(bool status, string message, T value, string token, string tokenexpire)
        {
            return new Response<T>
            {
                status = status,
                msg = message,
                value = value,
                token = token,
                tokenexpire = tokenexpire
            };
        }
        public static Response<T> Failure(string message)
        {
            return new Response<T>
            {
                status = false,
                value = default,
                msg = message,
                token = null,
                tokenexpire = null
            };
        }
    }
}
