using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agrisys.Migrations.HomeDb
{
    /// <inheritdoc />
    public partial class InitialHomeDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HomeViewModels",
                columns: table => new
                {
                    HomeViewModelId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LogMessages = table.Column<string>(type: "TEXT", nullable: true),
                    SiloAmount = table.Column<double>(type: "REAL", nullable: true),
                    SiloState = table.Column<int>(type: "INTEGER", nullable: true),
                    MixerAmount = table.Column<double>(type: "REAL", nullable: true),
                    MixerState = table.Column<int>(type: "INTEGER", nullable: true),
                    HatchOneState = table.Column<int>(type: "INTEGER", nullable: true),
                    DistributorAmount = table.Column<double>(type: "REAL", nullable: true),
                    DistributorState = table.Column<int>(type: "INTEGER", nullable: true),
                    HatchTwoState = table.Column<int>(type: "INTEGER", nullable: true),
                    FanAmount = table.Column<double>(type: "REAL", nullable: true),
                    FanState = table.Column<int>(type: "INTEGER", nullable: true),
                    Pressure = table.Column<double>(type: "REAL", nullable: true),
                    TargetId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeViewModels", x => x.HomeViewModelId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HomeViewModels");
        }
    }
}
