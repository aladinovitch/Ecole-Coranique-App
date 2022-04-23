using Ecole_Coranique.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Ecole_Coranique.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) {
        }
        public DbSet<Enseignant> Enseignants { get; set; }
        public DbSet<Groupe> Groupes { get; set; }
        public DbSet<Etudiant> Etudiants { get; set; }
        public DbSet<Huitieme> Huitiemes { get; set; }
        public DbSet<Hizb> Hizbs { get; set; }
        public DbSet<Absence> Absences { get; set; }
        public DbSet<Revision> Revisions { get; set; }
        public DbSet<IdentificationEtudiant> IdentificationEtudiants { get; set; }
        public DbSet<IdentificationEnseignant> IdentificationEnseignants { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("ec");
            modelBuilder.Entity<Enseignant>().HasMany(x => x.EnseignantGroupes).WithOne(x => x.Enseignant).HasForeignKey(x => x.EnseignantId);
            modelBuilder.Entity<Groupe>().HasMany(x => x.GroupeEtudiants).WithOne(x => x.Groupe).HasForeignKey(x => x.GroupeId);
            modelBuilder.Entity<Etudiant>().HasMany(x => x.EtudiantAbsences).WithOne(x => x.Etudiant).HasForeignKey(x => x.EtudiantId);
            modelBuilder.Entity<Etudiant>().HasMany(x => x.EtudiantRevisions).WithOne(x => x.Etudiant).HasForeignKey(x => x.EtudiantId);
            modelBuilder.Entity<Huitieme>().HasMany(x => x.HuitiemeRevisions).WithOne(x => x.Huitieme).HasForeignKey(x => x.HuitiemeId);
            modelBuilder.Entity<Hizb>().HasMany(x => x.HizbRevisions).WithOne(x => x.Hizb).HasForeignKey(x => x.HizbId);
            modelBuilder.Entity<IdentificationEtudiant>().HasKey(x => x.EtudiantId);
            modelBuilder.Entity<IdentificationEtudiant>().HasOne(x => x.Etudiant).WithOne(x => x.Identification).HasForeignKey<IdentificationEtudiant>(x => x.EtudiantId);
            modelBuilder.Entity<IdentificationEnseignant>().HasKey(x => x.EnseignantId);
            modelBuilder.Entity<IdentificationEnseignant>().HasOne(x => x.Enseignant).WithOne(x => x.Identification).HasForeignKey<IdentificationEnseignant>(x => x.EnseignantId);

            SeedUsers(modelBuilder);
            SeedData(modelBuilder);
        }
        private static IdentityUser InitializeIdentityUser(string userId, string username, string password) {
            var identityUser = new IdentityUser {
                Id = userId, // Primary key
                Email = username,
                NormalizedEmail = username.ToUpper(),
                UserName = username,
                NormalizedUserName = username.ToUpper(),
                EmailConfirmed = true,
            };
            identityUser.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(identityUser, password);
            return identityUser;
        }
        private static void SeedUsers(ModelBuilder modelBuilder) {
            string ADMIN_ID = Guid.NewGuid().ToString();
            string TEACHER_ID = Guid.NewGuid().ToString();
            string STUDENT_ID = Guid.NewGuid().ToString();
            string password = "Pass_12345";
            var admin = InitializeIdentityUser(ADMIN_ID, "admin@email.com", password);
            var teacher = InitializeIdentityUser(TEACHER_ID, "teacher@email.com", password);
            var student = InitializeIdentityUser(STUDENT_ID, "student@email.com", password);
            // Seeding the User to AspNetUsers table
            modelBuilder.Entity<IdentityUser>().HasData(admin, teacher, student);
            modelBuilder.Entity<IdentityUserClaim<string>>().HasData(
               new IdentityUserClaim<string> { Id = 1, UserId = ADMIN_ID, ClaimType = AppClaimType.Concern, ClaimValue = AppClaimValue.Admin },
               new IdentityUserClaim<string> { Id = 2, UserId = TEACHER_ID, ClaimType = AppClaimType.Concern, ClaimValue = AppClaimValue.Teacher },
               new IdentityUserClaim<string> { Id = 3, UserId = STUDENT_ID, ClaimType = AppClaimType.Concern, ClaimValue = AppClaimValue.Student });
        }
        private static void SeedData(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Enseignant>().HasData(
                new Enseignant { Id = 1, Prenom = "سليمان", Nom = "سليماني", Phone = "05 10 10 10", Email = "sli.mane@gmail.com", Adresse = "حي ثنية الحجر، المدية" },
                new Enseignant { Id = 2, Prenom = "علي", Nom = "بن علي", Phone = "05 20 20 20", Email = "aliben@gmail.co", Adresse = "حي عين الذهب، المدية" },
                new Enseignant { Id = 3, Prenom = "سهيلة", Nom = "سنوسي", Phone = "05 30 30 30", Email = "ss.bousahla@gmail.com", Adresse = "حي المصلى، المدية" },
                new Enseignant { Id = 4, Prenom = "أمينة", Nom = "بن يمينة", Phone = "05 40 40 40", Email = "amina.ben@gmail.com", Adresse = "حي مرج الشكير، المدية" });

            modelBuilder.Entity<Groupe>().HasData(
                new Groupe { Id = 1, Numero = 1, Nom = "مجموعة البنات", EnseignantId = 3 },
                new Groupe { Id = 2, Numero = 2, Nom = "مجموعة الصباح", EnseignantId = 4 },
                new Groupe { Id = 3, Numero = 3, Nom = "مجموعة المساء", EnseignantId = 1 });

            modelBuilder.Entity<Etudiant>().HasData(
                new Etudiant { Id = 1, Prenom = "أحمد", Nom = "بوحمد", Naissance = DateTime.Parse("2001-12-11"), Phone = "05 01 01 01", Email = "ahmed.mido@gmail.com", Adresse = "حي تاكبو، المدية", GroupeId = 3 },
                new Etudiant { Id = 2, Prenom = "أرزقي", Nom = "بن رزقي", Naissance = DateTime.Parse("1978-03-10"), Phone = "05 02 02 02", Email = "arezki.rzk@gmail.com", Adresse = "حي الزهور، بجاية", GroupeId = 3 },
                new Etudiant { Id = 3, Prenom = "عمر", Nom = "بوعمر", Naissance = DateTime.Parse("1963-01-12"), Phone = "05 03 03 03", Email = "amerrr@gmail.com", Adresse = "حى باب القواس، المدية", GroupeId = 3 },
                new Etudiant { Id = 4, Prenom = "سفيان", Nom = "سيدو", Naissance = DateTime.Parse("1990-02-03"), Phone = "05 04 04 04", Email = "so.sidou33@bmail.com", Adresse = "مدينة الصخور، الرغاية", GroupeId = 2 },
                new Etudiant { Id = 5, Prenom = "سميحة", Nom = "سليمة", Naissance = DateTime.Parse("1998-12-12"), Phone = "05 05 05 05", Email = "samimi@gmail.com", Adresse = "حي بولوغين، الجزائر العاصمة", GroupeId = 1 },
                new Etudiant { Id = 6, Prenom = "فاطمة", Nom = "بوفطوم", Naissance = DateTime.Parse("2005-02-01"), Phone = "05 06 06 06", Email = "fati.bb@gmail.com", Adresse = "حي خمسة منازل، الجزائر العاصمة", GroupeId = 1 },
                new Etudiant { Id = 7, Prenom = "سميرة", Nom = "بو سمار", Naissance = DateTime.Parse("1999-01-13"), Phone = "05 07 07 07", Email = "bousemar.sam@gmail.com", Adresse = "طريق الأكاسيا، المدية", GroupeId = 1 });

            modelBuilder.Entity<Absence>().HasData(
                new Absence { Id = 1, Date = DateTime.Parse("2022-01-01"), Observation = "مشغول", EtudiantId = 1 },
                new Absence { Id = 2, Date = DateTime.Parse("2022-01-05"), Observation = "غير مبرر", EtudiantId = 1 },
                new Absence { Id = 3, Date = DateTime.Parse("2022-01-06"), Observation = "شؤون عائلية", EtudiantId = 3 },
                new Absence { Id = 4, Date = DateTime.Parse("2022-01-07"), Observation = "حركة المرور", EtudiantId = 3 },
                new Absence { Id = 5, Date = DateTime.Parse("2022-01-12"), Observation = "عرس", EtudiantId = 4 },
                new Absence { Id = 6, Date = DateTime.Parse("2022-01-13"), Observation = "مشغول", EtudiantId = 1 },
                new Absence { Id = 7, Date = DateTime.Parse("2022-01-13"), Observation = "غير مبرر", EtudiantId = 2 },
                new Absence { Id = 8, Date = DateTime.Parse("2022-01-14"), Observation = "غير مبرر", EtudiantId = 1 },
                new Absence { Id = 9, Date = DateTime.Parse("2022-01-15"), Observation = "خرجة عائلية", EtudiantId = 1 },
                new Absence { Id = 10, Date = DateTime.Parse("2022-01-14"), Observation = "نسيان", EtudiantId = 2 },
                new Absence { Id = 11, Date = DateTime.Parse("2022-01-15"), Observation = "مراجعة إمتحان", EtudiantId = 2 },
                new Absence { Id = 12, Date = DateTime.Parse("2022-01-16"), Observation = "تفرج مبارات", EtudiantId = 2 },
                new Absence { Id = 13, Date = DateTime.Parse("2022-01-13"), Observation = "رحلة", EtudiantId = 4 },
                new Absence { Id = 14, Date = DateTime.Parse("2022-01-14"), Observation = "شؤون تجارية", EtudiantId = 3 },
                new Absence { Id = 15, Date = DateTime.Parse("2022-01-14"), Observation = "شؤون تجارية", EtudiantId = 3 },
                new Absence { Id = 16, Date = DateTime.Parse("2022-01-14"), Observation = "غير مبرر", EtudiantId = 4 });

            modelBuilder.Entity<Huitieme>().HasData(
                new Huitieme { Id = 1, Numero = 1, Nom = "الأول" },
                new Huitieme { Id = 2, Numero = 2, Nom = "الثاني" },
                new Huitieme { Id = 3, Numero = 3, Nom = "الثالث" },
                new Huitieme { Id = 4, Numero = 4, Nom = "الرابع" },
                new Huitieme { Id = 5, Numero = 5, Nom = "الخامس" },
                new Huitieme { Id = 6, Numero = 6, Nom = "السادس" },
                new Huitieme { Id = 7, Numero = 7, Nom = "السابع" },
                new Huitieme { Id = 8, Numero = 8, Nom = "الثامن" });

            // Data from:
            // https://amgpm-4.blogspot.com/
            // https://ar.wikipedia.org/wiki/%D8%AC%D8%B2%D8%A1_(%D9%82%D8%B1%D8%A2%D9%86)
            // https://en.wikipedia.org/wiki/Juz%27

            modelBuilder.Entity<Hizb>().HasData(
                new Hizb { Id = 1, Numero = 1, Nom = "الحزب 01", Description = "( ٱلْحَمْدُ لِلَّهِ ) من الفاتحة (1:1) سورة البقرة (2:74)" },
                new Hizb { Id = 2, Numero = 2, Nom = "الحزب 02", Description = "( واذا لقوا ) من سورة البقرة (2:75) إلى (2:141)" },
                new Hizb { Id = 3, Numero = 3, Nom = "الحزب 03", Description = "( سيقول السفهاء ) من سورة البقرة (2:142) إلى (2:202)" },
                new Hizb { Id = 4, Numero = 4, Nom = "الحزب 04", Description = "( واذكرواالله ) من سورة البقرة (2:203) إلى (2:252)" },
                new Hizb { Id = 5, Numero = 5, Nom = "الحزب 05", Description = "( تلك الرسل ) من سورة البقرة (2:253) إلى سورة أل عمران (3:14)" },
                new Hizb { Id = 6, Numero = 6, Nom = "الحزب 06", Description = "( قل أؤنبئكم ) من سورة أل عمران (3:15) إلى (3:92)" },
                new Hizb { Id = 7, Numero = 7, Nom = "الحزب 07", Description = "( لن تنالوا ) من سورة أل عمران (3:93) إلى (3:170)" },
                new Hizb { Id = 8, Numero = 8, Nom = "الحزب 08", Description = "( كُلُّ الطَّعَامِ ) من سورة أل عمران (3:171) إلى سورة النساء (4:23)" },
                new Hizb { Id = 9, Numero = 9, Nom = "الحزب 09", Description = "( وَٱلْمُحْصَنَاتُ ) من سورة النساء (4:24) إلى (4:87)" },
                new Hizb { Id = 10, Numero = 10, Nom = "الحزب 10", Description = "( الله لااله الاهو ) من سورة النساء (4:88) إلى (4:147)" },
                new Hizb { Id = 11, Numero = 11, Nom = "الحزب 11", Description = "( لَا يُحِبُّ ٱللهُ ) من سورة النساء (4:148) إلى سورة المائدة (5:26)" },
                new Hizb { Id = 12, Numero = 12, Nom = "الحزب 12", Description = "( قال رجلان ) من سورة المائدة (5:27) إلى (5:81)" },
                new Hizb { Id = 13, Numero = 13, Nom = "الحزب 13", Description = "( لتجدن ) من سورة المائدة (5:82) - سورة الأنعام (6:35)" },
                new Hizb { Id = 14, Numero = 14, Nom = "الحزب 14", Description = "( انما يستجيب ) من سورة الأنعام (6:36) إلى (6:110)" },
                new Hizb { Id = 15, Numero = 15, Nom = "الحزب 15", Description = "( ولو أننا نزلنا ) من سورة الأنعام (6:111) إلى (6:165)" },
                new Hizb { Id = 16, Numero = 16, Nom = "الحزب 16", Description = "( المص كتب ) من سورة الأعراف (7:1) إلى (7:87)" },
                new Hizb { Id = 17, Numero = 17, Nom = "الحزب 17", Description = "( قال الملأ ) من سورة الأعراف (7:88) إلى (7:170)" },
                new Hizb { Id = 18, Numero = 18, Nom = "الحزب 18", Description = "( واذ نتقنا ) من سورة الأعراف (7:171) إلى سورة الأنفال (8:40)" },
                new Hizb { Id = 19, Numero = 19, Nom = "الحزب 19", Description = "( واعلموا ) من سورة الأنفال (8:41)  إلى سورة التوبة (9:33)" },
                new Hizb { Id = 20, Numero = 20, Nom = "الحزب 20", Description = "( ان كثيرا ) من سورة التوبة (9:34) إلى (9:92)" },
                new Hizb { Id = 21, Numero = 21, Nom = "الحزب 21", Description = "( انما السبيل ) من سورة التوبة (9:93) إلى سورة يونس (10:25)" },
                new Hizb { Id = 22, Numero = 22, Nom = "الحزب 22", Description = "( للذين أحسنوا ) من سورة يونس (10:26) إلى سورة هود (11:5)" },
                new Hizb { Id = 23, Numero = 23, Nom = "الحزب 23", Description = "( ومامن دابة ) من سورة هود (11:6) إلى (11:83)" },
                new Hizb { Id = 24, Numero = 24, Nom = "الحزب 24", Description = "( والى مدين ) من سورة هود (11:84) إلى سورة يوسف (12:52)" },
                new Hizb { Id = 25, Numero = 25, Nom = "الحزب 25", Description = "( وما أبرئ ) من سورة يوسف (12:53) إلى سورة الرعد (13:18)" },
                new Hizb { Id = 26, Numero = 26, Nom = "الحزب 26", Description = "( أفمن يعلم ) من سورة الرعد (13:19) إلى سورة إبراهيم (14:52)" },
                new Hizb { Id = 27, Numero = 27, Nom = "الحزب 27", Description = "( ربما ) من سورة الحجر (15:1) إلى سورة النحل (16:50)" },
                new Hizb { Id = 28, Numero = 28, Nom = "الحزب 28", Description = "( وقال الله لا تتخذوا ) من سورة النحل (16:51) إلى (16:128)" },
                new Hizb { Id = 29, Numero = 29, Nom = "الحزب 29", Description = "( سبحن ) من سورة الاسراء (17:1) إلى (17:98)" },
                new Hizb { Id = 30, Numero = 30, Nom = "الحزب 30", Description = "( أولم يروا ) من سورة الاسراء (17:99) إلى سورة الكهف (18:74)" },
                new Hizb { Id = 31, Numero = 31, Nom = "الحزب 31", Description = "( قال ألم أقل ) من سورة الكهف (18:75) إلى سورة مريم (19:98)" },
                new Hizb { Id = 32, Numero = 32, Nom = "الحزب 32", Description = "( طه ) من سورة طه (20:1) إلى (20:135)" },
                new Hizb { Id = 33, Numero = 33, Nom = "الحزب 33", Description = "( اقترب ) من سورة الأنبياء (21:1) إلى (21:112)" },
                new Hizb { Id = 34, Numero = 34, Nom = "الحزب 34", Description = "( يأيها الناس ) من سورة الحج (22:1) إلى (22:78)" },
                new Hizb { Id = 35, Numero = 35, Nom = "الحزب 35", Description = "( قدأفلح ) من سورة المؤمنون (23:1) إلى سورة النور (24:20)" },
                new Hizb { Id = 36, Numero = 36, Nom = "الحزب 36", Description = "( لاتتبعوا ) من سورة النور (24:21) إلى سورة الفرقان (25:20)" },
                new Hizb { Id = 37, Numero = 37, Nom = "الحزب 37", Description = "( وقال الذين ) من سورة الفرقان (25:21) إلى سورة الشعراء (26:110)" },
                new Hizb { Id = 38, Numero = 38, Nom = "الحزب 38", Description = "( قالوا أنومن ) من سورة الشعراء (26:111)  إلى سورة النمل (27:55)" },
                new Hizb { Id = 39, Numero = 39, Nom = "الحزب 39", Description = "( فما كان جواب ) من سورة النمل (27:56) إلى سورة اقصص (28:50)" },
                new Hizb { Id = 40, Numero = 40, Nom = "الحزب 40", Description = "( ولقد وصلنا ) من سورة القصص (28:51)  إلى سورة العنكبوت (29:45)" },
                new Hizb { Id = 41, Numero = 41, Nom = "الحزب 41", Description = "( ولا تجادلوا ) من سورة العنكبوت (29:46) إلى سورة لقمان (31:21)" },
                new Hizb { Id = 42, Numero = 42, Nom = "الحزب 42", Description = "( ومن يسلم ) من سورة لقمن (31:22) إلى سورة الأحزاب (33:30)" },
                new Hizb { Id = 43, Numero = 43, Nom = "الحزب 43", Description = "( ومن يقنت ) من سورة الأحزاب (33:31) إلى سورة سبأ (34:23)" },
                new Hizb { Id = 44, Numero = 44, Nom = "الحزب 44", Description = "( قل من يرزقكم ) من سورة سبأ (34:24) إلى سورة يس (36:27)" },
                new Hizb { Id = 45, Numero = 45, Nom = "الحزب 45", Description = "( وماأنزلنا ) من سورة يس (36:28) إلى سورة الصفت (37:144)" },
                new Hizb { Id = 46, Numero = 46, Nom = "الحزب 46", Description = "( فنبذنه ) من سورة الصفت (37:145) إلى سورة الزمر (39:31)" },
                new Hizb { Id = 47, Numero = 47, Nom = "الحزب 47", Description = "( فمن أظلم ) من سورة الزمر (39:32) إلى سورة غافر (40:40)" },
                new Hizb { Id = 48, Numero = 48, Nom = "الحزب 48", Description = "( ويقوم مالي ) من سورة غافر (40:41) إلى سورة فصلت (41:46)" },
                new Hizb { Id = 49, Numero = 49, Nom = "الحزب 49", Description = "( اليه يرد ) من سورة فصلت (41:47) إلى سورة الزخرف (43:23)" },
                new Hizb { Id = 50, Numero = 50, Nom = "الحزب 50", Description = "( قل أولوجئتكم ) من سورة الزخرف (43:24) إلى سورة الجاثية (45:37)" },
                new Hizb { Id = 51, Numero = 51, Nom = "الحزب 51", Description = "( حم ماخلقنا ) من سورة الأحقاف (46:1) إلى سورة الفتح (48:17)" },
                new Hizb { Id = 52, Numero = 52, Nom = "الحزب 52", Description = "( لقد رضي ) من سورة الفتح (48:18) إلى سورة الذريات (51:30)" },
                new Hizb { Id = 53, Numero = 53, Nom = "الحزب 53", Description = "( قال فما خطبكم ) من سورة الذريات (51:31) إلى القمر (54:55)" },
                new Hizb { Id = 54, Numero = 54, Nom = "الحزب 54", Description = "( الرحمن ) من سورة الرحمن (55:1) إلى سورة الحديد (57:29)" },
                new Hizb { Id = 55, Numero = 55, Nom = "الحزب 55", Description = "( قد سمع ) من سورة المجادلة (58:1) إلى سورة الصف (61:14)" },
                new Hizb { Id = 56, Numero = 56, Nom = "الحزب 56", Description = "( يسبح لله ) من سورة الجمعة (62:1) إلى سورة التحريم (66:12)" },
                new Hizb { Id = 57, Numero = 57, Nom = "الحزب 57", Description = "( تبرك الذي ) من سورة الملك (67:1) إلى سورة نوح (71:28)" },
                new Hizb { Id = 58, Numero = 58, Nom = "الحزب 58", Description = "( قل أوحي ) من سورة الجن (72:1) إلى سورة المرسلات (77:50)" },
                new Hizb { Id = 59, Numero = 59, Nom = "الحزب 59", Description = "( عم يتساءلون ) سورة النبأ (78:1) إلى الطارق (86:17)" },
                new Hizb { Id = 60, Numero = 60, Nom = "الحزب 60", Description = "( سبح ) من سورة الأعلى (87:1) إلى سورة الناس (114:6)" });

            modelBuilder.Entity<Revision>().HasData(
                new Revision { Id = 1, Date = DateTime.Parse("2022-01-10"), EtudiantId = 1, HizbId = 1, HuitiemeId = 1 },
                new Revision { Id = 2, Date = DateTime.Parse("2022-01-10"), EtudiantId = 2, HizbId = 1, HuitiemeId = 1 },
                new Revision { Id = 3, Date = DateTime.Parse("2022-01-10"), EtudiantId = 3, HizbId = 1, HuitiemeId = 1 },
                new Revision { Id = 4, Date = DateTime.Parse("2022-01-10"), EtudiantId = 4, HizbId = 1, HuitiemeId = 1 },
                new Revision { Id = 5, Date = DateTime.Parse("2022-01-15"), EtudiantId = 1, HizbId = 1, HuitiemeId = 1 },
                new Revision { Id = 6, Date = DateTime.Parse("2022-01-15"), EtudiantId = 2, HizbId = 1, HuitiemeId = 1 },
                new Revision { Id = 7, Date = DateTime.Parse("2022-01-15"), EtudiantId = 3, HizbId = 1, HuitiemeId = 2 },
                new Revision { Id = 8, Date = DateTime.Parse("2022-01-15"), EtudiantId = 4, HizbId = 1, HuitiemeId = 2 },
                new Revision { Id = 9, Date = DateTime.Parse("2022-01-20"), EtudiantId = 1, HizbId = 1, HuitiemeId = 2 },
                new Revision { Id = 10, Date = DateTime.Parse("2022-01-20"), EtudiantId = 2, HizbId = 1, HuitiemeId = 2 },
                new Revision { Id = 11, Date = DateTime.Parse("2022-01-20"), EtudiantId = 3, HizbId = 1, HuitiemeId = 3 },
                new Revision { Id = 12, Date = DateTime.Parse("2022-01-20"), EtudiantId = 4, HizbId = 1, HuitiemeId = 3 },
                new Revision { Id = 13, Date = DateTime.Parse("2022-01-21"), EtudiantId = 1, HizbId = 1, HuitiemeId = 2 },
                new Revision { Id = 14, Date = DateTime.Parse("2022-01-21"), EtudiantId = 2, HizbId = 1, HuitiemeId = 4 },
                new Revision { Id = 15, Date = DateTime.Parse("2022-01-21"), EtudiantId = 3, HizbId = 1, HuitiemeId = 3 },
                new Revision { Id = 16, Date = DateTime.Parse("2022-01-21"), EtudiantId = 4, HizbId = 1, HuitiemeId = 4 });
        }
    }
}