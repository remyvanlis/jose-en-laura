using Microsoft.EntityFrameworkCore;
using JoseEnLaura.Data.Models;

namespace JoseEnLaura.Data;

public class WeddingDbContext : DbContext
{
    public WeddingDbContext(DbContextOptions<WeddingDbContext> options) : base(options) { }

    public DbSet<AdminUser> AdminUsers => Set<AdminUser>();
    public DbSet<Guest> Guests => Set<Guest>();
    public DbSet<Attendance> Attendances => Set<Attendance>();
    public DbSet<Play> Plays => Set<Play>();
    public DbSet<SiteText> SiteTexts => Set<SiteText>();
    public DbSet<FaqItem> FaqItems => Set<FaqItem>();
    public DbSet<ScheduleItem> ScheduleItems => Set<ScheduleItem>();
    public DbSet<ContactInfo> ContactInfos => Set<ContactInfo>();
    public DbSet<SiteImage> SiteImages => Set<SiteImage>();
    public DbSet<DressCodeColor> DressCodeColors => Set<DressCodeColor>();
    public DbSet<WeddingLocation> WeddingLocations => Set<WeddingLocation>();
    
    
    // Planning module
    public DbSet<PlanningCategory> PlanningCategories => Set<PlanningCategory>();
    public DbSet<PlanningNote> PlanningNotes => Set<PlanningNote>();
    public DbSet<PlanningBlock> PlanningBlocks => Set<PlanningBlock>();
    public DbSet<PlanningNoteVersion> PlanningNoteVersions => Set<PlanningNoteVersion>();
    public DbSet<PlanningAuditLog> PlanningAuditLogs => Set<PlanningAuditLog>();
    public DbSet<PlanningAttachment> PlanningAttachments => Set<PlanningAttachment>();
    public DbSet<PlanningComment> PlanningComments => Set<PlanningComment>();
    public DbSet<UserNoteVisit> UserNoteVisits => Set<UserNoteVisit>();
    public DbSet<UserBlockVisit> UserBlockVisits => Set<UserBlockVisit>();
    public DbSet<GeneralNoteEntry> GeneralNoteEntries => Set<GeneralNoteEntry>();
    public DbSet<GeneralNoteComment> GeneralNoteComments => Set<GeneralNoteComment>();
    public DbSet<VisitorLog> VisitorLogs => Set<VisitorLog>();
    
