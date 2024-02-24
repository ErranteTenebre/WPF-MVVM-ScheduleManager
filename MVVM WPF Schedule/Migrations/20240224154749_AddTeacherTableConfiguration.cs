using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVVM_WPF_Schedule.Migrations
{
    public partial class AddTeacherTableConfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Teachers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FIO",
                table: "Teachers",
                type: "nvarchar(70)",
                maxLength: 70,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Workload",
                value: 36);

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 2,
                column: "Workload",
                value: 36);

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 3,
                column: "Workload",
                value: 36);

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 4,
                column: "Workload",
                value: 36);

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 5,
                column: "Workload",
                value: 36);

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 6,
                column: "Workload",
                value: 36);

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 7,
                column: "Workload",
                value: 30);

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 8,
                column: "Workload",
                value: 32);

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 9,
                column: "Workload",
                value: 36);

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 10,
                column: "Workload",
                value: 34);

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 11,
                column: "Workload",
                value: 36);

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_FIO",
                table: "Teachers",
                column: "FIO",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_Phone",
                table: "Teachers",
                column: "Phone",
                unique: true);

            migrationBuilder.AddCheckConstraint(
                name: "CK_Teachers_Workload_CHK",
                table: "Teachers",
                sql: "Workload > 0 AND Workload <=36");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Teachers_FIO",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_Phone",
                table: "Teachers");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Teachers_Workload_CHK",
                table: "Teachers");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Teachers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "FIO",
                table: "Teachers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(70)",
                oldMaxLength: 70);

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Workload",
                value: 432);

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 2,
                column: "Workload",
                value: 450);

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 3,
                column: "Workload",
                value: 420);

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 4,
                column: "Workload",
                value: 420);

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 5,
                column: "Workload",
                value: 370);

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 6,
                column: "Workload",
                value: 422);

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 7,
                column: "Workload",
                value: 360);

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 8,
                column: "Workload",
                value: 400);

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 9,
                column: "Workload",
                value: 360);

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 10,
                column: "Workload",
                value: 380);

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 11,
                column: "Workload",
                value: 340);
        }
    }
}
