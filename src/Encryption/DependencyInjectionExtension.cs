using Encryption.Contract;
using Encryption.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Encryption
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddEncryptionServices(this IServiceCollection services)
        {
            services.AddSingleton<ISymmetricEncryption, DesEncryptionService>();

            return services;
        }
    }
}