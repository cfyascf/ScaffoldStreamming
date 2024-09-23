using App.Models;

public record UserDTO(
    Guid Id,
    string Fullname,
    string Email,
    DateTime BirthDate,
    int Role
)
{
    public static UserDTO BuildFromEntity(UserData user)
    {
        return new UserDTO(
            user.Id,
            user.Fullname,
            user.Email,
            user.BirthDate,
            user.Role
        );
    }
}