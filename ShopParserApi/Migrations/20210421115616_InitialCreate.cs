﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopParserApi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Categories",
                table => new
                {
                    Id = table.Column<int>("int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>("nvarchar(max)", nullable: true),
                    Href = table.Column<string>("nvarchar(max)", nullable: true),
                    SupCategoryId = table.Column<int>("int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        "FK_Categories_Categories_SupCategoryId",
                        x => x.SupCategoryId,
                        "Categories",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "Sources",
                table => new
                {
                    Id = table.Column<int>("int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>("nvarchar(max)", nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Sources", x => x.Id); });

            migrationBuilder.CreateTable(
                "Shops",
                table => new
                {
                    Id = table.Column<int>("int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SourceId = table.Column<int>("int", nullable: true),
                    ExternalId = table.Column<string>("nvarchar(max)", nullable: true),
                    Name = table.Column<string>("nvarchar(max)", nullable: true),
                    Url = table.Column<string>("nvarchar(max)", nullable: true),
                    SyncDate = table.Column<DateTime>("datetime2", nullable: false),
                    JsonData = table.Column<string>("nvarchar(max)", nullable: true),
                    JsonDataSchema = table.Column<string>("nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shops", x => x.Id);
                    table.ForeignKey(
                        "FK_Shops_Sources_SourceId",
                        x => x.SourceId,
                        "Sources",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "Products",
                table => new
                {
                    Id = table.Column<int>("int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShopId = table.Column<int>("int", nullable: true),
                    ExternalId = table.Column<string>("nvarchar(max)", nullable: true),
                    Title = table.Column<string>("nvarchar(max)", nullable: true),
                    Url = table.Column<string>("nvarchar(max)", nullable: true),
                    SyncDate = table.Column<DateTime>("datetime2", nullable: false),
                    ExpirationDate = table.Column<DateTime>("datetime2", nullable: false),
                    ProductState = table.Column<int>("int", nullable: false),
                    Description = table.Column<string>("nvarchar(max)", nullable: true),
                    Price = table.Column<string>("nvarchar(max)", nullable: true),
                    KeyWords = table.Column<string>("nvarchar(max)", nullable: true),
                    JsonData = table.Column<string>("nvarchar(max)", nullable: true),
                    JsonDataSchema = table.Column<string>("nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        "FK_Products_Shops_ShopId",
                        x => x.ShopId,
                        "Shops",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "CategoryProductData",
                table => new
                {
                    CategoriesId = table.Column<int>("int", nullable: false),
                    ProductsId = table.Column<int>("int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryProductData", x => new {x.CategoriesId, x.ProductsId});
                    table.ForeignKey(
                        "FK_CategoryProductData_Categories_CategoriesId",
                        x => x.CategoriesId,
                        "Categories",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_CategoryProductData_Products_ProductsId",
                        x => x.ProductsId,
                        "Products",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "ProductAttributes",
                table => new
                {
                    Id = table.Column<int>("int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>("int", nullable: true),
                    AttributeName = table.Column<string>("nvarchar(max)", nullable: true),
                    AttributeValue = table.Column<string>("nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductAttributes", x => x.Id);
                    table.ForeignKey(
                        "FK_ProductAttributes_Products_ProductId",
                        x => x.ProductId,
                        "Products",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                "IX_Categories_SupCategoryId",
                "Categories",
                "SupCategoryId");

            migrationBuilder.CreateIndex(
                "IX_CategoryProductData_ProductsId",
                "CategoryProductData",
                "ProductsId");

            migrationBuilder.CreateIndex(
                "IX_ProductAttributes_ProductId",
                "ProductAttributes",
                "ProductId");

            migrationBuilder.CreateIndex(
                "IX_Products_ShopId",
                "Products",
                "ShopId");

            migrationBuilder.CreateIndex(
                "IX_Shops_SourceId",
                "Shops",
                "SourceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "CategoryProductData");

            migrationBuilder.DropTable(
                "ProductAttributes");

            migrationBuilder.DropTable(
                "Categories");

            migrationBuilder.DropTable(
                "Products");

            migrationBuilder.DropTable(
                "Shops");

            migrationBuilder.DropTable(
                "Sources");
        }
    }
}