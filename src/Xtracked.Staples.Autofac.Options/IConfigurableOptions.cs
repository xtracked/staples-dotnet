// Copyright 2024 Xtracked
// SPDX-License-Identifier: Apache-2.0

using Autofac.Core;

namespace Xtracked.Staples.Autofac.Options;

/// <summary>Interface to mark a component (e.g. an <see cref="IModule"/>) to have configurable options.</summary>
/// <typeparam name="TOptions">Type of the options.</typeparam>
/// <seealso cref="ContainerBuilderOptionsModuleExtensions"/>
public interface IConfigurableOptions<TOptions> where TOptions : class
{
}