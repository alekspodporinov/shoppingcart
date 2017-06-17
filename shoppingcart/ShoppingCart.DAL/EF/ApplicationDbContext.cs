using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using ShoppingCart.DAL.CustomIdentity;
using ShoppingCart.DAL.Entities;

namespace ShoppingCart.DAL.EF
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, CustomRole, long,
        CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public ApplicationDbContext(string conectionString) : base(conectionString) { }

        public virtual DbSet<Bascet> Bascets { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Characteristic> Characteristics { get; set; }
        public virtual DbSet<ContactDetail> ContactDetails { get; set; }
        public virtual DbSet<Discount> Discounts { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Logo> Logoes { get; set; }
        public virtual DbSet<Photo> Photoes { get; set; }
        public virtual DbSet<Shop> Shops { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<Telephone> Telephones { get; set; }

        public DbSet<UserProfile> UserProfile { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>()
                .HasOptional(e => e.ParentCategory)
                .WithMany(e => e.Children)
                .HasForeignKey(e => e.ParentId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Products)
                .WithMany(e => e.Categories);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Characteristics)
                .WithRequired(e => e.Category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Characteristic>()
                .HasMany(e => e.Values)
                .WithRequired(e => e.Characteristic)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ContactDetail>()
                .HasMany(e => e.Telephones)
                .WithRequired(e => e.ContactDetail)
                .HasForeignKey(e => e.ContactDetailsId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Bascets)
                .WithRequired(e => e.Product)
                .HasForeignKey(e => e.ProductId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Categories)
                .WithMany(e => e.Products);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Comments)
                .WithRequired(e => e.Product)
                .HasForeignKey(e => e.ProductId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Discounts)
                .WithRequired(e => e.Product)
                .HasForeignKey(e => e.ProductId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Photoes)
                .WithRequired(e => e.Product)
                .HasForeignKey(e => e.ProductId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.CharacteristicValue)
                .WithRequired(e => e.Product)
                .HasForeignKey(e => e.ProductId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Shop>()
                .HasMany(e => e.ContactDetails)
                .WithRequired(e => e.Shop)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Shop>()
                .HasMany(e => e.Logoes)
                .WithRequired(e => e.Shop)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<State>()
                .HasMany(e => e.Bascets)
                .WithRequired(e => e.State)
                .WillCascadeOnDelete(false);
        }
    }
}
