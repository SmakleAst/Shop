using FluentValidation;

namespace Shop.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(createProductCommand => createProductCommand.Name)
                .NotEmpty().WithMessage("Название товара не может быть пустым")
                .MaximumLength(50).WithMessage("Максимальная длина названия товара 50 символов");

            RuleFor(createProductCommand => createProductCommand.Description)
                .NotEmpty().WithMessage("Описание товара не может быть пустым")
                .MaximumLength(250).WithMessage("Максимальная длина описания товара 250 символов");

            RuleFor(createProductCommand => createProductCommand.Price)
                .GreaterThan(0).WithMessage("Цена должна быть больше нуля")
                .NotNull().WithMessage("Цена не может быть пустой");
        }
    }
}
