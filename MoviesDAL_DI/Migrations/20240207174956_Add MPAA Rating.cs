using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoviesDAL_DI.Migrations
{
    public partial class AddMPAARating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MPAARating",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MPAARating",
                table: "Movies");
        }
    }
}
