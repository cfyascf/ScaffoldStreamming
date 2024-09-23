namespace App.Exceptions;

public class GlobalException : Exception
{
    public int StatusCode { get; set; }

    public GlobalException(string message, int statusCode) : base(message)
        => StatusCode = statusCode;
}