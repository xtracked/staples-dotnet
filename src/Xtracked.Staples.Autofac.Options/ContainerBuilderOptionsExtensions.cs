// Copyright 2025 Xtracked
// SPDX-License-Identifier: Apache-2.0

using Autofac;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MOptions = Microsoft.Extensions.Options.Options;

namespace Xtracked.Staples.Autofac.Options;

/// <summary>Extensions for <see cref="ContainerBuilder"/> and <see cref="IOptions{TOptions}"/>.</summary>
public static class ContainerBuilderOptionsExtensions
{
    /// <summary>Registers services required for using <see cref="IOptions{TOptions}"/>.</summary>
    /// <param name="builder">The <see cref="ContainerBuilder"/> to register services.</param>
    /// <returns>The <paramref name="builder"/> so that additional calls can be chained.</returns>
    /// <remarks>Based on <see cref="OptionsServiceCollectionExtensions.AddOptions"/>.</remarks>
    public static ContainerBuilder RegisterOptions(this ContainerBuilder builder)
    {
        builder.RegisterGeneric(typeof(OptionsManager<>))
            .As(typeof(IOptions<>))
            .SingleInstance()
            .IfNotRegistered(typeof(IOptions<>));
        builder.RegisterGeneric(typeof(OptionsManager<>))
            .As(typeof(IOptionsSnapshot<>))
            .InstancePerLifetimeScope()
            .IfNotRegistered(typeof(IOptionsSnapshot<>));
        builder.RegisterGeneric(typeof(OptionsMonitor<>))
            .As(typeof(IOptionsMonitor<>))
            .SingleInstance()
            .IfNotRegistered(typeof(IOptionsMonitor<>));
        builder.RegisterGeneric(typeof(OptionsFactory<>))
            .As(typeof(IOptionsFactory<>))
            .IfNotRegistered(typeof(IOptionsFactory<>));
        builder.RegisterGeneric(typeof(OptionsCache<>))
            .As(typeof(IOptionsMonitorCache<>))
            .SingleInstance()
            .IfNotRegistered(typeof(IOptionsMonitorCache<>));

        return builder;
    }
    
    /// <summary>
    /// Registers the <paramref name="configureOptions"/> action to configure the <typeparamref name="TOptions"/>.
    /// </summary>
    /// <param name="builder">The <see cref="ContainerBuilder"/> to register services.</param>
    /// <param name="name">The name of the options instance.</param>
    /// <param name="configureOptions">The action used to configure the options.</param>
    /// <typeparam name="TOptions">The options type to be configured.</typeparam>
    /// <returns>The <paramref name="builder"/> so that additional calls can be chained.</returns>
    /// <remarks>
    /// Based on <see cref="OptionsServiceCollectionExtensions.Configure{T}(IServiceCollection,string,Action{T})"/>.
    /// </remarks>
    public static ContainerBuilder ConfigureOptions<TOptions>(
        this ContainerBuilder builder,
        string? name,
        Action<TOptions> configureOptions
    ) where TOptions : class
    {
        builder.RegisterOptions();
        builder.Register(_ => new ConfigureNamedOptions<TOptions>(name, configureOptions))
            .As<IConfigureOptions<TOptions>>()
            .SingleInstance();

        return builder;
    }

    /// <summary>
    /// Registers the <paramref name="configureOptions"/> action to configure the <typeparamref name="TOptions"/>.
    /// </summary>
    /// <param name="builder">The <see cref="ContainerBuilder"/> to register services.</param>
    /// <param name="configureOptions">The action used to configure the options.</param>
    /// <typeparam name="TOptions">The options type to be configured.</typeparam>
    /// <returns>The <paramref name="builder"/> so that additional calls can be chained.</returns>
    /// <remarks>
    /// Based on <see cref="OptionsServiceCollectionExtensions.Configure{T}(IServiceCollection,Action{T})"/>.
    /// </remarks>
    public static ContainerBuilder ConfigureOptions<TOptions>(
        this ContainerBuilder builder,
        Action<TOptions> configureOptions
    ) where TOptions : class => builder.ConfigureOptions(MOptions.DefaultName, configureOptions);

