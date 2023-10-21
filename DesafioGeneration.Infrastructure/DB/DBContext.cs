using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DesafioGeneration.Infrastructure.DB
{
    public class DBContext
    {
        private readonly IConfiguration _configuration;

        public DBContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        IConfigurationRoot configuration = new ConfigurationBuilder().
            SetBasePath(AppDomain.CurrentDomain.BaseDirectory).AddJsonFile("appsettings.json").Build();
        public IDbConnection Connection => new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
    }
}
