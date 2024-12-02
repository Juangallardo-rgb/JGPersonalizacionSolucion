using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JGadornosApp.JGmodels
{
    public class JGadorno
    {
        public int jgadornosId { get; set; }
        [Required]
        public string? jgname { get; set; }
        public bool jgnavideno { get; set; }
        public decimal jgprice { get; set; }
    }


}
