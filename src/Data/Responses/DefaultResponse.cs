namespace App.Data.Responses;

public record DefaultResponse<T>(string message, T data);