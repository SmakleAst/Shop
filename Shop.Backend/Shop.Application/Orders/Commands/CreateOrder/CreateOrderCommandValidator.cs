using FluentValidation;

namespace Shop.Application.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(createOrderCommand => createOrderCommand.CustomerName)
                .NotEmpty().WithMessage("Имя заказчика не может быть пустым.")
                .MaximumLength(50).WithMessage("Максимальная длинна имени заказчика 50 символов.");

            RuleFor(createOrderCommand => createOrderCommand.CustomerEmail)
                .NotEmpty().WithMessage("Email заказчика не может быть пустым.")
                .MaximumLength(50).WithMessage("Максимальная длинна email заказчика 50 символов.");

            RuleFor(createOrderCommand => createOrderCommand.OrderItems)
                .NotEmpty().WithMessage("Список товаров не может быть пустым.")
                .Must(orderItems => orderItems != null && orderItems.Count > 0)
                .WithMessage("Заказ должен содержать хотя бы один товар.");

            RuleForEach(createOrderCommand => createOrderCommand.OrderItems).ChildRules(orderItem =>
            {
                orderItem.RuleFor(item => item.ProductId)
                    .GreaterThan(0).WithMessage("Идентификатор товара должен быть больше нуля.")
                    .NotNull().WithMessage("Идентификатор товара не может быть пустым");

                orderItem.RuleFor(item => item.Quantity)
                    .GreaterThan(0).WithMessage("Количество товара должно быть больше нуля.")
                    .NotNull().WithMessage("Количество товара не может быть пустым");
            });
        }
    }
}
