using Microsoft.EntityFrameworkCore.Migrations;

namespace Theory.Migrations
{
    public partial class Marks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Ans",
                table: "Answer",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Ans",
                table: "Answer",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
