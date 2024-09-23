namespace App.Data.Payloads;

public record VideoUploadPayload(
    string Title, 
    string Description, 
    IFormFile Video
);