// Copyright 2024 Xtracked
// SPDX-License-Identifier: Apache-2.0

using FluentValidation;
using MediatR;

namespace Xtracked.Staples.MediatR.FluentValidation;

/// <summary>
/// Implementation of <see cref="IPipelineBehavior{TRequest,TResponse}"/> that executes all <see cref="IValidator"/> for
/// the <typeparamref name="TRequest"/>.
/// </summary>
/// <typeparam name="TRequest">Type of the request.</typeparam>
/// <typeparam name="TResponse">Type of the response.</typeparam>
public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    /// <summary>Validators for <typeparamref name="TRequest"/>.</summary>
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    /// <summary>Initializes properties</summary>
    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    /// <inheritdoc/>
    /// <summary>Validates the <paramref name="request"/> using <see cref="_validators"/>.</summary>
    /// <exception cref="ValidationException">If any validation failed.</exception>
    public async Task<TResponse> Handle(
        TRequest request, 
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken
    )
    {
        // If there are no validators, simply continue
        if (!_validators.Any()) 
            return await next();

        // Validate the request
        var context = new ValidationContext<TRequest>(request);
        var validationResults = await Task.WhenAll(
            _validators.Select(validator => validator.ValidateAsync(context, cancellationToken))
        );
        var errors = validationResults
            .Where(it => !it.IsValid)
            .SelectMany(it => it.Errors)
            .ToList();

        // Throw if validation failed
        if (errors.Count != 0) 
            throw new ValidationException(errors);

        // Validation successful, so continue
        return await next();
    }
}