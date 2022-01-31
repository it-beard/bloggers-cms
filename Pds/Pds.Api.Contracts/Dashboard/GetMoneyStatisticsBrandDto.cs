namespace Pds.Api.Contracts.Dashboard;

public class GetMoneyStatisticsBrandDto
{
    public string BrandName { get; set; }
    
    public Guid BrandId { get; set; }
    
    public decimal BillsSumForThisMonth { get; set; }
    public decimal BillsSumForPreviousMonth { get; set; }
    public decimal BillsSumSameMonthYearAgo { get; set; }
    
    public decimal CostsSumForThisMonth { get; set; }
    public decimal CostsSumForPreviousMonth { get; set; }
    public decimal CostsSumSameMonthYearAgo { get; set; }
}