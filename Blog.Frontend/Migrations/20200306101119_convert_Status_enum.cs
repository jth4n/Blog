using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Frontend.Migrations
{
    public partial class convert_Status_enum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Posts",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Posts",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
