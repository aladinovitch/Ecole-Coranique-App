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
                name: "Ecole_Coranique");

            migrationBuilder.CreateTable(
                name: "Enseignant",
                schema: "Ecole_Coranique",
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
                    table.PrimaryKey("PK_Enseignant", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hizb",
                schema: "Ecole_Coranique",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hizb", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Huitieme",
                schema: "Ecole_Coranique",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Huitieme", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Groupe",
                schema: "Ecole_Coranique",
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
                    table.PrimaryKey("PK_Groupe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Groupe_Enseignant_EnseignantId",
                        column: x => x.EnseignantId,
                        principalSchema: "Ecole_Coranique",
                        principalTable: "Enseignant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Etudiant",
                schema: "Ecole_Coranique",
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
                    table.PrimaryKey("PK_Etudiant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Etudiant_Groupe_GroupeId",
                        column: x => x.GroupeId,
                        principalSchema: "Ecole_Coranique",
                        principalTable: "Groupe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Absence",
                schema: "Ecole_Coranique",
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
                    table.PrimaryKey("PK_Absence", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Absence_Etudiant_EtudiantId",
                        column: x => x.EtudiantId,
                        principalSchema: "Ecole_Coranique",
                        principalTable: "Etudiant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Revision",
                schema: "Ecole_Coranique",
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
                    table.PrimaryKey("PK_Revision", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Revision_Etudiant_EtudiantId",
                        column: x => x.EtudiantId,
                        principalSchema: "Ecole_Coranique",
                        principalTable: "Etudiant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Revision_Hizb_HizbId",
                        column: x => x.HizbId,
                        principalSchema: "Ecole_Coranique",
                        principalTable: "Hizb",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Revision_Huitieme_HuitiemeId",
                        column: x => x.HuitiemeId,
                        principalSchema: "Ecole_Coranique",
                        principalTable: "Huitieme",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "22a1995d-7000-4d96-b40d-0b9f42973836", 0, "4bf36c32-76f1-4db4-871f-6287e1683a31", "basic@email.com", true, false, null, "BASIC@EMAIL.COM", "BASIC@EMAIL.COM", "AQAAAAEAACcQAAAAEI8G0tK6X0chJWxGfjwxWxmneCVsik7cVj358bCvuF+1gslaaKvHVKOvaX0/KMlGNw==", null, false, "3c39b0b2-f16b-45fc-b36e-4f1571219c54", false, "basic@email.com" },
                    { "73841e2d-15a3-47a3-a6eb-e76b04614cbc", 0, "4f050bb6-101b-4f31-ad78-1e8f5efa8cd7", "manager@email.com", true, false, null, "MANAGER@EMAIL.COM", "MANAGER@EMAIL.COM", "AQAAAAEAACcQAAAAEE1tWtDhUIUUpZ2+jE8titfIKVQUndKlFnO7GnE1bQKtW71OoHFgWoyHUKvtYFENAA==", null, false, "6deca103-6838-4639-9aca-d1b665d8b858", false, "manager@email.com" }
                });

            migrationBuilder.InsertData(
                schema: "Ecole_Coranique",
                table: "Enseignant",
                columns: new[] { "Id", "Adresse", "Email", "Nom", "Phone", "Prenom" },
                values: new object[,]
                {
                    { 1, "Quartier Thniet el Hdjer, Médéa", "sli.mane@gmail.com", "Benslimane", "05 10 10 10", "Slimane" },
                    { 2, "Quartier Ain Dhheb, Médéa", "aliben@gmail.co", "Benali", "05 20 20 20", "Ali" },
                    { 3, "Quartier M'salah, Médéa", "ss.bousahla@gmail.com", "Bousahla", "05 30 30 30", "Souhila" },
                    { 4, "Quartier Merdj Echkir, Médéa", "amina.ben@gmail.com", "Benyamina", "05 40 40 40", "Amina" }
                });

            migrationBuilder.InsertData(
                schema: "Ecole_Coranique",
                table: "Hizb",
                columns: new[] { "Id", "Nom", "Numero" },
                values: new object[,]
                {
                    { 1, "الحزب 01 - ( الم ذلك ) من سورة البقرة", 1 },
                    { 2, "الحزب 02 - ( واذا لقوا ) من سورة البقرة", 2 },
                    { 3, "الحزب 03 - ( سيقولالسفهاء ) من سورة البقرة", 3 },
                    { 4, "الحزب 04 - ( واذكرواالله ) من سورة البقرة", 4 },
                    { 5, "الحزب 05 - ( تلك الرسل ) من سورة البقرة - سورة أل عمران", 5 },
                    { 6, "الحزب 06 - ( قل أؤنبئكم ) من سورة أل عمران", 6 },
                    { 7, "الحزب 07 - ( لن تنالوا ) من سورة أل عمران", 7 },
                    { 8, "الحزب 08 - ( يستبشرون ) من سورة أل عمران - سورة النساء", 8 },
                    { 9, "الحزب 09 -( والمحصنات ) من سورة النساء", 9 },
                    { 10, "الحزب 10 - ( الله لااله الاهو ) من سورة النساء", 10 },
                    { 11, "الحزب 11 - ( لا يحب ) من سورة النساء - سورة المائدة", 11 },
                    { 12, "الحزب 12 - ( قال رجلان ) من سورة المائدة", 12 },
                    { 13, "الحزب 13 - ( لتجدن ) من سورة المائدة - سورة الأنعام", 13 },
                    { 14, "الحزب 14 - ( انما يستجيب ) من سورة الأنعام", 14 },
                    { 15, "الحزب 15 - ( ولو أننا نزلنا ) من سورة الأنعام", 15 },
                    { 16, "الحزب 16 - ( المص كتب ) من سورة الأعراف", 16 },
                    { 17, "الحزب 17 - ( قال الملأ ) من سورة الأعراف", 17 },
                    { 18, "الحزب 18 - ( واذ نتقنا ) من سورة الأعراف - سورة الأنفال", 18 },
                    { 19, "الحزب 19 - ( واعلموا ) من سورة الأنفال - سورة التوبة", 19 },
                    { 20, "الحزب 20 - ( ان كثيرا ) من سورة التوبة", 20 },
                    { 21, "الحزب 21 - ( انما السبيل ) من سورة التوبة - سورة يونس", 21 },
                    { 22, "الحزب 22 - ( للذين أحسنوا ) من سورة يونس - سورة هود", 22 },
                    { 23, "الحزب 23 - ( ومامن دابة ) من سورة هود", 23 },
                    { 24, "الحزب 24 - ( والى مدين ) من سورة هود - سورة يوسف", 24 },
                    { 25, "الحزب 25 - ( وما أبرئ ) من سورة يوسف - سورة الرعد", 25 },
                    { 26, "الحزب 26 - ( أفمن يعلم ) من سورة الرعد - سورة ابراهيم", 26 },
                    { 27, "الحزب 27 - ( ربما ) من سورة الحجر - سورة النحل", 27 },
                    { 28, "الحزب 28 - ( وقال الله لا تتخذوا ) من سورة النحل", 28 },
                    { 29, "الحزب 29 - ( سبحن ) من سورة الاسراء", 29 },
                    { 30, "الحزب 30 - ( أولم يروا ) من سورة الاسراء - سورة الكهف", 30 },
                    { 31, "الحزب 31 - ( قال ألم أقل ) من سورة الكهف - سورة مريم", 31 },
                    { 32, "الحزب 32 - ( طه ) من سورة طه", 32 },
                    { 33, "الحزب 33 - ( اقترب ) من سورة الأنبياء", 33 },
                    { 34, "الحزب 34 - ( يأيها الناس ) من سورة الحج", 34 },
                    { 35, "الحزب 35 - ( قدأفلح ) من سورة المومنون - سورة النور", 35 },
                    { 36, "الحزب 36 - ( لاتتبعوا ) من سورة النور - سورة الفرقان", 36 }
                });

            migrationBuilder.InsertData(
                schema: "Ecole_Coranique",
                table: "Hizb",
                columns: new[] { "Id", "Nom", "Numero" },
                values: new object[,]
                {
                    { 37, "الحزب 37 - ( وقال الذين ) من سورة الفرقان - سورة الشعراء", 37 },
                    { 38, "الحزب 38 - ( قالوا أنومن ) من سورة الشعراء - سورة النمل", 38 },
                    { 39, "الحزب 39 - ( فما كان جواب ) من سورة النمل - سورة اقصص", 39 },
                    { 40, "الحزب 40 - ( ولقد وصلنا ) من سورة القصص - سورة العنكبوت", 40 },
                    { 41, "الحزب 41 - ( ولا تجادلوا ) من سورة العنكبوت - سورة الروم - سورة لقمن", 41 },
                    { 42, "الحزب 42 - ( ومن يسلم ) من سورة لقمن - سورة السجدة - سورة الأحزاب", 42 },
                    { 43, "الحزب 43 - ( ومن يقنت ) من سورة الأحزاب - سورة سبأ", 43 },
                    { 44, "الحزب 44 - ( قل من يرزقكم ) من سورة سبأ - سورة فاطر - سورة يس", 44 },
                    { 45, "الحزب 45 - ( وماأنزلنا ) من سورة يس - سورة الصفت", 45 },
                    { 46, "الحزب 46 - ( فنبذنه ) من سورة الصفت الى سورة ص الى سورة الزمر", 46 },
                    { 47, "الحزب 47 - ( فمن أظلم ) من سورة الزمر - سورة غافر", 47 },
                    { 48, "الحزب 48 - ( ويقوم مالي ) من سورة غافر - سورة فصلت", 48 },
                    { 49, "الحزب 49 - ( اليه يرد ) من سورة فصلت - سورة الشورى - سورة الزخرف", 49 },
                    { 50, "الحزب 50 - ( قل أولوجئتكم ) من سورة الزخرف - سورة الدخان - سورة الجاثية", 50 },
                    { 51, "الحزب 51 - ( حم ماخلقنا ) من سورة الأحقاف الىسورة محمد - سورة الفتح", 51 },
                    { 52, "الحزب 52 - ( لقد رضي ) من سورة الفتح - سورة :سورة الحجرات - سورة ق - سورة الذريات", 52 },
                    { 53, "الحزب 53 - ( قال فما خطبكم ) من سورة الذريات - سورة الطور - سورة النجم - سورة القمر", 53 },
                    { 54, "الحزب 54 - ( الرحمن ) من سورة الرحمن - سورة الواقعة - سورة الحديد", 54 },
                    { 55, "الحزب 55 - ( قد سمع ) من سورة المجادلة - سورة الحشر - سورة الممتحنة - سورة الصف", 55 },
                    { 56, "الحزب 56 - ( يسبح لله ) من سورة الجمعة - سورة المنفقون - سورة التغابن - سورة الطلاق - سورة التحريم", 56 },
                    { 57, "الحزب 57 - ( تبرك الذي ) من سورة الملك - سورة القلم - سورة الحاقة - سورة المعارج - سورة نوح", 57 },
                    { 58, "الحزب 58 - ( قل أوحي ) من سورة الجن - سورة المزمل - سورة المدثر - سورة القيمة - سورة الانسان - سورة المرسلات", 58 },
                    { 59, "الحزب 59 - ( عم يتساءلون ) سورة النبأ - النزعات - عبس - التكوير - الانفطار - المطففين - الانشقاق - البروج - الطارق", 59 },
                    { 60, "الحزب 60 - ( سبح ) من سورة الأعلى الى سورة الناس", 60 }
                });

            migrationBuilder.InsertData(
                schema: "Ecole_Coranique",
                table: "Huitieme",
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
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[,]
                {
                    { 1, "Manager", "true", "73841e2d-15a3-47a3-a6eb-e76b04614cbc" },
                    { 2, "Basic user", "true", "22a1995d-7000-4d96-b40d-0b9f42973836" }
                });

            migrationBuilder.InsertData(
                schema: "Ecole_Coranique",
                table: "Groupe",
                columns: new[] { "Id", "EnseignantId", "Nom", "Numero" },
                values: new object[,]
                {
                    { 1, 3, "Groupe filles", 1 },
                    { 2, 4, "Groupe matin", 2 },
                    { 3, 1, "Groupe après-midi", 3 }
                });

            migrationBuilder.InsertData(
                schema: "Ecole_Coranique",
                table: "Etudiant",
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
                schema: "Ecole_Coranique",
                table: "Absence",
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
                schema: "Ecole_Coranique",
                table: "Revision",
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
                name: "IX_Absence_EtudiantId",
                schema: "Ecole_Coranique",
                table: "Absence",
                column: "EtudiantId");

            migrationBuilder.CreateIndex(
                name: "IX_Etudiant_GroupeId",
                schema: "Ecole_Coranique",
                table: "Etudiant",
                column: "GroupeId");

            migrationBuilder.CreateIndex(
                name: "IX_Groupe_EnseignantId",
                schema: "Ecole_Coranique",
                table: "Groupe",
                column: "EnseignantId");

            migrationBuilder.CreateIndex(
                name: "IX_Revision_EtudiantId",
                schema: "Ecole_Coranique",
                table: "Revision",
                column: "EtudiantId");

            migrationBuilder.CreateIndex(
                name: "IX_Revision_HizbId",
                schema: "Ecole_Coranique",
                table: "Revision",
                column: "HizbId");

            migrationBuilder.CreateIndex(
                name: "IX_Revision_HuitiemeId",
                schema: "Ecole_Coranique",
                table: "Revision",
                column: "HuitiemeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Absence",
                schema: "Ecole_Coranique");

            migrationBuilder.DropTable(
                name: "Revision",
                schema: "Ecole_Coranique");

            migrationBuilder.DropTable(
                name: "Etudiant",
                schema: "Ecole_Coranique");

            migrationBuilder.DropTable(
                name: "Hizb",
                schema: "Ecole_Coranique");

            migrationBuilder.DropTable(
                name: "Huitieme",
                schema: "Ecole_Coranique");

            migrationBuilder.DropTable(
                name: "Groupe",
                schema: "Ecole_Coranique");

            migrationBuilder.DropTable(
                name: "Enseignant",
                schema: "Ecole_Coranique");

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22a1995d-7000-4d96-b40d-0b9f42973836");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "73841e2d-15a3-47a3-a6eb-e76b04614cbc");
        }
    }
}
