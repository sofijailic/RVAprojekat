using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uopsteno.Interfejsi;
using Uopsteno.Klase;

namespace Server.PristupBazi.ImplementacijeInterfejsa
{
    public class BeleskaBP : IBeleska
    {
        private static IBeleska bazaBel;
        public static IBeleska Instance {
            get
            {
                if (bazaBel == null)
                    bazaBel = new BeleskaBP();

                return bazaBel;
            }
            set
            {
                if (bazaBel == null)
                    bazaBel = value;
            }
        }
        public bool dodajBelesku(Beleska beleska)
        {
            using (var pristup = new PristupBP())
            {
                var beleske = pristup.Beleske;

                pristup.Beleske.Add(beleska);
                int uspesno = pristup.SaveChanges();

                if (uspesno > 0)
                {
                    return true;
                }
                else return false;

            }
        }

        public bool izmeniBelesku(Beleska beleska)
        {
            using (var pristup = new PristupBP())
            {
                Beleska bel = pristup.Beleske.First(x => x.Id == beleska.Id);
                bel.Naslov = beleska.Naslov;
                bel.Sadrzaj = beleska.Sadrzaj;
                bel.Grupe = beleska.Grupe;
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

        public bool obrisiBelesku(int id)
        {
            using (var pristup = new PristupBP())
            {
                var beleska = new Beleska { Id = id };
                pristup.Beleske.Attach(beleska);
                pristup.Beleske.Remove(beleska);
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

        public List<Beleska> uzmiBeleskeOdKorisnika(Korisnik k)
        {
            List<Beleska> listaBeleskiKorisnika = new List<Beleska>();
            string[] korisnickeGrupe = k.Grupe.Split(';');
            using (var pristup = new PristupBP())
            {
                var beleske = pristup.Beleske;

                foreach (var beleska in beleske)
                {
                    foreach (string grupa in korisnickeGrupe)
                    {
                        if (beleska.Grupe.Contains(grupa))
                        {
                            listaBeleskiKorisnika.Add(beleska);
                            break;
                        }
                    }
                }

            }

            return listaBeleskiKorisnika;
        }

        public Beleska uzmiBeleskuPoId(int id)
        {
            using (var pristup = new PristupBP())
            {
                var beleske = pristup.Beleske;

                foreach (var beleska in beleske)
                {
                    if (beleska.Id == id)
                    {
                        return beleska;
                    }
                }
            }
            return null; ;
        }
    }
}
