using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrackingApp.Migrations
{
    /// <inheritdoc />
    public partial class track : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    lastname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    firstname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    middlename = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    suffixname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    yeargraduated = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    mobilenumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    studentnumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    graduate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    program = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    employment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    trackingnumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    housenumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    zipcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    currentemployer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    yearsstay = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    position = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    joblevel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    recordRequested = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    others = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
