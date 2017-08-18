using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uopsteno.Klase
{
    public class Korisnik
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Grupe { get; set; }
        public bool Admin { get; set; }

        public Korisnik(string korisnickoIme, string lozinka)
        {
            this.Username = korisnickoIme;
            this.Password = lozinka;
        }
        public Korisnik() { }
    }
}
