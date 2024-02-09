using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppVendasWeb.Migrations
{
    /// <inheritdoc />
    public partial class AddItensDaVenda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ItemDaVenda",
                columns: table => new
                {
                    ItemDaVendaID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProdutoID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VendaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemDaVenda", x => x.ItemDaVendaID);
                    table.ForeignKey(
                        name: "FK_ItemDaVenda_Produto_ProdutoID",
                        column: x => x.ProdutoID,
                        principalTable: "Produto",
                        principalColumn: "ProdutoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemDaVenda_Venda_VendaId",
                        column: x => x.VendaId,
                        principalTable: "Venda",
                        principalColumn: "VendaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemDaVenda_ProdutoID",
                table: "ItemDaVenda",
                column: "ProdutoID");

            migrationBuilder.CreateIndex(
                name: "IX_ItemDaVenda_VendaId",
                table: "ItemDaVenda",
                column: "VendaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemDaVenda");
        }
    }
}
