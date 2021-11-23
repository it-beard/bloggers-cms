namespace Pds.Api.Contracts.Content.GetContent;

public class GetContentForPayResponse
{
    public string Id { get; set; }

    public string Title { get; set; }

    public GetContentBillForPayResponse Bill { get; set; }
}