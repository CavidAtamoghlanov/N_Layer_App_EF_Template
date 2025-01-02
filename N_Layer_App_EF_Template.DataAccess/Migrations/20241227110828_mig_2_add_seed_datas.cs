using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace N_Layer_App_EF_Template.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class mig_2_add_seed_datas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Claims",
                columns: new[] { "Id", "CreatedDate", "Description", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1L, new DateTime(2024, 12, 27, 11, 8, 27, 955, DateTimeKind.Utc).AddTicks(8287), "Permission to manage users", "ManageUsers", null },
                    { 2L, new DateTime(2024, 12, 27, 11, 8, 27, 955, DateTimeKind.Utc).AddTicks(8293), "Permission to view reports", "ViewReports", null },
                    { 3L, new DateTime(2024, 12, 27, 11, 8, 27, 955, DateTimeKind.Utc).AddTicks(8295), "Permission to edit content", "EditContent", null }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "Description", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1L, new DateTime(2024, 12, 27, 11, 8, 27, 955, DateTimeKind.Utc).AddTicks(8418), "Administrator role", "Admin", null },
                    { 2L, new DateTime(2024, 12, 27, 11, 8, 27, 955, DateTimeKind.Utc).AddTicks(8422), "Moderator role", "Moderator", null },
                    { 3L, new DateTime(2024, 12, 27, 11, 8, 27, 955, DateTimeKind.Utc).AddTicks(8423), "Standard user role", "User", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "CreatedDate", "DeletedDate", "Email", "EmailComfirmed", "FirstName", "IsDeleted", "IsPermanently", "LastName", "LockOutEnabled", "MiddleName", "Otp", "OtpExpiration", "OtpSendDate", "OtpVerificationMethod", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "UpdatedDate" },
                values: new object[,]
                {
                    { 1L, (byte)0, new DateTime(1990, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 27, 11, 8, 27, 955, DateTimeKind.Utc).AddTicks(8480), null, "john.doe@example.com", true, "John", false, false, "Doe", false, "Michael", "1234", new DateTime(2024, 12, 27, 11, 13, 27, 955, DateTimeKind.Utc).AddTicks(8471), new DateTime(2024, 12, 27, 11, 8, 27, 955, DateTimeKind.Utc).AddTicks(8477), 1, "hashed_password_1", "+123456789", true, null },
                    { 2L, (byte)1, new DateTime(1985, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 27, 11, 8, 27, 955, DateTimeKind.Utc).AddTicks(8489), null, "jane.smith@example.com", true, "Jane", false, false, "Smith", true, "Elizabeth", "5678", new DateTime(2024, 12, 27, 11, 18, 27, 955, DateTimeKind.Utc).AddTicks(8486), new DateTime(2024, 12, 27, 11, 8, 27, 955, DateTimeKind.Utc).AddTicks(8487), 0, "hashed_password_2", "+987654321", true, null },
                    { 3L, (byte)2, new DateTime(1995, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 27, 11, 8, 27, 955, DateTimeKind.Utc).AddTicks(8494), null, "alice.brown@example.com", false, "Alice", false, false, "Brown", false, "Marie", "91011", new DateTime(2024, 12, 27, 11, 23, 27, 955, DateTimeKind.Utc).AddTicks(8492), new DateTime(2024, 12, 27, 11, 8, 27, 955, DateTimeKind.Utc).AddTicks(8492), 1, "hashed_password_3", "+555123456", false, null }
                });

            migrationBuilder.InsertData(
                table: "ClaimRole",
                columns: new[] { "ClaimsId", "RolesId" },
                values: new object[,]
                {
                    { 1L, 1L },
                    { 2L, 2L },
                    { 3L, 3L }
                });

            migrationBuilder.InsertData(
                table: "RoleUser",
                columns: new[] { "RolesId", "UsersId" },
                values: new object[,]
                {
                    { 1L, 1L },
                    { 2L, 2L },
                    { 3L, 3L }
                });

            migrationBuilder.InsertData(
                table: "UserLogins",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "IsDeleted", "IsPermanently", "ProviderKey", "ProviderName", "UpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2024, 12, 27, 11, 8, 27, 955, DateTimeKind.Utc).AddTicks(8538), null, false, false, "google-key-1", "Google", null, 1L },
                    { 2L, new DateTime(2024, 12, 27, 11, 8, 27, 955, DateTimeKind.Utc).AddTicks(8543), null, false, false, "facebook-key-2", "Facebook", null, 2L },
                    { 3L, new DateTime(2024, 12, 27, 11, 8, 27, 955, DateTimeKind.Utc).AddTicks(8545), null, false, false, "twitter-key-3", "Twitter", null, 3L }
                });

            migrationBuilder.InsertData(
                table: "UserTokens",
                columns: new[] { "Id", "CreatedDate", "ExpireDate", "Key", "UpdatedDate", "UserId", "Value" },
                values: new object[,]
                {
                    { "token-1", new DateTime(2024, 12, 27, 11, 8, 27, 955, DateTimeKind.Utc).AddTicks(8587), new DateTime(2025, 1, 3, 11, 8, 27, 955, DateTimeKind.Utc).AddTicks(8585), "refresh", null, 1L, "token-value-1" },
                    { "token-2", new DateTime(2024, 12, 27, 11, 8, 27, 955, DateTimeKind.Utc).AddTicks(8593), new DateTime(2025, 1, 3, 11, 8, 27, 955, DateTimeKind.Utc).AddTicks(8592), "refresh", null, 2L, "token-value-2" },
                    { "token-3", new DateTime(2024, 12, 27, 11, 8, 27, 955, DateTimeKind.Utc).AddTicks(8595), new DateTime(2025, 1, 3, 11, 8, 27, 955, DateTimeKind.Utc).AddTicks(8594), "refresh", null, 3L, "token-value-3" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ClaimRole",
                keyColumns: new[] { "ClaimsId", "RolesId" },
                keyValues: new object[] { 1L, 1L });

            migrationBuilder.DeleteData(
                table: "ClaimRole",
                keyColumns: new[] { "ClaimsId", "RolesId" },
                keyValues: new object[] { 2L, 2L });

            migrationBuilder.DeleteData(
                table: "ClaimRole",
                keyColumns: new[] { "ClaimsId", "RolesId" },
                keyValues: new object[] { 3L, 3L });

            migrationBuilder.DeleteData(
                table: "RoleUser",
                keyColumns: new[] { "RolesId", "UsersId" },
                keyValues: new object[] { 1L, 1L });

            migrationBuilder.DeleteData(
                table: "RoleUser",
                keyColumns: new[] { "RolesId", "UsersId" },
                keyValues: new object[] { 2L, 2L });

            migrationBuilder.DeleteData(
                table: "RoleUser",
                keyColumns: new[] { "RolesId", "UsersId" },
                keyValues: new object[] { 3L, 3L });

            migrationBuilder.DeleteData(
                table: "UserLogins",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "UserLogins",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "UserLogins",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "UserTokens",
                keyColumn: "Id",
                keyValue: "token-1");

            migrationBuilder.DeleteData(
                table: "UserTokens",
                keyColumn: "Id",
                keyValue: "token-2");

            migrationBuilder.DeleteData(
                table: "UserTokens",
                keyColumn: "Id",
                keyValue: "token-3");

            migrationBuilder.DeleteData(
                table: "Claims",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Claims",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Claims",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3L);
        }
    }
}
