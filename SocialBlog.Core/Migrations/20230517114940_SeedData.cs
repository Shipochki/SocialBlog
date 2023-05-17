using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialBlog.Core.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "IsDeleted", "LastName", "LockoutEnabled", "LockoutEnd", "NickName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "bcb4f072-ecca-43c9-ab26-c060c6f364e4", 0, "aa58a865-6789-4bb1-aa26-77ab8aea2ba4", "admin@mail.com", false, "Owner", false, "Admin", false, null, "Admin", "admin@mail.com", "admin@mail.com", "AQAAAAEAACcQAAAAEJeAx/EtqV70+7DU5IcblLOl4fWMQn8nXCJPmGzJe7d5ND4vC5VLevsbmn1VOPCa0g==", null, false, "6a13dcd2-9971-4a2f-a459-aa2ce2c6532e", false, "admin@mail.com" });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "IsActive", "IsDeleted", "PhoneNumber", "UserId" },
                values: new object[] { 1, true, false, "0123456789", "bcb4f072-ecca-43c9-ab26-c060c6f364e4" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AuthorId", "Created", "Description", "ImageUrlLink", "IsDeleted", "Tag", "Text", "TimeForRead", "Title", "Updated" },
                values: new object[] { 1, 1, new DateTime(2023, 5, 17, 14, 49, 40, 39, DateTimeKind.Local).AddTicks(8219), "Explore the advancements and impact of renewable energy sources such as solar, wind, hydro.", "https://www.visualcapitalist.com/wp-content/uploads/2022/06/typess-of-renewable-energy.jpg", false, "Energy", "Explore the advancements and impact of renewable energy sources such as solar, wind, hydro, and geothermal power. Discuss their role in combating climate change, reducing carbon emissions, and creating a sustainable future.", 5, "Renewable Energy", new DateTime(2023, 5, 17, 14, 49, 40, 39, DateTimeKind.Local).AddTicks(8256) });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AuthorId", "Created", "Description", "ImageUrlLink", "IsDeleted", "Tag", "Text", "TimeForRead", "Title", "Updated" },
                values: new object[] { 2, 1, new DateTime(2023, 5, 17, 14, 49, 40, 39, DateTimeKind.Local).AddTicks(8259), "Delve into the applications of artificial intelligence (AI).", "https://online.stanford.edu/sites/default/files/styles/embedded_large/public/2020-08/artificial-intelligence-in-healthcare-MAIN.jpg?itok=uRNflQFw", false, "AI", "Delve into the applications of artificial intelligence (AI) in healthcare, including medical diagnosis, drug discovery, personalized medicine, and patient care. Highlight the benefits, challenges, and ethical considerations surrounding the use of AI in this critical field.", 2, "Artificial Intelligence in Healthcare", new DateTime(2023, 5, 17, 14, 49, 40, 39, DateTimeKind.Local).AddTicks(8261) });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AuthorId", "Created", "Description", "ImageUrlLink", "IsDeleted", "Tag", "Text", "TimeForRead", "Title", "Updated" },
                values: new object[] { 3, 1, new DateTime(2023, 5, 17, 14, 49, 40, 39, DateTimeKind.Local).AddTicks(8264), "Examine the evolving landscape of work in the digital age.", "https://www.leadingauthorities.com/sites/default/files/2019-11/the-future-of-work.details.png", false, "Work", "Examine the evolving landscape of work in the digital age, considering the impact of automation, remote work, gig economy, and emerging technologies on employment patterns and job opportunities. Discuss the skills and adaptations needed for individuals and societies to thrive in the future work environment.", 4, "Future of Work", new DateTime(2023, 5, 17, 14, 49, 40, 39, DateTimeKind.Local).AddTicks(8265) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4");
        }
    }
}
