namespace App.Data.Payloads;

public record VideoUploadPayload(string name, IFormFile video);