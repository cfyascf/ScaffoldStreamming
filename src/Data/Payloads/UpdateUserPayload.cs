public record UpdateUserPayload(
    Guid Id,
    string? Fullname,
    string? Email,
    string? BirthDate,
    string? Password,
    int? Role
);