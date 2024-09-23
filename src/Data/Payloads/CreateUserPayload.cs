namespace App.Data.Payloads;

public record CreateUserPayload(
    string Fullname, 
    string Email, 
    string BirthDate,
    string Password,
    int Role
);