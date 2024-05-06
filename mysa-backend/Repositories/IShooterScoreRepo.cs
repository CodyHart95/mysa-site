using mysa_backend.DynamoModels;

namespace mysa_backend.Repositories
{
    public interface IShooterScoreRepo
    {
        Task<ShooterScoreEntity?> GetEntity(ShooterScoreEntity template);
        Task<ShooterScoreEntity?> GetEntity(string shooterId, string shootId);
        Task SaveEntity(ShooterScoreEntity template);
    }
}