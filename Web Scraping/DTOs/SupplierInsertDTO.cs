namespace Web_Scraping.DTOs
{
    public class SupplierInsertDTO
    {
        public string? CompanyName { get; set; }
        public string? TradeName { get; set; }
        public required int TaxIdentification { get; set; }
        public required int TelephoneNumber { get; set; }
        public string? EMail { get; set; }
        public required int WebPage { get; set; }
        public string? Adress { get; set; }
        public string? Country { get; set; }
        public int? AnnualTurnover { get; set; }
        public DateTime? LastEdition { get; set; }
    }
}
