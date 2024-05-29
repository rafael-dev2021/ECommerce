namespace Application.CustomExceptions;

public class CategoryException(string message, Exception innerException) : Exception(message, innerException)
{}
