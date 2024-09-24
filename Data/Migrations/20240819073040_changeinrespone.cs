using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class changeinrespone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_userDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FailedAttempt = table.Column<int>(type: "int", nullable: true),
                    LoginTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LockoutEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: true),
                    LoggedIn = table.Column<byte>(type: "tinyint", nullable: true),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Validate = table.Column<bool>(type: "bit", nullable: true),
                    IpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrowserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrowserVersion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HeartBeat = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_userDetails", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_userDetails");
        }
    }
}
