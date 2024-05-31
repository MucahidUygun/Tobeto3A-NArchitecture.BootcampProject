using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class bootcampDescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("b76836db-ecc5-43ad-ae3f-2e940180f9d8"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c0cc8462-83a1-4983-83a7-e29321eaa4c0"));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Bootcamps",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DateOfBirth", "DeletedDate", "Email", "FirstName", "LastName", "NationalIdentity", "PasswordHash", "PasswordSalt", "UpdatedDate", "UserName" },
                values: new object[] { new Guid("16fb6763-be75-46ce-baa2-98062694bb6f"), 0, new DateTime(2024, 5, 21, 15, 42, 6, 530, DateTimeKind.Local).AddTicks(4521), new DateTime(2024, 5, 21, 15, 42, 6, 530, DateTimeKind.Local).AddTicks(4507), null, "uygun@uygun.yg", "John", "Doe", "1234567", new byte[] { 80, 124, 146, 15, 230, 77, 143, 52, 195, 78, 102, 243, 127, 124, 33, 126, 254, 119, 129, 159, 62, 35, 139, 27, 153, 245, 193, 91, 9, 114, 228, 193, 188, 82, 237, 101, 65, 27, 35, 53, 203, 156, 246, 32, 215, 23, 81, 188, 194, 91, 43, 33, 140, 84, 108, 154, 47, 239, 120, 183, 103, 105, 25, 74 }, new byte[] { 128, 213, 169, 123, 252, 139, 188, 95, 4, 50, 14, 165, 255, 84, 124, 210, 54, 205, 206, 226, 53, 114, 220, 3, 11, 24, 192, 133, 33, 255, 78, 83, 235, 160, 56, 160, 22, 148, 242, 20, 250, 114, 66, 0, 218, 43, 78, 211, 61, 55, 4, 186, 105, 62, 244, 88, 91, 12, 158, 155, 105, 225, 52, 232, 14, 38, 130, 201, 23, 113, 146, 8, 9, 33, 32, 74, 75, 243, 18, 76, 250, 227, 71, 193, 206, 73, 130, 108, 71, 128, 20, 20, 159, 164, 8, 34, 95, 162, 163, 68, 209, 28, 252, 220, 6, 207, 184, 223, 82, 167, 215, 146, 73, 187, 250, 160, 192, 189, 49, 228, 210, 216, 145, 182, 158, 164, 40, 65 }, null, "admin" });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("26bd43e0-a2d3-4e12-b4f9-7fab11debabf"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("16fb6763-be75-46ce-baa2-98062694bb6f") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("26bd43e0-a2d3-4e12-b4f9-7fab11debabf"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("16fb6763-be75-46ce-baa2-98062694bb6f"));

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Bootcamps");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DateOfBirth", "DeletedDate", "Email", "FirstName", "LastName", "NationalIdentity", "PasswordHash", "PasswordSalt", "UpdatedDate", "UserName" },
                values: new object[] { new Guid("c0cc8462-83a1-4983-83a7-e29321eaa4c0"), 0, new DateTime(2024, 4, 5, 18, 28, 47, 433, DateTimeKind.Local).AddTicks(5924), new DateTime(2024, 4, 5, 18, 28, 47, 433, DateTimeKind.Local).AddTicks(5912), null, "uygun@uygun.yg", "John", "Doe", "1234567", new byte[] { 67, 142, 111, 12, 86, 112, 170, 195, 127, 80, 238, 86, 152, 32, 3, 34, 129, 4, 151, 201, 51, 58, 216, 88, 200, 186, 148, 209, 241, 20, 231, 104, 59, 138, 14, 93, 167, 238, 182, 136, 222, 74, 31, 136, 105, 50, 151, 191, 233, 152, 93, 189, 93, 118, 109, 80, 48, 249, 208, 39, 54, 40, 125, 86 }, new byte[] { 15, 57, 13, 2, 234, 134, 114, 18, 143, 89, 106, 89, 75, 58, 189, 167, 69, 121, 250, 78, 58, 122, 108, 168, 67, 42, 128, 14, 144, 81, 82, 117, 172, 146, 157, 132, 152, 65, 171, 217, 242, 59, 182, 118, 163, 50, 183, 84, 97, 83, 157, 49, 130, 226, 194, 95, 71, 36, 176, 1, 179, 165, 83, 10, 135, 223, 74, 112, 90, 181, 59, 232, 138, 101, 48, 105, 154, 167, 193, 159, 245, 47, 190, 229, 57, 124, 31, 227, 111, 25, 202, 183, 75, 245, 200, 23, 121, 252, 185, 6, 146, 73, 174, 8, 69, 187, 170, 205, 146, 192, 10, 240, 227, 10, 1, 255, 50, 214, 150, 106, 177, 176, 208, 153, 153, 205, 216, 216 }, null, "admin" });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("b76836db-ecc5-43ad-ae3f-2e940180f9d8"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("c0cc8462-83a1-4983-83a7-e29321eaa4c0") });
        }
    }
}
