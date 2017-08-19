using Common.Data;
using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.Lock;


namespace Server.Access
{
    public class BeleskaDB : IBeleskaDB
    {
        private static IBeleskaDB myDB;

        public static IBeleskaDB Instance
        {
            get
            {
                if (myDB == null)
                    myDB = new BeleskaDB();

                return myDB;
            }
            set
            {
                if (myDB == null)
                    myDB = value;
            }
        }

        public Beleska dodavanjeBeleske(Beleska newBeleska)
        {
            lock (Lock.Lock.lockBeleska) {
                using (var access = new AccessDB())
                {
                    var beleske = access.Beleske;

                    access.Beleske.Add(newBeleska);
                    int uspesno = access.SaveChanges();

                    if (uspesno > 0)
                    {
                        return newBeleska;
                    }
                    else return null;

                }
            }
            
        }

        public bool izmeniBelesku(Beleska beleska)
        {
            lock (Lock.Lock.lockBeleska)
            {
                using (var access = new AccessDB())
                {
                    Beleska bel = access.Beleske.First(x => x.Id == beleska.Id);
                    bel.Naslov = beleska.Naslov;
                    bel.Sadrzaj = beleska.Sadrzaj;
                    int i = access.SaveChanges();

                    return (i > 0 ? true : false);
                }

            }
               
        }

        public bool obrisiBelesku(int id)
        {
            lock (Lock.Lock.lockBeleska)
            {
                using (var access = new AccessDB())
                {
                    var beleske = access.Beleske;

                    foreach (var item in beleske)
                    {
                        if (item.Id == id)
                        {
                            access.Beleske.Remove(item);
                            break;
                        }
                    }

                    int i = access.SaveChanges();
                    if (i > 0)
                    {
                        return true;
                    }
                    else
                        return false;
                }


            }

        }

        public Beleska uzmiBeleksuPoId(int id)
        {

            lock (Lock.Lock.lockBeleska)
            {
                using (var access = new AccessDB())
                {
                    var beleske = access.Beleske;

                    foreach (var beleska in beleske)
                    {
                        if (beleska.Id == id)
                        {
                            return beleska;
                        }
                    }
                }
                return null;
            }
               
        
    }

        public List<Beleska> uzmiBeleskeOdKorisnika(User u)
        {
            lock (Lock.Lock.lockBeleska)
            {
                List<Beleska> listaBeleski = new List<Beleska>();
                string[] korisnickeGrupe = u.Grupe.Split(';');
                using (var access = new AccessDB())
                {
                    var beleske = access.Beleske;

                    foreach (var beleska in beleske)
                    {
                        foreach (string grupa in korisnickeGrupe)
                        {
                            if (beleska.Grupe.Contains(grupa))
                            {
                                listaBeleski.Add(beleska);
                                break;
                            }
                        }
                    }

                }

                return listaBeleski;

            }
              
        }

        public List<Beleska> uzmiSveBeleske()
        {
            lock (Lock.Lock.lockBeleska)
            {
                using (var access = new AccessDB())
                {
                    var beleske = access.Beleske;
                    return (List<Beleska>)beleske.ToList();
                }

            }
               
        }
    }
}
