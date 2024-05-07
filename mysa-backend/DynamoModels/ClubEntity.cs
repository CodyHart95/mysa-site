using mysa_backend.Models;

namespace mysa_backend.DynamoModels
{
    public class ClubEntity : EntityBase
    {
        public static string Prefix = "CLUB";
        public ClubEntity() { }

        public ClubEntity(Shoot shoot)
        {
            this.PK = $"${Prefix}-{NormalizeForKey(shoot.ClubName)}";
            this.SK = $"{Prefix}-{NormalizeForKey(shoot.City)}";

            this.ClubName = Normalize(shoot.ClubName);
            this.City = Normalize(shoot.City);
            this.State = Normalize(shoot.State);
        }

        public ClubEntity(string name, string city)
        {
            this.PK = $"${Prefix}-{NormalizeForKey(name)}";
            this.SK = $"{Prefix}-{NormalizeForKey(city)}";

            this.ClubName = Normalize(name);
            this.City = Normalize(city);
        }

        public string ClubName {get; set;}

        public string City { get; set;}

        public string State { get; set;}

        private string Normalize(string name)
        {
            var lowercase = name.ToLower();

            var nameParts = name.Split(' ');

            var uppers = nameParts.Select(part => string.Concat(name[0].ToString().ToUpper(), name.AsSpan(1)));

            return string.Join(" ", uppers);
        }

        private string NormalizeForKey(string name) => name.ToLower().Replace(" ", "");
    }
}
