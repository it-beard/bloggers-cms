namespace Pds.Api.Contracts.Topic;

public class UpdateTopicResponse
{
    public UpdateTopicResponse(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; set; }
}