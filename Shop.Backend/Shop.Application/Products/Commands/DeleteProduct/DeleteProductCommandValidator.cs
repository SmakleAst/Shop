using FluentValidation;

namespace Shop.Application.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductCommandValidator()
        {
            RuleFor(deleteNoteCommand => deleteNoteCommand.ProductId)
                .GreaterThan(0).WithMessage("Id товара не может быть меньше и равно 0.")
                .NotNull().WithMessage("Id товара не может быть пустым.");
        }
    }
}
