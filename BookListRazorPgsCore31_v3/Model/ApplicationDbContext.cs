using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace BookListRazorPgsCore31_v3.Model
{
    public class ApplicationDbContext : DbContext
    {

        // New constructor added to ensure DEPENDENCY DEPENDENCY...added by th 02232020
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {

        }

        //*** START: Approach is externally configured and will allow for easy test driven development...added by th 02102019
        //   DEPENDENCY INJECTION ***
        //public ChatFulDBContext(DbContextOptions<ChatFulDBContext> options)
        //    : base(options)
        //{
        //}
        //public DbSet<ChatUser> ChatUsers { get; set; }
        //*** END: Approach is externally configured and will allow for easy test driven development...added by th 02102019

        //*** START: Approach in internally configured and fails to allow for easy test driven development...added by th 02102019
        //    NO DEPENDENCY INJECTION
        public IConfiguration Configuration;

        public DbSet<Book> Books { get; set; }
        //public DbSet<Mat> Mats { get; set; }
        //public DbSet<Match> Matches { get; set; }
        //public DbSet<Player> Players { get; set; }
        //public DbSet<Result_Type> Result_Types { get; set; }
        //public DbSet<Team> Teams { get; set; }


        // *    This was the way this DBContext was working prior adding the constructor above that allows for DEPENDENCY INJECTION  *
        // *    Note Connection String is now in the appsetting.json file. 
        // *    ...added by th 02232020
        
        // WORKS WITHOUT DEPENDENCY INJECTION OF THE DBCONTEXT...COMMENTED OUT BY TH 03082020
        // ONCONFIGURING NOT NEEDED WHEN USING DEPENDENCY INJECTION ABOVE PASSING OPTIONS TO THE BASE.OPTIONS

        ////protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        ////{

        ////    // optionsBuilder.UseSqlServer(Configuration.GetConnectionString("ConnectionStrings:WhichMatDBConnection"));

        ////    // OR

        ////    // NEW LOCAL DEV DB...ADDED BY TH 03062020

        ////    string strConn = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BookListRazor;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";

        ////    // WEB DEV...COMMENTED OUT 03062020

        ////    // string strConn = "data source=tcp:sql2k804.discountasp.net;user id=SQL2008R2_135955_hvision_user;password=hvision04net;Min Pool Size=10;Max Pool Size=200;";

        ////    optionsBuilder.UseSqlServer(strConn);

        ////}


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    string strConn = "data source=tcp:sql2k804.discountasp.net;user id=SQL2008R2_135955_hvision_user;password=hvision04net;Min Pool Size=10;Max Pool Size=200;";

        //    optionsBuilder.UseSqlServer(strConn);

        //    optionsBuilder.UseSqlServer(Configuration.GetConnectionString("ChatFulDBContext"));
        //}

        //*** END: Approach in internally configured and fails to allow for easy test driven development...added by th 02102019
    }



}



