using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FailureAnalysis.Core.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddFailureModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Failures",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssignTo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FailureArea = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SprintName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FailureIdString = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FailureDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ErrorMessage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    Severity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Failures", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Failures");
        }
    }
}
