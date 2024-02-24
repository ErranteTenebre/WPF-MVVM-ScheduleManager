using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVVM_WPF_Schedule.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DaysOfWeek",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DaysOfWeek", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Disciplines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Specialties",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Acronym = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialties", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FIO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Workload = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FIO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AvatarPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Number = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsBudget = table.Column<bool>(type: "bit", nullable: false),
                    AdmissionYear = table.Column<int>(type: "int", nullable: false),
                    SpecialtyCode = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Number);
                    table.ForeignKey(
                        name: "FK_Groups_Specialties_SpecialtyCode",
                        column: x => x.SpecialtyCode,
                        principalTable: "Specialties",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpecialtiesDisciplines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpecialtyCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DisciplineId = table.Column<int>(type: "int", nullable: false),
                    HoursCountPerWeek = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialtiesDisciplines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpecialtiesDisciplines_Disciplines_DisciplineId",
                        column: x => x.DisciplineId,
                        principalTable: "Disciplines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpecialtiesDisciplines_Specialties_SpecialtyCode",
                        column: x => x.SpecialtyCode,
                        principalTable: "Specialties",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupsDisciplines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DisciplineId = table.Column<int>(type: "int", nullable: false),
                    TeacherId = table.Column<int>(type: "int", nullable: true),
                    HoursCountPerWeek = table.Column<int>(type: "int", nullable: false),
                    GroupNumber1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupsDisciplines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupsDisciplines_Disciplines_DisciplineId",
                        column: x => x.DisciplineId,
                        principalTable: "Disciplines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupsDisciplines_Groups_GroupNumber",
                        column: x => x.GroupNumber,
                        principalTable: "Groups",
                        principalColumn: "Number",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupsDisciplines_Groups_GroupNumber1",
                        column: x => x.GroupNumber1,
                        principalTable: "Groups",
                        principalColumn: "Number");
                    table.ForeignKey(
                        name: "FK_GroupsDisciplines_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ScheduleItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupDisciplineId = table.Column<int>(type: "int", nullable: false),
                    LessonNumber = table.Column<int>(type: "int", nullable: false),
                    DayOfWeekId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScheduleItems_DaysOfWeek_DayOfWeekId",
                        column: x => x.DayOfWeekId,
                        principalTable: "DaysOfWeek",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScheduleItems_GroupsDisciplines_GroupDisciplineId",
                        column: x => x.GroupDisciplineId,
                        principalTable: "GroupsDisciplines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DaysOfWeek",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Понедельник" },
                    { 2, "Вторник" },
                    { 3, "Среда" },
                    { 4, "Четверг" },
                    { 5, "Пятница" },
                    { 6, "Суббота" }
                });

            migrationBuilder.InsertData(
                table: "Disciplines",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Информационные технологии и платформы разработки информационных систем (ч.1)" },
                    { 2, "Физическая культура" },
                    { 3, "Иностранный язык" },
                    { 4, "Информационные системы в организации авиационного производства" },
                    { 5, "Инновационное предпринимательство" },
                    { 6, "Безопасность функционирования информационных систем" },
                    { 7, "Организация администрирования компьютерных систем" },
                    { 8, "Эксплуатация объектов сетевой инфраструктуры (ч.1)" },
                    { 9, "Эксплуатация объектов сетевой инфраструктуры (ч.2)" },
                    { 10, "Информационные технологии и платформы разработки информационных систем (ч.2)" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Секретарь" },
                    { 2, "Диспетчер" }
                });

            migrationBuilder.InsertData(
                table: "Specialties",
                columns: new[] { "Code", "Acronym", "Name" },
                values: new object[,]
                {
                    { "09.02.02", "КС", "Компьютерные сети" },
                    { "09.02.04", "И", "Информационные системы" }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "FIO", "Phone", "Workload" },
                values: new object[,]
                {
                    { 1, "Андреева Татьяна Эдуардовна", "+7(923)456-78-90", 432 },
                    { 2, "Трифонова Элина Марсовна", "+7(998)765-43-21", 450 },
                    { 3, "Нургалиева Альбина Шамсулловна", "+7(955)555-55-55", 420 },
                    { 4, "Рязанов Евгений Владимирович", "+7(966)666-66-66", 420 },
                    { 5, "Цыбина Евгений Александровна", "+7(977)777-77-77", 370 },
                    { 6, "Латыпова Лилия Азгамовна", "+7(955)222-31-81", 422 },
                    { 7, "Айметдинова Ульяна Александровна", "+7(914)351-44-51", 360 },
                    { 8, "Сайтуколова Ольга Ремовна", "+7(971)581-24-35", 400 },
                    { 9, "Челяева Ирина Валерьевна", "+7(911)84-88-55", 360 },
                    { 10, "Мавлекеева Лилия Эльдаровна", "+7(982)84-73-12", 380 },
                    { 11, "Cафиуллина Лейсан Маратовна", "+7(951)55-26-71", 340 }
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Number", "AdmissionYear", "IsBudget", "SpecialtyCode" },
                values: new object[,]
                {
                    { "20И1", 2020, true, "09.02.04" },
                    { "20И2", 2020, false, "09.02.04" },
                    { "20КС1", 2020, true, "09.02.02" },
                    { "20КС2", 2020, false, "09.02.02" }
                });

            migrationBuilder.InsertData(
                table: "SpecialtiesDisciplines",
                columns: new[] { "Id", "DisciplineId", "HoursCountPerWeek", "SpecialtyCode" },
                values: new object[,]
                {
                    { 1, 1, 400, "09.02.04" },
                    { 2, 2, 400, "09.02.04" },
                    { 3, 3, 400, "09.02.04" },
                    { 4, 4, 400, "09.02.04" },
                    { 5, 5, 400, "09.02.02" },
                    { 6, 6, 400, "09.02.02" },
                    { 7, 7, 400, "09.02.02" },
                    { 8, 8, 400, "09.02.02" },
                    { 9, 2, 400, "09.02.02" },
                    { 10, 3, 400, "09.02.02" },
                    { 11, 10, 400, "09.02.04" },
                    { 12, 9, 400, "09.02.02" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AvatarPath", "Email", "FIO", "Login", "Password", "Phone", "PostId" },
                values: new object[,]
                {
                    { 1, "чебупеля.jpg", "ivanov@example.com", "Иванов Иван Иванович", "ivanov", "password123", "+79123456789", 1 },
                    { 2, "чебупеля.jpg", "petrov@example.com", "Петров Петр Петрович", "petrov", "password456", "+79234567890", 2 }
                });

            migrationBuilder.InsertData(
                table: "GroupsDisciplines",
                columns: new[] { "Id", "DisciplineId", "GroupNumber", "GroupNumber1", "HoursCountPerWeek", "TeacherId" },
                values: new object[,]
                {
                    { 1, 1, "20И1", null, 400, 2 },
                    { 2, 2, "20И1", null, 400, 4 },
                    { 3, 3, "20И1", null, 400, 1 },
                    { 4, 4, "20И1", null, 400, 3 },
                    { 5, 1, "20И2", null, 400, 3 },
                    { 6, 2, "20И2", null, 400, 4 },
                    { 7, 3, "20И2", null, 400, 1 },
                    { 8, 4, "20И2", null, 400, 3 },
                    { 9, 6, "20КС1", null, 400, 6 },
                    { 10, 8, "20КС1", null, 400, 10 },
                    { 11, 3, "20КС1", null, 400, 1 },
                    { 12, 2, "20КС1", null, 400, 4 },
                    { 13, 6, "20КС2", null, 400, 6 },
                    { 14, 8, "20КС2", null, 400, 10 },
                    { 15, 3, "20КС2", null, 400, 1 },
                    { 16, 2, "20КС2", null, 400, 4 },
                    { 17, 10, "20И1", null, 400, 11 },
                    { 18, 10, "20И2", null, 400, 11 },
                    { 19, 9, "20КС1", null, 400, 8 },
                    { 20, 9, "20КС2", null, 400, 8 }
                });

            migrationBuilder.InsertData(
                table: "ScheduleItems",
                columns: new[] { "Id", "DayOfWeekId", "GroupDisciplineId", "LessonNumber" },
                values: new object[,]
                {
                    { 1, 1, 8, 4 },
                    { 2, 1, 6, 5 },
                    { 3, 2, 18, 2 },
                    { 4, 2, 18, 3 },
                    { 5, 2, 8, 4 },
                    { 6, 3, 8, 1 },
                    { 7, 3, 5, 2 },
                    { 8, 3, 18, 3 },
                    { 10, 4, 5, 4 },
                    { 11, 4, 18, 5 },
                    { 12, 4, 6, 6 },
                    { 13, 6, 5, 1 },
                    { 14, 6, 18, 2 },
                    { 15, 6, 18, 3 },
                    { 16, 6, 18, 4 },
                    { 19, 1, 9, 3 },
                    { 20, 1, 9, 4 },
                    { 21, 1, 9, 5 },
                    { 23, 3, 10, 4 },
                    { 24, 3, 19, 5 },
                    { 25, 3, 11, 6 },
                    { 26, 4, 12, 3 },
                    { 27, 4, 11, 4 },
                    { 28, 4, 9, 5 },
                    { 29, 4, 9, 6 },
                    { 30, 5, 9, 2 },
                    { 31, 5, 9, 3 },
                    { 32, 5, 9, 4 },
                    { 33, 5, 9, 5 },
                    { 34, 6, 19, 1 },
                    { 35, 6, 19, 2 },
                    { 36, 6, 10, 3 },
                    { 37, 6, 10, 4 },
                    { 40, 2, 13, 3 },
                    { 41, 2, 13, 4 },
                    { 42, 2, 13, 5 },
                    { 43, 3, 20, 1 },
                    { 44, 3, 20, 2 },
                    { 45, 3, 16, 3 },
                    { 47, 4, 15, 2 },
                    { 48, 4, 13, 3 },
                    { 49, 4, 13, 4 }
                });

            migrationBuilder.InsertData(
                table: "ScheduleItems",
                columns: new[] { "Id", "DayOfWeekId", "GroupDisciplineId", "LessonNumber" },
                values: new object[,]
                {
                    { 50, 4, 15, 5 },
                    { 52, 5, 20, 2 },
                    { 53, 5, 20, 3 },
                    { 54, 5, 14, 4 },
                    { 55, 5, 14, 5 },
                    { 56, 6, 14, 1 },
                    { 57, 6, 14, 2 },
                    { 58, 6, 20, 3 },
                    { 59, 6, 20, 4 },
                    { 60, 5, 5, 3 },
                    { 61, 5, 5, 4 },
                    { 62, 5, 5, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Groups_SpecialtyCode",
                table: "Groups",
                column: "SpecialtyCode");

            migrationBuilder.CreateIndex(
                name: "IX_GroupsDisciplines_DisciplineId",
                table: "GroupsDisciplines",
                column: "DisciplineId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupsDisciplines_GroupNumber",
                table: "GroupsDisciplines",
                column: "GroupNumber");

            migrationBuilder.CreateIndex(
                name: "IX_GroupsDisciplines_GroupNumber1",
                table: "GroupsDisciplines",
                column: "GroupNumber1");

            migrationBuilder.CreateIndex(
                name: "IX_GroupsDisciplines_TeacherId",
                table: "GroupsDisciplines",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleItems_DayOfWeekId",
                table: "ScheduleItems",
                column: "DayOfWeekId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleItems_GroupDisciplineId",
                table: "ScheduleItems",
                column: "GroupDisciplineId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialtiesDisciplines_DisciplineId",
                table: "SpecialtiesDisciplines",
                column: "DisciplineId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialtiesDisciplines_SpecialtyCode",
                table: "SpecialtiesDisciplines",
                column: "SpecialtyCode");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PostId",
                table: "Users",
                column: "PostId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScheduleItems");

            migrationBuilder.DropTable(
                name: "SpecialtiesDisciplines");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "DaysOfWeek");

            migrationBuilder.DropTable(
                name: "GroupsDisciplines");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Disciplines");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "Specialties");
        }
    }
}
