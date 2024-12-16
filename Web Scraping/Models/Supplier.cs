using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Web_Scraping.Models
{
    [Table("Supplier")]
    public class Supplier
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_SUPPLIER")]
        public int IdSupplier { get; set; }

        //Razón social
        [Column("COMPANY_NAME", TypeName = "VARCHAR(100)")]
        public string? CompanyName { get; set; }


        //Nombre comercial
        [Column("TRADE_NAME", TypeName = "VARCHAR(100)")]
        public string? TradeName { get; set; }


        //Identificación tributaria
        [Column("TAX_IDENTIFICATION", TypeName = "INT")]
        public required int TaxIdentification { get; set; }


        //Número telefónico
        [Column("TELEPHONE_NUMBER", TypeName = "INT")]
        public required int TelephoneNumber { get; set; }


        //Correo electrónico
        [Column("EMAIL", TypeName = "VARCHAR(100)")]
        public string? EMail { get; set; }


        //Página Web
        [Column("WEB_PAGE", TypeName = "VARCHAR(100)")]
        public required string WebPage { get; set; }


        //Dirección física
        [Column("ADRESS", TypeName = "VARCHAR(100)")]
        public string? Adress { get; set; }


        //Páis
        [Column("COUNTRY", TypeName = "VARCHAR(50)")]
        public string? Country { get; set; }


        //Facturación anual en dólares
        [Column("ANNUAL_TURNOVER", TypeName = "INT")]
        public int? AnnualTurnover { get; set; }


        //Fecha última de edición
        [Column("LAST_EDITION", TypeName = "DATETIME")]
        public DateTime? LastEdition { get; set; }

        
        
    }
}
