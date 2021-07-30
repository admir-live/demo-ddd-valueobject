using Microsoft.EntityFrameworkCore.Migrations;

namespace Demo.DDD.ValueObject.Data.Migrations
{
    public partial class BudApiMetadataValueObject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BudApiMetadata",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BudApiMetadata",
                table: "Users");
        }
    }
}
