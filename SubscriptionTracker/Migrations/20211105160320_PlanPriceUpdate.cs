using Microsoft.EntityFrameworkCore.Migrations;

namespace SubscriptionTracker.Migrations
{
    public partial class PlanPriceUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Plans",
                keyColumn: "PlanId",
                keyValue: 2,
                column: "Cost",
                value: 2800m);

            migrationBuilder.UpdateData(
                table: "Plans",
                keyColumn: "PlanId",
                keyValue: 3,
                column: "Cost",
                value: 4000m);

            migrationBuilder.UpdateData(
                table: "Plans",
                keyColumn: "PlanId",
                keyValue: 4,
                column: "Cost",
                value: 6500m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Plans",
                keyColumn: "PlanId",
                keyValue: 2,
                column: "Cost",
                value: 1200m);

            migrationBuilder.UpdateData(
                table: "Plans",
                keyColumn: "PlanId",
                keyValue: 3,
                column: "Cost",
                value: 1200m);

            migrationBuilder.UpdateData(
                table: "Plans",
                keyColumn: "PlanId",
                keyValue: 4,
                column: "Cost",
                value: 1200m);
        }
    }
}
