using exercise.webapi.DTOs;

namespace exercise.webapi.Repository;

public interface IPublisherRepository
{
    public Task<IEnumerable<PublisherDto>> GetPublishers();
    public Task<PublisherDto?> GetPublisher(int id);
}