using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.FeatureDto;
using SignalR.DtoLayer.ProductDto;
using SignalR.EntityLayer.Entities;

namespace SignalRapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Productlist()
        {
            var value = _mapper.Map<List<ResultProductDto>>(_productService.TGetAll());
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto createProductDto)
        {
            _productService.TAdd(new Product()
            {
                ImageUrl = createProductDto.ImageUrl,
                ProductDescription = createProductDto.ProductDescription,
                ProductName = createProductDto.ProductName,
                ProductPrice = createProductDto.ProductPrice,
                ProductStatus = createProductDto.ProductStatus

            });
            return Ok("Ürün Eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            var value = _productService.TGetById(id);
            _productService.TDelete(value);
            return Ok("Ürün silindi");
        }
        [HttpGet("GetProduct")]
        public IActionResult GetProduct(int id)
        {
            var value = _productService.TGetById(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDto updateProductDto)
        {
            _productService.TUpdate(new Product()
            {
                ImageUrl = updateProductDto.ImageUrl,
                ProductDescription = updateProductDto.ProductDescription,
                ProductName = updateProductDto.ProductName,
                ProductPrice = updateProductDto.ProductPrice,
                ProductStatus = updateProductDto.ProductStatus,
                ProductID = updateProductDto.ProductID

            });
            return Ok("Ürün bilgileri güncellendi");

        }
    }
}
