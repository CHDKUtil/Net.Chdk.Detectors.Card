using Microsoft.Extensions.DependencyInjection;

namespace Net.Chdk.Detectors.Card
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCardDetector(IServiceCollection serviceCollection)
        {
            return serviceCollection
                .AddSingleton<ICardDetector, CardDetector>();
        }
    }
}
