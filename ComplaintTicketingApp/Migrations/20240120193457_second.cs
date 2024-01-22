using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComplaintTicketingApp.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {           

            migrationBuilder.DropForeignKey(
                name: "FK_TicketTransaction_User_ToUserID",
                table: "TicketTransaction");

            migrationBuilder.DropIndex(
                name: "IX_TicketTransaction_ToUserID",
                table: "TicketTransaction");

            migrationBuilder.DropColumn(
                name: "ToUserID",
                table: "TicketTransaction");

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Ticket",
				type: "int", nullable: false
				);

     

            migrationBuilder.AlterColumn<string>(
                name: "Note",
                table: "TicketTransaction",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "AdminUserID",
                table: "Ticket",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_User_UserID",
                table: "Ticket",
                column: "UserID",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_User_UserID",
                table: "Ticket");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Ticket",
                newName: "ReceiverUserID");

            migrationBuilder.RenameIndex(
                name: "IX_Ticket_UserID",
                table: "Ticket",
                newName: "IX_Ticket_ReceiverUserID");

            migrationBuilder.AlterColumn<string>(
                name: "Note",
                table: "TicketTransaction",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ToUserID",
                table: "TicketTransaction",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "AdminUserID",
                table: "Ticket",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TicketTransaction_ToUserID",
                table: "TicketTransaction",
                column: "ToUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_User_ReceiverUserID",
                table: "Ticket",
                column: "ReceiverUserID",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketTransaction_User_ToUserID",
                table: "TicketTransaction",
                column: "ToUserID",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
