using System.ComponentModel.DataAnnotations;

namespace BGExcursion.DAL
{    
    public class Tbl_CartStatus
    {
        public int CartStatusId { get; set; }
        [CreditCard]
        [Required(ErrorMessage = "���������� �� ����� �� ������ �� �������")]
        public string CartStatus { get; set; }
    }
}
