using System.Globalization;
using App.Data.Payloads;
using App.Exceptions;
using App.Interfaces.Repositories;
using App.Models;

namespace App.Services;

public class UserService(IUserRepository repository, PasswordService passService)
{
    public async Task<UserDTO> CreateUser(CreateUserPayload payload)
    {
        var existingEmail = repository.GetByEmail(payload.Email);
        if(existingEmail != null)
            throw new GlobalException("Email already in use.", 400);

        var hashedPass = passService.HashPassword(payload.Password);
        var birthDate = DateTime.ParseExact(
            payload.BirthDate, "yyyy/MM/dd", CultureInfo.InvariantCulture);

        var user = await repository.Create(UserData.CreateEntity(
            payload.Fullname,
            payload.Email,
            birthDate,
            hashedPass,
            payload.Role
        ));

        return UserDTO.BuildFromEntity(user);
    }

    public async Task<UserDTO> GetById(Guid id)
    {
        var user = await repository.GetById(id)
            ?? throw new GlobalException("User not found.", 404);

        return UserDTO.BuildFromEntity(user);
    }

    public async Task<UserDTO> UpdateUser(UpdateUserPayload payload)
    {
        var user = await repository.GetById(payload.Id)
            ?? throw new GlobalException("User not found.", 404);

        if(payload.Fullname != null)
            user.Fullname = payload.Fullname;

        if(payload.Email != null)
        {
            var existingEmail = await repository.GetByEmail(payload.Email);
            if(existingEmail != null)
                throw new GlobalException("Email already in use.", 400);

            user.Email = payload.Email;
        }

        if(payload.Fullname != null)
            user.Fullname = payload.Fullname;

        // if(payload.BirthDate != null)
        // {
        //     user.BirthDate = payload.BirthDate;
        // }

        return null;
    }
}