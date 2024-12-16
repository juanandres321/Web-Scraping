namespace Web_Scraping.DTOs
{
    public class SupplierUpdateDTO
    {
        public int IdSupplier { get; set; }
        public string? CompanyName { get; set; }
        public string? TradeName { get; set; }
        public required int TaxIdentification { get; set; }
        public required int TelephoneNumber { get; set; }
        public string? EMail { get; set; }
        public string? WebPage { get; set; }
        public string? Adress { get; set; }
        public string? Country { get; set; }
        public int? AnnualTurnover { get; set; }
        public DateTime? LastEdition { get; set; }
    }
}
