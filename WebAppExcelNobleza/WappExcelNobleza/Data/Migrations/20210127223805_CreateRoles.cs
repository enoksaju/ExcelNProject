using Microsoft.EntityFrameworkCore.Migrations;

namespace WappExcelNobleza.Data.Migrations
{
    public partial class CreateRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7bda7324-b6ba-41f7-b78b-305feabb5e1f",
                column: "ConcurrencyStamp",
                value: "e8c7c40b-ed75-4adf-bb4f-09015750ea26");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c95a97cc-99f5-458f-b714-aecc3389f830",
                column: "ConcurrencyStamp",
                value: "0edf8fcf-fb8c-4dad-ad87-d9c60e961007");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6ba880d-864f-4d16-9ee2-225f7af5788f",
                column: "ConcurrencyStamp",
                value: "7fe181c7-2591-4d70-97b5-52d37a40b029");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "e96df311-2a07-4757-beff-1878c9823093", "d6c0cc7d-7e21-4965-b527-8712b757e2c3", "Generic", null },
                    { "5aed0bf0-0e3e-423f-bd6f-cd2083f041ba", "a1e6a683-c609-4c66-aa7f-fd64a2b43c10", "User", null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5aed0bf0-0e3e-423f-bd6f-cd2083f041ba");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e96df311-2a07-4757-beff-1878c9823093");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7bda7324-b6ba-41f7-b78b-305feabb5e1f",
                column: "ConcurrencyStamp",
                value: "3efd2ad4-9145-41a5-8dc4-0c75f1061bf2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c95a97cc-99f5-458f-b714-aecc3389f830",
                column: "ConcurrencyStamp",
                value: "d09f31f3-e269-4870-ae02-6f2c07dd5a06");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6ba880d-864f-4d16-9ee2-225f7af5788f",
                column: "ConcurrencyStamp",
                value: "adad70b5-38bb-4d6d-845d-39b597c3b916");
        }
    }
}
