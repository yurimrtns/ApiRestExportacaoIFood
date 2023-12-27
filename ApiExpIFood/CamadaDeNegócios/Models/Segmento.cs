using System.ComponentModel.DataAnnotations;

namespace CamadaDeNegócios.Models;

public class Segmento
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required(ErrorMessage = "O nome do segmento deve ser preenchido")]
    [MaxLength(40, ErrorMessage = "O nome do segmento deve ter no máximo 40 caracteres")]
    [MinLength(3, ErrorMessage = "O nome do segmento deve ter no mínimo 3 caracteres")]
    public string Nome { get; set; }
}
