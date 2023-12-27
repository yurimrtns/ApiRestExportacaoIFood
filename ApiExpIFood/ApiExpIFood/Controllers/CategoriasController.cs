using CamadaDeNegócios.Models.Dtos;
using CamadaDeNegócios.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using CamadaDeDados.Interface;

namespace ApiExpIFood.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoriasController : ControllerBase
{
    private readonly ICategoriaRepository _repo;
    private IMapper _mapper;
    public CategoriasController(ICategoriaRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;

    }

    /// <summary>
    /// Adiciona uma categoria ao repositório
    /// </summary>
    /// <param name="categoriaDto">Objeto com os campos necessários para criação de uma categoria</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    /// <response code="400">Caso tenha um erro de validação ou na semântica da requisição</response>
    [HttpPost]
    public IActionResult AdicionarCategoria([FromBody] CategoriaDto categoriaDto)
    {
        Categoria categoria = _mapper.Map<Categoria>(categoriaDto);

        var e = _repo.Inserir(categoria.Nome);

        return CreatedAtAction(nameof(RecuperarCategoriasPorId), new { id = e.Id }, e);
    }

    /// <summary>
    /// Mostra todas as categorias
    /// </summary>
    /// <param name="skip">Define o número de objetos ignorados</param>
    /// <param name="take">Define o número de objetos mostrados</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso a busca seja efetivada</response>
    /// <response code="400">Caso tenha um erro na semântica da requisição</response>
    [HttpGet]
    public IActionResult RecuperarCategorias([FromQuery] int skip = 0, int take = 5)
    {
        var a = _repo.BuscaTodas();
        var categorias = _mapper.Map<List<CategoriaDto>>(_repo.BuscaTodas().Skip(skip).Take(take));
        if (categorias == null) return NotFound();
        return Ok(categorias);
    }

    /// <summary>
    /// Seleciona uma categoria com base no id do objeto
    /// </summary>
    /// <param name="id">id do objeto</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso a busca seja concluida com sucesso</response>
    /// <response code="404">Caso o objeto não tenha sido encontrado</response>
    [HttpGet("{id}")]
    public IActionResult RecuperarCategoriasPorId(int id)
    {
        var categoria = _repo.BuscaPorId(id);
        if (categoria == null) return NotFound();
        var categoriaDto = _mapper.Map<List<CategoriaDto>>(categoria);
        return Ok(categoriaDto);
    }

    /// <summary>
    /// Atualiza as informações da categoria
    /// </summary>
    /// <param name="id">id do objeto</param>
    /// <param name="categoriaDto">Objeto com os campos necessários para a troca das informações</param>
    /// <returns>IActionResult</returns>
    /// <response code="204">Caso a atualização seja feita com sucesso</response>
    /// <response code="404">Caso o objeto não tenha sido econtrado</response>
    [HttpPut("{id}")]
    public IActionResult AtualizarCategoria(int id, [FromBody] CategoriaDto categoriaDto)
    {
        var existe = _repo.BuscaPorId(id);
        if (existe == null) return NotFound();
        var categoria = _mapper.Map<Categoria>(categoriaDto);
        _repo.Atualizar(id, categoria);
        return NoContent();
    }
}
