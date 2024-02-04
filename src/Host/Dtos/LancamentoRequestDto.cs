using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Host.Dtos
{
    public class LancamentoRequestDto
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Valor")]
        [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "O Valor deve ser numérico e sem sinal, com até duas casas decimais separadas por um ponto. (100.50)")]
        [MaxLength(18, ErrorMessage = "O valor deve ser menor que um quintilhão. Se você movimenta mais que um quintilhão (uau) me mande um e-mail, eu posso te ajudar! alexandrealen@hotmail.com.")]
        [DefaultValue("100.50")]
        public string Valor { get; set; }
    }
}
