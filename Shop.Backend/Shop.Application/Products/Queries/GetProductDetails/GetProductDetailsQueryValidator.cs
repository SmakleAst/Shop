using FluentValidation;

namespace Shop.Application.Products.Queries.GetProductDetails
{
    public class GetProductDetailsQueryValidator : AbstractValidator<GetProductDetailsQuery>
    {
        public GetProductDetailsQueryValidator()
        {
            RuleFor(getProductDetailsQuery => getProductDetailsQuery.ProductId)
                .GreaterThan(0).WithMessage("Id товара не может быть меньше или равно 0.")
                .NotNull().WithMessage("Id товара не может быть пустым.");
        }
    }
}
