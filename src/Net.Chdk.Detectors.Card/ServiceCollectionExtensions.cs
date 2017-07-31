using Microsoft.Extensions.DependencyInjection;
using System;

namespace Net.Chdk.Detectors.Card
{
    public static class ServiceCollectionExtensions
    {
        [Obsolete]
        public static IServiceCollection AddCardDetector(this IServiceCollection serviceCollection)
        {
            return serviceCollection
                .AddSingleton<ICardDetector, CardDetector>();
        }
    }
}
