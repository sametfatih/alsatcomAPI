﻿using alsatcomAPI.Application.Features.Products.Commands;
using alsatcomAPI.Application.Features.Products.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace alsatcomAPI.API.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        readonly IMediator mediator;

        public ProductController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllProductQueryRequest getAllProductQueryRequest)
        {
            GetAllProductQueryResponse response = await mediator.Send(getAllProductQueryRequest);
            if (!response.Success)
                return BadRequest(response);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllPassive([FromQuery] GetAllPassiveProductQueryRequest getAllPassiveProductQueryRequest)
        {
            GetAllPassiveProductQueryResponse response = await mediator.Send(getAllPassiveProductQueryRequest);
            if (!response.Success)
                return BadRequest(response);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetById([FromQuery] GetByIdProductQueryRequest getByIdProductQueryRequest)
        {
            GetByIdProductQueryResponse response = await mediator.Send(getByIdProductQueryRequest);
            if (!response.Success)
                return BadRequest(response);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateProductCommandRequest createProductCommandRequest)
        {
            CreateProductCommandResponse response = await mediator.Send(createProductCommandRequest);
            if (!response.Success)
                return BadRequest(response);
            return Ok(response); ;
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateProductCommandRequest updateProductCommandRequest)
        {
            UpdateProductCommandResponse response = await mediator.Send(updateProductCommandRequest);
            if (!response.Success)
                return BadRequest(response);
            return Ok(response);
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteProductCommandRequest deleteProductCommandRequest)
        {
            DeleteProductCommandResponse response = await mediator.Send(deleteProductCommandRequest);
            if (!response.Success)
                return BadRequest(response);
            return Ok(response);
        }
    }
}
