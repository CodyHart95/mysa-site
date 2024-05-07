using mysa_backend.DynamoModels;

namespace mysa_backend.Models
{
    public class Shoot
    {
        public Shoot() { }

        public Shoot(ShootEntity entity) 
        { 
            this.ShootId = entity.ShootId;
            this.ClubName = entity.ClubName;
            this.Date = entity.Date;
            this.City = entity.City;
            this.State = entity.State;
            this.Name = entity.Name;
        }
        public string ShootId { get; set; }
        public string ClubName { get; set; }
        public DateTime Date { get; set; }

        public string City { get; set; }
        public string State { get; set; }
        public string Name { get; set; }
    }
}
