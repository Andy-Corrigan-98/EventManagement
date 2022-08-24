using EventsDBConnector.Data;
using EventsDBConnector.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EventsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SportsController : ControllerBase
    {
        private readonly IDbContextFactory<EventsDBContext> _contextFactory;

        public SportsController(IDbContextFactory<EventsDBContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        // GET: api/<SportsController>
        [HttpGet]
        public IEnumerable<Sports> Get()
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                var sports = context.Sports.ToList();
                return sports;
            }
        }

        // GET api/<SportsController>/5
        [HttpGet("{id}")]
        public Sports Get(int id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                var sport = context.Sports.FirstOrDefault(x => x.Id == id);
                return sport ?? new Sports { Name = "Not Found" };
            }
        }

        // POST api/<SportsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                context.Sports.Add(new Sports { Name = value });
                context.SaveChanges();
            }
        }

        // PUT api/<SportsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                var sport = context.Sports.FirstOrDefault(x => x.Id == id);
                if (sport != null)
                {
                    sport.Name = value;
                    context.SaveChanges();
                }
            }
        }
    }
}