﻿// <auto-generated />

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ShopParserApi.Service;

namespace ShopParserApi.Migrations
{
    [DbContext(typeof(ApplicationDb))]
    [Migration("20210421115616_InitialCreate")]
    partial class InitialCreate
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

            modelBuilder.Entity("PrjModule25_Parser.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Href")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SupCategoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SupCategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("PrjModule25_Parser.Models.Helpers.ProductAttribute", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AttributeName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AttributeValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductAttributes");
                });

            modelBuilder.Entity("PrjModule25_Parser.Models.ProductData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

                    b.Property<int?>("companyId")
                        .HasColumnType("int");

                    b.Property<DateTime>("SyncDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("companyId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("PrjModule25_Parser.Models.companyData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

                    b.ToTable("companys");
                });

            modelBuilder.Entity("PrjModule25_Parser.Models.companySource", b =>
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

            modelBuilder.Entity("CategoryProductData", b =>
                {
                    b.HasOne("PrjModule25_Parser.Models.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PrjModule25_Parser.Models.ProductData", null)
                        .WithMany()
                        .HasForeignKey("ProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PrjModule25_Parser.Models.Category", b =>
                {
                    b.HasOne("PrjModule25_Parser.Models.Category", "SupCategory")
                        .WithMany()
                        .HasForeignKey("SupCategoryId");

                    b.Navigation("SupCategory");
                });

            modelBuilder.Entity("PrjModule25_Parser.Models.Helpers.ProductAttribute", b =>
                {
                    b.HasOne("PrjModule25_Parser.Models.ProductData", "Product")
                        .WithMany("ProductAttribute")
                        .HasForeignKey("ProductId");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("PrjModule25_Parser.Models.ProductData", b =>
                {
                    b.HasOne("PrjModule25_Parser.Models.companyData", "company")
                        .WithMany("Products")
                        .HasForeignKey("companyId");

                    b.Navigation("company");
                });

            modelBuilder.Entity("PrjModule25_Parser.Models.companyData", b =>
                {
                    b.HasOne("PrjModule25_Parser.Models.companySource", "Source")
                        .WithMany("companys")
                        .HasForeignKey("SourceId");

                    b.Navigation("Source");
                });

            modelBuilder.Entity("PrjModule25_Parser.Models.ProductData", b =>
                {
                    b.Navigation("ProductAttribute");
                });

            modelBuilder.Entity("PrjModule25_Parser.Models.companyData", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("PrjModule25_Parser.Models.companySource", b =>
                {
                    b.Navigation("companys");
                });
#pragma warning restore 612, 618
        }
    }
}
