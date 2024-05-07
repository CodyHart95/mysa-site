using mysa_backend.DynamoModels;

namespace mysa_backend.Repositories
{
    public interface IClubRepository
    {
        Task<ClubEntity?> GetEntity(ClubEntity template);
        Task<ClubEntity?> GetEntity(string clubName, string city);
        Task SaveEntity(ClubEntity template);
    }
}