using Microsoft.AspNetCore.Mvc;
using mysa_backend.DynamoModels;
using mysa_backend.Models;
using mysa_backend.Repositories;

namespace mysa_backend.Controllers
{
    [Route("[controller]")]
    public class ShootsController : Controller
    {
        private readonly IShooterScoreRepo shooterScoreRepo;

        public ShootsController(IShooterScoreRepo shooterScoreRepo) 
        {
            this.shooterScoreRepo = shooterScoreRepo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return View();
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ShootScore scores)
        {
            try
            {
                // We should really batch save these, but for now this will work for testing
                foreach (var score in scores.Scores)
                {
                    var entity = new ShooterScoreEntity(score.ShooterId, scores.ShootId);
                    entity.Score = score.Score;

                    await shooterScoreRepo.SaveEntity(entity);
                }

                return Ok();
            }
            catch(Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}
