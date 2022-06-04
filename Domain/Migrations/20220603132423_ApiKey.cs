using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    public partial class ApiKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApiKey",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "ProductReviews",
                columns: new[] { "ProductId", "ReviewUri" },
                values: new object[,]
                {
                    { 1, "https://www.amazon.com/beyerdynamic-770-PRO-Studio-Headphone/dp/B0016MNAAI/ref=sr_1_1?crid=11D3FY6ZK31AM&keywords=dt770+pro+80+ohm&qid=1654074204&sprefix=dt770+pro+80+ohm%2Caps%2C194&sr=8-1" },
                    { 2, "https://www.amazon.com/Sonos-Arc-Premium-Soundbar-Movies/dp/B087CD7H2G/ref=sr_1_3?crid=3HCLLN96MF1NX&keywords=sonos+arc&qid=1654074219&sprefix=sonos+ar%2Caps%2C215&sr=8-3" },
                    { 3, "https://www.amazon.com/LG-OLED55C1PUB-Alexa-Built-Smart/dp/B08WFV7L3N/ref=sr_1_1?crid=LQKW12KEDK9T&keywords=lg+c1&qid=1654074240&sprefix=lg+c%2Caps%2C207&sr=8-1" },
                    { 4, "https://www.amazon.com/Synology-Bay-DiskStation-DS220-Diskless/dp/B087ZCBWFH/ref=sr_1_2?crid=YBRJ8TD03N5C&keywords=synology+ds220%2B&qid=1654074261&sprefix=synology+ds220%2Caps%2C235&sr=8-2" },
                    { 6, "https://www.amazon.com/ASUS-AX1800-WiFi-Router-RT-AX55/dp/B08J6CFM39/ref=sr_1_3?crid=QTUQDW513R35&keywords=rt-ax55&qid=1654074279&sprefix=rt-ax5%2Caps%2C194&sr=8-3" },
                    { 7, "https://www.amazon.com/Solar-Power-Charger-Flashlight-Splashproof/dp/B07FDXDB3W/ref=sr_1_3?keywords=power+bank+solar+charger&qid=1654074318&sprefix=powerbank+solar%2Caps%2C208&sr=8-3" },
                    { 8, "https://www.amazon.com/iFixit-Pro-Tech-Toolkit-Electronics/dp/B01GF0KV6G/ref=sr_1_2_sspa?crid=1KSXA0TK748ZL&keywords=ifixit+pro+tech+toolkit&qid=1654074336&sprefix=ifixit+pro+tech+toolk%2Caps%2C198&sr=8-2-spons&psc=1&smid=A3JGOE00MHF9QZ&spLa=ZW5jcnlwdGVkUXVhbGlmaWVyPUFOMzlCWjc0Mk1JTEMmZW5jcnlwdGVkSWQ9QTA3MjE3NzhRTzMzSjRYOUVHVDQmZW5jcnlwdGVkQWRJZD1BMDA3MTU4NjJSSTIzNkVWSUxUOVUmd2lkZ2V0TmFtZT1zcF9hdGYmYWN0aW9uPWNsaWNrUmVkaXJlY3QmZG9Ob3RMb2dDbGljaz10cnVl" },
                    { 9, "https://www.amazon.com/Samsung-Factory-Unlocked-Smartphone-Intelligent/dp/B09BFRV59N/ref=sr_1_1_sspa?crid=1QAPS0XSSUG9J&keywords=galaxy+s21+fe&qid=1654074353&sprefix=galaxy+s21+%2Caps%2C241&sr=8-1-spons&psc=1&spLa=ZW5jcnlwdGVkUXVhbGlmaWVyPUEyOTdSOUpXME1JNDhEJmVuY3J5cHRlZElkPUEwOTE5MjY1MUVaVkEyNFFWODVSSSZlbmNyeXB0ZWRBZElkPUEwNjI4MTA1MzAzVUREM0UxSFpBVSZ3aWRnZXROYW1lPXNwX2F0ZiZhY3Rpb249Y2xpY2tSZWRpcmVjdCZkb05vdExvZ0NsaWNrPXRydWU=" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ApiKey",
                table: "AspNetUsers",
                column: "ApiKey",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ApiKey",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "ProductReviews",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductReviews",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductReviews",
                keyColumn: "ProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProductReviews",
                keyColumn: "ProductId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProductReviews",
                keyColumn: "ProductId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ProductReviews",
                keyColumn: "ProductId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ProductReviews",
                keyColumn: "ProductId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ProductReviews",
                keyColumn: "ProductId",
                keyValue: 9);

            migrationBuilder.DropColumn(
                name: "ApiKey",
                table: "AspNetUsers");
        }
    }
}
