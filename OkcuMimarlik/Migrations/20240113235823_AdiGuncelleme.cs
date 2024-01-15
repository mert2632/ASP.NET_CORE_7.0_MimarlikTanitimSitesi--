using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MertProje.Migrations
{
    /// <inheritdoc />
    public partial class AdiGuncelleme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AdSoyad",
                table: "iletisimBilgileris",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<string>(
                name: "Facebook",
                table: "hakkımızdas",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "hakkımızdas",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gmail",
                table: "hakkımızdas",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Linkledin",
                table: "hakkımızdas",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "İnstegram",
                table: "hakkımızdas",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Facebook",
                table: "hakkımızdas");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "hakkımızdas");

            migrationBuilder.DropColumn(
                name: "Gmail",
                table: "hakkımızdas");

            migrationBuilder.DropColumn(
                name: "Linkledin",
                table: "hakkımızdas");

            migrationBuilder.DropColumn(
                name: "İnstegram",
                table: "hakkımızdas");

            migrationBuilder.AlterColumn<string>(
                name: "AdSoyad",
                table: "iletisimBilgileris",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);
        }
    }
}
