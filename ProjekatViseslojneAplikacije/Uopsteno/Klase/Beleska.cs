using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uopsteno.Klase
{
    public class Beleska :BeleskaPrototip
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Naslov { get; set; }
        public string Sadrzaj { get; set; }
        public string Grupe { get; set; }

        public override Beleska Kloniraj()
        {
            Beleska klonirana = new Beleska();
            klonirana.Naslov = this.Naslov;
            klonirana.Sadrzaj = this.Sadrzaj;
            klonirana.Grupe = this.Grupe;
            return klonirana;
        }
    }
}
