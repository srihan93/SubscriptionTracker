using Microsoft.EntityFrameworkCore.Migrations;

namespace SubscriptionTracker.Migrations
{
    public partial class DataSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PaymentModes",
                columns: new[] { "PaymentModeId", "IsActive", "PaymentModeName" },
                values: new object[,]
                {
                    { 1, true, "GPay" },
                    { 2, true, "Cash" },
                    { 3, true, "PhonePe" }
                });

            migrationBuilder.InsertData(
                table: "Plans",
                columns: new[] { "PlanId", "Cost", "Name" },
                values: new object[,]
                {
                    { 1, 1200m, "Monthly" },
                    { 2, 1200m, "Quartely" },
                    { 3, 1200m, "Half-Yearly" },
                    { 4, 1200m, "Annualy" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PaymentModes",
                keyColumn: "PaymentModeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PaymentModes",
                keyColumn: "PaymentModeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PaymentModes",
                keyColumn: "PaymentModeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Plans",
                keyColumn: "PlanId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Plans",
                keyColumn: "PlanId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Plans",
                keyColumn: "PlanId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Plans",
                keyColumn: "PlanId",
                keyValue: 4);
        }
    }
}
