using DeviceManagement.Domain.Contracts;
using DeviceManagement.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace DeviceManagement.Infrastructure
{
    public interface ITransponderRepositoryFactory
    {
        ITransponderRepository GetTransponderRepsitory(int year);
    }
    public class TransponderRepositoryFactory : ITransponderRepositoryFactory
    {
        private readonly ILogger<TransponderRepositoryFactory> _logger;
        private readonly IEnumerable<ITransponderRepository> _repos;

        public TransponderRepositoryFactory(IServiceProvider serviceProvider, ILogger<TransponderRepositoryFactory> logger)
        {
            _repos = serviceProvider.GetServices<ITransponderRepository>();
            _logger = logger;
        }

        public ITransponderRepository GetTransponderRepsitory(int year)
        {
            ITransponderRepository repo;

            switch (year)
            {
                case var expression when year <= (DateTime.Now.Year - 25):
                    repo = _repos.First(x => x.GetType() == typeof(ClassicTransponderRepository));
                    break;
                default:
                    repo = _repos.First(x => x.GetType() == typeof(ModernTransponderRepository));
                    break;
            }

            _logger.LogInformation($"{repo.GetType().Name} selected for {year} vehicle");

            return repo;
        }
    }
}