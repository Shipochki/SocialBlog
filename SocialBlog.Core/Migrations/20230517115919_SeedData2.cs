using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialBlog.Core.Migrations
{
    public partial class SeedData2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d197bc19-680e-4d67-ad99-3c98c0eae144", "AQAAAAEAACcQAAAAEFRQdD+s93Miyl4duVr1IMMSkL8kaIr/06QiT2m96cIYYHVOIfOm3+aZ041D9Z51AA==", "878a4975-03a7-4d17-b78c-1bc6f3b44ec8" });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Description", "Updated" },
                values: new object[] { new DateTime(2023, 5, 17, 14, 59, 18, 817, DateTimeKind.Local).AddTicks(9878), "Explore the advancements and impact of renewable energy sources such as solar, wind, hydro", new DateTime(2023, 5, 17, 14, 59, 18, 817, DateTimeKind.Local).AddTicks(9919) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2023, 5, 17, 14, 59, 18, 817, DateTimeKind.Local).AddTicks(9922), new DateTime(2023, 5, 17, 14, 59, 18, 817, DateTimeKind.Local).AddTicks(9923) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2023, 5, 17, 14, 59, 18, 817, DateTimeKind.Local).AddTicks(9926), new DateTime(2023, 5, 17, 14, 59, 18, 817, DateTimeKind.Local).AddTicks(9928) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aa58a865-6789-4bb1-aa26-77ab8aea2ba4", "AQAAAAEAACcQAAAAEJeAx/EtqV70+7DU5IcblLOl4fWMQn8nXCJPmGzJe7d5ND4vC5VLevsbmn1VOPCa0g==", "6a13dcd2-9971-4a2f-a459-aa2ce2c6532e" });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Description", "Updated" },
                values: new object[] { new DateTime(2023, 5, 17, 14, 49, 40, 39, DateTimeKind.Local).AddTicks(8219), "Explore the advancements and impact of renewable energy sources such as solar, wind, hydro, and geothermal power.", new DateTime(2023, 5, 17, 14, 49, 40, 39, DateTimeKind.Local).AddTicks(8256) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2023, 5, 17, 14, 49, 40, 39, DateTimeKind.Local).AddTicks(8259), new DateTime(2023, 5, 17, 14, 49, 40, 39, DateTimeKind.Local).AddTicks(8261) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2023, 5, 17, 14, 49, 40, 39, DateTimeKind.Local).AddTicks(8264), new DateTime(2023, 5, 17, 14, 49, 40, 39, DateTimeKind.Local).AddTicks(8265) });
        }
    }
}
