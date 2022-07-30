using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistence.Migrations
{
    public partial class CreateApplicationMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Voucher",
                table: "Voucher");

            migrationBuilder.RenameTable(
                name: "Voucher",
                newName: "Vouchers");

            migrationBuilder.AddColumn<string>(
                name: "UserGuid",
                table: "Vouchers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vouchers",
                table: "Vouchers",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Applications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applications", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Applications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vouchers",
                table: "Vouchers");

            migrationBuilder.DropColumn(
                name: "UserGuid",
                table: "Vouchers");

            migrationBuilder.RenameTable(
                name: "Vouchers",
                newName: "Voucher");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Voucher",
                table: "Voucher",
                column: "Id");
        }
    }
}
