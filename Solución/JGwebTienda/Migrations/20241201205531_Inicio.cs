using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JGwebTienda.Migrations
{
    /// <inheritdoc />
    public partial class Inicio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JGadornos",
                columns: table => new
                {
                    JGadornosId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JGName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JGnavideno = table.Column<bool>(type: "bit", nullable: false),
                    JGprice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JGadornos", x => x.JGadornosId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JGadornos");
        }
    }
}
