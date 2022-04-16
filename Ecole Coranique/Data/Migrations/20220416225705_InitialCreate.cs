using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecole_Coranique.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "EcoleCoranique");

            migrationBuilder.RenameTable(
                name: "AspNetUserTokens",
                newName: "AspNetUserTokens",
                newSchema: "EcoleCoranique");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                newName: "AspNetUsers",
                newSchema: "EcoleCoranique");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                newName: "AspNetUserRoles",
                newSchema: "EcoleCoranique");

            migrationBuilder.RenameTable(
                name: "AspNetUserLogins",
                newName: "AspNetUserLogins",
                newSchema: "EcoleCoranique");

            migrationBuilder.RenameTable(
                name: "AspNetUserClaims",
                newName: "AspNetUserClaims",
                newSchema: "EcoleCoranique");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                newName: "AspNetRoles",
                newSchema: "EcoleCoranique");

            migrationBuilder.RenameTable(
                name: "AspNetRoleClaims",
                newName: "AspNetRoleClaims",
                newSchema: "EcoleCoranique");

            migrationBuilder.CreateTable(
                name: "Enseignants",
                schema: "EcoleCoranique",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adresse = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enseignants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hizbs",
                schema: "EcoleCoranique",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hizbs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Huitiemes",
                schema: "EcoleCoranique",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Huitiemes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Groupes",
                schema: "EcoleCoranique",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnseignantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groupes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Groupes_Enseignants_EnseignantId",
                        column: x => x.EnseignantId,
                        principalSchema: "EcoleCoranique",
                        principalTable: "Enseignants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Etudiants",
                schema: "EcoleCoranique",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Naissance = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adresse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GroupeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etudiants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Etudiants_Groupes_GroupeId",
                        column: x => x.GroupeId,
                        principalSchema: "EcoleCoranique",
                        principalTable: "Groupes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Absences",
                schema: "EcoleCoranique",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Observation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EtudiantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Absences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Absences_Etudiants_EtudiantId",
                        column: x => x.EtudiantId,
                        principalSchema: "EcoleCoranique",
                        principalTable: "Etudiants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Revisions",
                schema: "EcoleCoranique",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EtudiantId = table.Column<int>(type: "int", nullable: false),
                    HizbId = table.Column<int>(type: "int", nullable: false),
                    HuitiemeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Revisions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Revisions_Etudiants_EtudiantId",
                        column: x => x.EtudiantId,
                        principalSchema: "EcoleCoranique",
                        principalTable: "Etudiants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Revisions_Hizbs_HizbId",
                        column: x => x.HizbId,
                        principalSchema: "EcoleCoranique",
                        principalTable: "Hizbs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Revisions_Huitiemes_HuitiemeId",
                        column: x => x.HuitiemeId,
                        principalSchema: "EcoleCoranique",
                        principalTable: "Huitiemes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "EcoleCoranique",
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "95886126-045a-4c18-a257-02d8ff9ffe0e", 0, "da1d9b30-85bd-4ba1-ae35-7dc49a040172", "basic@email.com", true, false, null, "BASIC@EMAIL.COM", "BASIC@EMAIL.COM", "AQAAAAEAACcQAAAAEOSeyj6mXIRcNDDAh4QU/ubo+R4N9y6BtJ3Dq3PxD/Y82IuylQ7XEtdL7ER7LolpWw==", null, false, "df697ef6-e279-47fe-bb43-5af965f055a9", false, "basic@email.com" },
                    { "ce3ad27a-a79c-4af5-9ac4-f69010bf283b", 0, "5aeee0fb-bccc-44ff-a18f-560bca2d4dd4", "manager@email.com", true, false, null, "MANAGER@EMAIL.COM", "MANAGER@EMAIL.COM", "AQAAAAEAACcQAAAAECqeKQT6XZYWP9JXAM/xSrYqt/srPGIf6uZ29r1Ii8RTNYY5lKFS9WweDvOsXFmVLg==", null, false, "bd7503af-0811-4c20-a770-dff4d8c096df", false, "manager@email.com" }
                });

            migrationBuilder.InsertData(
                schema: "EcoleCoranique",
                table: "Enseignants",
                columns: new[] { "Id", "Adresse", "Email", "Nom", "Phone", "Prenom" },
                values: new object[,]
                {
                    { 1, "Quartier Thniet el Hdjer, Médéa", "sli.mane@gmail.com", "Benslimane", "05 10 10 10", "Slimane" },
                    { 2, "Quartier Ain Dhheb, Médéa", "aliben@gmail.co", "Benali", "05 20 20 20", "Ali" },
                    { 3, "Quartier M'salah, Médéa", "ss.bousahla@gmail.com", "Bousahla", "05 30 30 30", "Souhila" },
                    { 4, "Quartier Merdj Echkir, Médéa", "amina.ben@gmail.com", "Benyamina", "05 40 40 40", "Amina" }
                });

            migrationBuilder.InsertData(
                schema: "EcoleCoranique",
                table: "Hizbs",
                columns: new[] { "Id", "Description", "Nom", "Numero" },
                values: new object[,]
                {
                    { 1, "( ٱلْحَمْدُ لِلَّهِ ) من الفاتحة (1:1) سورة البقرة (2:74)", "الحزب 01", 1 },
                    { 2, "( واذا لقوا ) من سورة البقرة (2:75) إلى (2:141)", "الحزب 02", 2 },
                    { 3, "( سيقول السفهاء ) من سورة البقرة (2:142) إلى (2:202)", "الحزب 03", 3 },
                    { 4, "( واذكرواالله ) من سورة البقرة (2:203) إلى (2:252)", "الحزب 04", 4 },
                    { 5, "( تلك الرسل ) من سورة البقرة (2:253) إلى سورة أل عمران (3:14)", "الحزب 05", 5 },
                    { 6, "( قل أؤنبئكم ) من سورة أل عمران (3:15) إلى (3:92)", "الحزب 06", 6 },
                    { 7, "( لن تنالوا ) من سورة أل عمران (3:93) إلى (3:170)", "الحزب 07", 7 },
                    { 8, "( كُلُّ الطَّعَامِ ) من سورة أل عمران (3:171) إلى سورة النساء (4:23)", "الحزب 08", 8 },
                    { 9, "( وَٱلْمُحْصَنَاتُ ) من سورة النساء (4:24) إلى (4:87)", "الحزب 09", 9 },
                    { 10, "( الله لااله الاهو ) من سورة النساء (4:88) إلى (4:147)", "الحزب 10", 10 },
                    { 11, "( لَا يُحِبُّ ٱللهُ ) من سورة النساء (4:148) إلى سورة المائدة (5:26)", "الحزب 11", 11 },
                    { 12, "( قال رجلان ) من سورة المائدة (5:27) إلى (5:81)", "الحزب 12", 12 },
                    { 13, "( لتجدن ) من سورة المائدة (5:82) - سورة الأنعام (6:35)", "الحزب 13", 13 },
                    { 14, "( انما يستجيب ) من سورة الأنعام (6:36) إلى (6:110)", "الحزب 14", 14 },
                    { 15, "( ولو أننا نزلنا ) من سورة الأنعام (6:111) إلى (6:165)", "الحزب 15", 15 },
                    { 16, "( المص كتب ) من سورة الأعراف (7:1) إلى (7:87)", "الحزب 16", 16 },
                    { 17, "( قال الملأ ) من سورة الأعراف (7:88) إلى (7:170)", "الحزب 17", 17 },
                    { 18, "( واذ نتقنا ) من سورة الأعراف (7:171) إلى سورة الأنفال (8:40)", "الحزب 18", 18 },
                    { 19, "( واعلموا ) من سورة الأنفال (8:41)  إلى سورة التوبة (9:33)", "الحزب 19", 19 },
                    { 20, "( ان كثيرا ) من سورة التوبة (9:34) إلى (9:92)", "الحزب 20", 20 },
                    { 21, "( انما السبيل ) من سورة التوبة (9:93) إلى سورة يونس (10:25)", "الحزب 21", 21 },
                    { 22, "( للذين أحسنوا ) من سورة يونس (10:26) إلى سورة هود (11:5)", "الحزب 22", 22 },
                    { 23, "( ومامن دابة ) من سورة هود (11:6) إلى (11:83)", "الحزب 23", 23 },
                    { 24, "( والى مدين ) من سورة هود (11:84) إلى سورة يوسف (12:52)", "الحزب 24", 24 },
                    { 25, "( وما أبرئ ) من سورة يوسف (12:53) إلى سورة الرعد (13:18)", "الحزب 25", 25 },
                    { 26, "( أفمن يعلم ) من سورة الرعد (13:19) إلى سورة إبراهيم (14:52)", "الحزب 26", 26 },
                    { 27, "( ربما ) من سورة الحجر (15:1) إلى سورة النحل (16:50)", "الحزب 27", 27 },
                    { 28, "( وقال الله لا تتخذوا ) من سورة النحل (16:51) إلى (16:128)", "الحزب 28", 28 },
                    { 29, "( سبحن ) من سورة الاسراء (17:1) إلى (17:98)", "الحزب 29", 29 },
                    { 30, "( أولم يروا ) من سورة الاسراء (17:99) إلى سورة الكهف (18:74)", "الحزب 30", 30 },
                    { 31, "( قال ألم أقل ) من سورة الكهف (18:75) إلى سورة مريم (19:98)", "الحزب 31", 31 },
                    { 32, "( طه ) من سورة طه (20:1) إلى (20:135)", "الحزب 32", 32 },
                    { 33, "( اقترب ) من سورة الأنبياء (21:1) إلى (21:112)", "الحزب 33", 33 },
                    { 34, "( يأيها الناس ) من سورة الحج (22:1) إلى (22:78)", "الحزب 34", 34 },
                    { 35, "( قدأفلح ) من سورة المؤمنون (23:1) إلى سورة النور (24:20)", "الحزب 35", 35 },
                    { 36, "( لاتتبعوا ) من سورة النور (24:21) إلى سورة الفرقان (25:20)", "الحزب 36", 36 }
                });

            migrationBuilder.InsertData(
                schema: "EcoleCoranique",
                table: "Hizbs",
                columns: new[] { "Id", "Description", "Nom", "Numero" },
                values: new object[,]
                {
                    { 37, "( وقال الذين ) من سورة الفرقان (25:21) إلى سورة الشعراء (26:110)", "الحزب 37", 37 },
                    { 38, "( قالوا أنومن ) من سورة الشعراء (26:111)  إلى سورة النمل (27:55)", "الحزب 38", 38 },
                    { 39, "( فما كان جواب ) من سورة النمل (27:56) إلى سورة اقصص (28:50)", "الحزب 39", 39 },
                    { 40, "( ولقد وصلنا ) من سورة القصص (28:51)  إلى سورة العنكبوت (29:45)", "الحزب 40", 40 },
                    { 41, "( ولا تجادلوا ) من سورة العنكبوت (29:46) إلى سورة لقمان (31:21)", "الحزب 41", 41 },
                    { 42, "( ومن يسلم ) من سورة لقمن (31:22) إلى سورة الأحزاب (33:30)", "الحزب 42", 42 },
                    { 43, "( ومن يقنت ) من سورة الأحزاب (33:31) إلى سورة سبأ (34:23)", "الحزب 43", 43 },
                    { 44, "( قل من يرزقكم ) من سورة سبأ (34:24) إلى سورة يس (36:27)", "الحزب 44", 44 },
                    { 45, "( وماأنزلنا ) من سورة يس (36:28) إلى سورة الصفت (37:144)", "الحزب 45", 45 },
                    { 46, "( فنبذنه ) من سورة الصفت (37:145) إلى سورة الزمر (39:31)", "الحزب 46", 46 },
                    { 47, "( فمن أظلم ) من سورة الزمر (39:32) إلى سورة غافر (40:40)", "الحزب 47", 47 },
                    { 48, "( ويقوم مالي ) من سورة غافر (40:41) إلى سورة فصلت (41:46)", "الحزب 48", 48 },
                    { 49, "( اليه يرد ) من سورة فصلت (41:47) إلى سورة الزخرف (43:23)", "الحزب 49", 49 },
                    { 50, "( قل أولوجئتكم ) من سورة الزخرف (43:24) إلى سورة الجاثية (45:37)", "الحزب 50", 50 },
                    { 51, "( حم ماخلقنا ) من سورة الأحقاف (46:1) إلى سورة الفتح (48:17)", "الحزب 51", 51 },
                    { 52, "( لقد رضي ) من سورة الفتح (48:18) إلى سورة الذريات (51:30)", "الحزب 52", 52 },
                    { 53, "( قال فما خطبكم ) من سورة الذريات (51:31) إلى القمر (54:55)", "الحزب 53", 53 },
                    { 54, "( الرحمن ) من سورة الرحمن (55:1) إلى سورة الحديد (57:29)", "الحزب 54", 54 },
                    { 55, "( قد سمع ) من سورة المجادلة (58:1) إلى سورة الصف (61:14)", "الحزب 55", 55 },
                    { 56, "( يسبح لله ) من سورة الجمعة (62:1) إلى سورة التحريم (66:12)", "الحزب 56", 56 },
                    { 57, "( تبرك الذي ) من سورة الملك (67:1) إلى سورة نوح (71:28)", "الحزب 57", 57 },
                    { 58, "( قل أوحي ) من سورة الجن (72:1) إلى سورة المرسلات (77:50)", "الحزب 58", 58 },
                    { 59, "( عم يتساءلون ) سورة النبأ (78:1) إلى الطارق (86:17)", "الحزب 59", 59 },
                    { 60, "( سبح ) من سورة الأعلى (87:1) إلى سورة الناس (114:6)", "الحزب 60", 60 }
                });

            migrationBuilder.InsertData(
                schema: "EcoleCoranique",
                table: "Huitiemes",
                columns: new[] { "Id", "Nom", "Numero" },
                values: new object[,]
                {
                    { 1, "الأول", 1 },
                    { 2, "الثاني", 2 },
                    { 3, "الثالث", 3 },
                    { 4, "الرابع", 4 },
                    { 5, "الخامس", 5 },
                    { 6, "السادس", 6 },
                    { 7, "السابع", 7 },
                    { 8, "الثامن", 8 }
                });

            migrationBuilder.InsertData(
                schema: "EcoleCoranique",
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[,]
                {
                    { 1, "Manager", "true", "ce3ad27a-a79c-4af5-9ac4-f69010bf283b" },
                    { 2, "Basic user", "true", "95886126-045a-4c18-a257-02d8ff9ffe0e" }
                });

            migrationBuilder.InsertData(
                schema: "EcoleCoranique",
                table: "Groupes",
                columns: new[] { "Id", "EnseignantId", "Nom", "Numero" },
                values: new object[,]
                {
                    { 1, 3, "Groupe filles", 1 },
                    { 2, 4, "Groupe matin", 2 },
                    { 3, 1, "Groupe après-midi", 3 }
                });

            migrationBuilder.InsertData(
                schema: "EcoleCoranique",
                table: "Etudiants",
                columns: new[] { "Id", "Adresse", "Email", "GroupeId", "Naissance", "Nom", "Phone", "Prenom" },
                values: new object[,]
                {
                    { 1, "Quartier takbou, Médéa", "ahmed.mido@gmail.com", 3, new DateTime(2001, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bouhmed", "05 01 01 01", "Ahmed" },
                    { 2, "Quartier des fleurs, Bejaia", "arezki.rzk@gmail.com", 3, new DateTime(1978, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Benrezki", "05 02 02 02", "Arezki" },
                    { 3, "Quartier Bab el Kouas, Médéa", "amerrr@gmail.com", 3, new DateTime(1963, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bouamer", "05 03 03 03", "Amer" },
                    { 4, "Cité des roches, Réghaia", "so.sidou33@bmail.com", 2, new DateTime(1990, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sidou", "05 04 04 04", "Sofiane" },
                    { 5, "Quartier bouloughine, Alger", "samimi@gmail.com", 1, new DateTime(1998, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Smihi", "05 05 05 05", "Samiha" },
                    { 6, "Cité des cinq, Belcourt", "fati.bb@gmail.com", 1, new DateTime(2005, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Boufetoum", "05 06 06 06", "Fatima" },
                    { 7, "Route des accacias, Médéa", "bousemar.sam@gmail.com", 1, new DateTime(1999, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bousemar", "05 07 07 07", "Samira" }
                });

            migrationBuilder.InsertData(
                schema: "EcoleCoranique",
                table: "Absences",
                columns: new[] { "Id", "Date", "EtudiantId", "Observation" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Occupé" },
                    { 2, new DateTime(2022, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Non justifié" },
                    { 3, new DateTime(2022, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Assistance maternelle" },
                    { 4, new DateTime(2022, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Circulation" },
                    { 5, new DateTime(2022, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Occupé" }
                });

            migrationBuilder.InsertData(
                schema: "EcoleCoranique",
                table: "Revisions",
                columns: new[] { "Id", "Date", "EtudiantId", "HizbId", "HuitiemeId" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 1 },
                    { 2, new DateTime(2022, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 1 },
                    { 3, new DateTime(2022, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 1, 1 },
                    { 4, new DateTime(2022, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 1, 1 },
                    { 5, new DateTime(2022, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 1 },
                    { 6, new DateTime(2022, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 1 },
                    { 7, new DateTime(2022, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 1, 2 },
                    { 8, new DateTime(2022, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 1, 2 },
                    { 9, new DateTime(2022, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 2 },
                    { 10, new DateTime(2022, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 2 },
                    { 11, new DateTime(2022, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 1, 3 },
                    { 12, new DateTime(2022, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 1, 3 },
                    { 13, new DateTime(2022, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 2 },
                    { 14, new DateTime(2022, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 4 },
                    { 15, new DateTime(2022, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 1, 3 },
                    { 16, new DateTime(2022, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 1, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Absences_EtudiantId",
                schema: "EcoleCoranique",
                table: "Absences",
                column: "EtudiantId");

            migrationBuilder.CreateIndex(
                name: "IX_Etudiants_GroupeId",
                schema: "EcoleCoranique",
                table: "Etudiants",
                column: "GroupeId");

            migrationBuilder.CreateIndex(
                name: "IX_Groupes_EnseignantId",
                schema: "EcoleCoranique",
                table: "Groupes",
                column: "EnseignantId");

            migrationBuilder.CreateIndex(
                name: "IX_Revisions_EtudiantId",
                schema: "EcoleCoranique",
                table: "Revisions",
                column: "EtudiantId");

            migrationBuilder.CreateIndex(
                name: "IX_Revisions_HizbId",
                schema: "EcoleCoranique",
                table: "Revisions",
                column: "HizbId");

            migrationBuilder.CreateIndex(
                name: "IX_Revisions_HuitiemeId",
                schema: "EcoleCoranique",
                table: "Revisions",
                column: "HuitiemeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Absences",
                schema: "EcoleCoranique");

            migrationBuilder.DropTable(
                name: "Revisions",
                schema: "EcoleCoranique");

            migrationBuilder.DropTable(
                name: "Etudiants",
                schema: "EcoleCoranique");

            migrationBuilder.DropTable(
                name: "Hizbs",
                schema: "EcoleCoranique");

            migrationBuilder.DropTable(
                name: "Huitiemes",
                schema: "EcoleCoranique");

            migrationBuilder.DropTable(
                name: "Groupes",
                schema: "EcoleCoranique");

            migrationBuilder.DropTable(
                name: "Enseignants",
                schema: "EcoleCoranique");

            migrationBuilder.DeleteData(
                schema: "EcoleCoranique",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "EcoleCoranique",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "EcoleCoranique",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "95886126-045a-4c18-a257-02d8ff9ffe0e");

            migrationBuilder.DeleteData(
                schema: "EcoleCoranique",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ce3ad27a-a79c-4af5-9ac4-f69010bf283b");

            migrationBuilder.RenameTable(
                name: "AspNetUserTokens",
                schema: "EcoleCoranique",
                newName: "AspNetUserTokens");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                schema: "EcoleCoranique",
                newName: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                schema: "EcoleCoranique",
                newName: "AspNetUserRoles");

            migrationBuilder.RenameTable(
                name: "AspNetUserLogins",
                schema: "EcoleCoranique",
                newName: "AspNetUserLogins");

            migrationBuilder.RenameTable(
                name: "AspNetUserClaims",
                schema: "EcoleCoranique",
                newName: "AspNetUserClaims");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                schema: "EcoleCoranique",
                newName: "AspNetRoles");

            migrationBuilder.RenameTable(
                name: "AspNetRoleClaims",
                schema: "EcoleCoranique",
                newName: "AspNetRoleClaims");
        }
    }
}
