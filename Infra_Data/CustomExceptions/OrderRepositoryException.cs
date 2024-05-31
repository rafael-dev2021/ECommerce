namespace Infra_Data.CustomExceptions;

public class OrderRepositoryException(string message, Exception innerException) : Exception(message, innerException)
{ }