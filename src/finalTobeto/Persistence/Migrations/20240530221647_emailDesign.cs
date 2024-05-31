using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class emailDesign : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("26bd43e0-a2d3-4e12-b4f9-7fab11debabf"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("16fb6763-be75-46ce-baa2-98062694bb6f"));

            migrationBuilder.AddColumn<bool>(
                name: "ResetPasswordToken",
                table: "EmailAuthenticators",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ResetPasswordTokenExpiry",
                table: "EmailAuthenticators",
                type: "datetime2",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DateOfBirth", "DeletedDate", "Email", "FirstName", "LastName", "NationalIdentity", "PasswordHash", "PasswordSalt", "UpdatedDate", "UserName" },
                values: new object[] { new Guid("91423a7e-2526-465f-ad1f-1f35085adc2c"), 0, new DateTime(2024, 5, 31, 1, 16, 46, 566, DateTimeKind.Local).AddTicks(4403), new DateTime(2024, 5, 31, 1, 16, 46, 566, DateTimeKind.Local).AddTicks(4379), null, "uygun@uygun.yg", "John", "Doe", "1234567", new byte[] { 152, 131, 49, 27, 195, 17, 89, 232, 143, 8, 88, 223, 76, 240, 17, 100, 206, 246, 79, 189, 13, 117, 125, 1, 129, 159, 13, 129, 104, 117, 210, 80, 50, 185, 119, 64, 105, 112, 202, 79, 70, 46, 167, 195, 230, 212, 237, 189, 192, 235, 172, 54, 205, 219, 188, 129, 180, 186, 190, 173, 145, 161, 149, 169 }, new byte[] { 255, 96, 95, 74, 40, 227, 214, 159, 128, 151, 24, 184, 189, 224, 147, 103, 0, 107, 0, 74, 163, 204, 208, 111, 174, 46, 138, 241, 175, 145, 122, 173, 4, 250, 116, 66, 137, 134, 160, 196, 0, 57, 138, 26, 43, 164, 19, 143, 108, 212, 4, 172, 169, 133, 5, 81, 233, 222, 216, 251, 208, 235, 143, 52, 105, 64, 188, 196, 169, 254, 94, 183, 13, 232, 89, 178, 117, 78, 243, 110, 94, 153, 115, 231, 137, 99, 122, 66, 145, 91, 226, 157, 123, 23, 43, 194, 166, 154, 63, 255, 26, 118, 170, 211, 93, 143, 128, 181, 213, 168, 179, 101, 64, 126, 96, 148, 24, 204, 122, 115, 94, 126, 45, 136, 32, 203, 29, 243 }, null, "admin" });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("1f1c9099-ec71-44d0-b549-94fdbfa49049"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("91423a7e-2526-465f-ad1f-1f35085adc2c") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("1f1c9099-ec71-44d0-b549-94fdbfa49049"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("91423a7e-2526-465f-ad1f-1f35085adc2c"));

            migrationBuilder.DropColumn(
                name: "ResetPasswordToken",
                table: "EmailAuthenticators");

            migrationBuilder.DropColumn(
                name: "ResetPasswordTokenExpiry",
                table: "EmailAuthenticators");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DateOfBirth", "DeletedDate", "Email", "FirstName", "LastName", "NationalIdentity", "PasswordHash", "PasswordSalt", "UpdatedDate", "UserName" },
                values: new object[] { new Guid("16fb6763-be75-46ce-baa2-98062694bb6f"), 0, new DateTime(2024, 5, 21, 15, 42, 6, 530, DateTimeKind.Local).AddTicks(4521), new DateTime(2024, 5, 21, 15, 42, 6, 530, DateTimeKind.Local).AddTicks(4507), null, "uygun@uygun.yg", "John", "Doe", "1234567", new byte[] { 80, 124, 146, 15, 230, 77, 143, 52, 195, 78, 102, 243, 127, 124, 33, 126, 254, 119, 129, 159, 62, 35, 139, 27, 153, 245, 193, 91, 9, 114, 228, 193, 188, 82, 237, 101, 65, 27, 35, 53, 203, 156, 246, 32, 215, 23, 81, 188, 194, 91, 43, 33, 140, 84, 108, 154, 47, 239, 120, 183, 103, 105, 25, 74 }, new byte[] { 128, 213, 169, 123, 252, 139, 188, 95, 4, 50, 14, 165, 255, 84, 124, 210, 54, 205, 206, 226, 53, 114, 220, 3, 11, 24, 192, 133, 33, 255, 78, 83, 235, 160, 56, 160, 22, 148, 242, 20, 250, 114, 66, 0, 218, 43, 78, 211, 61, 55, 4, 186, 105, 62, 244, 88, 91, 12, 158, 155, 105, 225, 52, 232, 14, 38, 130, 201, 23, 113, 146, 8, 9, 33, 32, 74, 75, 243, 18, 76, 250, 227, 71, 193, 206, 73, 130, 108, 71, 128, 20, 20, 159, 164, 8, 34, 95, 162, 163, 68, 209, 28, 252, 220, 6, 207, 184, 223, 82, 167, 215, 146, 73, 187, 250, 160, 192, 189, 49, 228, 210, 216, 145, 182, 158, 164, 40, 65 }, null, "admin" });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("26bd43e0-a2d3-4e12-b4f9-7fab11debabf"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("16fb6763-be75-46ce-baa2-98062694bb6f") });
        }
    }
}
