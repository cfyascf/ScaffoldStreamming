namespace App.Exceptions;

public class ApplicationException : Exception
{
    public int Status { get; set; }

    public ApplicationException(string message, int status) : base(message)
        => Status = status;
}