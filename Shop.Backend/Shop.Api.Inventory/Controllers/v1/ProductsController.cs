﻿using Asp.Versioning;
using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Products.Commands.CreateProduct;
using Shop.Application.Products.Commands.DeleteProduct;
using Shop.Application.Products.Commands.UpdateProduct;
using Shop.Application.Products.Queries.GetProductDetails;
using Shop.Application.Products.Queries.GetProductList;
using Shop.WebApi.Inventory.Models;

namespace Shop.WebApi.Inventory.Controllers.v1
{
    [ApiVersion(1, Deprecated = false)]
    [Produces("application/json")]
    [Route("api/v{version::apiVersion}/[controller]")]
    public class ProductsController : BaseController
    {
        private readonly IMapper _mapper;

        public ProductsController(IMapper mapper) =>
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
        /// <response code="401">If unauthorized</response>
        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
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
        /// <response code="401">If unauthorized</response>
        /// <response code="404">If the product not found</response>
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
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
        /// <response code="401">If unauthorized</response>
        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<int>> Create([FromBody] CreateProductDto createProductDto)
        {
            var command = _mapper.Map<CreateProductCommand>(createProductDto);

            var productId = await Mediator.Send(command);

            return CreatedAtAction(nameof(Create), productId);
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
        /// <response code="401">If unauthorized</response>
        /// <response code="404">If the product not found</response>
        [HttpPut]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
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
        /// <response code="401">If unauthorized</response>
        /// <response code="404">If the product not found</response>
        [HttpDelete]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
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
