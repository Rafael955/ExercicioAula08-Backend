using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProdutosApp.Application.Dtos.Request;
using ProdutosApp.Application.Dtos.Response;
using ProdutosApp.Application.Interfaces;

namespace ProdutosApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController(IProdutosAppService produtosAppService) : ControllerBase
    {
        [HttpPost("criar-produto")]
        [ProducesResponseType(typeof(ProdutoResponseDto), StatusCodes.Status200OK)]
        public IActionResult Create(ProdutoRequestDto request)
        {
            try
            {
                var response = produtosAppService.CriarProduto(request);

                return StatusCode(StatusCodes.Status200OK, response);
            }
            catch (ValidationException ex)
            {
                var errors = ex.Errors.Select(e => new { field = e.PropertyName, message = e.ErrorMessage });

                return StatusCode(StatusCodes.Status400BadRequest, errors);
            }
            catch (ApplicationException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new
                {
                    error = ex.Message
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    error = ex.Message
                });
            }
        }

        [HttpPut("atualizar-produto/{id}")]
        public IActionResult Update()
        {
            return Ok();
        }

        [HttpDelete("remover-produto/{id}")]
        public IActionResult Delete()
        {
            return Ok();
        }

        [HttpGet("obter-produto/{id}")]
        public IActionResult GetById(Guid id)
        {
            return Ok();
        }

        [HttpGet("listar-produtos")]
        public IActionResult GetAll()
        {
            return Ok();
        }
    }
}
