using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace test.Migrations
{
    /// <inheritdoc />
    public partial class FilmSchemaSetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SallesCinema");

            migrationBuilder.DropColumn(
                name: "DatePublication",
                table: "Films");

            migrationBuilder.DropColumn(
                name: "Genre",
                table: "Films");

            migrationBuilder.DropColumn(
                name: "Resume",
                table: "Films");

            migrationBuilder.RenameColumn(
                name: "Titre",
                table: "Films",
                newName: "Image");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Films",
                newName: "FilmId");

            migrationBuilder.AddColumn<int>(
                name: "CinemaId",
                table: "Films",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Films",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "Price",
                table: "Films",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "QteStock",
                table: "Films",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Cinemas",
                columns: table => new
                {
                    CinemaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CinemaName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cinemas", x => x.CinemaId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Films_CinemaId",
                table: "Films",
                column: "CinemaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Films_Cinemas_CinemaId",
                table: "Films",
                column: "CinemaId",
                principalTable: "Cinemas",
                principalColumn: "CinemaId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Films_Cinemas_CinemaId",
                table: "Films");

            migrationBuilder.DropTable(
                name: "Cinemas");

            migrationBuilder.DropIndex(
                name: "IX_Films_CinemaId",
                table: "Films");

            migrationBuilder.DropColumn(
                name: "CinemaId",
                table: "Films");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Films");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Films");

            migrationBuilder.DropColumn(
                name: "QteStock",
                table: "Films");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Films",
                newName: "Titre");

            migrationBuilder.RenameColumn(
                name: "FilmId",
                table: "Films",
                newName: "Id");

            migrationBuilder.AddColumn<DateTime>(
                name: "DatePublication",
                table: "Films",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Genre",
                table: "Films",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Resume",
                table: "Films",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "SallesCinema",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adresse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SallesCinema", x => x.Id);
                });
        }
    }
}
