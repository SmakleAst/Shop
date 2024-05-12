using FluentValidation;

namespace Shop.Application.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductCommandValidator()
        {
            RuleFor(deleteNoteCommand => deleteNoteCommand.Id)
                .GreaterThan(0).WithMessage("Id товара не может быть меньше или равно 0.")
                .NotNull().WithMessage("Id товара не может быть пустым.");
        }
    }
}
