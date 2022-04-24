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
                name: "ec");

            migrationBuilder.RenameTable(
                name: "AspNetUserTokens",
                newName: "AspNetUserTokens",
                newSchema: "ec");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                newName: "AspNetUsers",
                newSchema: "ec");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                newName: "AspNetUserRoles",
                newSchema: "ec");

            migrationBuilder.RenameTable(
                name: "AspNetUserLogins",
                newName: "AspNetUserLogins",
                newSchema: "ec");

            migrationBuilder.RenameTable(
                name: "AspNetUserClaims",
                newName: "AspNetUserClaims",
                newSchema: "ec");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                newName: "AspNetRoles",
                newSchema: "ec");

            migrationBuilder.RenameTable(
                name: "AspNetRoleClaims",
                newName: "AspNetRoleClaims",
                newSchema: "ec");

            migrationBuilder.CreateTable(
                name: "Enseignants",
                schema: "ec",
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
                schema: "ec",
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
                schema: "ec",
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
                schema: "ec",
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
                        principalSchema: "ec",
                        principalTable: "Enseignants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentificationEnseignants",
                schema: "ec",
                columns: table => new
                {
                    EnseignantId = table.Column<int>(type: "int", nullable: false),
                    IdentityUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentificationEnseignants", x => x.EnseignantId);
                    table.ForeignKey(
                        name: "FK_IdentificationEnseignants_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalSchema: "ec",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IdentificationEnseignants_Enseignants_EnseignantId",
                        column: x => x.EnseignantId,
                        principalSchema: "ec",
                        principalTable: "Enseignants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Etudiants",
                schema: "ec",
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
                        principalSchema: "ec",
                        principalTable: "Groupes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Absences",
                schema: "ec",
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
                        principalSchema: "ec",
                        principalTable: "Etudiants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentificationEtudiants",
                schema: "ec",
                columns: table => new
                {
                    EtudiantId = table.Column<int>(type: "int", nullable: false),
                    IdentityUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentificationEtudiants", x => x.EtudiantId);
                    table.ForeignKey(
                        name: "FK_IdentificationEtudiants_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalSchema: "ec",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IdentificationEtudiants_Etudiants_EtudiantId",
                        column: x => x.EtudiantId,
                        principalSchema: "ec",
                        principalTable: "Etudiants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Revisions",
                schema: "ec",
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
                        principalSchema: "ec",
                        principalTable: "Etudiants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Revisions_Hizbs_HizbId",
                        column: x => x.HizbId,
                        principalSchema: "ec",
                        principalTable: "Hizbs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Revisions_Huitiemes_HuitiemeId",
                        column: x => x.HuitiemeId,
                        principalSchema: "ec",
                        principalTable: "Huitiemes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "ec",
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "149da79b-cbd6-4ee5-bd64-2782770ed5a6", 0, "c528b615-3228-4553-b118-f52f750f13f7", "enseignat.troisieme@email.com", true, false, null, "ENSEIGNAT.TROISIEME@EMAIL.COM", "ENSEIGNAT.TROISIEME@EMAIL.COM", "AQAAAAEAACcQAAAAEHhZ3yoIZZusdHL2hW7lNNmpMlGOtNOzTo6d3iT85XWHP7l3menIsJzbmdbZ36oVow==", null, false, "3d2e9610-193e-4c3e-a057-949302cb5a48", false, "enseignat.troisieme@email.com" },
                    { "1f085b34-69b0-49ba-a182-dab50bf0bda7", 0, "54a39d77-d332-41eb-8d4a-e50d2614c73a", "etudiant.troisieme@email.com", true, false, null, "ETUDIANT.TROISIEME@EMAIL.COM", "ETUDIANT.TROISIEME@EMAIL.COM", "AQAAAAEAACcQAAAAECFanY2cYl4izgycSu1R/KHC4tPE7Tg61H8aHpeXlXdLc7decoXQMIla229Nbb3+Gw==", null, false, "5eae586a-5a2d-49fd-ae8a-389fd1f434a1", false, "etudiant.troisieme@email.com" },
                    { "31e43467-b393-4895-a1d6-da6fbf87e7a2", 0, "520d4551-90c7-4d34-aebf-671db699fd5b", "etudiant.quatrieme@email.com", true, false, null, "ETUDIANT.QUATRIEME@EMAIL.COM", "ETUDIANT.QUATRIEME@EMAIL.COM", "AQAAAAEAACcQAAAAEHo+LmSWkBa+tDPGou0AOc2+mWUGeP8NE5xfL5XYdI/p4n4GwCAPVdx1a2qbtM++iw==", null, false, "603bb699-4269-427d-a567-2e42d618f16b", false, "etudiant.quatrieme@email.com" },
                    { "47367b6d-edad-467b-a373-7d4fafa3e875", 0, "a02da170-83ac-40c2-a133-b1988d0dd023", "etudiant.cinquieme@email.com", true, false, null, "ETUDIANT.CINQUIEME@EMAIL.COM", "ETUDIANT.CINQUIEME@EMAIL.COM", "AQAAAAEAACcQAAAAEDnoVOC68phle3XlccDAzB8q39XMPRrltcgmx6YuGGcjPPaQwjKQeepsbRe5OcGKlA==", null, false, "18082a70-63fa-4c05-98fd-5885a4033ce4", false, "etudiant.cinquieme@email.com" },
                    { "6438a460-46fa-4038-944e-df4e9869ce0d", 0, "112a2cbc-fd27-4960-a3a1-c72ff1d98e06", "enseignat.second@email.com", true, false, null, "ENSEIGNAT.SECOND@EMAIL.COM", "ENSEIGNAT.SECOND@EMAIL.COM", "AQAAAAEAACcQAAAAEETF3Rw36kBFyWqyDEmBsL8LyidTEVMwhbxbAvRLu7eMs0JpQ1QEq8S+TwD5ja2M2Q==", null, false, "322a27de-66a7-4a20-a7f1-212985712e1e", false, "enseignat.second@email.com" },
                    { "b69eed44-a66a-43ec-8698-6cb83f87e28a", 0, "e2fdcc94-3dc5-469c-8c46-57cbad5a41d5", "etudiant.premier@email.com", true, false, null, "ETUDIANT.PREMIER@EMAIL.COM", "ETUDIANT.PREMIER@EMAIL.COM", "AQAAAAEAACcQAAAAEP5Vvf9p/qAw/bcnUs+untPOhIdN6XclriyNOQhV4aAEZPahBXTS04mphID4sEzDyQ==", null, false, "7adc6fd3-0e6d-4196-8baf-e94151276a2e", false, "etudiant.premier@email.com" },
                    { "cc424f74-d7cf-4d26-87cf-b790679c8e3b", 0, "a40566bf-b97b-4866-9b18-1a1f48dd7679", "etudiant.second@email.com", true, false, null, "ETUDIANT.SECOND@EMAIL.COM", "ETUDIANT.SECOND@EMAIL.COM", "AQAAAAEAACcQAAAAEMXJqEm9zC7r19Ct1k815mc9wl4rq+T4x/fk/ruKM6bo+TCLkgGMEpR6qpp5JuaoHg==", null, false, "6df88a07-0da2-4051-b72b-0380f46e4eb7", false, "etudiant.second@email.com" },
                    { "e3df062f-6566-4238-88ad-7f5bcee653d7", 0, "7dd90cdf-08c4-4dce-bab1-b8ce7bfca09d", "enseignat.premier@email.com", true, false, null, "ENSEIGNAT.PREMIER@EMAIL.COM", "ENSEIGNAT.PREMIER@EMAIL.COM", "AQAAAAEAACcQAAAAEGvDnmOimsMVVb7wEpU/zkC0LWGo8O3f4Wp2DRSKRKe8Zbb+1RgAv9tUIWF5WNHDaA==", null, false, "3f744d36-3cc8-4934-bb98-8e65e9eec2ec", false, "enseignat.premier@email.com" },
                    { "fa5ab430-ac77-46b5-b4c2-48182b1a7694", 0, "9e96cef2-24e2-4a19-ab00-d4fe463a3b56", "admin@email.com", true, false, null, "ADMIN@EMAIL.COM", "ADMIN@EMAIL.COM", "AQAAAAEAACcQAAAAELC+UQsM94NVlxhHNfdFc1/of0TVRcBiQexk/TsBbEpFiIU2J75bcxH4X/yEmq5R7w==", null, false, "86540a06-d303-43fe-aa73-df4852ae62fd", false, "admin@email.com" }
                });

            migrationBuilder.InsertData(
                schema: "ec",
                table: "Enseignants",
                columns: new[] { "Id", "Adresse", "Email", "Nom", "Phone", "Prenom" },
                values: new object[,]
                {
                    { 1, "حي ثنية الحجر، المدية", "sli.mane@gmail.com", "سليماني", "05 10 10 10", "سليمان" },
                    { 2, "حي عين الذهب، المدية", "aliben@gmail.co", "بن علي", "05 20 20 20", "علي" },
                    { 3, "حي المصلى، المدية", "ss.bousahla@gmail.com", "سنوسي", "05 30 30 30", "سهيلة" },
                    { 4, "حي مرج الشكير، المدية", "amina.ben@gmail.com", "بن يمينة", "05 40 40 40", "أمينة" }
                });

            migrationBuilder.InsertData(
                schema: "ec",
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
                    { 29, "( سبحن ) من سورة الاسراء (17:1) إلى (17:98)", "الحزب 29", 29 }
                });

            migrationBuilder.InsertData(
                schema: "ec",
                table: "Hizbs",
                columns: new[] { "Id", "Description", "Nom", "Numero" },
                values: new object[,]
                {
                    { 30, "( أولم يروا ) من سورة الاسراء (17:99) إلى سورة الكهف (18:74)", "الحزب 30", 30 },
                    { 31, "( قال ألم أقل ) من سورة الكهف (18:75) إلى سورة مريم (19:98)", "الحزب 31", 31 },
                    { 32, "( طه ) من سورة طه (20:1) إلى (20:135)", "الحزب 32", 32 },
                    { 33, "( اقترب ) من سورة الأنبياء (21:1) إلى (21:112)", "الحزب 33", 33 },
                    { 34, "( يأيها الناس ) من سورة الحج (22:1) إلى (22:78)", "الحزب 34", 34 },
                    { 35, "( قدأفلح ) من سورة المؤمنون (23:1) إلى سورة النور (24:20)", "الحزب 35", 35 },
                    { 36, "( لاتتبعوا ) من سورة النور (24:21) إلى سورة الفرقان (25:20)", "الحزب 36", 36 },
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
                schema: "ec",
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
                schema: "ec",
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[,]
                {
                    { 1, "Concern", "Admin", "fa5ab430-ac77-46b5-b4c2-48182b1a7694" },
                    { 2, "Concern", "Teacher", "e3df062f-6566-4238-88ad-7f5bcee653d7" },
                    { 3, "Concern", "Teacher", "6438a460-46fa-4038-944e-df4e9869ce0d" },
                    { 4, "Concern", "Teacher", "149da79b-cbd6-4ee5-bd64-2782770ed5a6" },
                    { 5, "Concern", "Student", "b69eed44-a66a-43ec-8698-6cb83f87e28a" },
                    { 6, "Concern", "Student", "cc424f74-d7cf-4d26-87cf-b790679c8e3b" },
                    { 7, "Concern", "Student", "1f085b34-69b0-49ba-a182-dab50bf0bda7" },
                    { 8, "Concern", "Student", "31e43467-b393-4895-a1d6-da6fbf87e7a2" },
                    { 9, "Concern", "Student", "47367b6d-edad-467b-a373-7d4fafa3e875" }
                });

            migrationBuilder.InsertData(
                schema: "ec",
                table: "Groupes",
                columns: new[] { "Id", "EnseignantId", "Nom", "Numero" },
                values: new object[,]
                {
                    { 1, 3, "مجموعة البنات", 1 },
                    { 2, 2, "مجموعة الصباح", 2 },
                    { 3, 1, "مجموعة المساء", 3 },
                    { 4, 1, "مجموعة نهاية الأسبوع", 4 }
                });

            migrationBuilder.InsertData(
                schema: "ec",
                table: "IdentificationEnseignants",
                columns: new[] { "EnseignantId", "IdentityUserId" },
                values: new object[,]
                {
                    { 1, "e3df062f-6566-4238-88ad-7f5bcee653d7" },
                    { 2, "6438a460-46fa-4038-944e-df4e9869ce0d" },
                    { 3, "149da79b-cbd6-4ee5-bd64-2782770ed5a6" }
                });

            migrationBuilder.InsertData(
                schema: "ec",
                table: "Etudiants",
                columns: new[] { "Id", "Adresse", "Email", "GroupeId", "Naissance", "Nom", "Phone", "Prenom" },
                values: new object[,]
                {
                    { 1, "حي تاكبو، المدية", "ahmed.mido@gmail.com", 3, new DateTime(2001, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "بوحمد", "05 01 01 01", "أحمد" },
                    { 2, "حي الزهور، بجاية", "arezki.rzk@gmail.com", 3, new DateTime(1978, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "بن رزقي", "05 02 02 02", "أرزقي" },
                    { 3, "حى باب القواس، المدية", "amerrr@gmail.com", 3, new DateTime(1963, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "بوعمر", "05 03 03 03", "عمر" },
                    { 4, "مدينة الصخور، الرغاية", "so.sidou33@bmail.com", 2, new DateTime(1990, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "سيدو", "05 04 04 04", "سفيان" },
                    { 5, "حي بولوغين، الجزائر العاصمة", "samimi@gmail.com", 1, new DateTime(1998, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "سليمة", "05 05 05 05", "سميحة" },
                    { 6, "حي خمسة منازل، الجزائر العاصمة", "fati.bb@gmail.com", 1, new DateTime(2005, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "بوفطوم", "05 06 06 06", "فاطمة" },
                    { 7, "طريق الأكاسيا، المدية", "bousemar.sam@gmail.com", 1, new DateTime(1999, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "بوسمار", "05 07 07 07", "سميرة" },
                    { 8, "حي الأكاديمي، المدية", "ameur.am@gmail.com", 4, new DateTime(1996, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "معمر", "05 08 08 08", "عمر" },
                    { 9, "شارع الورود، البليدة", "anissa.nissou@gmail.com", 1, new DateTime(1994, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "ليونس", "05 09 09 09", "أنيسة" },
                    { 10, "حي الأربع طرق، تيبازة", "hamdi.h@gmail.com", 1, new DateTime(1992, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "حمدي", "05 10 10 10", "حميدة" },
                    { 11, "حي تاكبو، المدية", "bou7.hmidah@gmail.com", 4, new DateTime(1978, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "بوحمد ", "05 11 11 11", "محمود" },
                    { 12, "حي تاكبو، المدية", "lounis.anis@gmail.com", 2, new DateTime(1997, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "ليونس ", "05 12 12 12", "أنيس" },
                    { 13, "حى باب القواس، المدية", "elrachid03@gmail.com", 4, new DateTime(2003, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "بوراشدي", "05 13 13 13", "رشيد" },
                    { 14, "طريق الأكاسيا، المدية", "zaki7mimi@gmail.com", 4, new DateTime(2005, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "حميمي", "05 14 14 14", "زكريا" },
                    { 15, "حى باب القواس، المدية", "nassirou93@gmail.com", 2, new DateTime(1993, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "بن ناصر", "05 15 15 15", "نصرالدين" }
                });

            migrationBuilder.InsertData(
                schema: "ec",
                table: "Absences",
                columns: new[] { "Id", "Date", "EtudiantId", "Observation" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "مشغول" },
                    { 2, new DateTime(2022, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "غير مبرر" },
                    { 3, new DateTime(2022, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "شؤون عائلية" },
                    { 4, new DateTime(2022, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "حركة المرور" },
                    { 5, new DateTime(2022, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "عرس" },
                    { 6, new DateTime(2022, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "مشغول" },
                    { 7, new DateTime(2022, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "غير مبرر" },
                    { 8, new DateTime(2022, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "غير مبرر" },
                    { 9, new DateTime(2022, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "خرجة عائلية" },
                    { 10, new DateTime(2022, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "نسيان" },
                    { 11, new DateTime(2022, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "مراجعة إمتحان" },
                    { 12, new DateTime(2022, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "تفرج مبارات" },
                    { 13, new DateTime(2022, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "رحلة" },
                    { 14, new DateTime(2022, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "شؤون تجارية" },
                    { 15, new DateTime(2022, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "شؤون تجارية" },
                    { 16, new DateTime(2022, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "غير مبرر" }
                });

            migrationBuilder.InsertData(
                schema: "ec",
                table: "IdentificationEtudiants",
                columns: new[] { "EtudiantId", "IdentityUserId" },
                values: new object[,]
                {
                    { 1, "b69eed44-a66a-43ec-8698-6cb83f87e28a" },
                    { 3, "cc424f74-d7cf-4d26-87cf-b790679c8e3b" },
                    { 5, "1f085b34-69b0-49ba-a182-dab50bf0bda7" },
                    { 7, "31e43467-b393-4895-a1d6-da6fbf87e7a2" },
                    { 9, "47367b6d-edad-467b-a373-7d4fafa3e875" }
                });

            migrationBuilder.InsertData(
                schema: "ec",
                table: "Revisions",
                columns: new[] { "Id", "Date", "EtudiantId", "HizbId", "HuitiemeId" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 1 },
                    { 2, new DateTime(2022, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 1 },
                    { 3, new DateTime(2022, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 1, 1 },
                    { 4, new DateTime(2022, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 1, 1 },
                    { 5, new DateTime(2022, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 1, 1 },
                    { 6, new DateTime(2022, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 1, 1 },
                    { 7, new DateTime(2022, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 1, 1 },
                    { 8, new DateTime(2022, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 1 },
                    { 9, new DateTime(2022, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 1 },
                    { 10, new DateTime(2022, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 1, 2 },
                    { 11, new DateTime(2022, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 1, 2 },
                    { 12, new DateTime(2022, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 1, 2 },
                    { 13, new DateTime(2022, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 1, 2 },
                    { 14, new DateTime(2022, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 1, 3 },
                    { 15, new DateTime(2022, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 2 },
                    { 16, new DateTime(2022, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 2 },
                    { 17, new DateTime(2022, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 1, 3 },
                    { 18, new DateTime(2022, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 1, 3 },
                    { 19, new DateTime(2022, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 1, 3 },
                    { 20, new DateTime(2022, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 1, 4 },
                    { 21, new DateTime(2022, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 1, 4 }
                });

            migrationBuilder.InsertData(
                schema: "ec",
                table: "Revisions",
                columns: new[] { "Id", "Date", "EtudiantId", "HizbId", "HuitiemeId" },
                values: new object[,]
                {
                    { 22, new DateTime(2022, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 2 },
                    { 23, new DateTime(2022, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 4 },
                    { 24, new DateTime(2022, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 1, 3 },
                    { 25, new DateTime(2022, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 1, 5 },
                    { 26, new DateTime(2022, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 1, 4 },
                    { 27, new DateTime(2022, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 1, 6 },
                    { 28, new DateTime(2022, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 1, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Absences_EtudiantId",
                schema: "ec",
                table: "Absences",
                column: "EtudiantId");

            migrationBuilder.CreateIndex(
                name: "IX_Etudiants_GroupeId",
                schema: "ec",
                table: "Etudiants",
                column: "GroupeId");

            migrationBuilder.CreateIndex(
                name: "IX_Groupes_EnseignantId",
                schema: "ec",
                table: "Groupes",
                column: "EnseignantId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentificationEnseignants_IdentityUserId",
                schema: "ec",
                table: "IdentificationEnseignants",
                column: "IdentityUserId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentificationEtudiants_IdentityUserId",
                schema: "ec",
                table: "IdentificationEtudiants",
                column: "IdentityUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Revisions_EtudiantId",
                schema: "ec",
                table: "Revisions",
                column: "EtudiantId");

            migrationBuilder.CreateIndex(
                name: "IX_Revisions_HizbId",
                schema: "ec",
                table: "Revisions",
                column: "HizbId");

            migrationBuilder.CreateIndex(
                name: "IX_Revisions_HuitiemeId",
                schema: "ec",
                table: "Revisions",
                column: "HuitiemeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Absences",
                schema: "ec");

            migrationBuilder.DropTable(
                name: "IdentificationEnseignants",
                schema: "ec");

            migrationBuilder.DropTable(
                name: "IdentificationEtudiants",
                schema: "ec");

            migrationBuilder.DropTable(
                name: "Revisions",
                schema: "ec");

            migrationBuilder.DropTable(
                name: "Etudiants",
                schema: "ec");

            migrationBuilder.DropTable(
                name: "Hizbs",
                schema: "ec");

            migrationBuilder.DropTable(
                name: "Huitiemes",
                schema: "ec");

            migrationBuilder.DropTable(
                name: "Groupes",
                schema: "ec");

            migrationBuilder.DropTable(
                name: "Enseignants",
                schema: "ec");

            migrationBuilder.DeleteData(
                schema: "ec",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "ec",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "ec",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "ec",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "ec",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "ec",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "ec",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "ec",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                schema: "ec",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                schema: "ec",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "149da79b-cbd6-4ee5-bd64-2782770ed5a6");

            migrationBuilder.DeleteData(
                schema: "ec",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1f085b34-69b0-49ba-a182-dab50bf0bda7");

            migrationBuilder.DeleteData(
                schema: "ec",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "31e43467-b393-4895-a1d6-da6fbf87e7a2");

            migrationBuilder.DeleteData(
                schema: "ec",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "47367b6d-edad-467b-a373-7d4fafa3e875");

            migrationBuilder.DeleteData(
                schema: "ec",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6438a460-46fa-4038-944e-df4e9869ce0d");

            migrationBuilder.DeleteData(
                schema: "ec",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b69eed44-a66a-43ec-8698-6cb83f87e28a");

            migrationBuilder.DeleteData(
                schema: "ec",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cc424f74-d7cf-4d26-87cf-b790679c8e3b");

            migrationBuilder.DeleteData(
                schema: "ec",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e3df062f-6566-4238-88ad-7f5bcee653d7");

            migrationBuilder.DeleteData(
                schema: "ec",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fa5ab430-ac77-46b5-b4c2-48182b1a7694");

            migrationBuilder.RenameTable(
                name: "AspNetUserTokens",
                schema: "ec",
                newName: "AspNetUserTokens");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                schema: "ec",
                newName: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                schema: "ec",
                newName: "AspNetUserRoles");

            migrationBuilder.RenameTable(
                name: "AspNetUserLogins",
                schema: "ec",
                newName: "AspNetUserLogins");

            migrationBuilder.RenameTable(
                name: "AspNetUserClaims",
                schema: "ec",
                newName: "AspNetUserClaims");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                schema: "ec",
                newName: "AspNetRoles");

            migrationBuilder.RenameTable(
                name: "AspNetRoleClaims",
                schema: "ec",
                newName: "AspNetRoleClaims");
        }
    }
}
