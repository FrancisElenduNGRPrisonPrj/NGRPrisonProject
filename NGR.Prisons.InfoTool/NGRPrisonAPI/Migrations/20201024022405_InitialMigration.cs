using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NGRPrisonAPI.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "State",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Prisons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrisonName = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    EstablishedDate = table.Column<DateTime>(nullable: false),
                    StateId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prisons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prisons_State_StateId",
                        column: x => x.StateId,
                        principalTable: "State",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Inmates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    SentencedDate = table.Column<DateTime>(nullable: false),
                    RelasedDate = table.Column<DateTime>(nullable: false),
                    Gender = table.Column<string>(nullable: true),
                    Offenses = table.Column<string>(nullable: true),
                    StateId = table.Column<int>(nullable: false),
                    PrisonId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inmates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inmates_Prisons_PrisonId",
                        column: x => x.PrisonId,
                        principalTable: "Prisons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inmates_State_StateId",
                        column: x => x.StateId,
                        principalTable: "State",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "State",
                columns: new[] { "Id", "StateName" },
                values: new object[] { 1, "Abia" });

            migrationBuilder.InsertData(
                table: "State",
                columns: new[] { "Id", "StateName" },
                values: new object[] { 2, "Imo" });

            migrationBuilder.InsertData(
                table: "Prisons",
                columns: new[] { "Id", "DateCreated", "EstablishedDate", "PrisonName", "StateId" },
                values: new object[] { 1, new DateTime(2020, 10, 24, 2, 24, 5, 7, DateTimeKind.Utc).AddTicks(3719), new DateTime(1990, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Abia Maximum", 1 });

            migrationBuilder.InsertData(
                table: "Prisons",
                columns: new[] { "Id", "DateCreated", "EstablishedDate", "PrisonName", "StateId" },
                values: new object[] { 2, new DateTime(2020, 10, 24, 2, 24, 5, 7, DateTimeKind.Utc).AddTicks(4603), new DateTime(1980, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Abia Manimum", 1 });

            migrationBuilder.InsertData(
                table: "Prisons",
                columns: new[] { "Id", "DateCreated", "EstablishedDate", "PrisonName", "StateId" },
                values: new object[] { 3, new DateTime(2020, 10, 24, 2, 24, 5, 7, DateTimeKind.Utc).AddTicks(4621), new DateTime(1980, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Imo Maximum", 2 });

            migrationBuilder.InsertData(
                table: "Inmates",
                columns: new[] { "Id", "DateCreated", "DateOfBirth", "FirstName", "Gender", "LastName", "Offenses", "PrisonId", "RelasedDate", "SentencedDate", "StateId" },
                values: new object[] { 1, new DateTime(2020, 10, 24, 2, 24, 5, 7, DateTimeKind.Utc).AddTicks(4815), new DateTime(1965, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jane", "Female", "Doe", "Aggravated sex and armed robbery", 1, new DateTime(2010, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1995, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.InsertData(
                table: "Inmates",
                columns: new[] { "Id", "DateCreated", "DateOfBirth", "FirstName", "Gender", "LastName", "Offenses", "PrisonId", "RelasedDate", "SentencedDate", "StateId" },
                values: new object[] { 2, new DateTime(2020, 10, 24, 2, 24, 5, 7, DateTimeKind.Utc).AddTicks(5876), new DateTime(1960, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Joe", "Male", "Doe", "Serial Rapist", 3, new DateTime(2020, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1990, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Inmates_PrisonId",
                table: "Inmates",
                column: "PrisonId");

            migrationBuilder.CreateIndex(
                name: "IX_Inmates_StateId",
                table: "Inmates",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Prisons_StateId",
                table: "Prisons",
                column: "StateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inmates");

            migrationBuilder.DropTable(
                name: "Prisons");

            migrationBuilder.DropTable(
                name: "State");
        }
    }
}
