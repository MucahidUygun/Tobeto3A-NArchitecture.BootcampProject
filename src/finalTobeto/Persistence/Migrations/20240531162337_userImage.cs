using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class userImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("1f1c9099-ec71-44d0-b549-94fdbfa49049"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("91423a7e-2526-465f-ad1f-1f35085adc2c"));

            migrationBuilder.CreateTable(
                name: "UserImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserImages_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 78, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "UserImages.Admin", null },
                    { 79, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "UserImages.Read", null },
                    { 80, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "UserImages.Write", null },
                    { 81, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "UserImages.Create", null },
                    { 82, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "UserImages.Update", null },
                    { 83, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "UserImages.Delete", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DateOfBirth", "DeletedDate", "Email", "FirstName", "LastName", "NationalIdentity", "PasswordHash", "PasswordSalt", "UpdatedDate", "UserName" },
                values: new object[] { new Guid("55479fd2-16a1-4901-9514-e53f427f3d38"), 0, new DateTime(2024, 5, 31, 19, 23, 35, 826, DateTimeKind.Local).AddTicks(3948), new DateTime(2024, 5, 31, 19, 23, 35, 826, DateTimeKind.Local).AddTicks(3921), null, "uygun@uygun.yg", "John", "Doe", "1234567", new byte[] { 215, 202, 61, 26, 84, 120, 238, 199, 1, 245, 177, 34, 187, 114, 111, 179, 120, 134, 4, 58, 143, 173, 45, 80, 102, 88, 2, 139, 136, 13, 27, 33, 50, 39, 200, 19, 53, 234, 91, 51, 151, 177, 92, 193, 86, 216, 73, 91, 221, 244, 236, 17, 134, 132, 73, 78, 192, 189, 126, 3, 194, 38, 150, 0 }, new byte[] { 152, 4, 190, 246, 118, 37, 128, 125, 99, 184, 59, 9, 10, 99, 104, 33, 226, 116, 73, 138, 22, 252, 44, 151, 23, 46, 231, 86, 121, 248, 136, 229, 252, 148, 27, 176, 62, 79, 177, 24, 74, 202, 23, 45, 4, 40, 178, 172, 201, 119, 240, 192, 113, 167, 129, 76, 101, 183, 157, 73, 254, 209, 161, 78, 156, 5, 62, 196, 234, 166, 18, 69, 127, 179, 34, 240, 150, 156, 30, 177, 214, 247, 225, 46, 118, 177, 166, 22, 98, 59, 117, 100, 236, 11, 14, 144, 202, 148, 95, 59, 239, 89, 112, 213, 20, 141, 177, 219, 62, 213, 36, 186, 231, 239, 28, 12, 126, 80, 143, 183, 189, 83, 246, 80, 201, 92, 51, 98 }, null, "admin" });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("6d2ea5ef-dc78-4d3b-9f48-1297b8c30e06"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("55479fd2-16a1-4901-9514-e53f427f3d38") });

            migrationBuilder.CreateIndex(
                name: "IX_UserImages_UserId",
                table: "UserImages",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserImages");

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("6d2ea5ef-dc78-4d3b-9f48-1297b8c30e06"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("55479fd2-16a1-4901-9514-e53f427f3d38"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DateOfBirth", "DeletedDate", "Email", "FirstName", "LastName", "NationalIdentity", "PasswordHash", "PasswordSalt", "UpdatedDate", "UserName" },
                values: new object[] { new Guid("91423a7e-2526-465f-ad1f-1f35085adc2c"), 0, new DateTime(2024, 5, 31, 1, 16, 46, 566, DateTimeKind.Local).AddTicks(4403), new DateTime(2024, 5, 31, 1, 16, 46, 566, DateTimeKind.Local).AddTicks(4379), null, "uygun@uygun.yg", "John", "Doe", "1234567", new byte[] { 152, 131, 49, 27, 195, 17, 89, 232, 143, 8, 88, 223, 76, 240, 17, 100, 206, 246, 79, 189, 13, 117, 125, 1, 129, 159, 13, 129, 104, 117, 210, 80, 50, 185, 119, 64, 105, 112, 202, 79, 70, 46, 167, 195, 230, 212, 237, 189, 192, 235, 172, 54, 205, 219, 188, 129, 180, 186, 190, 173, 145, 161, 149, 169 }, new byte[] { 255, 96, 95, 74, 40, 227, 214, 159, 128, 151, 24, 184, 189, 224, 147, 103, 0, 107, 0, 74, 163, 204, 208, 111, 174, 46, 138, 241, 175, 145, 122, 173, 4, 250, 116, 66, 137, 134, 160, 196, 0, 57, 138, 26, 43, 164, 19, 143, 108, 212, 4, 172, 169, 133, 5, 81, 233, 222, 216, 251, 208, 235, 143, 52, 105, 64, 188, 196, 169, 254, 94, 183, 13, 232, 89, 178, 117, 78, 243, 110, 94, 153, 115, 231, 137, 99, 122, 66, 145, 91, 226, 157, 123, 23, 43, 194, 166, 154, 63, 255, 26, 118, 170, 211, 93, 143, 128, 181, 213, 168, 179, 101, 64, 126, 96, 148, 24, 204, 122, 115, 94, 126, 45, 136, 32, 203, 29, 243 }, null, "admin" });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("1f1c9099-ec71-44d0-b549-94fdbfa49049"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("91423a7e-2526-465f-ad1f-1f35085adc2c") });
        }
    }
}
