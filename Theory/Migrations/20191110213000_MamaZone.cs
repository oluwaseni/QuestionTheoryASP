using Microsoft.EntityFrameworkCore.Migrations;

namespace Theory.Migrations
{
    public partial class MamaZone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "Ans",
                table: "Answer",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Ans",
                table: "Answer",
                nullable: false,
                oldClrType: typeof(long));
        }
    }
}
