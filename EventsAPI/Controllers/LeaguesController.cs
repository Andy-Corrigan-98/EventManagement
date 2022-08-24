using EventsDBConnector.Data;
using EventsDBConnector.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EventsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaguesController : ControllerBase
    {
        private readonly IDbContextFactory<EventsDBContext> _contextFactory;

        public LeaguesController(IDbContextFactory<EventsDBContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }


        // GET: api/<LeaguesController>
        [HttpGet]
        public IEnumerable<Leagues> Get()
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                var leagues = context.Leagues.ToList();
                return leagues;
            }
        }

        // GET api/<LeaguesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LeaguesController>
        [HttpPost]
        public void Post([FromBody] string name, [FromBody] int sport)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                context.Leagues.Add(new Leagues { Name = name, SportId = sport });
                context.SaveChanges();
            }
        }

        // POST api/<LeaguesController>
        [HttpPost]
        public void Post([FromBody] string name, [FromBody] int sport, [FromBody] int promotesTo)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                context.Leagues.Add(new Leagues { Name = name, SportId = sport, PromotesTo = promotesTo });
                context.SaveChanges();
            }
        }

        // PUT api/<LeaguesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string name)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                var league = context.Leagues.FirstOrDefault(x => x.Id == id);
                if (league != null)
                {
                    league.Name = name;
                    context.SaveChanges();
                }
            }
        }
    }
}