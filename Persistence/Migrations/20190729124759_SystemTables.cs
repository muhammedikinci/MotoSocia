using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class SystemTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "EventIDs",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GroupIDs",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LasChangedPassword",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostIDs",
                table: "Users",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    _id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: false),
                    Content = table.Column<string>(nullable: false),
                    RelatedGroupID = table.Column<int>(nullable: false),
                    SenderUserID = table.Column<int>(nullable: false),
                    Subscribers = table.Column<string>(nullable: true),
                    EventDates = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x._id);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    _id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    MemberLimit = table.Column<int>(nullable: false),
                    GroupIcon = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    MediaLinks = table.Column<string>(nullable: true),
                    GroupOwnerID = table.Column<int>(nullable: false),
                    AdminIDs = table.Column<string>(nullable: true),
                    MemberIDs = table.Column<string>(nullable: true),
                    EventIDs = table.Column<string>(nullable: true),
                    PostIDs = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x._id);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    _id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(maxLength: 75, nullable: false),
                    Content = table.Column<string>(maxLength: 1000, nullable: false),
                    RelatedGroupID = table.Column<int>(nullable: false),
                    SenderUserID = table.Column<int>(nullable: false),
                    LikedUsers = table.Column<string>(nullable: true),
                    CommentedUser = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x._id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "EventIDs",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "GroupIDs",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LasChangedPassword",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PostIDs",
                table: "Users");
        }
    }
}
