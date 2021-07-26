using Microsoft.EntityFrameworkCore;
using TCCCards.Models.CustomerInfo;
using TCCCards.Models.Payment;

namespace TCCCards.Models
{
    public class TCCContext : DbContext
    {

        public TCCContext(DbContextOptions<TCCContext> options)
            : base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }


        //public DbSet<TemplateName> Template { get; set; }
        //public DbSet<Department> departments { get; set; }


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.ApplyConfiguration(new DeveloperEntityConfiguration());
        //}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(
            //    @"Server=DELL;Initial Catalog=TCCCardsDB;Integrated Security=True");

            optionsBuilder.UseSqlServer(
                @"Data Source = DELL; Initial Catalog=TCCCardsDB; Integrated Security = True; TrustServerCertificate = False;  MultiSubnetFailover = False");

        }
    }
}




    