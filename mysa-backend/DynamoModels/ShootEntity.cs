using Amazon.DynamoDBv2.DataModel;
using mysa_backend.Models;

namespace mysa_backend.DynamoModels
{
    public class ShootEntity : EntityBase
    {
        public static readonly string Prefix = "SHOOT";

        public ShootEntity() { }

        public ShootEntity(Shoot shoot)
        {
            this.PK = $"${Prefix}-{shoot.ShootId}";
            this.SK = $"{Prefix}-{shoot.Date.ToUniversalTime()}";
            this.GSI1PK = $"{Prefix}-{shoot.ClubName.ToLower().Replace(" ", "")}"; ;
            this.GSI1SK = $"${Prefix}-{shoot.ShootId}";
            

            this.ShootId = shoot.ShootId;
            this.ClubName = shoot.ClubName;
            this.Date = shoot.Date;
            this.City = shoot.City;
            this.State = shoot.State;
            this.Name = shoot.Name;
    }

        public ShootEntity(string id, string clubName, DateTime date) 
        { 
            this.PK = $"${Prefix}-{id}";
            this.SK = $"{Prefix}-{date.ToUniversalTime()}";
            this.GSI1PK = $"{Prefix}-{clubName.ToLower().Replace(" ", "")}"; ;
            this.GSI1SK = $"${Prefix}-{id}";

            this.ShootId = id;
            this.ClubName = clubName;
            this.Date = date;
        }

        public ShootEntity(string id, string clubName)
        {
            this.PK = $"${Prefix}-{id}";
            this.GSI1PK = $"{Prefix}-{clubName.ToLower().Replace(" ", "")}";
            this.GSI1SK = $"${Prefix}-{id}";

            this.ShootId = id;
            this.ClubName = clubName;
        }

        public ShootEntity(string id, DateTime date)
        {
            this.PK = $"${Prefix}-{id}";
            this.SK = $"{Prefix}-{date.ToUniversalTime()}";
            this.GSI1SK = $"${Prefix}-{id}";

            this.ShootId = id;
            this.Date = date;
        }

        public ShootEntity(DateTime date)
        {
            this.SK = $"{Prefix}-{date.ToUniversalTime()}";
            this.Date = date;
        }

        public ShootEntity(string clubName)
        {
            this.GSI1PK = $"{Prefix}-{clubName.ToLower().Replace(" ", "")}";
            this.ClubName = clubName;
        }

        [DynamoDBProperty("GSI1-PK")]
        public string GSI1PK { get; set; }

        [DynamoDBProperty("GSI1-SK")]
        public string GSI1SK { get; set; }

        public string ShootId { get; set; }
        public string ClubName { get; set; }
        public DateTime Date { get; set; }

        public string City { get; set; }
        public string State { get; set; }
        public string Name { get; set; }
    }
}
