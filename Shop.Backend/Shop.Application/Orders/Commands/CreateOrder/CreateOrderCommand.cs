using MediatR;

namespace Shop.Application.Orders.Commands.CreateOrder
{
    public class CreateOrderCommand : IRequest<int>
    {
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public List<OrderItemLookupDto> OrderItems { get; set; }
    }
}
