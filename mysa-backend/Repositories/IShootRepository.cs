using mysa_backend.DynamoModels;

namespace mysa_backend.Repositories
{
    public interface IShootRepository
    {
        Task<ShootEntity?> GetEntity(ShootEntity template);
        Task<ShootEntity?> GetEntity(string id, string clubName);
        Task<ShootEntity[]?> ListShoots(string? paginationToken = null);
        Task<ShootEntity[]?> ListShootsByClub(string clubName, string? paginationToken = null);
        Task<ShootEntity[]?> ListShootsByDate(DateTime date, string? paginationToken = null);
        Task<ShootEntity[]?> ListShootsAfterDate(DateTime date, string? paginationToken = null);
        Task SaveEntity(ShootEntity template);
    }
}