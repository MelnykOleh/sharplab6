using System.ComponentModel.DataAnnotations;

namespace lab6.Data
{
    public class Utility
    {
        [Key]
        public int ID { get; set; }
        public string ServiceName { get; set; } = null!;
        public string PricePerSquareMeter { get; set; } = null!;
        public string PricePerPerson { get; set; } = null!;

    }
}
