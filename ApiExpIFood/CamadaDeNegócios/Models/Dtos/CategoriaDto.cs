using System.ComponentModel.DataAnnotations;

namespace CamadaDeNegócios.Models.Dtos;

public class CategoriaDto
{
    [Required(ErrorMessage = "O nome da categoria deve ser preenchido")]
    [StringLength(20, ErrorMessage = "O nome da categoria deve ter no máximo 20 caracteres")]
    public string Nome { get; set; }
}
