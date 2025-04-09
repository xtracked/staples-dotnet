// Copyright 2025 Xtracked
// SPDX-License-Identifier: Apache-2.0

using Autofac;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MOptions = Microsoft.Extensions.Options.Options;

namespace Xtracked.Staples.Autofac.Options;

/// <summary>
/// Extensions for <see cref="ContainerBuilder"/>, <see cref="IOptions{TOptions}"/> and <see cref="IConfiguration"/>.
/// </summary>
public static class ContainerBuilderOptionsConfigurationExtensions
{
    /// <summary>
    /// Registers the <paramref name="config"/> which <typeparamref name="TOptions"/> will bind against.
    /// </summary>
    /// <param name="builder">The <see cref="ContainerBuilder"/> to register services.</param>
    /// <param name="name">The name of the options instance.</param>
    /// <param name="config">The configuration being bound.</param>
    /// <param name="configureBinder">Used to configure the <see cref="BinderOptions"/>.</param>
    /// <typeparam name="TOptions">The options type to be configured.</typeparam>
    /// <returns>The <paramref name="builder"/> so that additional calls can be chained.</returns>
    /// <remarks>
    /// Based on <see cref="OptionsConfigurationServiceCollectionExtensions.Configure{T}(IServiceCollection,string?,IConfiguration,Action{BinderOptions}?)"/>.
    /// </remarks>
    public static ContainerBuilder ConfigureOptions<TOptions>(
        this ContainerBuilder builder, 
        string? name,
        IConfiguration config, 
        Action<BinderOptions>? configureBinder
    ) where TOptions : class
    {
        builder.RegisterOptions();
        builder.Register(_ => new ConfigurationChangeTokenSource<TOptions>(name, config))
            .As<IOptionsChangeTokenSource<TOptions>>()
            .SingleInstance();
        builder.Register(_ => new NamedConfigureFromConfigurationOptions<TOptions>(name, config, configureBinder))
            .As<IConfigureOptions<TOptions>>()
            .SingleInstance();

        return builder;
    }

    /// <summary>
    /// Registers the <paramref name="config"/> which <typeparamref name="TOptions"/> will bind against.
    /// </summary>
    /// <param name="builder">The <see cref="ContainerBuilder"/> to register services.</param>
    /// <param name="config">The configuration being bound.</param>
    /// <param name="configureBinder">Used to configure the <see cref="BinderOptions"/>.</param>
    /// <typeparam name="TOptions">The options type to be configured.</typeparam>
    /// <returns>The <paramref name="builder"/> so that additional calls can be chained.</returns>
    /// <remarks>
    /// Based on <see cref="OptionsConfigurationServiceCollectionExtensions.Configure{T}(IServiceCollection,IConfiguration,Action{BinderOptions}?)"/>.
    /// </remarks>
    public static ContainerBuilder ConfigureOptions<TOptions>(
        this ContainerBuilder builder,
        IConfiguration config,
        Action<BinderOptions>? configureBinder
    ) where TOptions : class => builder.ConfigureOptions<TOptions>(MOptions.DefaultName, config, configureBinder);

    /// <summary>
    /// Registers the <paramref name="config"/> which <typeparamref name="TOptions"/> will bind against.
    /// </summary>
    /// <param name="builder">The <see cref="ContainerBuilder"/> to register services.</param>
    /// <param name="name">The name of the options instance.</param>
    /// <param name="config">The configuration being bound.</param>
    /// <typeparam name="TOptions">The options type to be configured.</typeparam>
    /// <returns>The <paramref name="builder"/> so that additional calls can be chained.</returns>
    /// <remarks>
    /// Based on <see cref="OptionsConfigurationServiceCollectionExtensions.Configure{T}(IServiceCollection,string?,IConfiguration)"/>.
    /// </remarks>
    public static ContainerBuilder ConfigureOptions<TOptions>(
        this ContainerBuilder builder,
        string? name,
        IConfiguration config
    ) where TOptions : class => builder.ConfigureOptions<TOptions>(name, config, null);

    /// <summary>
    /// Registers the <paramref name="config"/> which <typeparamref name="TOptions"/> will bind against.
    /// </summary>
    /// <param name="builder">The <see cref="ContainerBuilder"/> to register services.</param>
    /// <param name="config">The configuration being bound.</param>
    /// <typeparam name="TOptions">The options type to be configured.</typeparam>
    /// <returns>The <paramref name="builder"/> so that additional calls can be chained.</returns>
    /// <remarks>
    /// Based on <see cref="OptionsConfigurationServiceCollectionExtensions.Configure{T}(IServiceCollection,IConfiguration)"/>.
    /// </remarks>
    public static ContainerBuilder ConfigureOptions<TOptions>(
        this ContainerBuilder builder,
        IConfiguration config
    ) where TOptions : class => builder.ConfigureOptions<TOptions>(MOptions.DefaultName, config);
}