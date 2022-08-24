using EventsDBConnector.Data;
using Microsoft.EntityFrameworkCore;

namespace EventsAPI.DBConnection
{
    public class EventsDbContextFactory : IDbContextFactory<EventsDBContext>
    {
        private readonly IConfiguration _configuration;
        public EventsDbContextFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public EventsDBContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<EventsDBContext>();
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
            return new EventsDBContext(optionsBuilder.Options);
        }

    }
}