    // Photo session module
    public DbSet<PhotoSession> PhotoSessions => Set<PhotoSession>();
    public DbSet<PhotoSessionGuest> PhotoSessionGuests => Set<PhotoSessionGuest>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // AdminUser
        modelBuilder.Entity<AdminUser>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.Name).HasMaxLength(100).IsRequired();
            e.Property(x => x.PasswordHash).HasMaxLength(200);
            e.Property(x => x.Role).HasConversion<string>().HasMaxLength(20);
        });

        // Guest
        modelBuilder.Entity<Guest>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.FullName).HasMaxLength(200).IsRequired();
            e.Property(x => x.InvitedFor).HasConversion<string>().HasMaxLength(20);
            e.HasOne(x => x.Attendance)
                .WithOne(x => x.Guest)
                .HasForeignKey<Attendance>(x => x.GuestId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        // Attendance
        modelBuilder.Entity<Attendance>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.DietaryNotes).HasMaxLength(500);
            e.Property(x => x.Message).HasMaxLength(1000);
            e.HasOne(x => x.Play)
                .WithOne(x => x.Attendance)
                .HasForeignKey<Play>(x => x.AttendanceId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        // Play
        modelBuilder.Entity<Play>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.Requirements).HasMaxLength(500);
        });

        // Seed admin users
        modelBuilder.Entity<AdminUser>().HasData(
            new AdminUser { Id = 1, Name = "Lianne", Role = AdminRole.CeremonyMaster },
            new AdminUser { Id = 2, Name = "Chris", Role = AdminRole.CeremonyMaster },
            new AdminUser { Id = 3, Name = "José", Role = AdminRole.Standard },
            new AdminUser { Id = 4, Name = "Laura", Role = AdminRole.Standard }
        );

        // SiteText
        modelBuilder.Entity<SiteText>(e =>
        {
            e.HasKey(x => x.Id);
            e.HasIndex(x => x.Key).IsUnique();
            e.Property(x => x.Key).HasMaxLength(100).IsRequired();
            e.Property(x => x.Value).HasMaxLength(2000).IsRequired();
            e.Property(x => x.ValueEn).HasMaxLength(2000);
            e.Property(x => x.Label).HasMaxLength(200).IsRequired();
        });

        // FaqItem
        modelBuilder.Entity<FaqItem>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.Question).HasMaxLength(500).IsRequired();
            e.Property(x => x.QuestionEn).HasMaxLength(500);
            e.Property(x => x.Answer).HasMaxLength(2000).IsRequired();
            e.Property(x => x.AnswerEn).HasMaxLength(2000);
        });

        // Seed site texts
        modelBuilder.Entity<SiteText>().HasData(
            new SiteText { Id = 1, Key = "hero.pre", Label = "Hero — bovenste tekst", Value = "Wij gaan trouwen!" },
            new SiteText { Id = 2, Key = "hero.title", Label = "Hero — titel", Value = "José & Laura" },
            new SiteText { Id = 3, Key = "hero.date", Label = "Hero — datum", Value = "17 oktober 2026" },
            new SiteText { Id = 4, Key = "rsvp.title", Label = "RSVP — titel", Value = "Aanwezigheid indienen" },
            new SiteText { Id = 5, Key = "rsvp.subtitle", Label = "RSVP — ondertitel", Value = "Laat ons weten of je erbij bent — graag vóór 17 september 2026" },
            new SiteText { Id = 6, Key = "rsvp.success.attending", Label = "RSVP — bevestiging (aanwezig)", Value = "Wat fijn dat je erbij bent! We kijken ernaar uit." },
            new SiteText { Id = 7, Key = "rsvp.success.notattending", Label = "RSVP — bevestiging (niet aanwezig)", Value = "We hebben je antwoord opgeslagen. Hopelijk zien we je snel!" },
            new SiteText { Id = 8, Key = "help.title", Label = "Hulp nodig — titel", Value = "Hulp nodig?" },
            new SiteText { Id = 9, Key = "help.subtitle", Label = "Hulp nodig — ondertitel", Value = "Kom je er niet uit? Kies dan één van onderstaande contactopties:" },
            new SiteText { Id = 10, Key = "story.title", Label = "Welkom — titel", Value = "Welkom!" },
            new SiteText { Id = 11, Key = "story.text", Label = "Welkom — tekst", Value = "Met heel veel plezier nodigen wij jullie uit voor onze bruiloft. Het wordt een onvergetelijke dag en we hopen dat jullie erbij zijn om dit samen met ons te vieren!" },
            new SiteText { Id = 12, Key = "fullphoto.quote", Label = "Foto — quote", Value = "\"De beste dingen in het leven zijn de mensen van wie je houdt, de plekken waar je bent geweest en de herinneringen die je hebt gemaakt.\"" },
            new SiteText { Id = 13, Key = "planning.title", Label = "Programma — titel", Value = "Programma" },
            new SiteText { Id = 14, Key = "planning.subtitle", Label = "Programma — ondertitel", Value = "Een overzicht van de dag" },
            new SiteText { Id = 15, Key = "location.title", Label = "Locatie — titel", Value = "Locatie" },
            new SiteText { Id = 16, Key = "footer.names", Label = "Footer — namen", Value = "José & Laura" },
            new SiteText { Id = 17, Key = "footer.date", Label = "Footer — datum", Value = "17 · 10 · 2026" },
            new SiteText { Id = 18, Key = "faq.title", Label = "FAQ — titel", Value = "Veelgestelde vragen" },
            new SiteText { Id = 19, Key = "wedding.date", Label = "Trouwdatum (voor aftelteller)", Value = "2026-10-17" },
            new SiteText { Id = 20, Key = "dresscode.title", Label = "Dresscode — titel", Value = "Dresscode" },
            new SiteText { Id = 21, Key = "dresscode.subtitle", Label = "Dresscode — ondertitel", Value = "Wij vragen onze gasten om zich te kleden in de volgende kleurtinten", ValueEn = "We kindly ask our guests to dress in the following colour tones" }
        );

        // Seed FAQ items
        modelBuilder.Entity<FaqItem>().HasData(
            new FaqItem { Id = 1, Question = "Zijn kinderen welkom?", Answer = "Alleen als ze expliciet zijn uitgenodigd.", SortOrder = 1 },
            new FaqItem { Id = 2, Question = "Mag ik een +1 meenemen?", Answer = "In overleg.", SortOrder = 2 },
            new FaqItem { Id = 3, Question = "Tot wanneer kan ik mijn aanwezigheid doorgeven?", Answer = "16 april.", SortOrder = 3 },
            new FaqItem { Id = 4, Question = "Wat moet ik doen als ik ziek ben?", Answer = "Meld je af door te mailen naar het e-mail adres: huwelijkremyenmarit@hotmail.com.", SortOrder = 4 },
            new FaqItem { Id = 5, Question = "Wat voor vervoer is er mogelijk naar de locatie?", Answer = "Met het OV is het vanaf de dichtstbijzijnde bushalte 3 minuten lopen (280m).\nMet de auto zijn er genoeg parkeerplaatsen!\nJe altijd zelf een taxi huren.\nKen je iemand die mee gaat? Misschien kan je meerijden!", SortOrder = 5 },
            new FaqItem { Id = 6, Question = "Wilt u met de taxi komen?", Answer = "U kan contact opnemen met bijvoorbeeld één van deze bedrijven:\ninsert taxi company nearby...", SortOrder = 6 }
        );

        // ScheduleItem
        modelBuilder.Entity<ScheduleItem>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.Time).HasMaxLength(20).IsRequired();
            e.Property(x => x.Title).HasMaxLength(200).IsRequired();
            e.Property(x => x.TitleEn).HasMaxLength(200);
            e.Property(x => x.Description).HasMaxLength(500);
            e.Property(x => x.DescriptionEn).HasMaxLength(500);
            e.HasOne(x => x.Parent)
                .WithMany(x => x.Children)
                .HasForeignKey(x => x.ParentId)
                .OnDelete(DeleteBehavior.NoAction);
        });

        // ContactInfo
        modelBuilder.Entity<ContactInfo>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.Name).HasMaxLength(100).IsRequired();
            e.Property(x => x.Phone).HasMaxLength(50).IsRequired();
            e.Property(x => x.Email).HasMaxLength(200).IsRequired();
        });

        // Seed schedule items
        modelBuilder.Entity<ScheduleItem>().HasData(
            new ScheduleItem { Id = 1, Time = "13:30", Title = "Ontvangst", Description = "Welkom met een drankje", SortOrder = 1 },
            new ScheduleItem { Id = 2, Time = "14:00", Title = "Ceremonie", Description = "De trouwceremonie", SortOrder = 2 },
            new ScheduleItem { Id = 3, Time = "15:00", Title = "Toost & Felicitaties", Description = "Proosten op het bruidspaar", SortOrder = 3 },
            new ScheduleItem { Id = 4, Time = "16:00", Title = "Groepsfoto's", Description = "Foto's met familie en vrienden", SortOrder = 4 },
            new ScheduleItem { Id = 5, Time = "17:30", Title = "Diner", Description = "Samen genieten van een heerlijk diner", SortOrder = 5 },
            new ScheduleItem { Id = 6, Time = "19:00", Title = "Avondfeest", Description = "Dansen en feesten!", SortOrder = 6 },
            new ScheduleItem { Id = 7, Time = "20:30", Title = "Bruidstaart", Description = "Het aansnijden van de taart (lekker op tijd om 20.30 lol)", SortOrder = 7 },
            new ScheduleItem { Id = 8, Time = "00:00", Title = "Afsluiting", Description = "Bedankt voor deze mooie dag!", SortOrder = 8 }
        );

        // Seed contact info
        modelBuilder.Entity<ContactInfo>().HasData(
            new ContactInfo { Id = 1, Name = "Lianne", Phone = "0612345678", Email = "huwelijkjoseenlaura@hotmail.com", SortOrder = 1 },
            new ContactInfo { Id = 2, Name = "Chris", Phone = "0612345678", Email = "huwelijkjoseenlaura@hotmail.com", SortOrder = 2 }
        );

        // SiteImage
        modelBuilder.Entity<SiteImage>(e =>
        {
            e.HasKey(x => x.Id);
            e.HasIndex(x => x.Slot).IsUnique();
            e.Property(x => x.Name).HasMaxLength(200).IsRequired();
            e.Property(x => x.Slot).HasMaxLength(100).IsRequired();
            e.Property(x => x.FileName).HasMaxLength(300).IsRequired();
            e.Property(x => x.ContentType).HasMaxLength(100).IsRequired();
            e.Property(x => x.Data).IsRequired();
        });

        // DressCodeColor
        modelBuilder.Entity<DressCodeColor>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.Hex).HasMaxLength(20).IsRequired();
            e.Property(x => x.NameNl).HasMaxLength(50).IsRequired();
            e.Property(x => x.NameEn).HasMaxLength(50);
        });

        // Seed dress-code colours (blush / rose palette)
        modelBuilder.Entity<DressCodeColor>().HasData(
            new DressCodeColor { Id = 1, Hex = "#FBF1EE", NameNl = "Crème", NameEn = "Cream", SortOrder = 1 },
            new DressCodeColor { Id = 2, Hex = "#EFD3D0", NameNl = "Blush", NameEn = "Blush", SortOrder = 2 },
            new DressCodeColor { Id = 3, Hex = "#DDB3B8", NameNl = "Rosé", NameEn = "Rosé", SortOrder = 3 },
            new DressCodeColor { Id = 4, Hex = "#C98B96", NameNl = "Oudroze", NameEn = "Dusty Rose", SortOrder = 4 },
            new DressCodeColor { Id = 5, Hex = "#A85D6E", NameNl = "Mauve", NameEn = "Mauve", SortOrder = 5 },
            new DressCodeColor { Id = 6, Hex = "#7A4F54", NameNl = "Pruim", NameEn = "Plum", SortOrder = 6 }
        );

        // WeddingLocation
        modelBuilder.Entity<WeddingLocation>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.Title).HasMaxLength(100).IsRequired();
            e.Property(x => x.TitleEn).HasMaxLength(100);
            e.Property(x => x.Icon).HasMaxLength(50).IsRequired();
            e.Property(x => x.VenueName).HasMaxLength(200).IsRequired();
            e.Property(x => x.AddressLine1).HasMaxLength(200).IsRequired();
            e.Property(x => x.AddressLine2).HasMaxLength(200);
            e.Property(x => x.Phone).HasMaxLength(50);
        });

        // Seed wedding locations (matches the original hard-coded home page cards)
        modelBuilder.Entity<WeddingLocation>().HasData(
            new WeddingLocation { Id = 1, Title = "Ceremonie", TitleEn = "Ceremony", Icon = "&#9962;", VenueName = "Kampkuiper", AddressLine1 = "Almeloseweg 113, 7615 NA", AddressLine2 = "Harbrinkhoek", Phone = "0546 629 962", SortOrder = 1 },
            new WeddingLocation { Id = 2, Title = "Diner", TitleEn = "Dinner", Icon = "&#127860;", VenueName = "Kampkuiper", AddressLine1 = "Almeloseweg 113, 7615 NA", AddressLine2 = "Harbrinkhoek", Phone = "0546 629 962", SortOrder = 2 },
            new WeddingLocation { Id = 3, Title = "Feest", TitleEn = "Party", Icon = "&#127878;", VenueName = "Kampkuiper", AddressLine1 = "Almeloseweg 113, 7615 NA", AddressLine2 = "Harbrinkhoek", Phone = "0546 629 962", SortOrder = 3 }
        );

        // ==========================================
        // PLANNING MODULE
        // ==========================================
        
        // PlanningCategory
        modelBuilder.Entity<PlanningCategory>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.Name).HasMaxLength(200).IsRequired();
            e.Property(x => x.Icon).HasMaxLength(50);
            e.Property(x => x.Color).HasMaxLength(50);
            e.HasMany(x => x.Notes)
                .WithOne(x => x.Category)
                .HasForeignKey(x => x.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        // PlanningNote
        modelBuilder.Entity<PlanningNote>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.Title).HasMaxLength(500).IsRequired();
            e.Property(x => x.Status).HasConversion<string>().HasMaxLength(30);
            e.HasOne(x => x.AssignedTo).WithMany().HasForeignKey(x => x.AssignedToId).OnDelete(DeleteBehavior.NoAction);
            e.HasOne(x => x.CreatedBy).WithMany().HasForeignKey(x => x.CreatedById).OnDelete(DeleteBehavior.NoAction);
            e.HasOne(x => x.UpdatedBy).WithMany().HasForeignKey(x => x.UpdatedById).OnDelete(DeleteBehavior.NoAction);
            e.HasMany(x => x.Blocks).WithOne(x => x.Note).HasForeignKey(x => x.NoteId).OnDelete(DeleteBehavior.Cascade);
            e.HasMany(x => x.Versions).WithOne(x => x.Note).HasForeignKey(x => x.NoteId).OnDelete(DeleteBehavior.Cascade);
            e.HasMany(x => x.AuditLogs).WithOne(x => x.Note).HasForeignKey(x => x.NoteId).OnDelete(DeleteBehavior.Cascade);
            e.HasIndex(x => x.CategoryId);
            e.HasIndex(x => x.Status);
            e.HasIndex(x => x.Deadline);
        });

        // PlanningBlock
        modelBuilder.Entity<PlanningBlock>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.Content).HasMaxLength(5000);
            e.Property(x => x.Type).HasConversion<string>().HasMaxLength(20);
            e.Property(x => x.ItemStatus).HasConversion<string>().HasMaxLength(20);
            e.Property(x => x.Priority).HasConversion<string>().HasMaxLength(10);
            e.HasOne(x => x.AssignedTo).WithMany().HasForeignKey(x => x.AssignedToId).OnDelete(DeleteBehavior.NoAction);
            e.HasOne(x => x.Attachment).WithMany().HasForeignKey(x => x.AttachmentId).OnDelete(DeleteBehavior.SetNull);
            e.HasMany(x => x.Comments).WithOne(x => x.Block).HasForeignKey(x => x.BlockId).OnDelete(DeleteBehavior.Cascade);
            e.HasIndex(x => x.NoteId);
            e.HasIndex(x => x.AssignedToId);
        });

        // PlanningComment
        modelBuilder.Entity<PlanningComment>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.Content).HasMaxLength(2000).IsRequired();
            e.Property(x => x.MentionedUserIds).HasMaxLength(500);
            e.HasOne(x => x.CreatedBy).WithMany().HasForeignKey(x => x.CreatedById).OnDelete(DeleteBehavior.NoAction);
            e.HasOne(x => x.Attachment).WithMany().HasForeignKey(x => x.AttachmentId).OnDelete(DeleteBehavior.SetNull);
            e.HasIndex(x => x.BlockId);
        });

        // PlanningNoteVersion
        modelBuilder.Entity<PlanningNoteVersion>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.SnapshotJson).IsRequired();
            e.Property(x => x.Title).HasMaxLength(500);
            e.Property(x => x.Status).HasConversion<string>().HasMaxLength(30);
            e.HasOne(x => x.CreatedBy).WithMany().HasForeignKey(x => x.CreatedById).OnDelete(DeleteBehavior.NoAction);
            e.HasIndex(x => new { x.NoteId, x.VersionNumber }).IsUnique();
        });

        // PlanningAuditLog
        modelBuilder.Entity<PlanningAuditLog>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.Action).HasMaxLength(100).IsRequired();
            e.Property(x => x.Details).HasMaxLength(4000);
            e.HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.NoAction);
            e.HasIndex(x => x.NoteId);
            e.HasIndex(x => x.Timestamp);
            e.HasIndex(x => new { x.NoteId, x.Timestamp });
        });

        // UserNoteVisit
        modelBuilder.Entity<UserNoteVisit>(e =>
        {
            e.HasKey(x => x.Id);
            e.HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Cascade);
            e.HasOne(x => x.Note).WithMany().HasForeignKey(x => x.NoteId).OnDelete(DeleteBehavior.Cascade);
            e.HasIndex(x => new { x.UserId, x.NoteId }).IsUnique();
        });

        // PlanningAttachment
        modelBuilder.Entity<PlanningAttachment>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.FileName).HasMaxLength(300).IsRequired();
            e.Property(x => x.ContentType).HasMaxLength(100).IsRequired();
            e.Property(x => x.Data).IsRequired();
            e.HasOne(x => x.UploadedBy).WithMany().HasForeignKey(x => x.UploadedById).OnDelete(DeleteBehavior.NoAction);
        });

        // GeneralNoteEntry
        modelBuilder.Entity<GeneralNoteEntry>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.Content).HasMaxLength(5000).IsRequired();
            e.Property(x => x.MentionedUserIds).HasMaxLength(500);
            e.HasOne(x => x.CreatedBy).WithMany().HasForeignKey(x => x.CreatedById).OnDelete(DeleteBehavior.NoAction);
            e.HasOne(x => x.Attachment).WithMany().HasForeignKey(x => x.AttachmentId).OnDelete(DeleteBehavior.SetNull);
        });

        // UserBlockVisit
        modelBuilder.Entity<UserBlockVisit>(e =>
        {
            e.HasKey(x => x.Id);
            e.HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Cascade);
            e.HasOne(x => x.Block).WithMany().HasForeignKey(x => x.BlockId).OnDelete(DeleteBehavior.Cascade);
            e.HasIndex(x => new { x.UserId, x.BlockId }).IsUnique();
        });

        // PlanningComment – self-referencing for reply threading
        modelBuilder.Entity<PlanningComment>(e =>
        {
            e.HasOne(x => x.ParentComment)
                .WithMany(x => x.Replies)
                .HasForeignKey(x => x.ParentCommentId)
                .OnDelete(DeleteBehavior.NoAction);
        });

        // GeneralNoteComment
        modelBuilder.Entity<GeneralNoteComment>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.Content).HasMaxLength(5000).IsRequired();
            e.Property(x => x.MentionedUserIds).HasMaxLength(500);
            e.HasOne(x => x.GeneralNoteEntry).WithMany(x => x.Comments).HasForeignKey(x => x.GeneralNoteEntryId).OnDelete(DeleteBehavior.Cascade);
            e.HasOne(x => x.CreatedBy).WithMany().HasForeignKey(x => x.CreatedById).OnDelete(DeleteBehavior.NoAction);
            e.HasOne(x => x.Attachment).WithMany().HasForeignKey(x => x.AttachmentId).OnDelete(DeleteBehavior.SetNull);
            e.HasOne(x => x.ParentComment)
                .WithMany(x => x.Replies)
                .HasForeignKey(x => x.ParentCommentId)
                .OnDelete(DeleteBehavior.NoAction);
        });

        // VisitorLog
        modelBuilder.Entity<VisitorLog>(e =>
        {
            e.HasKey(x => x.Id);
            e.HasIndex(x => x.VisitedAt);
        });

        // ==========================================
        // PHOTO SESSION MODULE
        // ==========================================

        modelBuilder.Entity<PhotoSession>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.Name).HasMaxLength(300).IsRequired();
            e.HasMany(x => x.Guests)
                .WithOne(x => x.PhotoSession)
                .HasForeignKey(x => x.PhotoSessionId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<PhotoSessionGuest>(e =>
        {
            e.HasKey(x => x.Id);
            e.HasOne(x => x.Guest).WithMany().HasForeignKey(x => x.GuestId).OnDelete(DeleteBehavior.Cascade);
            e.HasIndex(x => new { x.PhotoSessionId, x.GuestId }).IsUnique();
        });

        // Seed default planning categories (fixed CreatedAt to avoid dynamic model warnings)
        var seedDate = new DateTime(2026, 3, 30, 0, 0, 0, DateTimeKind.Utc);
        modelBuilder.Entity<PlanningCategory>().HasData(
            new PlanningCategory { Id = 1, Name = "Ochtend", Icon = "🌅", Color = "#f4a261", SortOrder = 1, CreatedAt = seedDate },
            new PlanningCategory { Id = 2, Name = "Ceremonie", Icon = "💒", Color = "#e76f51", SortOrder = 2, CreatedAt = seedDate },
            new PlanningCategory { Id = 3, Name = "Foto's", Icon = "📸", Color = "#2a9d8f", SortOrder = 3, CreatedAt = seedDate },
            new PlanningCategory { Id = 4, Name = "Diner", Icon = "🍽️", Color = "#264653", SortOrder = 4, CreatedAt = seedDate },
            new PlanningCategory { Id = 5, Name = "Feest", Icon = "🎉", Color = "#e9c46a", SortOrder = 5, CreatedAt = seedDate },
            new PlanningCategory { Id = 6, Name = "Locatie", Icon = "📍", Color = "#606c38", SortOrder = 6, CreatedAt = seedDate },
            new PlanningCategory { Id = 7, Name = "Algemeen", Icon = "📋", Color = "#bc6c25", SortOrder = 7, CreatedAt = seedDate }
        );
    }
}

