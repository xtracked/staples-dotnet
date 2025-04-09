// Copyright 2025 Xtracked
// SPDX-License-Identifier: Apache-2.0

using Autofac;
using Autofac.Core;
using Autofac.Core.Registration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Xtracked.Staples.Autofac.Options;

/// <summary>
/// Extensions for <see cref="ContainerBuilder"/>, <see cref="IOptions{TOptions}"/> and <see cref="IModule"/>.
/// </summary>
public static class ContainerBuilderOptionsModuleExtensions
{
    /// <summary> 
    /// Registers the <typeparamref name="TModule"/>, configuring its <typeparamref name="TOptions"/> using the
    /// <paramref name="configureOptions"/>.
    /// </summary>
    /// <param name="builder">The <see cref="ContainerBuilder"/> to register services.</param>
    /// <param name="configureOptions">The action used to configure the options.</param>
    /// <typeparam name="TModule">The module for which to configure the options.</typeparam>
    /// <typeparam name="TOptions">The options type to be configured.</typeparam>
    /// <returns>The <see cref="IModuleRegistrar"/> to allow additional chained module registrations.</returns>
    /// <seealso cref="ContainerBuilderOptionsExtensions.ConfigureOptions{TOptions}(ContainerBuilder,Action{TOptions})"/>
    public static IModuleRegistrar RegisterModule<TModule, TOptions>(
        this ContainerBuilder builder,
        Action<TOptions> configureOptions
    ) where TModule : IModule, IConfigurableOptions<TOptions>, new() 
        where TOptions : class
    {
        builder.ConfigureOptions(configureOptions);
        return builder.RegisterModule<TModule>();
    }

    /// <summary>
    /// Registers the <typeparamref name="TModule"/>, configuring its <typeparamref name="TOptions"/> using the
    /// <paramref name="configureOptions"/>.
    /// </summary>
    /// <param name="builder">The <see cref="ContainerBuilder"/> to register services.</param>
    /// <param name="configureOptions">
    /// The action used to configure the options with the <see cref="IComponentContext"/> for any dependencies.
    /// </param>
    /// <typeparam name="TModule">The module for which to configure the options.</typeparam>
    /// <typeparam name="TOptions">The options type to be configured.</typeparam>
    /// <returns>The <see cref="IModuleRegistrar"/> to allow additional chained module registrations.</returns>
    /// <seealso cref="ContainerBuilderOptionsExtensions.ConfigureOptions{TOptions}(ContainerBuilder,Action{TOptions})"/>
    public static IModuleRegistrar RegisterModule<TModule, TOptions>(
        this ContainerBuilder builder,
        Action<IComponentContext, TOptions> configureOptions
    ) where TModule : IModule, IConfigurableOptions<TOptions>, new() 
        where TOptions : class
    {
        builder.ConfigureOptions(configureOptions);
        return builder.RegisterModule<TModule>();
    }
    
    /// <summary>
    /// Registers the <typeparamref name="TModule"/>, also registering the <paramref name="config"/> which
    /// <typeparamref name="TOptions"/> will bind against.
    /// </summary>
    /// <param name="builder">The <see cref="ContainerBuilder"/> to register services.</param>
    /// <param name="config">The configuration being bound.</param>
    /// <typeparam name="TModule">The module for which to configure the options.</typeparam>
    /// <typeparam name="TOptions">The options type to be configured.</typeparam>
    /// <returns>The <see cref="IModuleRegistrar"/> to allow additional chained module registrations.</returns>
    /// <seealso cref="ContainerBuilderOptionsConfigurationExtensions.ConfigureOptions{TOptions}(ContainerBuilder,IConfiguration)"/>
    public static IModuleRegistrar RegisterModule<TModule, TOptions>(
        this ContainerBuilder builder,
        IConfiguration config
    ) where TModule : IModule, IConfigurableOptions<TOptions>, new() 
        where TOptions : class
    {
        builder.ConfigureOptions<TOptions>(config);
        return builder.RegisterModule<TModule>();
    }
}