using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVVM_WPF_Schedule.Migrations
{
    public partial class UpdateScheduleItemTableConfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddCheckConstraint(
                name: "CK_ScheduleItems_CHK_Check_Lesson_Number",
                table: "ScheduleItems",
                sql: "LessonNumber>0 AND LessonNumber<=8");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_ScheduleItems_CHK_Check_Lesson_Number",
                table: "ScheduleItems");
        }
    }
}
