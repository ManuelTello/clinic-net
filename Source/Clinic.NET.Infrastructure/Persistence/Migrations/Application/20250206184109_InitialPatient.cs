using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinic.NET.Infrastructure.Persistence.Migrations.Application
{
    /// <inheritdoc />
    public partial class InitialPatient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    full_name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    date_of_birth = table.Column<DateTime>(type: "date", nullable: false),
                    phone_number = table.Column<int>(type: "int", nullable: false),
                    email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    identification = table.Column<int>(type: "int", nullable: false),
                    insurance_type = table.Column<string>(type: "nvarchar", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}
