// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Microsoft.Extensions.DependencyInjection
{
    using System.Linq;
    using System.Reflection;

    using EFCoreExtensions;

    /// <summary>
    /// EfCoreExtensions specific extension methods for <see cref="IServiceCollection"/>
    /// </summary>
    public static class ExtensionsServiceCollectionExtensions
    {
        /// <summary>
        ///     <para>
        ///         Adds the services required by the EFCoreExtensions package to an
        ///         <see cref="IServiceCollection"/>. You use this method when using
        ///         dependency injection in your application, such as ASP.NET
        ///     </para>
        ///     <para>
        ///         You only need to use this functionality when you want Entity Framework
        ///         to resolve the services it uses from an external dependency injection
        ///         container. If you are not using an external dependency injection container,
        ///         Entity Framework will take care of creating the services it requires
        ///     </para>
        /// </summary>
        /// <example>
        ///     <code>
        ///         public void ConfigureServices(IServiceCollection services)
        ///         {
        ///             services
        ///                 .AddEntityFrameworkCore()
        ///                 .AddEFCoreExtensions()
        ///         }
        ///     </code>
        /// </example>
        /// <param name="serviceCollection"></param>
        /// <returns></returns>
        public static IServiceCollection AddEFCoreExtensions(this IServiceCollection serviceCollection)
        {
            Ensure.NotNull(serviceCollection, nameof(serviceCollection));

            return serviceCollection;
        }
    }
}
