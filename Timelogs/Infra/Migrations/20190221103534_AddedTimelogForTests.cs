using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class AddedTimelogForTests : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TImelogSummaryID",
                table: "TimelogSummary",
                newName: "TimelogSummaryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TimelogSummaryID",
                table: "TimelogSummary",
                newName: "TImelogSummaryID");
        }
    }
}
