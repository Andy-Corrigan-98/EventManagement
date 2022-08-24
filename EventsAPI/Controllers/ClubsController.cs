using EventsDBConnector.Data;
using EventsDBConnector.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EventsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClubsController : ControllerBase
    {
        private readonly IDbContextFactory<EventsDBContext> _contextFactory;

        public ClubsController(IDbContextFactory<EventsDBContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }


        // GET: api/<ClubsController>
        [HttpGet]
        public IEnumerable<Clubs> Get()
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                var clubs = context.Clubs.ToList();
                return clubs;
            }
        }

        // GET api/<ClubsController>/5
        [HttpGet("{id}")]
        public Clubs Get(int id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                var club = context.Clubs.FirstOrDefault(x => x.Id == id);
                return club ?? new Clubs { Name = "Not Found" };
            }
        }

        // POST api/<ClubsController>
        [HttpPost]
        public void Post([FromBody] string name, [FromBody] string shortName, [FromBody] int league)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                var club = new Clubs { CurrentLeague = league, Name = name, ShortName = shortName };
                context.Clubs.Add(club);
                context.SaveChanges();
            }

        }

        // PUT api/<ClubsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string name, [FromBody] string shortName, [FromBody] int league)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                var club = context.Clubs.FirstOrDefault(x => x.Id == id);
                if (club != null)
                {
                    club.Name = name;
                    club.CurrentLeague = league;
                    club.ShortName = shortName;
                    context.SaveChanges();
                }
            }
        }
    }
}