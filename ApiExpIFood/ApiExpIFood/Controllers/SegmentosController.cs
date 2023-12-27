using CamadaDeNegócios.Models.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using CamadaDeDados.Interface;
using CamadaDeNegócios.Models;

namespace ApiExpIFood.Controllers;

[ApiController]
[Route("[controller]")]
public class SegmentosController : ControllerBase
{
    private readonly ISegmentoRepository _repo;
    private IMapper _mapper;
    public SegmentosController(ISegmentoRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;

    }

    /// <summary>
    /// Adiciona um segmento ao repositório
    /// </summary>
    /// <param name="segmentoDto">Objeto com os campos necessários para criação de um segmento</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    /// <response code="400">Caso tenha um erro de validação ou na semântica da requisição</response>
    [HttpPost]
    public IActionResult AdicionarSegmento([FromBody] SegmentoDto segmentoDto)
    {
        Segmento segmento = _mapper.Map<Segmento>(segmentoDto);

        var e = _repo.Inserir(segmento.Nome);

        return CreatedAtAction(nameof(RecuperarSegmentosPorId), new { id = e.Id }, e);
    }

    /// <summary>
    /// Mostra todos os segmentos
    /// </summary>
    /// <param name="skip">Define o número de objetos ignorados</param>
    /// <param name="take">Define o número de objetos mostrados</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso a busca seja efetivada</response>
    /// <response code="400">Caso tenha um erro na semântica da requisição</response>
    [HttpGet]
    public IActionResult RecuperarSegmentos([FromQuery] int skip = 0, int take = 5)
    {
        var a = _repo.BuscaTodos();
        var segmentos = _mapper.Map<List<SegmentoDto>>(_repo.BuscaTodos().Skip(skip).Take(take));
        if (segmentos == null) return NotFound();
        return Ok(segmentos);
    }

    /// <summary>
    /// Seleciona um segmento com base no id do objeto
    /// </summary>
    /// <param name="id">id do objeto</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso a busca seja concluida com sucesso</response>
    /// <response code="404">Caso o objeto não tenha sido encontrado</response>
    [HttpGet("{id}")]
    public IActionResult RecuperarSegmentosPorId(int id)
    {
        var segmento = _repo.BuscaPorId(id);
        if (segmento == null) return NotFound();
        var segmentoDto = _mapper.Map<List<SegmentoDto>>(segmento);
        return Ok(segmentoDto);
    }

    /// <summary>
    /// Atualiza as informações do segmento
    /// </summary>
    /// <param name="id">id do objeto</param>
    /// <param name="segmentoDto">Objeto com os campos necessários para a troca das informações</param>
    /// <returns>IActionResult</returns>
    /// <response code="204">Caso a atualização seja feita com sucesso</response>
    /// <response code="404">Caso o objeto não tenha sido econtrado</response>
    [HttpPut("{id}")]
    public IActionResult AtualizarSegmento(int id, [FromBody] SegmentoDto segmentoDto)
    {
        var existe = _repo.BuscaPorId(id);
        if (existe == null) return NotFound();
        var segmento = _mapper.Map<Segmento>(segmentoDto);
        _repo.Atualizar(id, segmento);
        return NoContent();
    }
}
