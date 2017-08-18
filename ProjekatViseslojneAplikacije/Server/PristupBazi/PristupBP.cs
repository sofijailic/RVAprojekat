using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uopsteno.Klase;

namespace Server.PristupBazi
{
    public class PristupBP :DbContext
    {
        public PristupBP() : base("dbConnection2015") { Database.SetInitializer(new MigrateDatabaseToLatestVersion<PristupBP, Konfiguracija>()); }

        public DbSet<Korisnik> Korisnici { get; set; }
        public DbSet<Beleska> Beleske { get; set; }
    }
}
