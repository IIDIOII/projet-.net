using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace examintp.Migrations
{
    /// <inheritdoc />
    public partial class AddImageToVoiture : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Voitures",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Voitures");
        }
    }
}
