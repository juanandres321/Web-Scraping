using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Due_Diligence.Models
{
    public class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_PERSON")]
        public int IdPerson { get; set; }


        [Column("USER_NAME", TypeName = "VARCHAR(100)")]
        public string? UserName { get; set; }
        [Column("PASSWORD", TypeName = "VARCHAR(250)")]
        public string? Password { get; set; }

    }
}
