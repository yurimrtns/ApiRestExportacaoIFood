using System.ComponentModel.DataAnnotations;

namespace CamadaDeNegócios.Models.Dtos;

public class EmpresaDto
{
    [Required(ErrorMessage = "O nome da empresa deve ser preenchido")]
    [StringLength(100, ErrorMessage = "O nome da empresa deve ter no máximo 100 caracteres")]
    public string Nome { get; set; }
}
