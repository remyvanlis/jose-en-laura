using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JoseEnLaura.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdminUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Role = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DressCodeColors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hex = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    NameNl = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SortOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DressCodeColors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FaqItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    QuestionEn = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Answer = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    AnswerEn = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    SortOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FaqItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Guests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    InvitedFor = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhotoSessions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhotoSessions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlanningCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Color = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanningCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ScheduleItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Time = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    TitleEn = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DescriptionEn = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScheduleItems_ScheduleItems_ParentId",
                        column: x => x.ParentId,
                        principalTable: "ScheduleItems",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SiteImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Slot = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Data = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteImages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SiteTexts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    ValueEn = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Label = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteTexts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VisitorLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VisitedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitorLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlanningAttachments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Data = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    FileSize = table.Column<long>(type: "bigint", nullable: false),
                    UploadedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UploadedById = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanningAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanningAttachments_AdminUsers_UploadedById",
                        column: x => x.UploadedById,
                        principalTable: "AdminUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Attendances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GuestId = table.Column<int>(type: "int", nullable: false),
                    AttendingCeremony = table.Column<bool>(type: "bit", nullable: false),
                    AttendingDinner = table.Column<bool>(type: "bit", nullable: false),
                    AttendingEvening = table.Column<bool>(type: "bit", nullable: false),
                    DietaryNotes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Message = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    SubmittedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CheckedInCeremonyAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CheckedInDinnerAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CheckedInPartyAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attendances_Guests_GuestId",
                        column: x => x.GuestId,
                        principalTable: "Guests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhotoSessionGuests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhotoSessionId = table.Column<int>(type: "int", nullable: false),
                    GuestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhotoSessionGuests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhotoSessionGuests_Guests_GuestId",
                        column: x => x.GuestId,
                        principalTable: "Guests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhotoSessionGuests_PhotoSessions_PhotoSessionId",
                        column: x => x.PhotoSessionId,
                        principalTable: "PhotoSessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlanningNotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    AssignedToId = table.Column<int>(type: "int", nullable: true),
                    Deadline = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsPinnedInfo = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedById = table.Column<int>(type: "int", nullable: false),
                    CurrentVersion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanningNotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanningNotes_AdminUsers_AssignedToId",
                        column: x => x.AssignedToId,
                        principalTable: "AdminUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlanningNotes_AdminUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AdminUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlanningNotes_AdminUsers_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "AdminUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlanningNotes_PlanningCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "PlanningCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GeneralNoteEntries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    MentionedUserIds = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    AttachmentId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralNoteEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GeneralNoteEntries_AdminUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AdminUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GeneralNoteEntries_PlanningAttachments_AttachmentId",
                        column: x => x.AttachmentId,
                        principalTable: "PlanningAttachments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Plays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttendanceId = table.Column<int>(type: "int", nullable: false),
                    DurationMinutes = table.Column<int>(type: "int", nullable: false),
                    NeedsBeamer = table.Column<bool>(type: "bit", nullable: false),
                    Requirements = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plays_Attendances_AttendanceId",
                        column: x => x.AttendanceId,
                        principalTable: "Attendances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlanningAuditLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoteId = table.Column<int>(type: "int", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Details = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanningAuditLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanningAuditLogs_AdminUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AdminUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlanningAuditLogs_PlanningNotes_NoteId",
                        column: x => x.NoteId,
                        principalTable: "PlanningNotes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlanningBlocks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoteId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    IsChecked = table.Column<bool>(type: "bit", nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    IndentLevel = table.Column<int>(type: "int", nullable: false),
                    AssignedToId = table.Column<int>(type: "int", nullable: true),
                    ItemStatus = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Priority = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Deadline = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsCollapsed = table.Column<bool>(type: "bit", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AttachmentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanningBlocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanningBlocks_AdminUsers_AssignedToId",
                        column: x => x.AssignedToId,
                        principalTable: "AdminUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlanningBlocks_PlanningAttachments_AttachmentId",
                        column: x => x.AttachmentId,
                        principalTable: "PlanningAttachments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_PlanningBlocks_PlanningNotes_NoteId",
                        column: x => x.NoteId,
                        principalTable: "PlanningNotes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlanningNoteVersions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoteId = table.Column<int>(type: "int", nullable: false),
                    VersionNumber = table.Column<int>(type: "int", nullable: false),
                    SnapshotJson = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanningNoteVersions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanningNoteVersions_AdminUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AdminUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlanningNoteVersions_PlanningNotes_NoteId",
                        column: x => x.NoteId,
                        principalTable: "PlanningNotes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserNoteVisits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    NoteId = table.Column<int>(type: "int", nullable: false),
                    LastVisitedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserNoteVisits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserNoteVisits_AdminUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AdminUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserNoteVisits_PlanningNotes_NoteId",
                        column: x => x.NoteId,
                        principalTable: "PlanningNotes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GeneralNoteComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GeneralNoteEntryId = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    MentionedUserIds = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    AttachmentId = table.Column<int>(type: "int", nullable: true),
                    ParentCommentId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedById = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralNoteComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GeneralNoteComments_AdminUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AdminUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GeneralNoteComments_GeneralNoteComments_ParentCommentId",
                        column: x => x.ParentCommentId,
                        principalTable: "GeneralNoteComments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GeneralNoteComments_GeneralNoteEntries_GeneralNoteEntryId",
                        column: x => x.GeneralNoteEntryId,
                        principalTable: "GeneralNoteEntries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeneralNoteComments_PlanningAttachments_AttachmentId",
                        column: x => x.AttachmentId,
                        principalTable: "PlanningAttachments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "PlanningComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlockId = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    Importance = table.Column<int>(type: "int", nullable: false),
                    MentionedUserIds = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    AttachmentId = table.Column<int>(type: "int", nullable: true),
                    ParentCommentId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanningComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanningComments_AdminUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AdminUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlanningComments_PlanningAttachments_AttachmentId",
                        column: x => x.AttachmentId,
                        principalTable: "PlanningAttachments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_PlanningComments_PlanningBlocks_BlockId",
                        column: x => x.BlockId,
                        principalTable: "PlanningBlocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlanningComments_PlanningComments_ParentCommentId",
                        column: x => x.ParentCommentId,
                        principalTable: "PlanningComments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserBlockVisits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    BlockId = table.Column<int>(type: "int", nullable: false),
                    LastVisitedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBlockVisits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserBlockVisits_AdminUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AdminUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserBlockVisits_PlanningBlocks_BlockId",
                        column: x => x.BlockId,
                        principalTable: "PlanningBlocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AdminUsers",
                columns: new[] { "Id", "Name", "PasswordHash", "Role" },
                values: new object[,]
                {
                    { 1, "Lianne", null, "CeremonyMaster" },
                    { 2, "Chris", null, "CeremonyMaster" },
                    { 3, "José", null, "Standard" },
                    { 4, "Laura", null, "Standard" }
                });

            migrationBuilder.InsertData(
                table: "ContactInfos",
                columns: new[] { "Id", "Email", "Name", "Phone", "SortOrder" },
                values: new object[,]
                {
                    { 1, "huwelijkjoseenlaura@hotmail.com", "Lianne", "0612345678", 1 },
                    { 2, "huwelijkjoseenlaura@hotmail.com", "Chris", "0612345678", 2 }
                });

            migrationBuilder.InsertData(
                table: "DressCodeColors",
                columns: new[] { "Id", "Hex", "NameEn", "NameNl", "SortOrder" },
                values: new object[,]
                {
                    { 1, "#FBF1EE", "Cream", "Crème", 1 },
                    { 2, "#EFD3D0", "Blush", "Blush", 2 },
                    { 3, "#DDB3B8", "Rosé", "Rosé", 3 },
                    { 4, "#C98B96", "Dusty Rose", "Oudroze", 4 },
                    { 5, "#A85D6E", "Mauve", "Mauve", 5 },
                    { 6, "#7A4F54", "Plum", "Pruim", 6 }
                });

            migrationBuilder.InsertData(
                table: "FaqItems",
                columns: new[] { "Id", "Answer", "AnswerEn", "Question", "QuestionEn", "SortOrder" },
                values: new object[,]
                {
                    { 1, "Alleen als ze expliciet zijn uitgenodigd.", null, "Zijn kinderen welkom?", null, 1 },
                    { 2, "In overleg.", null, "Mag ik een +1 meenemen?", null, 2 },
                    { 3, "16 april.", null, "Tot wanneer kan ik mijn aanwezigheid doorgeven?", null, 3 },
                    { 4, "Meld je af door te mailen naar het e-mail adres: huwelijkremyenmarit@hotmail.com.", null, "Wat moet ik doen als ik ziek ben?", null, 4 },
                    { 5, "Met het OV is het vanaf de dichtstbijzijnde bushalte 3 minuten lopen (280m).\nMet de auto zijn er genoeg parkeerplaatsen!\nJe altijd zelf een taxi huren.\nKen je iemand die mee gaat? Misschien kan je meerijden!", null, "Wat voor vervoer is er mogelijk naar de locatie?", null, 5 },
                    { 6, "U kan contact opnemen met bijvoorbeeld één van deze bedrijven:\ninsert taxi company nearby...", null, "Wilt u met de taxi komen?", null, 6 }
                });

            migrationBuilder.InsertData(
                table: "PlanningCategories",
                columns: new[] { "Id", "Color", "CreatedAt", "Icon", "Name", "SortOrder" },
                values: new object[,]
                {
                    { 1, "#f4a261", new DateTime(2026, 3, 30, 0, 0, 0, 0, DateTimeKind.Utc), "🌅", "Ochtend", 1 },
                    { 2, "#e76f51", new DateTime(2026, 3, 30, 0, 0, 0, 0, DateTimeKind.Utc), "💒", "Ceremonie", 2 },
                    { 3, "#2a9d8f", new DateTime(2026, 3, 30, 0, 0, 0, 0, DateTimeKind.Utc), "📸", "Foto's", 3 },
                    { 4, "#264653", new DateTime(2026, 3, 30, 0, 0, 0, 0, DateTimeKind.Utc), "🍽️", "Diner", 4 },
                    { 5, "#e9c46a", new DateTime(2026, 3, 30, 0, 0, 0, 0, DateTimeKind.Utc), "🎉", "Feest", 5 },
                    { 6, "#606c38", new DateTime(2026, 3, 30, 0, 0, 0, 0, DateTimeKind.Utc), "📍", "Locatie", 6 },
                    { 7, "#bc6c25", new DateTime(2026, 3, 30, 0, 0, 0, 0, DateTimeKind.Utc), "📋", "Algemeen", 7 }
                });

            migrationBuilder.InsertData(
                table: "ScheduleItems",
                columns: new[] { "Id", "Description", "DescriptionEn", "ParentId", "SortOrder", "Time", "Title", "TitleEn" },
                values: new object[,]
                {
                    { 1, "Welkom met een drankje", null, null, 1, "13:30", "Ontvangst", null },
                    { 2, "De trouwceremonie", null, null, 2, "14:00", "Ceremonie", null },
                    { 3, "Proosten op het bruidspaar", null, null, 3, "15:00", "Toost & Felicitaties", null },
                    { 4, "Foto's met familie en vrienden", null, null, 4, "16:00", "Groepsfoto's", null },
                    { 5, "Samen genieten van een heerlijk diner", null, null, 5, "17:30", "Diner", null },
                    { 6, "Dansen en feesten!", null, null, 6, "19:00", "Avondfeest", null },
                    { 7, "Het aansnijden van de taart (lekker op tijd om 20.30 lol)", null, null, 7, "20:30", "Bruidstaart", null },
                    { 8, "Bedankt voor deze mooie dag!", null, null, 8, "00:00", "Afsluiting", null }
                });

            migrationBuilder.InsertData(
                table: "SiteTexts",
                columns: new[] { "Id", "Key", "Label", "Value", "ValueEn" },
                values: new object[,]
                {
                    { 1, "hero.pre", "Hero — bovenste tekst", "Wij gaan trouwen!", null },
                    { 2, "hero.title", "Hero — titel", "José & Laura", null },
                    { 3, "hero.date", "Hero — datum", "17 oktober 2026", null },
                    { 4, "rsvp.title", "RSVP — titel", "Aanwezigheid indienen", null },
                    { 5, "rsvp.subtitle", "RSVP — ondertitel", "Laat ons weten of je erbij bent — graag vóór 17 september 2026", null },
                    { 6, "rsvp.success.attending", "RSVP — bevestiging (aanwezig)", "Wat fijn dat je erbij bent! We kijken ernaar uit.", null },
                    { 7, "rsvp.success.notattending", "RSVP — bevestiging (niet aanwezig)", "We hebben je antwoord opgeslagen. Hopelijk zien we je snel!", null },
                    { 8, "help.title", "Hulp nodig — titel", "Hulp nodig?", null },
                    { 9, "help.subtitle", "Hulp nodig — ondertitel", "Kom je er niet uit? Kies dan één van onderstaande contactopties:", null },
                    { 10, "story.title", "Welkom — titel", "Welkom!", null },
                    { 11, "story.text", "Welkom — tekst", "Met heel veel plezier nodigen wij jullie uit voor onze bruiloft. Het wordt een onvergetelijke dag en we hopen dat jullie erbij zijn om dit samen met ons te vieren!", null },
                    { 12, "fullphoto.quote", "Foto — quote", "\"De beste dingen in het leven zijn de mensen van wie je houdt, de plekken waar je bent geweest en de herinneringen die je hebt gemaakt.\"", null },
                    { 13, "planning.title", "Programma — titel", "Programma", null },
                    { 14, "planning.subtitle", "Programma — ondertitel", "Een overzicht van de dag", null },
                    { 15, "location.title", "Locatie — titel", "Locatie", null },
                    { 16, "footer.names", "Footer — namen", "José & Laura", null },
                    { 17, "footer.date", "Footer — datum", "17 · 10 · 2026", null },
                    { 18, "faq.title", "FAQ — titel", "Veelgestelde vragen", null },
                    { 19, "wedding.date", "Trouwdatum (voor aftelteller)", "2026-10-17", null },
                    { 20, "dresscode.title", "Dresscode — titel", "Dresscode", null },
                    { 21, "dresscode.subtitle", "Dresscode — ondertitel", "Wij vragen onze gasten om zich te kleden in de volgende kleurtinten", "We kindly ask our guests to dress in the following colour tones" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_GuestId",
                table: "Attendances",
                column: "GuestId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GeneralNoteComments_AttachmentId",
                table: "GeneralNoteComments",
                column: "AttachmentId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralNoteComments_CreatedById",
                table: "GeneralNoteComments",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralNoteComments_GeneralNoteEntryId",
                table: "GeneralNoteComments",
                column: "GeneralNoteEntryId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralNoteComments_ParentCommentId",
                table: "GeneralNoteComments",
                column: "ParentCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralNoteEntries_AttachmentId",
                table: "GeneralNoteEntries",
                column: "AttachmentId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralNoteEntries_CreatedById",
                table: "GeneralNoteEntries",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_PhotoSessionGuests_GuestId",
                table: "PhotoSessionGuests",
                column: "GuestId");

            migrationBuilder.CreateIndex(
                name: "IX_PhotoSessionGuests_PhotoSessionId_GuestId",
                table: "PhotoSessionGuests",
                columns: new[] { "PhotoSessionId", "GuestId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlanningAttachments_UploadedById",
                table: "PlanningAttachments",
                column: "UploadedById");

            migrationBuilder.CreateIndex(
                name: "IX_PlanningAuditLogs_NoteId",
                table: "PlanningAuditLogs",
                column: "NoteId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanningAuditLogs_NoteId_Timestamp",
                table: "PlanningAuditLogs",
                columns: new[] { "NoteId", "Timestamp" });

            migrationBuilder.CreateIndex(
                name: "IX_PlanningAuditLogs_Timestamp",
                table: "PlanningAuditLogs",
                column: "Timestamp");

            migrationBuilder.CreateIndex(
                name: "IX_PlanningAuditLogs_UserId",
                table: "PlanningAuditLogs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanningBlocks_AssignedToId",
                table: "PlanningBlocks",
                column: "AssignedToId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanningBlocks_AttachmentId",
                table: "PlanningBlocks",
                column: "AttachmentId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanningBlocks_NoteId",
                table: "PlanningBlocks",
                column: "NoteId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanningComments_AttachmentId",
                table: "PlanningComments",
                column: "AttachmentId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanningComments_BlockId",
                table: "PlanningComments",
                column: "BlockId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanningComments_CreatedById",
                table: "PlanningComments",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_PlanningComments_ParentCommentId",
                table: "PlanningComments",
                column: "ParentCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanningNotes_AssignedToId",
                table: "PlanningNotes",
                column: "AssignedToId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanningNotes_CategoryId",
                table: "PlanningNotes",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanningNotes_CreatedById",
                table: "PlanningNotes",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_PlanningNotes_Deadline",
                table: "PlanningNotes",
                column: "Deadline");

            migrationBuilder.CreateIndex(
                name: "IX_PlanningNotes_Status",
                table: "PlanningNotes",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_PlanningNotes_UpdatedById",
                table: "PlanningNotes",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_PlanningNoteVersions_CreatedById",
                table: "PlanningNoteVersions",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_PlanningNoteVersions_NoteId_VersionNumber",
                table: "PlanningNoteVersions",
                columns: new[] { "NoteId", "VersionNumber" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Plays_AttendanceId",
                table: "Plays",
                column: "AttendanceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleItems_ParentId",
                table: "ScheduleItems",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_SiteImages_Slot",
                table: "SiteImages",
                column: "Slot",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SiteTexts_Key",
                table: "SiteTexts",
                column: "Key",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserBlockVisits_BlockId",
                table: "UserBlockVisits",
                column: "BlockId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBlockVisits_UserId_BlockId",
                table: "UserBlockVisits",
                columns: new[] { "UserId", "BlockId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserNoteVisits_NoteId",
                table: "UserNoteVisits",
                column: "NoteId");

            migrationBuilder.CreateIndex(
                name: "IX_UserNoteVisits_UserId_NoteId",
                table: "UserNoteVisits",
                columns: new[] { "UserId", "NoteId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VisitorLogs_VisitedAt",
                table: "VisitorLogs",
                column: "VisitedAt");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactInfos");

            migrationBuilder.DropTable(
                name: "DressCodeColors");

            migrationBuilder.DropTable(
                name: "FaqItems");

            migrationBuilder.DropTable(
                name: "GeneralNoteComments");

            migrationBuilder.DropTable(
                name: "PhotoSessionGuests");

            migrationBuilder.DropTable(
                name: "PlanningAuditLogs");

            migrationBuilder.DropTable(
                name: "PlanningComments");

            migrationBuilder.DropTable(
                name: "PlanningNoteVersions");

            migrationBuilder.DropTable(
                name: "Plays");

            migrationBuilder.DropTable(
                name: "ScheduleItems");

            migrationBuilder.DropTable(
                name: "SiteImages");

            migrationBuilder.DropTable(
                name: "SiteTexts");

            migrationBuilder.DropTable(
                name: "UserBlockVisits");

            migrationBuilder.DropTable(
                name: "UserNoteVisits");

            migrationBuilder.DropTable(
                name: "VisitorLogs");

            migrationBuilder.DropTable(
                name: "GeneralNoteEntries");

            migrationBuilder.DropTable(
                name: "PhotoSessions");

            migrationBuilder.DropTable(
                name: "Attendances");

            migrationBuilder.DropTable(
                name: "PlanningBlocks");

            migrationBuilder.DropTable(
                name: "Guests");

            migrationBuilder.DropTable(
                name: "PlanningAttachments");

            migrationBuilder.DropTable(
                name: "PlanningNotes");

            migrationBuilder.DropTable(
                name: "AdminUsers");

            migrationBuilder.DropTable(
                name: "PlanningCategories");
        }
    }
}
