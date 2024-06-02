using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Interfaces;
using Shop.Domain.Entities;
using Shop.Domain.Enums;

namespace Shop.Application.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, int>
    {
        private readonly IShopDbContext _dbContext;

        public CreateOrderCommandHandler(IShopDbContext dbContext) =>
            _dbContext = dbContext;
        
        public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var productIds = request.OrderItems
                .Select(orderItem => orderItem.ProductId)
                .Distinct()
                .ToList();

            var products = await _dbContext.Products
                .Where(product => productIds.Contains(product.Id))
                .ToDictionaryAsync(product => product.Id, cancellationToken);

            if (products.Count != productIds.Count)
            {
                throw new Exception("Some products were not found");
            }

            var order = new Order
            {
                CustomerName = request.CustomerName,
                CustomerEmail = request.CustomerEmail,
                Status = Statuses.New,
                CreationDate = DateTime.Now,
                OrderItems = request.OrderItems.Select(orderItem =>
                {
                    var product = products[orderItem.ProductId];

                    return new OrderItem
                    {
                        ProductId = orderItem.ProductId,
                        Quantity = orderItem.Quantity,
                        Price = product.Price,
                        TotalPrice = product.Price * orderItem.Quantity,
                        CreationDate = DateTime.Now
                    };
                }).ToList()
            };

            order.TotalPrice = order.OrderItems.Sum(orderItem => orderItem.TotalPrice);

            await  _dbContext.Orders.AddAsync(order, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return order.Id;
        }
    }
}
