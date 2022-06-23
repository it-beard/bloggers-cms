namespace Pds.Api.Contracts.Controllers.Content.GetContent;

public class GetContentForPayResponse
{
    public string Id { get; set; }

    public string Title { get; set; }

    public GetContentBillForPayResponse Bill { get; set; }
}