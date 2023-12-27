using CamadaDeNegócios.Models.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using CamadaDeDados.Interface;
using CamadaDeNegócios.Models;

namespace ApiExpIFood.Controllers;

[ApiController]
[Route("[controller]")]
public class EmpresasController : ControllerBase
{
    private readonly IEmpresaRepository _repo;
    private IMapper _mapper;
    public EmpresasController(IEmpresaRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;

    }

    /// <summary>
    /// Adiciona uma empresa ao repositório
    /// </summary>
    /// <param name="empresaDto">Objeto com os campos necessários para criação de uma empresa</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    /// <response code="400">Caso tenha um erro de validação ou na semântica da requisição</response>

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult AdicionarEmpresa([FromBody] EmpresaDto empresaDto)
    {
        Empresa empresa = _mapper.Map<Empresa>(empresaDto);

       var e = _repo.Inserir(empresa.Nome);

        return CreatedAtAction(nameof(RecuperarEmpresasPorId), new { id = e.Id}, e);        
    }

    /// <summary>
    /// Mostra todas as empresas
    /// </summary>
    /// <param name="skip">Define o número de objetos ignorados</param>
    /// <param name="take">Define o número de objetos mostrados</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso a busca seja efetivada</response>
    /// <response code="400">Caso tenha um erro na semântica da requisição</response>
    [HttpGet]
    public IActionResult RecuperarEmpresas([FromQuery] int skip = 0, int take = 5)
    {
        var a = _repo.BuscaTodas();
        var empresas = _mapper.Map<List<EmpresaDto>>(_repo.BuscaTodas().Skip(skip).Take(take));
        if (empresas == null) return NotFound();
        return Ok(empresas);
    }

    /// <summary>
    /// Seleciona uma empresa com base no id do objeto
    /// </summary>
    /// <param name="id">id do objeto</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso a busca seja concluida com sucesso</response>
    /// <response code="404">Caso o objeto não tenha sido encontrado</response>
    [HttpGet("{id}")]
    public IActionResult RecuperarEmpresasPorId(int id)
    {
        var empresa = _repo.BuscaPorId(id);
        if(empresa == null) return NotFound();
        var empresaDto = _mapper.Map <List<EmpresaDto>> (empresa);
        return Ok(empresaDto);
    }

    /// <summary>
    /// Atualiza as informações da empresa
    /// </summary>
    /// <param name="id">id do objeto</param>
    /// <param name="empresaDto">Objeto com os campos necessários para a troca das informações</param>
    /// <returns>IActionResult</returns>
    /// <response code="204">Caso a atualização seja feita com sucesso</response>
    /// <response code="404">Caso o objeto não tenha sido econtrado</response>
    [HttpPut("{id}")]
    public IActionResult AtualizarEmpresa(int id, [FromBody] EmpresaDto empresaDto)
    {
        var existe = _repo.BuscaPorId(id);
        if (existe == null) return NotFound();
        var empresa = _mapper.Map<Empresa>(empresaDto);
        _repo.Atualizar(id, empresa);
        return NoContent();
    }
}
