using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MertProje.Migrations
{
    /// <inheritdoc />
    public partial class AdiGuncelleme44 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "İnstegram",
                table: "hakkımızdas",
                newName: "Personelİnstegram2");

            migrationBuilder.RenameColumn(
                name: "Linkledin",
                table: "hakkımızdas",
                newName: "Personelİnstegram1");

            migrationBuilder.RenameColumn(
                name: "Görev",
                table: "hakkımızdas",
                newName: "PersonelLinkledin2");

            migrationBuilder.RenameColumn(
                name: "Gmail",
                table: "hakkımızdas",
                newName: "PersonelLinkledin1");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "hakkımızdas",
                newName: "PersonelGörev2");

            migrationBuilder.RenameColumn(
                name: "Facebook",
                table: "hakkımızdas",
                newName: "PersonelGörev1");

            migrationBuilder.AddColumn<string>(
                name: "PersonelFacebook1",
                table: "hakkımızdas",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PersonelFacebook2",
                table: "hakkımızdas",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PersonelFullName1",
                table: "hakkımızdas",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PersonelFullName2",
                table: "hakkımızdas",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PersonelGmail1",
                table: "hakkımızdas",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PersonelGmail2",
                table: "hakkımızdas",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PersonelFacebook1",
                table: "hakkımızdas");

            migrationBuilder.DropColumn(
                name: "PersonelFacebook2",
                table: "hakkımızdas");

            migrationBuilder.DropColumn(
                name: "PersonelFullName1",
                table: "hakkımızdas");

            migrationBuilder.DropColumn(
                name: "PersonelFullName2",
                table: "hakkımızdas");

            migrationBuilder.DropColumn(
                name: "PersonelGmail1",
                table: "hakkımızdas");

            migrationBuilder.DropColumn(
                name: "PersonelGmail2",
                table: "hakkımızdas");

            migrationBuilder.RenameColumn(
                name: "Personelİnstegram2",
                table: "hakkımızdas",
                newName: "İnstegram");

            migrationBuilder.RenameColumn(
                name: "Personelİnstegram1",
                table: "hakkımızdas",
                newName: "Linkledin");

            migrationBuilder.RenameColumn(
                name: "PersonelLinkledin2",
                table: "hakkımızdas",
                newName: "Görev");

            migrationBuilder.RenameColumn(
                name: "PersonelLinkledin1",
                table: "hakkımızdas",
                newName: "Gmail");

            migrationBuilder.RenameColumn(
                name: "PersonelGörev2",
                table: "hakkımızdas",
                newName: "FullName");

            migrationBuilder.RenameColumn(
                name: "PersonelGörev1",
                table: "hakkımızdas",
                newName: "Facebook");
        }
    }
}
