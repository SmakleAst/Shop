using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Products.Commands.CreateProduct;
using Shop.Application.Products.Commands.DeleteProduct;
using Shop.Application.Products.Commands.UpdateProduct;
using Shop.Application.Products.Queries.GetProductDetails;
using Shop.Application.Products.Queries.GetProductList;
using Shop.WebApi.Inventory.Models;

namespace Shop.WebApi.Inventory.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ProductController : BaseController
    {
        private readonly IMapper _mapper;

        public ProductController(IMapper mapper) =>
            _mapper = mapper;

        /// <summary>
        /// Gets the list of products
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /product
        /// </remarks>
        /// <returns>Returns ProductListVm</returns>
        /// <response code="200">Success</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ProductListVm>> GetAll()
        {
            var query = new GetProductListQuery
            {

            };

            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        /// <summary>
        /// Get the product by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /product/1
        /// </remarks>
        /// <param name="id">Product id (int)</param>
        /// <returns>Returns ProductDetailsVm</returns>
        /// <response code="200">Success</response>
        /// <response code="404">If the product not found</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductDetailsVm>> Get(int id)
        {
            var query = new GetProductDetailsQuery
            {
                Id = id
            };

            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        /// <summary>
        /// Creates the product
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST /product
        /// {
        ///     Name: "Product name",
        ///     Description: "Product description",
        ///     Price: 1000.00
        /// }
        /// </remarks>
        /// <param name="createProductDto">CreateProductDto object</param>
        /// <returns>Returns id (int) created product</returns>
        /// <response code="201">Success</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<int>> Create([FromBody] CreateProductDto createProductDto)
        {
            var command = _mapper.Map<CreateProductCommand>(createProductDto);

            var productId = await Mediator.Send(command);

            return Ok(productId);
        }

        /// <summary>
        /// Updates the product
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// PUT /product
        /// {
        ///     Id: 1,
        ///     Name: "Updated product name",
        ///     Description: "Updated product description",
        ///     Price: 10000.00,
        ///     Quantity: 100
        /// }
        /// </remarks>
        /// <param name="updateProductDto">UpdateProductDto object</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="404">If the product not found</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromBody] UpdateProductDto updateProductDto)
        {
            var command = _mapper.Map<UpdateProductCommand>(updateProductDto);

            await Mediator.Send(command);

            return NoContent();
        }

        /// <summary>
        /// Deletes the product by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// DELETE /product/1
        /// </remarks>
        /// <param name="id">Product id (int)</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="404">If the product not found</response>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteProductCommand
            {
                Id = id
            };

            await Mediator.Send(command);

            return NoContent();
        }
    }
}
