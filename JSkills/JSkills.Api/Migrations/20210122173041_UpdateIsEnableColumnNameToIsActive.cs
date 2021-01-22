using Microsoft.EntityFrameworkCore.Migrations;

namespace JSkills.Api.Migrations
{
    public partial class UpdateIsEnableColumnNameToIsActive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isEnable",
                table: "Skills",
                newName: "IsActive");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Skills",
                newName: "isEnable");
        }
    }
}
