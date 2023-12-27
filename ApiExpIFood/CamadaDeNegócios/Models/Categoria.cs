using System.ComponentModel.DataAnnotations;

namespace CamadaDeNegócios.Models;

public class Categoria
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required(ErrorMessage = "O nome da categoria deve ser preenchido")]
    [MaxLength(40, ErrorMessage = "O nome da categoria deve ter no máximo 40 caracteres")]
    [MinLength(3, ErrorMessage = "O nome da categoria deve ter no mínimo 3 caracteres")]
    public string Nome { get; set; }
}
