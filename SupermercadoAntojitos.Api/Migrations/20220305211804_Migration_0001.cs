using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SupermercadoAntojitos.Api.Migrations
{
    public partial class Migration_0001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombres = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false),
                    DocumentoIdentidad = table.Column<decimal>(type: "numeric(18,0)", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CLIENTE__4BD51FA53F029E7A", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Venta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCliente = table.Column<int>(type: "int", nullable: false),
                    ValorPagar = table.Column<decimal>(type: "numeric(18,0)", nullable: false),
                    UnidadesPorProducto = table.Column<decimal>(type: "numeric(18,0)", nullable: false),
                    FechaVenta = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__VENTA__4BD51FA53F029E7A", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Venta_Cliente_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Cliente",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdVenta = table.Column<int>(type: "int", nullable: true),
                    NombreProducto = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false),
                    Descripcion = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: true),
                    UnidadesExistentes = table.Column<decimal>(type: "numeric(18,0)", nullable: false),
                    ValorProducto = table.Column<decimal>(type: "numeric(18,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PRODUCTO__4BD51FA53F029E7A", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Producto_Venta_IdVenta",
                        column: x => x.IdVenta,
                        principalTable: "Venta",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Producto_IdVenta",
                table: "Producto",
                column: "IdVenta");

            migrationBuilder.CreateIndex(
                name: "IX_Venta_IdCliente",
                table: "Venta",
                column: "IdCliente");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "Venta");

            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
