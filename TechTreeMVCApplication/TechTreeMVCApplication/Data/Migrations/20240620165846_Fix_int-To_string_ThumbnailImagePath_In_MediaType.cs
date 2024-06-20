using Microsoft.EntityFrameworkCore.Migrations;

namespace TechTreeMVCApplication.Migrations
{
    public partial class Fix_intTo_string_ThumbnailImagePath_In_MediaType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ThumbnailImagePath",
                table: "MediaType",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ThumbnailImagePath",
                table: "MediaType",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
