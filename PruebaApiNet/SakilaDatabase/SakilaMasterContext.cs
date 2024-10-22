using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PruebaApiNet.SakilaDatabase;

public partial class SakilaMasterContext : DbContext
{
    public SakilaMasterContext()
    {
    }

    public SakilaMasterContext(DbContextOptions<SakilaMasterContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Actor> Actors { get; set; }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<CustomerList> CustomerLists { get; set; }

    public virtual DbSet<Film> Films { get; set; }

    public virtual DbSet<FilmActor> FilmActors { get; set; }

    public virtual DbSet<FilmCategory> FilmCategories { get; set; }

    public virtual DbSet<FilmList> FilmLists { get; set; }

    public virtual DbSet<FilmText> FilmTexts { get; set; }

    public virtual DbSet<Inventory> Inventories { get; set; }

    public virtual DbSet<Language> Languages { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Rental> Rentals { get; set; }

    public virtual DbSet<SalesByFilmCategory> SalesByFilmCategories { get; set; }

    public virtual DbSet<SalesByStore> SalesByStores { get; set; }

    public virtual DbSet<Staff> Staff { get; set; }

    public virtual DbSet<StaffList> StaffLists { get; set; }

    public virtual DbSet<Store> Stores { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("DataSource=sakila_master.db")
        .LogTo(Console.WriteLine);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Actor>(entity =>
        {
            entity.ToTable("actor");

            entity.HasIndex(e => e.LastName, "idx_actor_last_name");

            entity.Property(e => e.ActorId)
                .ValueGeneratedNever()
                .HasColumnType("numeric")
                .HasColumnName("actor_id");
            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasColumnType("VARCHAR(45)")
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .IsRequired()
                .HasColumnType("VARCHAR(45)")
                .HasColumnName("last_name");
            entity.Property(e => e.LastUpdate)
                .HasColumnType("TIMESTAMP")
                .HasColumnName("last_update");
        });

        modelBuilder.Entity<Address>(entity =>
        {
            entity.ToTable("address");

            entity.HasIndex(e => e.CityId, "idx_fk_city_id");

            entity.Property(e => e.AddressId)
                .ValueGeneratedNever()
                .HasColumnType("INT")
                .HasColumnName("address_id");
            entity.Property(e => e.Address1)
                .IsRequired()
                .HasColumnType("VARCHAR(50)")
                .HasColumnName("address");
            entity.Property(e => e.Address2)
                .HasDefaultValueSql("NULL")
                .HasColumnType("VARCHAR(50)")
                .HasColumnName("address2");
            entity.Property(e => e.CityId)
                .HasColumnType("INT")
                .HasColumnName("city_id");
            entity.Property(e => e.District)
                .IsRequired()
                .HasColumnType("VARCHAR(20)")
                .HasColumnName("district");
            entity.Property(e => e.LastUpdate)
                .HasColumnType("TIMESTAMP")
                .HasColumnName("last_update");
            entity.Property(e => e.Phone)
                .IsRequired()
                .HasColumnType("VARCHAR(20)")
                .HasColumnName("phone");
            entity.Property(e => e.PostalCode)
                .HasDefaultValueSql("NULL")
                .HasColumnType("VARCHAR(10)")
                .HasColumnName("postal_code");

            entity.HasOne(d => d.City).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.CityId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("category");

            entity.Property(e => e.CategoryId)
                .ValueGeneratedNever()
                .HasColumnType("SMALLINT")
                .HasColumnName("category_id");
            entity.Property(e => e.LastUpdate)
                .HasColumnType("TIMESTAMP")
                .HasColumnName("last_update");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasColumnType("VARCHAR(25)")
                .HasColumnName("name");
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.ToTable("city");

            entity.HasIndex(e => e.CountryId, "idx_fk_country_id");

            entity.Property(e => e.CityId)
                .ValueGeneratedNever()
                .HasColumnType("INT")
                .HasColumnName("city_id");
            entity.Property(e => e.City1)
                .IsRequired()
                .HasColumnType("VARCHAR(50)")
                .HasColumnName("city");
            entity.Property(e => e.CountryId)
                .HasColumnType("SMALLINT")
                .HasColumnName("country_id");
            entity.Property(e => e.LastUpdate)
                .HasColumnType("TIMESTAMP")
                .HasColumnName("last_update");

            entity.HasOne(d => d.Country).WithMany(p => p.Cities)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.ToTable("country");

            entity.Property(e => e.CountryId)
                .ValueGeneratedNever()
                .HasColumnType("SMALLINT")
                .HasColumnName("country_id");
            entity.Property(e => e.Country1)
                .IsRequired()
                .HasColumnType("VARCHAR(50)")
                .HasColumnName("country");
            entity.Property(e => e.LastUpdate)
                .HasColumnType("TIMESTAMP")
                .HasColumnName("last_update");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.ToTable("customer");

            entity.HasIndex(e => e.AddressId, "idx_customer_fk_address_id");

            entity.HasIndex(e => e.StoreId, "idx_customer_fk_store_id");

            entity.HasIndex(e => e.LastName, "idx_customer_last_name");

            entity.Property(e => e.CustomerId)
                .ValueGeneratedNever()
                .HasColumnType("INT")
                .HasColumnName("customer_id");
            entity.Property(e => e.Active)
                .IsRequired()
                .HasDefaultValue("Y")
                .HasColumnType("CHAR(1)")
                .HasColumnName("active");
            entity.Property(e => e.AddressId)
                .HasColumnType("INT")
                .HasColumnName("address_id");
            entity.Property(e => e.CreateDate)
                .HasColumnType("TIMESTAMP")
                .HasColumnName("create_date");
            entity.Property(e => e.Email)
                .HasDefaultValueSql("NULL")
                .HasColumnType("VARCHAR(50)")
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasColumnType("VARCHAR(45)")
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .IsRequired()
                .HasColumnType("VARCHAR(45)")
                .HasColumnName("last_name");
            entity.Property(e => e.LastUpdate)
                .HasColumnType("TIMESTAMP")
                .HasColumnName("last_update");
            entity.Property(e => e.StoreId)
                .HasColumnType("INT")
                .HasColumnName("store_id");

            entity.HasOne(d => d.Address).WithMany(p => p.Customers)
                .HasForeignKey(d => d.AddressId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Store).WithMany(p => p.Customers)
                .HasForeignKey(d => d.StoreId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<CustomerList>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("customer_list");

            entity.Property(e => e.Address)
                .HasColumnType("VARCHAR(50)")
                .HasColumnName("address");
            entity.Property(e => e.City)
                .HasColumnType("VARCHAR(50)")
                .HasColumnName("city");
            entity.Property(e => e.Country)
                .HasColumnType("VARCHAR(50)")
                .HasColumnName("country");
            entity.Property(e => e.Id)
                .HasColumnType("INT")
                .HasColumnName("ID");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Notes).HasColumnName("notes");
            entity.Property(e => e.Phone)
                .HasColumnType("VARCHAR(20)")
                .HasColumnName("phone");
            entity.Property(e => e.Sid)
                .HasColumnType("INT")
                .HasColumnName("SID");
            entity.Property(e => e.ZipCode)
                .HasColumnType("VARCHAR(10)")
                .HasColumnName("zip_code");
        });

        modelBuilder.Entity<Film>(entity =>
        {
            entity.ToTable("film");

            entity.HasIndex(e => e.LanguageId, "idx_fk_language_id");

            entity.HasIndex(e => e.OriginalLanguageId, "idx_fk_original_language_id");

            entity.Property(e => e.FilmId)
                .ValueGeneratedNever()
                .HasColumnType("INT")
                .HasColumnName("film_id");
            entity.Property(e => e.Description)
                .HasDefaultValueSql("NULL")
                .HasColumnType("BLOB SUB_TYPE TEXT")
                .HasColumnName("description");
            entity.Property(e => e.LanguageId)
                .HasColumnType("SMALLINT")
                .HasColumnName("language_id");
            entity.Property(e => e.LastUpdate)
                .HasColumnType("TIMESTAMP")
                .HasColumnName("last_update");
            entity.Property(e => e.Length)
                .HasDefaultValueSql("NULL")
                .HasColumnType("SMALLINT")
                .HasColumnName("length");
            entity.Property(e => e.OriginalLanguageId)
                .HasDefaultValueSql("NULL")
                .HasColumnType("SMALLINT")
                .HasColumnName("original_language_id");
            entity.Property(e => e.Rating)
                .HasDefaultValue("G")
                .HasColumnType("VARCHAR(10)")
                .HasColumnName("rating");
            entity.Property(e => e.ReleaseYear)
                .HasDefaultValueSql("NULL")
                .HasColumnType("VARCHAR(4)")
                .HasColumnName("release_year");
            entity.Property(e => e.RentalDuration)
                .HasDefaultValue((short)3)
                .HasColumnType("SMALLINT")
                .HasColumnName("rental_duration");
            entity.Property(e => e.RentalRate)
                .HasDefaultValueSql("4.99")
                .HasColumnType("DECIMAL(4,2)")
                .HasColumnName("rental_rate");
            entity.Property(e => e.ReplacementCost)
                .HasDefaultValueSql("19.99")
                .HasColumnType("DECIMAL(5,2)")
                .HasColumnName("replacement_cost");
            entity.Property(e => e.SpecialFeatures)
                .HasDefaultValueSql("NULL")
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("special_features");
            entity.Property(e => e.Title)
                .IsRequired()
                .HasColumnType("VARCHAR(255)")
                .HasColumnName("title");

            entity.HasOne(d => d.Language).WithMany(p => p.FilmLanguages)
                .HasForeignKey(d => d.LanguageId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.OriginalLanguage).WithMany(p => p.FilmOriginalLanguages).HasForeignKey(d => d.OriginalLanguageId);
        });

        modelBuilder.Entity<FilmActor>(entity =>
        {
            entity.HasKey(e => new { e.ActorId, e.FilmId });

            entity.ToTable("film_actor");

            entity.HasIndex(e => e.ActorId, "idx_fk_film_actor_actor");

            entity.HasIndex(e => e.FilmId, "idx_fk_film_actor_film");

            entity.Property(e => e.ActorId)
                .HasColumnType("INT")
                .HasColumnName("actor_id");
            entity.Property(e => e.FilmId)
                .HasColumnType("INT")
                .HasColumnName("film_id");
            entity.Property(e => e.LastUpdate)
                .HasColumnType("TIMESTAMP")
                .HasColumnName("last_update");

            entity.HasOne(d => d.Actor).WithMany(p => p.FilmActors)
                .HasForeignKey(d => d.ActorId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Film).WithMany(p => p.FilmActors)
                .HasForeignKey(d => d.FilmId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<FilmCategory>(entity =>
        {
            entity.HasKey(e => new { e.FilmId, e.CategoryId });

            entity.ToTable("film_category");

            entity.HasIndex(e => e.CategoryId, "idx_fk_film_category_category");

            entity.HasIndex(e => e.FilmId, "idx_fk_film_category_film");

            entity.Property(e => e.FilmId)
                .HasColumnType("INT")
                .HasColumnName("film_id");
            entity.Property(e => e.CategoryId)
                .HasColumnType("SMALLINT")
                .HasColumnName("category_id");
            entity.Property(e => e.LastUpdate)
                .HasColumnType("TIMESTAMP")
                .HasColumnName("last_update");

            entity.HasOne(d => d.Category).WithMany(p => p.FilmCategories)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Film).WithMany(p => p.FilmCategories)
                .HasForeignKey(d => d.FilmId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<FilmList>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("film_list");

            entity.Property(e => e.Actors).HasColumnName("actors");
            entity.Property(e => e.Category)
                .HasColumnType("VARCHAR(25)")
                .HasColumnName("category");
            entity.Property(e => e.Description)
                .HasColumnType("BLOB SUB_TYPE TEXT")
                .HasColumnName("description");
            entity.Property(e => e.Fid)
                .HasColumnType("INT")
                .HasColumnName("FID");
            entity.Property(e => e.Length)
                .HasColumnType("SMALLINT")
                .HasColumnName("length");
            entity.Property(e => e.Price)
                .HasColumnType("DECIMAL(4,2)")
                .HasColumnName("price");
            entity.Property(e => e.Rating)
                .HasColumnType("VARCHAR(10)")
                .HasColumnName("rating");
            entity.Property(e => e.Title)
                .HasColumnType("VARCHAR(255)")
                .HasColumnName("title");
        });

        modelBuilder.Entity<FilmText>(entity =>
        {
            entity.HasKey(e => e.FilmId);

            entity.ToTable("film_text");

            entity.Property(e => e.FilmId)
                .ValueGeneratedNever()
                .HasColumnType("SMALLINT")
                .HasColumnName("film_id");
            entity.Property(e => e.Description)
                .HasColumnType("BLOB SUB_TYPE TEXT")
                .HasColumnName("description");
            entity.Property(e => e.Title)
                .IsRequired()
                .HasColumnType("VARCHAR(255)")
                .HasColumnName("title");
        });

        modelBuilder.Entity<Inventory>(entity =>
        {
            entity.ToTable("inventory");

            entity.HasIndex(e => e.FilmId, "idx_fk_film_id");

            entity.HasIndex(e => new { e.StoreId, e.FilmId }, "idx_fk_film_id_store_id");

            entity.Property(e => e.InventoryId)
                .ValueGeneratedNever()
                .HasColumnType("INT")
                .HasColumnName("inventory_id");
            entity.Property(e => e.FilmId)
                .HasColumnType("INT")
                .HasColumnName("film_id");
            entity.Property(e => e.LastUpdate)
                .HasColumnType("TIMESTAMP")
                .HasColumnName("last_update");
            entity.Property(e => e.StoreId)
                .HasColumnType("INT")
                .HasColumnName("store_id");

            entity.HasOne(d => d.Film).WithMany(p => p.Inventories)
                .HasForeignKey(d => d.FilmId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Store).WithMany(p => p.Inventories)
                .HasForeignKey(d => d.StoreId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Language>(entity =>
        {
            entity.ToTable("language");

            entity.Property(e => e.LanguageId)
                .ValueGeneratedNever()
                .HasColumnType("SMALLINT")
                .HasColumnName("language_id");
            entity.Property(e => e.LastUpdate)
                .HasColumnType("TIMESTAMP")
                .HasColumnName("last_update");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasColumnType("CHAR(20)")
                .HasColumnName("name");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.ToTable("payment");

            entity.HasIndex(e => e.CustomerId, "idx_fk_customer_id");

            entity.HasIndex(e => e.StaffId, "idx_fk_staff_id");

            entity.Property(e => e.PaymentId)
                .ValueGeneratedNever()
                .HasColumnType("INT")
                .HasColumnName("payment_id");
            entity.Property(e => e.Amount)
                .HasColumnType("DECIMAL(5,2)")
                .HasColumnName("amount");
            entity.Property(e => e.CustomerId)
                .HasColumnType("INT")
                .HasColumnName("customer_id");
            entity.Property(e => e.LastUpdate)
                .HasColumnType("TIMESTAMP")
                .HasColumnName("last_update");
            entity.Property(e => e.PaymentDate)
                .HasColumnType("TIMESTAMP")
                .HasColumnName("payment_date");
            entity.Property(e => e.RentalId)
                .HasDefaultValueSql("NULL")
                .HasColumnType("INT")
                .HasColumnName("rental_id");
            entity.Property(e => e.StaffId)
                .HasColumnType("SMALLINT")
                .HasColumnName("staff_id");

            entity.HasOne(d => d.Customer).WithMany(p => p.Payments)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Rental).WithMany(p => p.Payments)
                .HasForeignKey(d => d.RentalId)
                .OnDelete(DeleteBehavior.SetNull);

            entity.HasOne(d => d.Staff).WithMany(p => p.Payments)
                .HasForeignKey(d => d.StaffId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Rental>(entity =>
        {
            entity.ToTable("rental");

            entity.HasIndex(e => e.CustomerId, "idx_rental_fk_customer_id");

            entity.HasIndex(e => e.InventoryId, "idx_rental_fk_inventory_id");

            entity.HasIndex(e => e.StaffId, "idx_rental_fk_staff_id");

            entity.HasIndex(e => new { e.RentalDate, e.InventoryId, e.CustomerId }, "idx_rental_uq").IsUnique();

            entity.Property(e => e.RentalId)
                .ValueGeneratedNever()
                .HasColumnType("INT")
                .HasColumnName("rental_id");
            entity.Property(e => e.CustomerId)
                .HasColumnType("INT")
                .HasColumnName("customer_id");
            entity.Property(e => e.InventoryId)
                .HasColumnType("INT")
                .HasColumnName("inventory_id");
            entity.Property(e => e.LastUpdate)
                .HasColumnType("TIMESTAMP")
                .HasColumnName("last_update");
            entity.Property(e => e.RentalDate)
                .HasColumnType("TIMESTAMP")
                .HasColumnName("rental_date");
            entity.Property(e => e.ReturnDate)
                .HasDefaultValueSql("NULL")
                .HasColumnType("TIMESTAMP")
                .HasColumnName("return_date");
            entity.Property(e => e.StaffId)
                .HasColumnType("SMALLINT")
                .HasColumnName("staff_id");

            entity.HasOne(d => d.Customer).WithMany(p => p.Rentals)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Inventory).WithMany(p => p.Rentals)
                .HasForeignKey(d => d.InventoryId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Staff).WithMany(p => p.Rentals)
                .HasForeignKey(d => d.StaffId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<SalesByFilmCategory>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("sales_by_film_category");

            entity.Property(e => e.Category)
                .HasColumnType("VARCHAR(25)")
                .HasColumnName("category");
            entity.Property(e => e.TotalSales).HasColumnName("total_sales");
        });

        modelBuilder.Entity<SalesByStore>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("sales_by_store");

            entity.Property(e => e.Manager).HasColumnName("manager");
            entity.Property(e => e.Store).HasColumnName("store");
            entity.Property(e => e.StoreId)
                .HasColumnType("INT")
                .HasColumnName("store_id");
            entity.Property(e => e.TotalSales).HasColumnName("total_sales");
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.ToTable("staff");

            entity.HasIndex(e => e.AddressId, "idx_fk_staff_address_id");

            entity.HasIndex(e => e.StoreId, "idx_fk_staff_store_id");

            entity.Property(e => e.StaffId)
                .ValueGeneratedNever()
                .HasColumnType("SMALLINT")
                .HasColumnName("staff_id");
            entity.Property(e => e.Active)
                .HasDefaultValue((short)1)
                .HasColumnType("SMALLINT")
                .HasColumnName("active");
            entity.Property(e => e.AddressId)
                .HasColumnType("INT")
                .HasColumnName("address_id");
            entity.Property(e => e.Email)
                .HasDefaultValueSql("NULL")
                .HasColumnType("VARCHAR(50)")
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasColumnType("VARCHAR(45)")
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .IsRequired()
                .HasColumnType("VARCHAR(45)")
                .HasColumnName("last_name");
            entity.Property(e => e.LastUpdate)
                .HasColumnType("TIMESTAMP")
                .HasColumnName("last_update");
            entity.Property(e => e.Password)
                .HasDefaultValueSql("NULL")
                .HasColumnType("VARCHAR(40)")
                .HasColumnName("password");
            entity.Property(e => e.Picture)
                .HasDefaultValueSql("NULL")
                .HasColumnName("picture");
            entity.Property(e => e.StoreId)
                .HasColumnType("INT")
                .HasColumnName("store_id");
            entity.Property(e => e.Username)
                .IsRequired()
                .HasColumnType("VARCHAR(16)")
                .HasColumnName("username");

            entity.HasOne(d => d.Address).WithMany(p => p.Staff)
                .HasForeignKey(d => d.AddressId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Store).WithMany(p => p.Staff)
                .HasForeignKey(d => d.StoreId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<StaffList>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("staff_list");

            entity.Property(e => e.Address)
                .HasColumnType("VARCHAR(50)")
                .HasColumnName("address");
            entity.Property(e => e.City)
                .HasColumnType("VARCHAR(50)")
                .HasColumnName("city");
            entity.Property(e => e.Country)
                .HasColumnType("VARCHAR(50)")
                .HasColumnName("country");
            entity.Property(e => e.Id)
                .HasColumnType("SMALLINT")
                .HasColumnName("ID");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasColumnType("VARCHAR(20)")
                .HasColumnName("phone");
            entity.Property(e => e.Sid)
                .HasColumnType("INT")
                .HasColumnName("SID");
            entity.Property(e => e.ZipCode)
                .HasColumnType("VARCHAR(10)")
                .HasColumnName("zip_code");
        });

        modelBuilder.Entity<Store>(entity =>
        {
            entity.ToTable("store");

            entity.HasIndex(e => e.AddressId, "idx_fk_store_address");

            entity.HasIndex(e => e.ManagerStaffId, "idx_store_fk_manager_staff_id");

            entity.Property(e => e.StoreId)
                .ValueGeneratedNever()
                .HasColumnType("INT")
                .HasColumnName("store_id");
            entity.Property(e => e.AddressId)
                .HasColumnType("INT")
                .HasColumnName("address_id");
            entity.Property(e => e.LastUpdate)
                .HasColumnType("TIMESTAMP")
                .HasColumnName("last_update");
            entity.Property(e => e.ManagerStaffId)
                .HasColumnType("SMALLINT")
                .HasColumnName("manager_staff_id");

            entity.HasOne(d => d.Address).WithMany(p => p.Stores)
                .HasForeignKey(d => d.AddressId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.ManagerStaff).WithMany(p => p.Stores)
                .HasForeignKey(d => d.ManagerStaffId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
