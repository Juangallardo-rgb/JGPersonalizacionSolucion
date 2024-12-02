    using System.ComponentModel.DataAnnotations;

namespace JGwebTienda.Models
{
    public class JGadornos
    {
        public int JGadornosId { get; set; }
        [Required]
        public string? JGName { get; set; }
        public bool JGnavideno { get; set; }
        [Range(0.01, 99.99)]
        public decimal JGprice { get; set; }

    }
}
