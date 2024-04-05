// Copyright 2024 Xtracked
// SPDX-License-Identifier: Apache-2.0

namespace Xtracked.Staples.ValueHolders;

/// <summary>
/// Holder for a value of type <typeparamref name="T"/>. This is useful if you want to set 'null' as an explicit value.
/// </summary>
/// <typeparam name="T">Type of the value to hold.</typeparam>
public record ValueHolder<T>(T Value);