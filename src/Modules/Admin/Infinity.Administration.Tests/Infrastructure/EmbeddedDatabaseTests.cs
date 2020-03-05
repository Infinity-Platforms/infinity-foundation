using Infinity.Administration.Infrastructure.EmbeddedDataAccess.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Infinity.Administration.Tests.Infrastructure
{
    [TestClass]
    public class EmbeddedDatabaseTests
    {

        [TestMethod]
        public async Task Connectivity_ToDatabase_ShouldBeSuccess()
        {
            var context = new EmbeddedDatabaseContext(@"D:\FOSS\Infinity\Infinity\aspnet-core\microservices\admin\Infinity.Administration.Api\database\infinity-tests.db");
            var repository = new SqlDatabaseBaseRepository<EmbeddedTestClass>("UnitTestCollection",context);

            var result = await repository.Insert(new EmbeddedTestClass { Name="Sample" });

            Assert.AreEqual(result, 1);
        }

    }

    public class EmbeddedTestClass 
    { 
        public string Name { get; set; }
    }
}
