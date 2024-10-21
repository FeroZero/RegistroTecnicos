using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistroTecnicos.Migrations
{
    /// <inheritdoc />
    public partial class Next : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ArticulosArticuloId",
                table: "TrabajosDetalle",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrabajosDetalle_ArticulosArticuloId",
                table: "TrabajosDetalle",
                column: "ArticulosArticuloId");

            migrationBuilder.AddForeignKey(
                name: "FK_TrabajosDetalle_Articulos_ArticulosArticuloId",
                table: "TrabajosDetalle",
                column: "ArticulosArticuloId",
                principalTable: "Articulos",
                principalColumn: "ArticuloId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrabajosDetalle_Articulos_ArticulosArticuloId",
                table: "TrabajosDetalle");

            migrationBuilder.DropIndex(
                name: "IX_TrabajosDetalle_ArticulosArticuloId",
                table: "TrabajosDetalle");

            migrationBuilder.DropColumn(
                name: "ArticulosArticuloId",
                table: "TrabajosDetalle");
        }
    }
}
