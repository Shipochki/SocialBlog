using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialBlog.Core.Migrations
{
    public partial class AddProfilImgLinkUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProfileImgLink",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8ee1320a-4a49-4179-9b84-16b7f0940359", "AQAAAAEAACcQAAAAELWga0xh1KvOOAkJmboE2OyjGGznTtbpcVq085vOPVtpHrbgDh0mQryx7JjfNlFX3g==", "12b8da94-fd34-4590-83bf-ad20343eb988" });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2023, 5, 18, 11, 35, 11, 340, DateTimeKind.Local).AddTicks(7855), new DateTime(2023, 5, 18, 11, 35, 11, 340, DateTimeKind.Local).AddTicks(7887) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2023, 5, 18, 11, 35, 11, 340, DateTimeKind.Local).AddTicks(7890), new DateTime(2023, 5, 18, 11, 35, 11, 340, DateTimeKind.Local).AddTicks(7892) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2023, 5, 18, 11, 35, 11, 340, DateTimeKind.Local).AddTicks(7895), new DateTime(2023, 5, 18, 11, 35, 11, 340, DateTimeKind.Local).AddTicks(7896) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfileImgLink",
                table: "AspNetUsers");

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
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2023, 5, 17, 14, 59, 18, 817, DateTimeKind.Local).AddTicks(9878), new DateTime(2023, 5, 17, 14, 59, 18, 817, DateTimeKind.Local).AddTicks(9919) });

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
    }
}
