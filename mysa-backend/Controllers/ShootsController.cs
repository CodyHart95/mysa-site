using Microsoft.AspNetCore.Mvc;
using mysa_backend.DynamoModels;
using mysa_backend.Models;
using mysa_backend.Repositories;

namespace mysa_backend.Controllers
{
    [Route("[controller]")]
    public class ShootsController : Controller
    {
        private readonly IShootRepository shootRepo;
        private readonly IClubRepository clubRepo;

        public ShootsController(IShootRepository shootRepo, IClubRepository clubRepo) 
        {
            this.shootRepo = shootRepo;
            this.clubRepo = clubRepo;
        }

        [HttpGet]
        public async Task<IActionResult> List([FromQuery] string paginationToken)
        {
            try
            {
                var shoots = await shootRepo.ListShoots(paginationToken);

                if(shoots == null)
                {
                    return Ok(new Shoot[0]);
                }
                var shootResponses = shoots.Select(s => new Shoot(s));
                return Ok(shootResponses);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("/date")]
        public async Task<IActionResult> ListByDate([FromQuery] DateTime date, [FromQuery] string paginationToken)
        {
            try
            {
                var shoots = await shootRepo.ListShootsByDate(date, paginationToken);

                if (shoots == null)
                {
                    return Ok(new Shoot[0]);
                }
                var shootResponses = shoots.Select(s => new Shoot(s));
                return Ok(shootResponses);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("/upcoming")]
        public async Task<IActionResult> ListUpcoming([FromQuery] string paginationToken)
        {
            try
            {
                var shoots = await shootRepo.ListShootsAfterDate(DateTime.Now, paginationToken);

                if (shoots == null)
                {
                    return Ok(new Shoot[0]);
                }

                var shootResponses = shoots.Select(s => new Shoot(s));
                return Ok(shootResponses);
            }
            catch
            {
                return StatusCode(500);
            }
        }


        [HttpGet]
        [Route("/club")]
        public async Task<IActionResult> ListByClub([FromQuery] string clubName, [FromQuery] string paginationToken)
        {
            try
            {
                var shoots = await shootRepo.ListShootsByClub(clubName, paginationToken);

                if (shoots == null)
                {
                    return Ok(new Shoot[0]);
                }
                var shootResponses = shoots.Select(s => new Shoot(s));
                return Ok(shootResponses);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Shoot shoot)
        {
            try
            {
                var shootEntity = new ShootEntity(shoot);
                var clubEntity = new ClubEntity(shoot);

                await shootRepo.SaveEntity(shootEntity);
                await clubRepo.SaveEntity(clubEntity);
                return Ok();
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
