using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MertProje.Migrations
{
    /// <inheritdoc />
    public partial class AdiGuncelleme11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Görev",
                table: "hakkımızdas",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Görev",
                table: "hakkımızdas");
        }
    }
}
