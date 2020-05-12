using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Web.Motors.WebAPI.ViewModel
{
    public class AdvertisementViewModel : BaseViewModel
    {  
       // [NotMapped]
        public int? Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(45, ErrorMessage = "O campo {0} ultapassou o limite máximo de caracters", MinimumLength = 1)]
        public string Marca { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(45, ErrorMessage = "O campo {0} ultapassou o limite máximo de caracters", MinimumLength = 1)]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(45, ErrorMessage = "O campo {0} ultapassou o limite máximo de caracters", MinimumLength = 1)]
        public string Versao { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "O campo {0} ultapassou o valor máximo permitido")]
        public int Ano { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Range(1, int.MaxValue , ErrorMessage = "O campo {0} ultapassou o valor máximo permitido")]
        public int Quilometragem { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(45, ErrorMessage = "O campo {0} ultapassou o limite máximo de caracters", MinimumLength = 1)]
        public string Observacao { get; set; }
    }   
}
