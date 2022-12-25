using System.ComponentModel.DataAnnotations;

namespace lab6.Data
{
    public class Receipt
    {
        [Key]
        public int ID { get; set; }
        public int ConsumerID { get; set; }
        public int UtilityID { get; set; }
        public string TypeOfPayment { get; set; } = null!;
        public DateTime ByDate { get; set; }
        public DateTime DateOfPayment { get; set; }
        public float Amount { get; set; }
        public float Benefits { get; set; }
        public float Subsidies { get; set; }
        public float FinalAmount { get; set; }


        public Consumer Consumer { get; set; } = null!;
        public Utility Utility { get; set; } = null!;

    }
}
