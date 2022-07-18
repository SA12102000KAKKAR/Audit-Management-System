using Microsoft.EntityFrameworkCore.Migrations;

namespace AuditManagmentPortal.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "storeAuditResponses",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectManagerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationOwnerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuditType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuditDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuditId = table.Column<int>(type: "int", nullable: false),
                    ProjectExecutionStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RemedialActionDuration = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_storeAuditResponses", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "storeAuditResponses");
        }
    }
}
