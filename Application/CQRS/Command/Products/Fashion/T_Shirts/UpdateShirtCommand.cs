namespace Application.CQRS.Command.Products.Fashion.T_Shirts;

public class UpdateShirtCommand : ShirtCommand
{
    public int Id { get; set; }
}