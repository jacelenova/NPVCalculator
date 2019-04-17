using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NPVCalculator.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NPVQueries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InitialInvestment = table.Column<decimal>(nullable: false),
                    LowerBoundRate = table.Column<decimal>(nullable: false),
                    UpperBoundRate = table.Column<decimal>(nullable: false),
                    RateIncrement = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NPVQueries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CashFlow",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NPVQueryId = table.Column<int>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashFlow", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CashFlow_NPVQueries_NPVQueryId",
                        column: x => x.NPVQueryId,
                        principalTable: "NPVQueries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QueryResults",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NPVQueryId = table.Column<int>(nullable: false),
                    DiscountRate = table.Column<decimal>(nullable: false),
                    Result = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QueryResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QueryResults_NPVQueries_NPVQueryId",
                        column: x => x.NPVQueryId,
                        principalTable: "NPVQueries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CashFlow_NPVQueryId",
                table: "CashFlow",
                column: "NPVQueryId");

            migrationBuilder.CreateIndex(
                name: "IX_QueryResults_NPVQueryId",
                table: "QueryResults",
                column: "NPVQueryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CashFlow");

            migrationBuilder.DropTable(
                name: "QueryResults");

            migrationBuilder.DropTable(
                name: "NPVQueries");
        }
    }
}