    /// <summary>
    /// Registers the <paramref name="configureOptions"/> action to configure all instances of
    /// <typeparamref name="TOptions"/>.
    /// </summary>
    /// <param name="builder">The <see cref="ContainerBuilder"/> to register services.</param>
    /// <param name="configureOptions">The action used to configure the options.</param>
    /// <typeparam name="TOptions">The options type to be configured.</typeparam>
    /// <returns>The <paramref name="builder"/> so that additional calls can be chained.</returns>
    /// <remarks>
    /// Based on <see cref="OptionsServiceCollectionExtensions.ConfigureAll{T}(IServiceCollection,Action{T})"/>.
    /// </remarks>
    public static ContainerBuilder ConfigureAllOptions<TOptions>(
        this ContainerBuilder builder,
        Action<TOptions> configureOptions
    ) where TOptions : class => builder.ConfigureOptions(null, configureOptions);
    
    /// <summary>
    /// Registers the <paramref name="configureOptions"/> action to configure the <typeparamref name="TOptions"/>.
    /// </summary>
    /// <param name="builder">The <see cref="ContainerBuilder"/> to register services.</param>
    /// <param name="name">The name of the options instance.</param>
    /// <param name="configureOptions">
    /// The action used to configure the options with the <see cref="IComponentContext"/> for any dependencies.
    /// </param>
    /// <typeparam name="TOptions">The options type to be configured.</typeparam>
    /// <returns>The <paramref name="builder"/> so that additional calls can be chained.</returns>
    /// <remarks>
    /// Based on <see cref="OptionsBuilder{TOptions}.Configure{TDep}(Action{TOptions,TDep})"/>.
    ///
    /// Differs from <see cref="ConfigureOptions{TOptions}(ContainerBuilder,Action{TOptions})"/> in that this registers
    /// the <see cref="IConfigureOptions{TOptions}"/> as instance per dependency instead of singleton.
    /// </remarks>
    public static ContainerBuilder ConfigureOptions<TOptions>(
        this ContainerBuilder builder,
        string? name,
        Action<IComponentContext, TOptions> configureOptions
    ) where TOptions : class
    {
        builder.RegisterOptions();
        builder.Register(ctx => 
            new ConfigureNamedOptions<TOptions>(name, options => configureOptions(ctx, options))
        ).As<IConfigureOptions<TOptions>>();

        return builder;
    }

    /// <summary>
    /// Registers the <paramref name="configureOptions"/> action to configure the <typeparamref name="TOptions"/>.
    /// </summary>
    /// <param name="builder">The <see cref="ContainerBuilder"/> to register services.</param>
    /// <param name="configureOptions">
    /// The action used to configure the options with the <see cref="IComponentContext"/> for any dependencies.
    /// </param>
    /// <typeparam name="TOptions">The options type to be configured.</typeparam>
    /// <returns>The <paramref name="builder"/> so that additional calls can be chained.</returns>
    /// <remarks>
    /// Based on <see cref="OptionsBuilder{TOptions}.Configure{TDep}(Action{TOptions,TDep})"/>.
    ///
    /// Differs from <see cref="ConfigureOptions{TOptions}(ContainerBuilder,Action{TOptions})"/> in that this registers
    /// the <see cref="IConfigureOptions{TOptions}"/> as instance per dependency instead of singleton.
    /// </remarks>
    public static ContainerBuilder ConfigureOptions<TOptions>(
        this ContainerBuilder builder,
        Action<IComponentContext, TOptions> configureOptions
    ) where TOptions : class => builder.ConfigureOptions(MOptions.DefaultName, configureOptions);

    /// <summary>
    /// Registers the <paramref name="configureOptions"/> action to configure the <typeparamref name="TOptions"/>.
    /// </summary>
    /// <param name="builder">The <see cref="ContainerBuilder"/> to register services.</param>
    /// <param name="configureOptions">
    /// The action used to configure the options with the <see cref="IComponentContext"/> for any dependencies.
    /// </param>
    /// <typeparam name="TOptions">The options type to be configured.</typeparam>
    /// <returns>The <paramref name="builder"/> so that additional calls can be chained.</returns>
    /// <remarks>
    /// Based on <see cref="OptionsBuilder{TOptions}.Configure{TDep}(Action{TOptions,TDep})"/> and
    /// <see cref="OptionsServiceCollectionExtensions.ConfigureAll{T}(IServiceCollection,Action{T})"/>.
    ///
    /// Differs from <see cref="ConfigureAllOptions{TOptions}(ContainerBuilder,Action{TOptions})"/> in that this
    /// registers the <see cref="IConfigureOptions{TOptions}"/> as instance per dependency instead of singleton.
    /// </remarks>
    public static ContainerBuilder ConfigureAllOptions<TOptions>(
        this ContainerBuilder builder,
        Action<IComponentContext, TOptions> configureOptions
    ) where TOptions : class => builder.ConfigureOptions(null, configureOptions);
}