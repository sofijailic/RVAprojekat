using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uopsteno.Interfejsi;
using Uopsteno.Klase;

namespace Server.PristupBazi.ImplementacijeInterfejsa
{
    public class KorisnikBP : IKorisnik
    {
        private static IKorisnik bazaKor;

        public static IKorisnik Instance {

            get
            {
                if (bazaKor == null)
                    bazaKor = new KorisnikBP();

                return bazaKor;
            }
            set
            {
                if (bazaKor == null)
                    bazaKor = value;
            }
        }
        public bool dodajKorisnika(Korisnik noviKorisnik)
        {
            using (var pristup = new PristupBP())
            {
                var korisnici = pristup.Korisnici;
                foreach (var korisnik in korisnici)
                {
                    if (korisnik.Username == noviKorisnik.Username)
                    {
                        return false;
                    }
                }
                pristup.Korisnici.Add(noviKorisnik);
                int uspesno = pristup.SaveChanges();

                if (uspesno > 0)
                {
                    return true;
                }
                else return false;
            }
        }

        public bool izmeniPodatke(Korisnik k)
        {
            using (var pristup = new PristupBP())
            {
                Korisnik korisnik = pristup.Korisnici.First(x => x.Username == k.Username);
                korisnik.Ime = k.Ime;
                korisnik.Prezime = k.Prezime;
                int provera = pristup.SaveChanges();

                if (provera > 0)
                {
                    return true;
                }
                else {
                    return false;
                }
                
            }
        }

        public bool promeniGrupe(Korisnik k)
        {
            using (var p = new PristupBP())
            {

                Korisnik korisnik = p.Korisnici.First(x => x.Username == k.Username);
                korisnik.Grupe = k.Grupe;
                int provera = p.SaveChanges();

                if (provera > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }


            }
        }
        public Korisnik ulogujKorisnika(string korisnickoIme, string lozinka)
        {
            using (var pristup = new PristupBP())
            {
                var korisnici = pristup.Korisnici;

                foreach (var korisnik in korisnici)
                {
                    if (korisnik.Username == korisnickoIme && korisnik.Password == lozinka)
                    {
                        return korisnik;
                    }
                }
            }
            return null;
        }

        public List<Korisnik> uzmiSveKorisnike()
        {
            using (var pristup = new PristupBP())
            {

                var korisnici = pristup.Korisnici;
                return (List<Korisnik>)korisnici.ToList();
            }
        }
    }
}
