// Copyright 2025 Xtracked
// SPDX-License-Identifier: Apache-2.0

using System.Runtime.Serialization;

namespace Xtracked.Staples.ApiErrors.Models;

/// <summary>The error types for API calls.</summary>
/// <remarks>
/// Based on gRPC error codes: https://github.com/googleapis/googleapis/blob/master/google/rpc/code.proto. Currently
/// using a subset, so it can be extended with more types from gRPC codes when necessary.
/// </remarks>
public enum ApiErrorType
{
    /// <summary>
    /// The client specified an invalid argument.
    ///
    /// HTTP Mapping: 400 Bad Request - Syntax errors
    /// HTTP Mapping: 422 Unprocessable Entity - Semantic errors
    /// </summary>
    [EnumMember(Value = "INVALID_ARGUMENT")]
    InvalidArgument,
    /// <summary>
    /// The request does not have valid authentication credentials for the operation.
    ///
    /// HTTP Mapping: 401 Unauthorized
    /// </summary>
    [EnumMember(Value = "UNAUTHENTICATED")]
    Unauthenticated,
    /// <summary>
    /// The caller does not have permission to execute the specified operation.
    ///
    /// HTTP Mapping: 403 Forbidden
    /// </summary>
    [EnumMember(Value = "PERMISSION_DENIED")]
    PermissionDenied,
    /// <summary>
    /// Some requested resource was not found.
    ///
    /// HTTP Mapping: 404 Not Found
    /// </summary>
    [EnumMember(Value = "NOT_FOUND")]
    NotFound,
    /// <summary>
    /// The resource that a client tried to create already exists.
    ///
    /// HTTP Mapping: 409 Conflict
    /// </summary>
    [EnumMember(Value = "ALREADY_EXISTS")]
    AlreadyExists,
    /// <summary>
    /// Some resource has been exhausted due to e.g. a per-user quota.
    ///
    /// HTTP Mapping: 429 Too Many Requests
    /// </summary>
    [EnumMember(Value = "RESOURCE_EXHAUSTED")]
    ResourceExhausted,
    /// <summary>
    /// Internal errors. This means that some invariants expected by the underlying system have been broken. This error
    /// code is reserved for serious errors.
    ///
    /// HTTP Mapping: 500 Internal Server Error
    /// </summary>
    [EnumMember(Value = "INTERNAL")]
    Internal,
    /// <summary>
    /// The operation is not implemented or is not supported/enabled in this service.
    ///
    /// HTTP Mapping: 501 Not Implemented
    /// </summary>
    [EnumMember(Value = "NOT_IMPLEMENTED")]
    NotImplemented,
    /// <summary>
    /// The service is currently unavailable. This is most likely a transient condition, which can be corrected by
    /// retrying with a backoff.
    ///
    /// HTTP Mapping: 503 Service Unavailable
    /// </summary>
    [EnumMember(Value = "UNAVAILABLE")]
    Unavailable
}