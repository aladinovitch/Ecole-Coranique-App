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

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Enseignant>().ToTable("Enseignant", "Ecole_Coranique")
                .HasKey(k => new { k.Id })
                .HasName("PK_Enseignant");

            modelBuilder.Entity<Enseignant>().ToTable("Enseignant", "Ecole_Coranique")
                .HasMany(x => x.EnseignantGroupes).WithOne(x => x.Enseignant).HasForeignKey(x => new { x.EnseignantId });

            modelBuilder.Entity<Groupe>().ToTable("Groupe", "Ecole_Coranique")
                .HasKey(k => new { k.Id })
                .HasName("PK_Groupe");

            modelBuilder.Entity<Groupe>().ToTable("Groupe", "Ecole_Coranique")
                .HasMany(x => x.GroupeEtudiants).WithOne(x => x.Groupe).HasForeignKey(x => new { x.GroupeId });

            modelBuilder.Entity<Etudiant>().ToTable("Etudiant", "Ecole_Coranique")
                .HasKey(k => new { k.Id })
                .HasName("PK_Etudiant");

            modelBuilder.Entity<Etudiant>().ToTable("Etudiant", "Ecole_Coranique")
                .HasMany(x => x.EtudiantAbsences).WithOne(x => x.Etudiant).HasForeignKey(x => new { x.EtudiantId });
            modelBuilder.Entity<Etudiant>().ToTable("Etudiant", "Ecole_Coranique")
                .HasMany(x => x.EtudiantRevisions).WithOne(x => x.Etudiant).HasForeignKey(x => new { x.EtudiantId });

            modelBuilder.Entity<Huitieme>().ToTable("Huitieme", "Ecole_Coranique")
                .HasKey(k => new { k.Id })
                .HasName("PK_Huitieme");

            modelBuilder.Entity<Huitieme>().ToTable("Huitieme", "Ecole_Coranique")
                .HasMany(x => x.HuitiemeRevisions).WithOne(x => x.Huitieme).HasForeignKey(x => new { x.HuitiemeId });

            modelBuilder.Entity<Hizb>().ToTable("Hizb", "Ecole_Coranique")
                .HasKey(k => new { k.Id })
                .HasName("PK_Hizb");

            modelBuilder.Entity<Hizb>().ToTable("Hizb", "Ecole_Coranique")
                .HasMany(x => x.HizbRevisions).WithOne(x => x.Hizb).HasForeignKey(x => new { x.HizbId });

            modelBuilder.Entity<Absence>().ToTable("Absence", "Ecole_Coranique")
                .HasKey(k => new { k.Id })
                .HasName("PK_Absence");


            modelBuilder.Entity<Revision>().ToTable("Revision", "Ecole_Coranique")
                .HasKey(k => new { k.Id })
                .HasName("PK_Revision");

            SeedUsers(modelBuilder);
            SeedData(modelBuilder);
        }
        private static void SeedUsers(ModelBuilder modelBuilder) {
            string MANAGER_ID = Guid.NewGuid().ToString();
            string BASIC_ID = Guid.NewGuid().ToString();
            var passwordHasher = new PasswordHasher<IdentityUser>();
            // Manager
            var managerName = "manager@email.com";
            var manager = new IdentityUser {
                Id = MANAGER_ID, // Primary key
                Email = managerName,
                NormalizedEmail = managerName.ToUpper(),
                UserName = managerName,
                NormalizedUserName = managerName.ToUpper(),
                EmailConfirmed = true,
            };
            manager.PasswordHash = passwordHasher.HashPassword(manager, "Pass_12345");

            // Basic user
            var basicname = "basic@email.com";
            var basic = new IdentityUser {
                Id = BASIC_ID, // Primary key
                Email = basicname,
                NormalizedEmail = basicname.ToUpper(),
                UserName = basicname,
                NormalizedUserName = basicname.ToUpper(),
                EmailConfirmed = true,
            };
            basic.PasswordHash = passwordHasher.HashPassword(basic, "Pass_12345");
            // Seeding the User to AspNetUsers table
            modelBuilder.Entity<IdentityUser>().HasData(manager, basic);
            modelBuilder.Entity<IdentityUserClaim<string>>().HasData(
               new IdentityUserClaim<string> { Id = 1, UserId = MANAGER_ID, ClaimType = AppClaimType.Manager, ClaimValue = "true" },
               new IdentityUserClaim<string> { Id = 2, UserId = BASIC_ID, ClaimType = AppClaimType.Basic, ClaimValue = "true" });
        }
        private static void SeedData(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Enseignant>().HasData(
                new Enseignant { Id = 1, Prenom = "Slimane", Nom = "Benslimane", Phone = "05 10 10 10", Email = "sli.mane@gmail.com", Adresse = "Quartier Thniet el Hdjer, Médéa" },
                new Enseignant { Id = 2, Prenom = "Ali", Nom = "Benali", Phone = "05 20 20 20", Email = "aliben@gmail.co", Adresse = "Quartier Ain Dhheb, Médéa" },
                new Enseignant { Id = 3, Prenom = "Souhila", Nom = "Bousahla", Phone = "05 30 30 30", Email = "ss.bousahla@gmail.com", Adresse = "Quartier M'salah, Médéa" },
                new Enseignant { Id = 4, Prenom = "Amina", Nom = "Benyamina", Phone = "05 40 40 40", Email = "amina.ben@gmail.com", Adresse = "Quartier Merdj Echkir, Médéa" });

            modelBuilder.Entity<Groupe>().HasData(
                new Groupe { Id = 1, Numero = 1, Nom = "Groupe filles", EnseignantId = 3 },
                new Groupe { Id = 2, Numero = 2, Nom = "Groupe matin", EnseignantId = 4 },
                new Groupe { Id = 3, Numero = 3, Nom = "Groupe après-midi", EnseignantId = 1 });

            modelBuilder.Entity<Etudiant>().HasData(
                new Etudiant { Id = 1, Prenom = "Ahmed", Nom = "Bouhmed", Naissance = DateTime.Parse("2001-12-11"), Phone = "05 01 01 01", Email = "ahmed.mido@gmail.com", Adresse = "Quartier takbou, Médéa", GroupeId = 3 },
                new Etudiant { Id = 2, Prenom = "Arezki", Nom = "Benrezki", Naissance = DateTime.Parse("1978-03-10"), Phone = "05 02 02 02", Email = "arezki.rzk@gmail.com", Adresse = "Quartier des fleurs, Bejaia", GroupeId = 3 },
                new Etudiant { Id = 3, Prenom = "Amer", Nom = "Bouamer", Naissance = DateTime.Parse("1963-01-12"), Phone = "05 03 03 03", Email = "amerrr@gmail.com", Adresse = "Quartier Bab el Kouas, Médéa", GroupeId = 3 },
                new Etudiant { Id = 4, Prenom = "Sofiane", Nom = "Sidou", Naissance = DateTime.Parse("1990-02-03"), Phone = "05 04 04 04", Email = "so.sidou33@bmail.com", Adresse = "Cité des roches, Réghaia", GroupeId = 2 },
                new Etudiant { Id = 5, Prenom = "Samiha", Nom = "Smihi", Naissance = DateTime.Parse("1998-12-12"), Phone = "05 05 05 05", Email = "samimi@gmail.com", Adresse = "Quartier bouloughine, Alger", GroupeId = 1 },
                new Etudiant { Id = 6, Prenom = "Fatima", Nom = "Boufetoum", Naissance = DateTime.Parse("2005-02-01"), Phone = "05 06 06 06", Email = "fati.bb@gmail.com", Adresse = "Cité des cinq, Belcourt", GroupeId = 1 },
                new Etudiant { Id = 7, Prenom = "Samira", Nom = "Bousemar", Naissance = DateTime.Parse("1999-01-13"), Phone = "05 07 07 07", Email = "bousemar.sam@gmail.com", Adresse = "Route des accacias, Médéa", GroupeId = 1 });
            
            modelBuilder.Entity<Absence>().HasData(
                new Absence { Id = 1, Date = DateTime.Parse("2022-01-01"), Observation = "Occupé", EtudiantId = 3 },
                new Absence { Id = 2, Date = DateTime.Parse("2022-01-05"), Observation = "Non justifié", EtudiantId = 3 },
                new Absence { Id = 3, Date = DateTime.Parse("2022-01-06"), Observation = "Assistance maternelle", EtudiantId = 5 },
                new Absence { Id = 4, Date = DateTime.Parse("2022-01-07"), Observation = "Circulation", EtudiantId = 3 },
                new Absence { Id = 5, Date = DateTime.Parse("2022-01-12"), Observation = "Occupé", EtudiantId = 4 });

            modelBuilder.Entity<Huitieme>().HasData(
                new Huitieme { Id=1, Numero=1, Nom= "الأول" },
                new Huitieme { Id=2, Numero=2, Nom= "الثاني" },
                new Huitieme { Id=3, Numero=3, Nom= "الثالث" },
                new Huitieme { Id=4, Numero=4, Nom= "الرابع" },
                new Huitieme { Id=5, Numero=5, Nom= "الخامس" },
                new Huitieme { Id=6, Numero=6, Nom= "السادس" },
                new Huitieme { Id=7, Numero=7, Nom= "السابع" },
                new Huitieme { Id=8, Numero=8, Nom= "الثامن" });

            // Data from: https://amgpm-4.blogspot.com/
            modelBuilder.Entity<Hizb>().HasData(
                new Hizb { Id = 1, Numero = 1, Nom = "الحزب 01 - ( الم ذلك ) من سورة البقرة" },
                new Hizb { Id = 2, Numero = 2, Nom = "الحزب 02 - ( واذا لقوا ) من سورة البقرة" },
                new Hizb { Id = 3, Numero = 3, Nom = "الحزب 03 - ( سيقولالسفهاء ) من سورة البقرة" },
                new Hizb { Id = 4, Numero = 4, Nom = "الحزب 04 - ( واذكرواالله ) من سورة البقرة" },
                new Hizb { Id = 5, Numero = 5, Nom = "الحزب 05 - ( تلك الرسل ) من سورة البقرة - سورة أل عمران" },
                new Hizb { Id = 6, Numero = 6, Nom = "الحزب 06 - ( قل أؤنبئكم ) من سورة أل عمران" },
                new Hizb { Id = 7, Numero = 7, Nom = "الحزب 07 - ( لن تنالوا ) من سورة أل عمران" },
                new Hizb { Id = 8, Numero = 8, Nom = "الحزب 08 - ( يستبشرون ) من سورة أل عمران - سورة النساء" },
                new Hizb { Id = 9, Numero = 9, Nom = "الحزب 09 -( والمحصنات ) من سورة النساء" },
                new Hizb { Id = 10, Numero = 10, Nom = "الحزب 10 - ( الله لااله الاهو ) من سورة النساء" },
                new Hizb { Id = 11, Numero = 11, Nom = "الحزب 11 - ( لا يحب ) من سورة النساء - سورة المائدة" },
                new Hizb { Id = 12, Numero = 12, Nom = "الحزب 12 - ( قال رجلان ) من سورة المائدة" },
                new Hizb { Id = 13, Numero = 13, Nom = "الحزب 13 - ( لتجدن ) من سورة المائدة - سورة الأنعام" },
                new Hizb { Id = 14, Numero = 14, Nom = "الحزب 14 - ( انما يستجيب ) من سورة الأنعام" },
                new Hizb { Id = 15, Numero = 15, Nom = "الحزب 15 - ( ولو أننا نزلنا ) من سورة الأنعام" },
                new Hizb { Id = 16, Numero = 16, Nom = "الحزب 16 - ( المص كتب ) من سورة الأعراف" },
                new Hizb { Id = 17, Numero = 17, Nom = "الحزب 17 - ( قال الملأ ) من سورة الأعراف" },
                new Hizb { Id = 18, Numero = 18, Nom = "الحزب 18 - ( واذ نتقنا ) من سورة الأعراف - سورة الأنفال" },
                new Hizb { Id = 19, Numero = 19, Nom = "الحزب 19 - ( واعلموا ) من سورة الأنفال - سورة التوبة" },
                new Hizb { Id = 20, Numero = 20, Nom = "الحزب 20 - ( ان كثيرا ) من سورة التوبة" },
                new Hizb { Id = 21, Numero = 21, Nom = "الحزب 21 - ( انما السبيل ) من سورة التوبة - سورة يونس" },
                new Hizb { Id = 22, Numero = 22, Nom = "الحزب 22 - ( للذين أحسنوا ) من سورة يونس - سورة هود" },
                new Hizb { Id = 23, Numero = 23, Nom = "الحزب 23 - ( ومامن دابة ) من سورة هود" },
                new Hizb { Id = 24, Numero = 24, Nom = "الحزب 24 - ( والى مدين ) من سورة هود - سورة يوسف" },
                new Hizb { Id = 25, Numero = 25, Nom = "الحزب 25 - ( وما أبرئ ) من سورة يوسف - سورة الرعد" },
                new Hizb { Id = 26, Numero = 26, Nom = "الحزب 26 - ( أفمن يعلم ) من سورة الرعد - سورة ابراهيم" },
                new Hizb { Id = 27, Numero = 27, Nom = "الحزب 27 - ( ربما ) من سورة الحجر - سورة النحل" },
                new Hizb { Id = 28, Numero = 28, Nom = "الحزب 28 - ( وقال الله لا تتخذوا ) من سورة النحل" },
                new Hizb { Id = 29, Numero = 29, Nom = "الحزب 29 - ( سبحن ) من سورة الاسراء" },
                new Hizb { Id = 30, Numero = 30, Nom = "الحزب 30 - ( أولم يروا ) من سورة الاسراء - سورة الكهف" },
                new Hizb { Id = 31, Numero = 31, Nom = "الحزب 31 - ( قال ألم أقل ) من سورة الكهف - سورة مريم" },
                new Hizb { Id = 32, Numero = 32, Nom = "الحزب 32 - ( طه ) من سورة طه" },
                new Hizb { Id = 33, Numero = 33, Nom = "الحزب 33 - ( اقترب ) من سورة الأنبياء" },
                new Hizb { Id = 34, Numero = 34, Nom = "الحزب 34 - ( يأيها الناس ) من سورة الحج" },
                new Hizb { Id = 35, Numero = 35, Nom = "الحزب 35 - ( قدأفلح ) من سورة المومنون - سورة النور" },
                new Hizb { Id = 36, Numero = 36, Nom = "الحزب 36 - ( لاتتبعوا ) من سورة النور - سورة الفرقان" },
                new Hizb { Id = 37, Numero = 37, Nom = "الحزب 37 - ( وقال الذين ) من سورة الفرقان - سورة الشعراء" },
                new Hizb { Id = 38, Numero = 38, Nom = "الحزب 38 - ( قالوا أنومن ) من سورة الشعراء - سورة النمل" },
                new Hizb { Id = 39, Numero = 39, Nom = "الحزب 39 - ( فما كان جواب ) من سورة النمل - سورة اقصص" },
                new Hizb { Id = 40, Numero = 40, Nom = "الحزب 40 - ( ولقد وصلنا ) من سورة القصص - سورة العنكبوت" },
                new Hizb { Id = 41, Numero = 41, Nom = "الحزب 41 - ( ولا تجادلوا ) من سورة العنكبوت - سورة الروم - سورة لقمن" },
                new Hizb { Id = 42, Numero = 42, Nom = "الحزب 42 - ( ومن يسلم ) من سورة لقمن - سورة السجدة - سورة الأحزاب" },
                new Hizb { Id = 43, Numero = 43, Nom = "الحزب 43 - ( ومن يقنت ) من سورة الأحزاب - سورة سبأ" },
                new Hizb { Id = 44, Numero = 44, Nom = "الحزب 44 - ( قل من يرزقكم ) من سورة سبأ - سورة فاطر - سورة يس" },
                new Hizb { Id = 45, Numero = 45, Nom = "الحزب 45 - ( وماأنزلنا ) من سورة يس - سورة الصفت" },
                new Hizb { Id = 46, Numero = 46, Nom = "الحزب 46 - ( فنبذنه ) من سورة الصفت الى سورة ص الى سورة الزمر" },
                new Hizb { Id = 47, Numero = 47, Nom = "الحزب 47 - ( فمن أظلم ) من سورة الزمر - سورة غافر" },
                new Hizb { Id = 48, Numero = 48, Nom = "الحزب 48 - ( ويقوم مالي ) من سورة غافر - سورة فصلت" },
                new Hizb { Id = 49, Numero = 49, Nom = "الحزب 49 - ( اليه يرد ) من سورة فصلت - سورة الشورى - سورة الزخرف" },
                new Hizb { Id = 50, Numero = 50, Nom = "الحزب 50 - ( قل أولوجئتكم ) من سورة الزخرف - سورة الدخان - سورة الجاثية" },
                new Hizb { Id = 51, Numero = 51, Nom = "الحزب 51 - ( حم ماخلقنا ) من سورة الأحقاف الىسورة محمد - سورة الفتح" },
                new Hizb { Id = 52, Numero = 52, Nom = "الحزب 52 - ( لقد رضي ) من سورة الفتح - سورة :سورة الحجرات - سورة ق - سورة الذريات" },
                new Hizb { Id = 53, Numero = 53, Nom = "الحزب 53 - ( قال فما خطبكم ) من سورة الذريات - سورة الطور - سورة النجم - سورة القمر" },
                new Hizb { Id = 54, Numero = 54, Nom = "الحزب 54 - ( الرحمن ) من سورة الرحمن - سورة الواقعة - سورة الحديد" },
                new Hizb { Id = 55, Numero = 55, Nom = "الحزب 55 - ( قد سمع ) من سورة المجادلة - سورة الحشر - سورة الممتحنة - سورة الصف" },
                new Hizb { Id = 56, Numero = 56, Nom = "الحزب 56 - ( يسبح لله ) من سورة الجمعة - سورة المنفقون - سورة التغابن - سورة الطلاق - سورة التحريم" },
                new Hizb { Id = 57, Numero = 57, Nom = "الحزب 57 - ( تبرك الذي ) من سورة الملك - سورة القلم - سورة الحاقة - سورة المعارج - سورة نوح" },
                new Hizb { Id = 58, Numero = 58, Nom = "الحزب 58 - ( قل أوحي ) من سورة الجن - سورة المزمل - سورة المدثر - سورة القيمة - سورة الانسان - سورة المرسلات" },
                new Hizb { Id = 59, Numero = 59, Nom = "الحزب 59 - ( عم يتساءلون ) سورة النبأ - النزعات - عبس - التكوير - الانفطار - المطففين - الانشقاق - البروج - الطارق" },
                new Hizb { Id = 60, Numero = 60, Nom = "الحزب 60 - ( سبح ) من سورة الأعلى الى سورة الناس" });
            
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