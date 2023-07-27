

using DeviceManagement.Domain.Contracts;
using DeviceManagement.Infrastructure;
using DeviceManagement.Infrastructure.Extensions;
using DeviceManagement.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moq;

namespace DeviceManagement.Infrastructure.Tests
{
    public class Tests
    {
        private Mock<ILogger<TransponderRepositoryFactory>> _logger;
        private IServiceProvider _serviceProvider;
        private TransponderRepositoryFactory _transponderRepositoryFactory;

        [SetUp]
        public void Setup()
        {
            _logger = new Mock<ILogger<TransponderRepositoryFactory>>();
            var services = new ServiceCollection();
            services.AddDeviceManagementRepositories();
            _serviceProvider = services.BuildServiceProvider();
            _transponderRepositoryFactory = new TransponderRepositoryFactory(_serviceProvider, _logger.Object);
        }

        [Test]
        public void TransponderRepository_Should_Have_Access_To_Transponder_Repositories()
        {
            var classicTransponderRepository = _serviceProvider.GetServices<ITransponderRepository>().First(x => x.GetType() == typeof(ClassicTransponderRepository));
            var modernTransponderRepository = _serviceProvider.GetServices<ITransponderRepository>().First(x => x.GetType() == typeof(ModernTransponderRepository));

            Assert.That(classicTransponderRepository, Is.Not.Null);
            Assert.That(modernTransponderRepository, Is.Not.Null);
        }

        [Test]
        public void TransponderRepositoryFactory_Should_Return_ClassicTransponderRepository()
        {
            var classicYear = DateTime.Now.Year - 25;
            var repo = _transponderRepositoryFactory.GetTransponderRepsitory(classicYear);

            Assert.That(repo.GetType(), Is.EqualTo(typeof(ClassicTransponderRepository)));
        }

        [Test]
        public void TransponderRepositoryFactory_Should_Return_ModernTransponderRepository()
        {
            var modernYear = DateTime.Now.Year;
            var repo = _transponderRepositoryFactory.GetTransponderRepsitory(modernYear);

            Assert.That(repo.GetType(), Is.EqualTo(typeof(ModernTransponderRepository)));
        }

    }
}