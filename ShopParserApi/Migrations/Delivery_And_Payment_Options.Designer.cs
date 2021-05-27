// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShopParserApi.Services;

namespace ShopParserApi.Migrations
{
    [DbContext(typeof(ApplicationDb))]
    [Migration("20210428092144_Delivery_And_Payment_Options")]
    partial class Delivery_And_Payment_Options
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CategoryProductData", b =>
                {
                    b.Property<int>("CategoriesId")
                        .HasColumnType("int");

                    b.Property<int>("ProductsId")
                        .HasColumnType("int");

                    b.HasKey("CategoriesId", "ProductsId");

                    b.HasIndex("ProductsId");

                    b.ToTable("CategoryProductData");
                });

            modelBuilder.Entity("ShopParserApi.Models.CategoryData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SupCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SupCategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("ShopParserApi.Models.CompanyData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CompanyState")
                        .HasColumnType("int");

                    b.Property<string>("ExternalId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JsonData")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JsonDataSchema")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SourceId")
                        .HasColumnType("int");

                    b.Property<DateTime>("SyncDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SourceId");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("ShopParserApi.Models.CompanySource", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Sources");
                });

            modelBuilder.Entity("ShopParserApi.Models.Helpers.ProductAttribute", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AttributeGroup")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AttributeName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AttributeValues")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ExternalId")
                        .HasColumnType("int");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductAttributes");
                });

            modelBuilder.Entity("ShopParserApi.Models.Helpers.ProductDeliveryOption", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ExternalId")
                        .HasColumnType("int");

                    b.Property<string>("OptionName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OptionsComment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductDeliveryOption");
                });

            modelBuilder.Entity("ShopParserApi.Models.Helpers.ProductPaymentOption", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ExternalId")
                        .HasColumnType("int");

                    b.Property<string>("OptionName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OptionsComment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductPaymentOption");
                });

            modelBuilder.Entity("ShopParserApi.Models.PresenceData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Available")
                        .HasColumnType("bit");

                    b.Property<bool>("Ending")
                        .HasColumnType("bit");

                    b.Property<bool>("OrderAvailable")
                        .HasColumnType("bit");

                    b.Property<bool>("PresenceSureAvailable")
                        .HasColumnType("bit");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Waiting")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("ProductId")
                        .IsUnique();

                    b.ToTable("Presence");
                });

            modelBuilder.Entity("ShopParserApi.Models.ProductData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ExternalId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JsonData")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JsonDataSchema")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KeyWords")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Price")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductState")
                        .HasColumnType("int");

                    b.Property<DateTime>("SyncDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("CategoryProductData", b =>
                {
                    b.HasOne("ShopParserApi.Models.CategoryData", null)
                        .WithMany()
                        .HasForeignKey("CategoriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShopParserApi.Models.ProductData", null)
                        .WithMany()
                        .HasForeignKey("ProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ShopParserApi.Models.CategoryData", b =>
                {
                    b.HasOne("ShopParserApi.Models.CategoryData", "SupCategoryData")
                        .WithMany()
                        .HasForeignKey("SupCategoryId");

                    b.Navigation("SupCategoryData");
                });

            modelBuilder.Entity("ShopParserApi.Models.CompanyData", b =>
                {
                    b.HasOne("ShopParserApi.Models.CompanySource", "Source")
                        .WithMany("Companies")
                        .HasForeignKey("SourceId");

                    b.Navigation("Source");
                });

            modelBuilder.Entity("ShopParserApi.Models.Helpers.ProductAttribute", b =>
                {
                    b.HasOne("ShopParserApi.Models.ProductData", "Product")
                        .WithMany("ProductAttribute")
                        .HasForeignKey("ProductId");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ShopParserApi.Models.Helpers.ProductDeliveryOption", b =>
                {
                    b.HasOne("ShopParserApi.Models.ProductData", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ShopParserApi.Models.Helpers.ProductPaymentOption", b =>
                {
                    b.HasOne("ShopParserApi.Models.ProductData", "Product")
                        .WithMany("ProductPaymentOption")
                        .HasForeignKey("ProductId");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ShopParserApi.Models.PresenceData", b =>
                {
                    b.HasOne("ShopParserApi.Models.ProductData", "Product")
                        .WithOne("Presence")
                        .HasForeignKey("ShopParserApi.Models.PresenceData", "ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ShopParserApi.Models.ProductData", b =>
                {
                    b.HasOne("ShopParserApi.Models.CompanyData", "Company")
                        .WithMany("Products")
                        .HasForeignKey("CompanyId");

                    b.Navigation("Company");
                });

            modelBuilder.Entity("ShopParserApi.Models.CompanyData", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("ShopParserApi.Models.CompanySource", b =>
                {
                    b.Navigation("Companies");
                });

            modelBuilder.Entity("ShopParserApi.Models.ProductData", b =>
                {
                    b.Navigation("Presence");

                    b.Navigation("ProductAttribute");

                    b.Navigation("ProductPaymentOption");
                });
#pragma warning restore 612, 618
        }
    }
}
