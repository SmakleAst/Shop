using FluentValidation;

namespace Shop.Application.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(updateProductCommand => updateProductCommand.ProductId)
                .GreaterThan(0).WithMessage("Id товара не может быть меньше или равно 0.")
                .NotNull().WithMessage("Id товара не может быть пустым.");

            RuleFor(updateProductCommand => updateProductCommand.Name)
                .NotEmpty().WithMessage("Название товара не может быть пустым")
                .MaximumLength(50).WithMessage("Максимальная длина названия товара 50 символов");

            RuleFor(updateProductCommand => updateProductCommand.Description)
                .NotEmpty().WithMessage("Описание товара не может быть пустым")
                .MaximumLength(250).WithMessage("Максимальная длина описания товара 250 символов");

            RuleFor(updateProductCommand => updateProductCommand.Price)
                .GreaterThan(0).WithMessage("Цена товара не может быть меньше или равна 0.")
                .NotNull().WithMessage("Цена товара не может быть пустой.");

            RuleFor(updateProductCommand => updateProductCommand.Quantity)
                .GreaterThan(-1).WithMessage("Количество товара не может быть меньше 0.")
                .NotNull().WithMessage("Количество товара не может быть пустым.");
        }
    }
}
