using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CoffeeShopApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigrate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClientName = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    ClientLastName = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    Ci = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedTimeUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastUpdateUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrderTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ClientId = table.Column<int>(type: "integer", nullable: true),
                    State = table.Column<int>(type: "integer", nullable: false),
                    TotalPay = table.Column<int>(type: "integer", nullable: false),
                    TotalPaid = table.Column<int>(type: "integer", nullable: false),
                    Payment = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedTimeUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastUpdateUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrderId = table.Column<int>(type: "integer", nullable: true),
                    ProductName = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    Description = table.Column<string>(type: "character varying(125)", maxLength: 125, nullable: false),
                    Category = table.Column<int>(type: "integer", nullable: false),
                    Availability = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<int>(type: "integer", nullable: false),
                    Picture = table.Column<byte[]>(type: "bytea", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedTimeUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastUpdateUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Availability", "Category", "DeletedTimeUtc", "Description", "IsDeleted", "LastUpdateUtc", "OrderId", "Picture", "Price", "ProductName" },
                values: new object[,]
                {
                    { 1, 50, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Café negro preparado con agua caliente.", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new byte[0], 223, "Café Americano" },
                    { 2, 30, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Café espresso con leche vaporizada.", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new byte[0], 343, "Café Latte" },
                    { 3, 40, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Café espresso con leche vaporizada y espuma de leche.", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new byte[0], 412, "Capuchino" },
                    { 4, 60, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Té verde natural con un toque de miel.", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new byte[0], 299, "Té Verde" },
                    { 5, 20, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Muffin esponjoso con arándanos frescos.", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new byte[0], 399, "Muffin de Arándanos" },
                    { 6, 25, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Croissant crujiente hecho con mantequilla pura.", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new byte[0], 299, "Croissant de Mantequilla" },
                    { 7, 15, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sándwich clásico con jamón, queso y vegetales frescos.", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new byte[0], 599, "Sándwich de Jamón y Queso" },
                    { 8, 10, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ensalada fresca con pollo, crutones y aderezo César.", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new byte[0], 699, "Ensalada César" },
                    { 9, 35, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jugo recién exprimido de naranjas frescas.", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new byte[0], 399, "Jugo de Naranja Natural" },
                    { 10, 18, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brownie rico y esponjoso con trozos de chocolate.", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new byte[0], 499, "Brownie de Chocolate" },
                    { 11, 40, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Café espresso con chocolate y leche vaporizada.", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new byte[0], 499, "Café Mocha" },
                    { 12, 55, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Té de manzana con un toque de canela.", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new byte[0], 299, "Té de Manzana" },
                    { 13, 20, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bagel fresco con queso crema suave.", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new byte[0], 399, "Bagel con Queso Crema" },
                    { 14, 30, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Galletas caseras de avena con pasas.", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new byte[0], 299, "Galletas de Avena" },
                    { 15, 25, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Smoothie refrescante con mezcla de frutas tropicales.", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new byte[0], 599, "Smoothie de Frutas" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Client_Ci",
                table: "Client",
                column: "Ci",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Order_ClientId",
                table: "Order",
                column: "ClientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_OrderId",
                table: "Product",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Client");
        }
    }
}
