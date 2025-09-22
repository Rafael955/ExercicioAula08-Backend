using Azure.Core;
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
        [ProducesResponseType(typeof(ProdutoResponseDto), StatusCodes.Status201Created)]
        public IActionResult Create(ProdutoRequestDto request)
        {
            try
            {
                var response = produtosAppService.CriarProduto(request);

                return StatusCode(StatusCodes.Status201Created, response);
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
        [ProducesResponseType(typeof(ProdutoResponseDto), StatusCodes.Status200OK)]
        public IActionResult Update(Guid id, ProdutoRequestDto request)
        {
            try
            {
                var response = produtosAppService.AlterarProduto(id, request);

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

        [HttpDelete("remover-produto/{id}")]
        [ProducesResponseType(typeof(ProdutoResponseDto), StatusCodes.Status200OK)]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var response = produtosAppService.ExcluirProduto(id);

                return StatusCode(StatusCodes.Status200OK, response);
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

        [HttpGet("obter-produto/{id}")]
        [ProducesResponseType(typeof(ProdutoResponseDto), StatusCodes.Status200OK)]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var response = produtosAppService.ObterProdutoPorId(id);

                return StatusCode(StatusCodes.Status200OK, response);
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

        [HttpGet("listar-produtos")]
        [ProducesResponseType(typeof(ProdutoResponseDto), StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            try
            {
                var response = produtosAppService.ObterTodosProdutos();

                return StatusCode(StatusCodes.Status200OK, response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    error = ex.Message
                });
            }
        }
    }
}
