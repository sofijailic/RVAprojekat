using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Data;

namespace Server.Access
{
    public class UserDB : IUserDB
    {

        private static IUserDB myDB;

        public static IUserDB Instance
        {
            get
            {
                if (myDB == null)
                    myDB = new UserDB();

                return myDB;
            }
            set
            {
                if (myDB == null)
                    myDB = value;
            }
        }

        public User UlogujKorisnika(string username, string password)
        {
            lock (Lock.Lock.lockUser) {
                using (var access = new AccessDB())
                {
                    var users = access.Users;

                    foreach (var user in users)
                    {
                        if (user.Username == username && user.Password == password)
                        {
                            return user;
                        }
                    }
                }
                return null;
            }
            
        }

        public bool DodajKorisnika(User newUser)
        {
            lock (Lock.Lock.lockUser)
            {
                using (var access = new AccessDB())
                {
                    var users = access.Users;
                    foreach (var user in users)
                    {
                        if (user.Username == newUser.Username)
                        {
                            return false;
                        }
                    }
                    access.Users.Add(newUser);
                    int uspesno = access.SaveChanges();

                    if (uspesno > 0)
                    {
                        return true;
                    }
                    else return false;
                }
            }
                
               
        }

        public bool IzmeniPodatke(User u)
        {
            lock (Lock.Lock.lockUser)
            {
                using (var access = new AccessDB())
                {
                    User user = access.Users.First(x => x.Username == u.Username);
                    user.Ime = u.Ime;
                    user.Prezime = u.Prezime;
                    int provera = access.SaveChanges();

                    if (provera > 0)
                    {

                        return true;
                    }
                    else {
                        return false;
                    }
                   
                }

            }
               
        }

        public List<User> uzmiSveKorisnike()
        {
            lock (Lock.Lock.lockUser)
            {
                using (var access = new AccessDB())
                {

                    var korisnici = access.Users;
                    return (List<User>)korisnici.ToList();
                }

            }
                
        }

        public bool promeniGrupe(User u)
        {
            lock (Lock.Lock.lockUser)
            {
                using (var a = new AccessDB())
                {

                    User us = a.Users.First(x => x.Username == u.Username);
                    us.Grupe = u.Grupe;
                    int i = a.SaveChanges();

                    if (i > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

            }
                
        }
    }
}