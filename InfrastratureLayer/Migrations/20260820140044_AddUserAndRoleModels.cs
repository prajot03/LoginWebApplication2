using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfrastratureLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddUserAndRoleModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Roles");

            migrationBuilder.AddColumn<string>(
                name: "RoleType",
                table: "Roles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoleType",
                table: "Roles");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Roles",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
