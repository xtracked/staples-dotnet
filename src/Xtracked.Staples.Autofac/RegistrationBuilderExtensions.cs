// Copyright 2024 Xtracked
// SPDX-License-Identifier: Apache-2.0

using Autofac;
using Autofac.Builder;

namespace Xtracked.Staples.Autofac;

/// <summary>Extensions for <see cref="IRegistrationBuilder{TLimit,TActivatorData,TRegistrationStyle}"/>.</summary>
public static class RegistrationBuilderExtensions
{
    /// <summary>
    /// Configure a named value for a constructor parameter, resolved using given <paramref name="parameterType"/>.
    /// </summary>
    /// <param name="registration">Registration to set parameter on.</param>
    /// <param name="parameterName">Name of parameter.</param>
    /// <param name="parameterType">Type of parameter.</param>
    /// <typeparam name="TLimit">Registration limit type.</typeparam>
    /// <typeparam name="TReflectionActivatorData">Activator data type.</typeparam>
    /// <typeparam name="TStyle">Registration style.</typeparam>
    /// <returns>A registration builder allowing further configuration of the component.</returns>
    public static IRegistrationBuilder<TLimit, TReflectionActivatorData, TStyle> WithNamedParameter<TLimit,
        TReflectionActivatorData, TStyle>(
        this IRegistrationBuilder<TLimit, TReflectionActivatorData, TStyle> registration,
        string parameterName, 
        Type parameterType
    ) where TReflectionActivatorData : ReflectionActivatorData
    {
        return registration.WithParameter(
            (info, _) => info.ParameterType == parameterType, 
            (_, context) => context.ResolveNamed(parameterName, parameterType)
        );
    }

    /// <summary>
    /// Configure a named value for a constructor parameter, resolved using given <typeparamref name="TParameter"/>.
    /// </summary>
    /// <param name="registration">Registration to set parameter on.</param>
    /// <param name="parameterName">Name of parameter.</param>
    /// <typeparam name="TLimit">Registration limit type.</typeparam>
    /// <typeparam name="TReflectionActivatorData">Activator data type.</typeparam>
    /// <typeparam name="TStyle">Registration style.</typeparam>
    /// <typeparam name="TParameter">Type of the parameter.</typeparam>
    /// <returns>A registration builder allowing further configuration of the component.</returns>
    public static IRegistrationBuilder<TLimit, TReflectionActivatorData, TStyle> WithNamedParameter<TLimit, 
        TReflectionActivatorData, TStyle, TParameter>(
        this IRegistrationBuilder<TLimit, TReflectionActivatorData, TStyle> registration, 
        string parameterName
    ) where TReflectionActivatorData : ReflectionActivatorData 
        where TParameter : notnull => registration.WithNamedParameter(parameterName, typeof(TParameter));
    
    /// <summary>
    /// Configure a keyed value for a constructor parameter, resolved using given <paramref name="serviceType"/>.
    /// </summary>
    /// <param name="registration">Registration to set parameter on.</param>
    /// <param name="serviceKey">Key of service.</param>
    /// <param name="serviceType">Type of service.</param>
    /// <typeparam name="TLimit">Registration limit type.</typeparam>
    /// <typeparam name="TReflectionActivatorData">Activator data type.</typeparam>
    /// <typeparam name="TStyle">Registration style.</typeparam>
    /// <returns>A registration builder allowing further configuration of the component.</returns>
    public static IRegistrationBuilder<TLimit, TReflectionActivatorData, TStyle> WithKeyedParameter<TLimit,
        TReflectionActivatorData, TStyle>(
        this IRegistrationBuilder<TLimit, TReflectionActivatorData, TStyle> registration,
        object serviceKey,
        Type serviceType
    ) where TReflectionActivatorData : ReflectionActivatorData
    {
        return registration.WithParameter(
            (info, _) => info.ParameterType == serviceType, 
            (_, context) => context.ResolveKeyed(serviceKey, serviceType)
        );
    }

    /// <summary>
    /// Configure a keyed value for a constructor parameter, resolved using given <typeparamref name="TService"/>.
    /// </summary>
    /// <param name="registration">Registration to set parameter on.</param>
    /// <param name="serviceKey">Key of service.</param>
    /// <typeparam name="TLimit">Registration limit type.</typeparam>
    /// <typeparam name="TReflectionActivatorData">Activator data type.</typeparam>
    /// <typeparam name="TStyle">Registration style.</typeparam>
    /// <typeparam name="TService">Type of service.</typeparam>
    /// <returns>A registration builder allowing further configuration of the component.</returns>
    public static IRegistrationBuilder<TLimit, TReflectionActivatorData, TStyle> WithKeyedParameter<TLimit,
        TReflectionActivatorData, TStyle, TService>(
        this IRegistrationBuilder<TLimit, TReflectionActivatorData, TStyle> registration,
        object serviceKey
    ) where TReflectionActivatorData : ReflectionActivatorData 
        where TService : notnull => registration.WithKeyedParameter(serviceKey, typeof(TService));
}