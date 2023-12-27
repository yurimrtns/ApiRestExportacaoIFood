using System.ComponentModel.DataAnnotations;

namespace CamadaDeNegócios.Models.Dtos;

public class SegmentoDto
{
    [Required(ErrorMessage = "O nome do segmento deve ser preenchido")]
    [StringLength(100, ErrorMessage = "O nome do segmento deve ter no máximo 100 caracteres")]
    public string Nome { get; set; }
}
