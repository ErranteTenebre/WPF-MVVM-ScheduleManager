using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVVM_WPF_Schedule.Migrations
{
    public partial class UpdateGroupDisciplineTableConfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupsDisciplines_Teachers_TeacherId",
                table: "GroupsDisciplines");

            migrationBuilder.AlterColumn<int>(
                name: "TeacherId",
                table: "GroupsDisciplines",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddCheckConstraint(
                name: "CK_GroupsDisciplines_CHK_Hours_Count_Per_Week",
                table: "GroupsDisciplines",
                sql: "HoursCountPerWeek>0");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupsDisciplines_Teachers_TeacherId",
                table: "GroupsDisciplines",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupsDisciplines_Teachers_TeacherId",
                table: "GroupsDisciplines");

            migrationBuilder.DropCheckConstraint(
                name: "CK_GroupsDisciplines_CHK_Hours_Count_Per_Week",
                table: "GroupsDisciplines");

            migrationBuilder.AlterColumn<int>(
                name: "TeacherId",
                table: "GroupsDisciplines",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupsDisciplines_Teachers_TeacherId",
                table: "GroupsDisciplines",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id");
        }
    }
}
