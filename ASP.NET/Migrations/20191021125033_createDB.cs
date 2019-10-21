using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ASP.NET.Migrations
{
    public partial class createDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "country",
                columns: table => new
                {
                    code = table.Column<string>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    continent = table.Column<string>(nullable: true),
                    region = table.Column<string>(nullable: true),
                    surfacearea = table.Column<long>(nullable: false),
                    indepyear = table.Column<int>(nullable: false),
                    population = table.Column<long>(nullable: false),
                    lifeexpectancy = table.Column<double>(nullable: false),
                    gnp = table.Column<long>(nullable: false),
                    gnpold = table.Column<long>(nullable: false),
                    localname = table.Column<string>(nullable: true),
                    governmentform = table.Column<string>(nullable: true),
                    headofstate = table.Column<string>(nullable: true),
                    capital = table.Column<long>(nullable: false),
                    code2 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_country", x => x.code);
                });

            migrationBuilder.CreateTable(
                name: "city",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    countrycode = table.Column<string>(nullable: true),
                    district = table.Column<string>(nullable: true),
                    population = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_city", x => x.id);
                    table.ForeignKey(
                        name: "FK_city_country_countrycode",
                        column: x => x.countrycode,
                        principalTable: "country",
                        principalColumn: "code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_city_countrycode",
                table: "city",
                column: "countrycode",
                unique: true,
                filter: "[countrycode] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "city");

            migrationBuilder.DropTable(
                name: "country");
        }
    }
}
