using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CastlesToWatch.API.Migrations.CastlesAuthDb
{
    /// <inheritdoc />
    public partial class changedauth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "adb3883f-439f-4129-baac-ec334de9cc0c");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "adb3883f-439f-4129-baac-ec334de9cc0c", "adb3883f-439f-4129-baac-ec334de9cc0c", "User", "USER" });
        }
    }
}
