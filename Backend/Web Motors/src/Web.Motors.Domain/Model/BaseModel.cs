using System.ComponentModel.DataAnnotations.Schema;
using Web.Motors.Domain.Types;

namespace Web.Motors.Domain.Model
{
    public class BaseModel
    {

        [NotMapped]
        public OperationType Operation { get; set; }
    }
}
