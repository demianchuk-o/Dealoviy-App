using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Dealoviy.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContractorProfiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdditionalInfo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractorProfiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContractorProfiles_ContactInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractorProfiles_ContactInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContractorProfiles_ContactInfos_ContractorProfiles_UserId",
                        column: x => x.UserId,
                        principalTable: "ContractorProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContractorProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_ContractorProfiles_ContractorProfileId",
                        column: x => x.ContractorProfileId,
                        principalTable: "ContractorProfiles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RegionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContractorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    LowerPriceBound = table.Column<int>(type: "int", nullable: false),
                    UpperPriceBound = table.Column<int>(type: "int", nullable: false),
                    AverageRating = table.Column<double>(type: "float", nullable: false),
                    RatingCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Services_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Services_ContractorProfiles_ContractorId",
                        column: x => x.ContractorId,
                        principalTable: "ContractorProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentAmount = table.Column<int>(type: "int", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerContactType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CustomerContactValue = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ContractorContactType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ContractorContactValue = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Users_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentAmount = table.Column<int>(type: "int", nullable: false),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RequestStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerContactType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CustomerContactValue = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ContractorContactType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ContractorContactValue = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requests_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Requests_Users_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("1323431f-827f-4e00-9f50-227d743b1f92"), "Khmelnytska Oblast" },
                    { new Guid("3866942e-5959-4f70-8858-224e3d24ac08"), "Kharkivska Oblast" },
                    { new Guid("43aeb7dd-426f-4b27-a2c4-06e0ff07d381"), "Chernihivska Oblast" },
                    { new Guid("4a62f755-ade2-4151-96bc-f9e705df4660"), "Odeska Oblast" },
                    { new Guid("4b8c90e4-b235-4cda-87f1-a35e2c0d9ff9"), "Khersonska Oblast" },
                    { new Guid("580d250d-74e2-435d-b446-a9f961d0aa0b"), "Ivano-Frankivska Oblast" },
                    { new Guid("5fc1486d-c59c-4c09-8fef-3c1e99f083ae"), "Ternopilska Oblast" },
                    { new Guid("60062e61-8215-4016-a6f5-d66241791949"), "Zakarpatska Oblast" },
                    { new Guid("618fde56-be7c-489a-a7ec-99a1991d2fa8"), "Rivnenska Oblast" },
                    { new Guid("6b389a1c-46be-4214-8976-e654c1e19b89"), "Dnipropetrovska Oblast" },
                    { new Guid("709eed3c-e5f4-47a6-9701-a758b770504f"), "Sumska Oblast" },
                    { new Guid("8271b2b5-cdc3-4ddb-82cb-479cec96a5fa"), "Kyivska Oblast" },
                    { new Guid("843e9b23-ccaa-4574-890a-4a4584b0e627"), "Donetska Oblast" },
                    { new Guid("855ec202-37c6-4687-91f3-309533ba4f22"), "Mykolaivska Oblast" },
                    { new Guid("8dd1a890-003b-4bc4-ab17-f7842f59a7e5"), "Kirovohradska Oblast" },
                    { new Guid("93857ec5-5719-43cf-b892-c4315473ac24"), "Chernivetska Oblast" },
                    { new Guid("97c88dc3-1450-4a11-9ae5-e6daf828971e"), "Sevastopol, Misto" },
                    { new Guid("9d08ac6d-6cbe-43ec-b501-46ae19de0ddb"), "Zhytomyrska Oblast" },
                    { new Guid("a1099927-b4f8-4154-ac4e-fc170784468a"), "Krym, Avtonomna Respublika" },
                    { new Guid("a317761b-0e25-4efb-9586-0f65c8d6afe4"), "Volynska Oblast" },
                    { new Guid("b047d78d-760f-4ecc-9ce7-4a956ede3ba6"), "Luhanska Oblast" },
                    { new Guid("e1340df7-76f5-46ab-a46a-db19eb78c67b"), "Kyiv, Misto" },
                    { new Guid("e4c7e65f-59eb-4613-ad49-5520726399b9"), "Zaporizka Oblast" },
                    { new Guid("ea6feef8-8328-4f9e-bd88-e40ad74f3506"), "Poltavska Oblast" },
                    { new Guid("f9cae5cf-fcc2-4915-94c1-eba20d22dd6f"), "Vinnytska Oblast" },
                    { new Guid("fb00c154-2eee-4190-bbad-36ce2abc77d0"), "Cherkaska Oblast" },
                    { new Guid("fd38a444-2429-4d5f-921d-e5c69eaabade"), "Lvivska Oblast" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name", "RegionId" },
                values: new object[,]
                {
                    { new Guid("02ed0b87-f430-4bbd-84b1-86367121b637"), "Mariupol", new Guid("843e9b23-ccaa-4574-890a-4a4584b0e627") },
                    { new Guid("06145181-e200-41e9-86c5-c8eb07ba91e5"), "Piskivka", new Guid("8271b2b5-cdc3-4ddb-82cb-479cec96a5fa") },
                    { new Guid("06d9eeb3-39a5-4db3-a544-6a86378e3ae1"), "Rivne", new Guid("618fde56-be7c-489a-a7ec-99a1991d2fa8") },
                    { new Guid("0789037e-efa0-4f9a-9e9d-f96817b0459c"), "Khmelnytskyi", new Guid("1323431f-827f-4e00-9f50-227d743b1f92") },
                    { new Guid("0a9ca6ea-3864-4f14-b836-34bb3603869a"), "Druzhkivka", new Guid("843e9b23-ccaa-4574-890a-4a4584b0e627") },
                    { new Guid("0c788eb9-baad-40e5-a3b8-83865aa5a1bf"), "Vynnyky", new Guid("fd38a444-2429-4d5f-921d-e5c69eaabade") },
                    { new Guid("0d207a50-8c3c-46e3-99cb-ad1cb4d42fbb"), "Kamianske", new Guid("6b389a1c-46be-4214-8976-e654c1e19b89") },
                    { new Guid("0dbd88c8-7059-41bc-835c-95f07a042010"), "Kaihador", new Guid("a1099927-b4f8-4154-ac4e-fc170784468a") },
                    { new Guid("0fd75b60-b9d3-48ad-9db2-0eae7e33ca2e"), "Sambir", new Guid("fd38a444-2429-4d5f-921d-e5c69eaabade") },
                    { new Guid("1126b894-6f8e-4c2a-b1d3-12fdfdb188e0"), "Vasylkiv", new Guid("8271b2b5-cdc3-4ddb-82cb-479cec96a5fa") },
                    { new Guid("11f5cf63-13e0-46ff-8e89-8aa4d025312e"), "Donetsk", new Guid("843e9b23-ccaa-4574-890a-4a4584b0e627") },
                    { new Guid("129e05fe-2678-4e57-9c9f-2178bb17433c"), "Pokrovsk", new Guid("843e9b23-ccaa-4574-890a-4a4584b0e627") },
                    { new Guid("12fef53b-81e4-432b-85fe-8e26e969122d"), "Yevpatoriia", new Guid("a1099927-b4f8-4154-ac4e-fc170784468a") },
                    { new Guid("141e4e4c-0159-4a90-a0d5-bce978623ef1"), "Novohrad-Volynskyi", new Guid("9d08ac6d-6cbe-43ec-b501-46ae19de0ddb") },
                    { new Guid("172f8305-2191-49b4-becf-d72ed2472594"), "Avdiivka", new Guid("843e9b23-ccaa-4574-890a-4a4584b0e627") },
                    { new Guid("17dd1dd0-2092-43ba-a732-4f3c8415da4f"), "Khartsyzk", new Guid("843e9b23-ccaa-4574-890a-4a4584b0e627") },
                    { new Guid("1ac439c1-4edc-4adb-aa24-f8828b513ff5"), "Ivano-Frankivsk", new Guid("580d250d-74e2-435d-b446-a9f961d0aa0b") },
                    { new Guid("1cb28c2a-2b36-43fd-a335-9aeea0e73cf6"), "Chornukhyne", new Guid("b047d78d-760f-4ecc-9ce7-4a956ede3ba6") },
                    { new Guid("1cc0d71c-2ffc-4159-b001-dde89d3d2fb7"), "Ruski Tyshky", new Guid("3866942e-5959-4f70-8858-224e3d24ac08") },
                    { new Guid("1d96c5cd-d1b2-4aca-86f4-ee42d2059c5e"), "Simferopol", new Guid("a1099927-b4f8-4154-ac4e-fc170784468a") },
                    { new Guid("1dda1719-fe42-457e-8111-b16494128f84"), "Nyzhnia Krynka", new Guid("843e9b23-ccaa-4574-890a-4a4584b0e627") },
                    { new Guid("1f652aab-8327-4e62-90a7-bc68f5a8ec64"), "Bila Tserkva", new Guid("8271b2b5-cdc3-4ddb-82cb-479cec96a5fa") },
                    { new Guid("1f8157cd-903a-486e-bc79-683d8540ced5"), "Kryukivshchyna", new Guid("8271b2b5-cdc3-4ddb-82cb-479cec96a5fa") },
                    { new Guid("20b56fbd-55c6-49d8-8d2f-c6c2055187fa"), "Kotsyubyns’ke", new Guid("e1340df7-76f5-46ab-a46a-db19eb78c67b") },
                    { new Guid("22c1ecfe-d9eb-45c8-93ec-ac12577b2645"), "Chystiakove", new Guid("843e9b23-ccaa-4574-890a-4a4584b0e627") },
                    { new Guid("23701685-e2a6-49a9-aeb0-d589c4ae31cb"), "Mykhaylivka-Rubezhivka", new Guid("8271b2b5-cdc3-4ddb-82cb-479cec96a5fa") },
                    { new Guid("23b0b7a0-60a4-4e0d-9266-66dcfc594d30"), "Inkerman", new Guid("97c88dc3-1450-4a11-9ae5-e6daf828971e") },
                    { new Guid("243ffa66-a531-4a8b-bc52-bbbe880cd424"), "Zhmerynka", new Guid("f9cae5cf-fcc2-4915-94c1-eba20d22dd6f") },
                    { new Guid("245cf490-e860-4079-9da0-bca55f1dfaaa"), "Romny", new Guid("709eed3c-e5f4-47a6-9701-a758b770504f") },
                    { new Guid("24b0651d-7411-40f6-b013-4d242c3f8b69"), "Bilshivtsi", new Guid("580d250d-74e2-435d-b446-a9f961d0aa0b") },
                    { new Guid("26a388d4-9133-42c6-ac8e-e172a8769b3e"), "Pesochin", new Guid("3866942e-5959-4f70-8858-224e3d24ac08") },
                    { new Guid("284838ef-2c2c-4949-9343-96fd9cd3498e"), "Taromske", new Guid("6b389a1c-46be-4214-8976-e654c1e19b89") },
                    { new Guid("2a008c69-114b-4805-912e-355ab4a2595b"), "Horlivka", new Guid("843e9b23-ccaa-4574-890a-4a4584b0e627") },
                    { new Guid("2a10ca51-d440-4550-9840-fc9154889e7f"), "Haspra", new Guid("a1099927-b4f8-4154-ac4e-fc170784468a") },
                    { new Guid("2a50bf71-0a47-4a54-8fdc-95d00bfb522e"), "Masandra", new Guid("a1099927-b4f8-4154-ac4e-fc170784468a") },
                    { new Guid("2a97618a-fe9e-4646-9844-f8db7454a28d"), "Sievierodonetsk", new Guid("b047d78d-760f-4ecc-9ce7-4a956ede3ba6") },
                    { new Guid("2af46870-4eb5-4d37-be27-56d9ca79d976"), "Molodohvardiisk", new Guid("b047d78d-760f-4ecc-9ce7-4a956ede3ba6") },
                    { new Guid("2b565b7d-675c-43a4-960a-276c5cf67039"), "Iverske", new Guid("843e9b23-ccaa-4574-890a-4a4584b0e627") },
                    { new Guid("2c0fd78d-f2f4-49c8-8b4d-6e6fb7f94a3a"), "Sloviansk", new Guid("843e9b23-ccaa-4574-890a-4a4584b0e627") },
                    { new Guid("2d69f693-c50c-4216-8ce8-1f8a3aeac7b5"), "Vynohradiv", new Guid("60062e61-8215-4016-a6f5-d66241791949") },
                    { new Guid("2d85345e-d075-4805-8f6c-7d058ccfef70"), "Chervonohrad", new Guid("fd38a444-2429-4d5f-921d-e5c69eaabade") },
                    { new Guid("2d90c829-dd42-4f13-9537-8f02f256c677"), "Liubotyn", new Guid("3866942e-5959-4f70-8858-224e3d24ac08") },
                    { new Guid("2dcb360b-2370-40d7-b1c1-a9f52f06bca9"), "Khrustalnyi", new Guid("b047d78d-760f-4ecc-9ce7-4a956ede3ba6") },
                    { new Guid("3119b682-53e2-44f1-8525-fdd1a89480ca"), "Stari Kodaky", new Guid("6b389a1c-46be-4214-8976-e654c1e19b89") },
                    { new Guid("312efef1-6d3f-4971-951e-615943782be5"), "Lyubymivka", new Guid("6b389a1c-46be-4214-8976-e654c1e19b89") },
                    { new Guid("330aaa8e-21a6-4e0c-9b85-05ff7f7e2e32"), "Sartana", new Guid("843e9b23-ccaa-4574-890a-4a4584b0e627") },
                    { new Guid("339e52aa-5362-41e4-918d-bbf5c40187f8"), "Pereyaslav-Khmel’nyts’kyy", new Guid("8271b2b5-cdc3-4ddb-82cb-479cec96a5fa") },
                    { new Guid("34ded21f-8b33-4ac4-8b4c-573ad8da803c"), "Horodenka", new Guid("580d250d-74e2-435d-b446-a9f961d0aa0b") },
                    { new Guid("35cb52d1-655d-4fb3-8a65-b5c98ca15326"), "Khotiv", new Guid("8271b2b5-cdc3-4ddb-82cb-479cec96a5fa") },
                    { new Guid("35cf8650-133b-40a2-8be1-5383433cbb72"), "Pervomaisk", new Guid("855ec202-37c6-4687-91f3-309533ba4f22") },
                    { new Guid("36716c9e-f965-48e3-bb44-08c91257dc9c"), "Borki", new Guid("fd38a444-2429-4d5f-921d-e5c69eaabade") },
                    { new Guid("37b21f91-d2c6-4987-aebb-79a7d29aadd0"), "Dubno", new Guid("618fde56-be7c-489a-a7ec-99a1991d2fa8") },
                    { new Guid("37fe8d0e-26f8-4d90-a79d-f5901805b3fe"), "Sniatyn", new Guid("580d250d-74e2-435d-b446-a9f961d0aa0b") },
                    { new Guid("3839cf40-c580-49bf-ad4d-df2af0919553"), "Lozova", new Guid("3866942e-5959-4f70-8858-224e3d24ac08") },
                    { new Guid("3a595290-4db1-4dc9-8459-6e04d3f20b0b"), "Chornomorsk", new Guid("4a62f755-ade2-4151-96bc-f9e705df4660") },
                    { new Guid("3b3d6bdd-c1be-4e1e-a633-3bb42405595b"), "Merefa", new Guid("3866942e-5959-4f70-8858-224e3d24ac08") },
                    { new Guid("3c5af788-76d0-47c4-8ac0-7a460038b7c6"), "Kamianets-Podilskyi", new Guid("1323431f-827f-4e00-9f50-227d743b1f92") },
                    { new Guid("3dba3008-dba3-4217-bfc3-1dd16a55638c"), "Pervomaiskyi", new Guid("843e9b23-ccaa-4574-890a-4a4584b0e627") },
                    { new Guid("3e4889a9-0fb2-4074-8d0e-50f0a83dedae"), "Boryslav", new Guid("fd38a444-2429-4d5f-921d-e5c69eaabade") },
                    { new Guid("4031b8e5-53f6-4eb6-8718-cff82848abcb"), "Odesa", new Guid("4a62f755-ade2-4151-96bc-f9e705df4660") },
                    { new Guid("40f51b10-2a5d-43d9-86ef-38cba564cd10"), "Korolevo", new Guid("60062e61-8215-4016-a6f5-d66241791949") },
                    { new Guid("4449494a-1598-4109-88d8-0de031f6724d"), "Toretsk", new Guid("843e9b23-ccaa-4574-890a-4a4584b0e627") },
                    { new Guid("454e1534-b967-47f0-bc46-8036e27013da"), "Dnipro", new Guid("6b389a1c-46be-4214-8976-e654c1e19b89") },
                    { new Guid("4783c80f-5877-498f-a47c-dda790f8335f"), "Shcherbani", new Guid("ea6feef8-8328-4f9e-bd88-e40ad74f3506") },
                    { new Guid("47a7f18c-a8a7-49f0-91fe-93d61906cf41"), "Perevalsk", new Guid("b047d78d-760f-4ecc-9ce7-4a956ede3ba6") },
                    { new Guid("47ba58e2-309b-4650-a53e-0d11f87563cc"), "Nasypne", new Guid("a1099927-b4f8-4154-ac4e-fc170784468a") },
                    { new Guid("486ba894-b02e-46d9-9967-219b8f7ddfa2"), "Kovel", new Guid("a317761b-0e25-4efb-9586-0f65c8d6afe4") },
                    { new Guid("490aedff-c16c-4298-a81b-0f0f7413659c"), "Kostiantynivka", new Guid("843e9b23-ccaa-4574-890a-4a4584b0e627") },
                    { new Guid("4a3ee649-f530-4791-9a5b-3d6129154899"), "Aviatorske", new Guid("6b389a1c-46be-4214-8976-e654c1e19b89") },
                    { new Guid("4b805e2d-0295-4fd4-bc33-3ad43aa79153"), "Obroshino", new Guid("fd38a444-2429-4d5f-921d-e5c69eaabade") },
                    { new Guid("4c920de1-511c-4a22-b6b8-43309d212b10"), "Halych", new Guid("580d250d-74e2-435d-b446-a9f961d0aa0b") },
                    { new Guid("4f65ec12-45b7-4e57-a4bc-b6d979703cd0"), "Boyarka", new Guid("8271b2b5-cdc3-4ddb-82cb-479cec96a5fa") },
                    { new Guid("4fab2616-e135-450e-82a2-2289333753d4"), "Krasnodon", new Guid("b047d78d-760f-4ecc-9ce7-4a956ede3ba6") },
                    { new Guid("4fcfc497-6243-489d-aa0c-a5fc0eb03dd6"), "Malokaterynivka", new Guid("e4c7e65f-59eb-4613-ad49-5520726399b9") },
                    { new Guid("50d219d9-60d7-4d21-adcc-03b38ee5bbc0"), "Pavlohrad", new Guid("6b389a1c-46be-4214-8976-e654c1e19b89") },
                    { new Guid("5229c2cb-e04f-4ba1-9bc3-25ec4f95fc16"), "Novooleksandrivka", new Guid("6b389a1c-46be-4214-8976-e654c1e19b89") },
                    { new Guid("52f5689a-ed8f-4f36-9f56-53c0e7756836"), "Berdiansk", new Guid("e4c7e65f-59eb-4613-ad49-5520726399b9") },
                    { new Guid("546b6772-9fd7-437c-bfd7-8331d50c0fd9"), "Stryi", new Guid("fd38a444-2429-4d5f-921d-e5c69eaabade") },
                    { new Guid("54d262a3-2953-427b-9927-48299a3b8086"), "Okhtyrka", new Guid("709eed3c-e5f4-47a6-9701-a758b770504f") },
                    { new Guid("555ec6de-3b09-433f-963a-8d6ce750a4e3"), "Vyshneve", new Guid("8271b2b5-cdc3-4ddb-82cb-479cec96a5fa") },
                    { new Guid("5567245e-d0e7-4577-b6e3-374960fe0e31"), "Petropavlivs’ka Borshchahivka", new Guid("8271b2b5-cdc3-4ddb-82cb-479cec96a5fa") },
                    { new Guid("55b81ab0-b6b0-44b0-9692-c48fb36f4410"), "Chervonopartyzansk", new Guid("b047d78d-760f-4ecc-9ce7-4a956ede3ba6") },
                    { new Guid("55d7a478-1b03-4646-90ca-aa57c9e47629"), "Zhdanivka", new Guid("843e9b23-ccaa-4574-890a-4a4584b0e627") },
                    { new Guid("56ded0b5-1a7d-41f6-9e57-81b755d552c9"), "Balabyne", new Guid("e4c7e65f-59eb-4613-ad49-5520726399b9") },
                    { new Guid("57ff5835-d9e1-40a5-8509-18789a961094"), "Dovzhansk", new Guid("b047d78d-760f-4ecc-9ce7-4a956ede3ba6") },
                    { new Guid("598e6218-ee78-4631-99e5-2dc00bc20468"), "Antonivka", new Guid("4b8c90e4-b235-4cda-87f1-a35e2c0d9ff9") },
                    { new Guid("5a49029d-9493-4af6-8de5-42b9dd3df2f2"), "Mykolaiv", new Guid("855ec202-37c6-4687-91f3-309533ba4f22") },
                    { new Guid("5a6e8434-9917-49a0-bbdd-59aa417e2a3c"), "Shevchenkivske", new Guid("6b389a1c-46be-4214-8976-e654c1e19b89") },
                    { new Guid("5ce7fcea-0728-4915-847a-b484c8888523"), "Irpin", new Guid("8271b2b5-cdc3-4ddb-82cb-479cec96a5fa") },
                    { new Guid("5d26036e-572c-495f-ba5f-c238916311ca"), "Kramatorsk", new Guid("843e9b23-ccaa-4574-890a-4a4584b0e627") },
                    { new Guid("5dddc60c-adca-455d-b3e6-aa5a9b87781f"), "Rozkishne", new Guid("b047d78d-760f-4ecc-9ce7-4a956ede3ba6") },
                    { new Guid("5eceb1ce-c8fd-44e3-9575-78bc8f4000ac"), "Rovenky", new Guid("b047d78d-760f-4ecc-9ce7-4a956ede3ba6") },
                    { new Guid("5f20da01-3665-40f6-944c-a55a684a0820"), "Almazna", new Guid("b047d78d-760f-4ecc-9ce7-4a956ede3ba6") },
                    { new Guid("607ea6d7-8c20-4ad0-ae6e-06250de002a0"), "Bucha", new Guid("8271b2b5-cdc3-4ddb-82cb-479cec96a5fa") },
                    { new Guid("61e9a571-f473-4a12-9707-753c60c9075e"), "Brovary", new Guid("8271b2b5-cdc3-4ddb-82cb-479cec96a5fa") },
                    { new Guid("6423cdda-9e85-4a8e-ab4d-ad6ad04beb73"), "Valianivske", new Guid("b047d78d-760f-4ecc-9ce7-4a956ede3ba6") },
                    { new Guid("64c15394-8cbd-4ecc-8df6-c9251d705e44"), "Selydove", new Guid("843e9b23-ccaa-4574-890a-4a4584b0e627") },
                    { new Guid("650264c5-2987-4e2f-91bb-ae63a4a27ae5"), "Zalizne", new Guid("843e9b23-ccaa-4574-890a-4a4584b0e627") },
                    { new Guid("661643dc-9a16-4f33-ae5f-5a9b0ffdc943"), "Poltava", new Guid("ea6feef8-8328-4f9e-bd88-e40ad74f3506") },
                    { new Guid("680005d7-05d3-49e5-9f24-3177400b7a3e"), "Shepetivka", new Guid("1323431f-827f-4e00-9f50-227d743b1f92") },
                    { new Guid("6879b8b6-f1d8-4ebc-9db4-c04bc91d0eb7"), "Horishni Plavni", new Guid("ea6feef8-8328-4f9e-bd88-e40ad74f3506") },
                    { new Guid("694d412a-9bca-490a-bb55-2c04c9c6cc17"), "Kharkiv", new Guid("3866942e-5959-4f70-8858-224e3d24ac08") },
                    { new Guid("6b28e88b-fa1d-4230-8c39-e4cdc02a3b66"), "Podilsk", new Guid("4a62f755-ade2-4151-96bc-f9e705df4660") },
                    { new Guid("6cbcd2c9-f735-41d1-9e03-6a08306dd34f"), "Duliby", new Guid("fd38a444-2429-4d5f-921d-e5c69eaabade") },
                    { new Guid("6e85c387-fb22-4493-96d3-19be0c9ebd1a"), "Brytivka", new Guid("4a62f755-ade2-4151-96bc-f9e705df4660") },
                    { new Guid("7132554e-523f-4a8f-b0d1-011ba4d059fd"), "Zhytomyr", new Guid("9d08ac6d-6cbe-43ec-b501-46ae19de0ddb") },
                    { new Guid("7210108c-7cbf-4483-a77d-94c0ebf4bce3"), "Slobozhanske", new Guid("3866942e-5959-4f70-8858-224e3d24ac08") },
                    { new Guid("723dea66-037a-43df-a0da-6641e61b90fc"), "Yablunytsia", new Guid("580d250d-74e2-435d-b446-a9f961d0aa0b") },
                    { new Guid("73d24bcc-a929-4a5e-b508-b4fbcac47b35"), "Vorzel", new Guid("8271b2b5-cdc3-4ddb-82cb-479cec96a5fa") },
                    { new Guid("7571b0d6-0933-4c28-9c40-ffc6c06ba2ec"), "Uman", new Guid("fb00c154-2eee-4190-bbad-36ce2abc77d0") },
                    { new Guid("77af525d-617c-4f4a-9886-a3b9364bad1a"), "Kherson", new Guid("4b8c90e4-b235-4cda-87f1-a35e2c0d9ff9") },
                    { new Guid("78949485-0ca0-4d33-8037-76664e4189b1"), "Krasnokamianka", new Guid("a1099927-b4f8-4154-ac4e-fc170784468a") },
                    { new Guid("789ffd88-a439-4e95-ab0c-eb1561c73055"), "Rohan", new Guid("3866942e-5959-4f70-8858-224e3d24ac08") },
                    { new Guid("7af9c48e-5f7a-4955-b585-3b64385e4a8f"), "Stakhanov", new Guid("b047d78d-760f-4ecc-9ce7-4a956ede3ba6") },
                    { new Guid("7deef8c0-b1a2-4b6a-824e-62c47fa08c8f"), "Bairachky", new Guid("b047d78d-760f-4ecc-9ce7-4a956ede3ba6") },
                    { new Guid("807502b5-c3f1-45c1-8919-9c3bd5cf79fe"), "Ternopil", new Guid("5fc1486d-c59c-4c09-8fef-3c1e99f083ae") },
                    { new Guid("814ee76c-5b7c-4078-9ee2-6aaef90cd5f7"), "Bryukhovychi", new Guid("fd38a444-2429-4d5f-921d-e5c69eaabade") },
                    { new Guid("83b2aaa3-2d97-4bb8-8780-c478ecb1f1a2"), "Kryvyi Rih", new Guid("6b389a1c-46be-4214-8976-e654c1e19b89") },
                    { new Guid("847c4271-5c03-4a22-9aa6-f5159aac00ad"), "Luhansk", new Guid("b047d78d-760f-4ecc-9ce7-4a956ede3ba6") },
                    { new Guid("84ac62b9-6875-4018-b760-2cab3850732b"), "Yalta", new Guid("a1099927-b4f8-4154-ac4e-fc170784468a") },
                    { new Guid("85efef91-5c09-402f-a0f5-68f370bdbe81"), "Lutsk", new Guid("a317761b-0e25-4efb-9586-0f65c8d6afe4") },
                    { new Guid("8640cd8c-31ec-4ec9-ab5a-6b44164f3fea"), "Lysychansk", new Guid("b047d78d-760f-4ecc-9ce7-4a956ede3ba6") },
                    { new Guid("866e929a-5c15-4836-a36c-fa8c2d96e2ca"), "Piilo", new Guid("580d250d-74e2-435d-b446-a9f961d0aa0b") },
                    { new Guid("871806ec-c358-4dd6-8bd1-5e1c7162f50b"), "Bilohorodka", new Guid("8271b2b5-cdc3-4ddb-82cb-479cec96a5fa") },
                    { new Guid("888d3885-14f3-42c9-ad44-dff6b7e5c5bc"), "Khmilnyk", new Guid("f9cae5cf-fcc2-4915-94c1-eba20d22dd6f") },
                    { new Guid("89ca6e2e-c791-42e7-b1c0-80114576dc72"), "Brianka", new Guid("b047d78d-760f-4ecc-9ce7-4a956ede3ba6") },
                    { new Guid("8a3089bc-3d5a-416d-a83e-b043e7335ce8"), "Lisnyky", new Guid("8271b2b5-cdc3-4ddb-82cb-479cec96a5fa") },
                    { new Guid("8af6f18b-8553-4775-be39-0cf57db2d5c6"), "Fastiv", new Guid("8271b2b5-cdc3-4ddb-82cb-479cec96a5fa") },
                    { new Guid("8b5e5350-359b-4b6c-bfa2-ae77493b7caf"), "Shakhtarsk", new Guid("843e9b23-ccaa-4574-890a-4a4584b0e627") },
                    { new Guid("8d432244-d870-40b4-9676-7bd38aa80e45"), "Nikita", new Guid("a1099927-b4f8-4154-ac4e-fc170784468a") },
                    { new Guid("8f8189d5-7aee-4c69-b2fc-380705c3eba6"), "Truskavets", new Guid("fd38a444-2429-4d5f-921d-e5c69eaabade") },
                    { new Guid("9133482b-a4b5-4c02-9504-1197d83c52c7"), "Berezivka", new Guid("3866942e-5959-4f70-8858-224e3d24ac08") },
                    { new Guid("9231d1a4-0d15-4f53-b1f6-fbddd81d2f3c"), "Pokrovske", new Guid("843e9b23-ccaa-4574-890a-4a4584b0e627") },
                    { new Guid("94bc440c-cadf-4f32-9fe3-7b0d1a29eca9"), "Kupiansk", new Guid("3866942e-5959-4f70-8858-224e3d24ac08") },
                    { new Guid("95febe50-0e15-4d09-85e6-a7063237ea77"), "Kolomyia", new Guid("580d250d-74e2-435d-b446-a9f961d0aa0b") },
                    { new Guid("97276346-8cc4-481c-8630-89ba3ac780b0"), "Zarichany", new Guid("9d08ac6d-6cbe-43ec-b501-46ae19de0ddb") },
                    { new Guid("972b1733-880e-405c-bbc9-ae61431ea56f"), "Mohyliv-Podilskyi", new Guid("f9cae5cf-fcc2-4915-94c1-eba20d22dd6f") },
                    { new Guid("97a46f32-9d09-44a5-9a99-a524556b4106"), "Sevastopol", new Guid("97c88dc3-1450-4a11-9ae5-e6daf828971e") },
                    { new Guid("9895c8f8-bd4d-4357-9db8-0c44366da742"), "Vuhlehirsk", new Guid("843e9b23-ccaa-4574-890a-4a4584b0e627") },
                    { new Guid("98a6e10f-e687-4242-81ea-89240ec352ae"), "Hurzuf", new Guid("a1099927-b4f8-4154-ac4e-fc170784468a") },
                    { new Guid("9bd9e68b-e9d0-4b3c-bb3b-c311c0a8b584"), "Koreiz", new Guid("a1099927-b4f8-4154-ac4e-fc170784468a") },
                    { new Guid("9e560d38-1963-4327-b64c-f16634d61bb8"), "Zaporizhzhia", new Guid("e4c7e65f-59eb-4613-ad49-5520726399b9") },
                    { new Guid("a3123276-c679-4ecf-9d69-e425b4a01c2c"), "Sadky", new Guid("ea6feef8-8328-4f9e-bd88-e40ad74f3506") },
                    { new Guid("a42bac28-8d66-43d6-9523-e7cce56c7277"), "Chuhuiv", new Guid("3866942e-5959-4f70-8858-224e3d24ac08") },
                    { new Guid("a4acd003-2770-40a9-8fca-392be9fa0e2d"), "Alchevsk", new Guid("b047d78d-760f-4ecc-9ce7-4a956ede3ba6") },
                    { new Guid("a517d1f2-6db2-448e-a6e9-44afaf13f903"), "Chernihiv", new Guid("43aeb7dd-426f-4b27-a2c4-06e0ff07d381") },
                    { new Guid("a703a839-7a9a-42c0-81ad-a2f0d40633be"), "Uzhhorod", new Guid("60062e61-8215-4016-a6f5-d66241791949") },
                    { new Guid("a79a2ee0-dc7c-4868-aac1-a7079ea3f0e8"), "Mukacheve", new Guid("60062e61-8215-4016-a6f5-d66241791949") },
                    { new Guid("a79b3c45-11fb-4be1-96db-214700fa7ff6"), "Saky", new Guid("a1099927-b4f8-4154-ac4e-fc170784468a") },
                    { new Guid("a8333219-fed5-4905-9f93-ccac3f95acf0"), "Shabelkivka", new Guid("843e9b23-ccaa-4574-890a-4a4584b0e627") },
                    { new Guid("a83d9c9c-4f99-4131-9674-fc4b0d4b21e7"), "Nizhyn", new Guid("43aeb7dd-426f-4b27-a2c4-06e0ff07d381") },
                    { new Guid("adb7b25a-c7ef-463e-bee7-7cfc6c36c197"), "Vylok", new Guid("60062e61-8215-4016-a6f5-d66241791949") },
                    { new Guid("ae14cef7-9fe4-4fed-9750-7eb68c495ecd"), "Snizhne", new Guid("843e9b23-ccaa-4574-890a-4a4584b0e627") },
                    { new Guid("aeb152de-6c2f-40bf-8525-aa3886526f6a"), "Horenka", new Guid("8271b2b5-cdc3-4ddb-82cb-479cec96a5fa") },
                    { new Guid("aed0d438-a11c-4956-8e21-6502f14ed18b"), "Novopillia", new Guid("6b389a1c-46be-4214-8976-e654c1e19b89") },
                    { new Guid("b0cdaae7-4873-445d-8929-c5111829b5a7"), "Yasnohirka", new Guid("843e9b23-ccaa-4574-890a-4a4584b0e627") },
                    { new Guid("b199b927-8761-484a-a9f8-c6b7c3afb87c"), "Verkhnosadove", new Guid("97c88dc3-1450-4a11-9ae5-e6daf828971e") },
                    { new Guid("b938337f-6fb5-4756-8612-4fea934eb02f"), "Lubny", new Guid("ea6feef8-8328-4f9e-bd88-e40ad74f3506") },
                    { new Guid("b9a03d95-5d91-4849-8960-9e70a8b62c0b"), "Komyshany", new Guid("4b8c90e4-b235-4cda-87f1-a35e2c0d9ff9") },
                    { new Guid("b9d6f87f-7956-4200-8a3a-e820f9a85f3d"), "Sumy", new Guid("709eed3c-e5f4-47a6-9701-a758b770504f") },
                    { new Guid("bc7308b5-f34c-43ff-a475-310e73bbf131"), "Nikopol", new Guid("6b389a1c-46be-4214-8976-e654c1e19b89") },
                    { new Guid("be546dec-e2dd-4522-a888-4aa702b46ed7"), "Hostomel", new Guid("8271b2b5-cdc3-4ddb-82cb-479cec96a5fa") },
                    { new Guid("bf40277d-3aa7-4a47-bd90-7d29ea7e89a3"), "Bilenke", new Guid("843e9b23-ccaa-4574-890a-4a4584b0e627") },
                    { new Guid("bf4a675e-67c4-4fe9-bffb-bf1b42b83aef"), "Sukhodilsk", new Guid("b047d78d-760f-4ecc-9ce7-4a956ede3ba6") },
                    { new Guid("c06796cc-1734-40e4-90f8-ddc91e8cfc7d"), "Lavky", new Guid("60062e61-8215-4016-a6f5-d66241791949") },
                    { new Guid("c100b133-1ca0-4a95-b4f3-f6906490121b"), "Melitopol", new Guid("e4c7e65f-59eb-4613-ad49-5520726399b9") },
                    { new Guid("c1af957e-9ed7-4667-b928-3dc1e0174971"), "Bakhmut", new Guid("843e9b23-ccaa-4574-890a-4a4584b0e627") },
                    { new Guid("c26e8a9d-70a0-444e-9f43-18c6eb35780f"), "Korosten", new Guid("9d08ac6d-6cbe-43ec-b501-46ae19de0ddb") },
                    { new Guid("c3c43825-607d-4ede-9285-cdc2aaf58319"), "Zorynsk", new Guid("b047d78d-760f-4ecc-9ce7-4a956ede3ba6") },
                    { new Guid("c6cca294-1048-4817-a225-b691bf71e079"), "Kremenchuk", new Guid("ea6feef8-8328-4f9e-bd88-e40ad74f3506") },
                    { new Guid("c78db828-5694-42d1-a302-5434ddf5cc14"), "Drohobych", new Guid("fd38a444-2429-4d5f-921d-e5c69eaabade") },
                    { new Guid("c7bb3292-da26-4f75-ad16-f9f64631179c"), "Zelenivka", new Guid("4b8c90e4-b235-4cda-87f1-a35e2c0d9ff9") },
                    { new Guid("c86b264c-8b7f-421f-bccd-39fac12b90e6"), "Yasynuvata", new Guid("843e9b23-ccaa-4574-890a-4a4584b0e627") },
                    { new Guid("c9f98454-2f0e-4e47-af5b-0a48e205ca1d"), "Myrhorod", new Guid("ea6feef8-8328-4f9e-bd88-e40ad74f3506") },
                    { new Guid("ca892bed-23b3-49a2-b145-2655f0865162"), "Sofiyivs’ka Borshchahivka", new Guid("8271b2b5-cdc3-4ddb-82cb-479cec96a5fa") },
                    { new Guid("ce36fd79-50e7-4841-839f-e24a0430dda3"), "Simeiz", new Guid("a1099927-b4f8-4154-ac4e-fc170784468a") },
                    { new Guid("cf43b197-aa12-434a-982d-8fe478209d0e"), "Konotop", new Guid("709eed3c-e5f4-47a6-9701-a758b770504f") },
                    { new Guid("cfa0f381-68e1-436d-ab49-31810b862867"), "Andriivka", new Guid("97c88dc3-1450-4a11-9ae5-e6daf828971e") },
                    { new Guid("d19c896e-44ce-4b7a-bac6-e4eb512d2b80"), "Bezliudivka", new Guid("3866942e-5959-4f70-8858-224e3d24ac08") },
                    { new Guid("d1ff69cb-4d14-4f16-b9ca-d1c33efcfc86"), "Volodymyr-Volynskyi", new Guid("a317761b-0e25-4efb-9586-0f65c8d6afe4") },
                    { new Guid("d239a67c-9f5b-4093-bced-73fcedddd48b"), "Hirnyk", new Guid("843e9b23-ccaa-4574-890a-4a4584b0e627") },
                    { new Guid("d61eb902-4bec-4357-b92c-b447f65d438f"), "Vinnytsia", new Guid("f9cae5cf-fcc2-4915-94c1-eba20d22dd6f") },
                    { new Guid("d7c66f57-bf73-4967-b229-0a045638a567"), "Kyiv", new Guid("e1340df7-76f5-46ab-a46a-db19eb78c67b") },
                    { new Guid("d9360224-7204-4395-a9d4-db2343dc38ab"), "Solomonovo", new Guid("60062e61-8215-4016-a6f5-d66241791949") },
                    { new Guid("d94d5701-3c10-466a-a241-452c35ced2eb"), "Mala Rohan", new Guid("3866942e-5959-4f70-8858-224e3d24ac08") },
                    { new Guid("da8ac10b-7ca5-416f-8ac6-a265b411819d"), "Vakhrusheve", new Guid("b047d78d-760f-4ecc-9ce7-4a956ede3ba6") },
                    { new Guid("db783569-a485-4595-8116-377c972c7dcc"), "Blyzhnie", new Guid("a1099927-b4f8-4154-ac4e-fc170784468a") },
                    { new Guid("db833041-2f85-41cb-9d75-019f03b85ee7"), "Smila", new Guid("fb00c154-2eee-4190-bbad-36ce2abc77d0") },
                    { new Guid("dc88f095-cb89-4c3d-b013-2676373b997d"), "Sofiivka", new Guid("843e9b23-ccaa-4574-890a-4a4584b0e627") },
                    { new Guid("deb99969-6fca-4844-b54d-76322c5a0a16"), "Chernivtsi", new Guid("93857ec5-5719-43cf-b892-c4315473ac24") },
                    { new Guid("e00778c9-5b69-49f3-8679-3870ceeb3d8d"), "Kropyvnytskyi", new Guid("8dd1a890-003b-4bc4-ab17-f7842f59a7e5") },
                    { new Guid("e0461a8b-51b9-4046-987f-7827eb1e4495"), "Kulynychi", new Guid("3866942e-5959-4f70-8858-224e3d24ac08") },
                    { new Guid("e1f61789-cc3f-4a1b-8f4f-1d752e06a04d"), "Karnaukhivka", new Guid("6b389a1c-46be-4214-8976-e654c1e19b89") },
                    { new Guid("e2177ecb-426d-47ba-9a1c-f7104a4860c2"), "Fedosiia", new Guid("a1099927-b4f8-4154-ac4e-fc170784468a") },
                    { new Guid("e2b8a26f-5fca-493c-8928-439a8295a12a"), "Lviv", new Guid("fd38a444-2429-4d5f-921d-e5c69eaabade") },
                    { new Guid("e6d42612-4c0b-46cc-9299-b968effbac9a"), "Novgorodskoye", new Guid("843e9b23-ccaa-4574-890a-4a4584b0e627") },
                    { new Guid("e6e0c1f2-3da8-4f69-a5fa-6350adeb82a3"), "Rubizhne", new Guid("b047d78d-760f-4ecc-9ce7-4a956ede3ba6") },
                    { new Guid("ea3d1358-0c00-40ec-848d-1cab0ce1cba5"), "Novosilky", new Guid("e1340df7-76f5-46ab-a46a-db19eb78c67b") },
                    { new Guid("ea56513d-6dbd-447a-bb97-c4ad5bb152d6"), "Mykhailivka", new Guid("b047d78d-760f-4ecc-9ce7-4a956ede3ba6") },
                    { new Guid("ec053db6-b3c3-4f50-bd23-2999de43ba71"), "Dobrovlyany", new Guid("5fc1486d-c59c-4c09-8fef-3c1e99f083ae") },
                    { new Guid("ed2184bf-4f6a-4127-b33b-9dd21eb302c0"), "Pochaiv", new Guid("5fc1486d-c59c-4c09-8fef-3c1e99f083ae") },
                    { new Guid("ed6c7e05-5a4b-437e-8b43-6285cb9dedd8"), "Cherkasy", new Guid("fb00c154-2eee-4190-bbad-36ce2abc77d0") },
                    { new Guid("ed6edc12-9a8b-4183-9f23-6a6d41a65730"), "Aeroflotskyi", new Guid("a1099927-b4f8-4154-ac4e-fc170784468a") },
                    { new Guid("edd71a45-09ea-4118-85e1-304cf5a39839"), "Petrovske", new Guid("b047d78d-760f-4ecc-9ce7-4a956ede3ba6") },
                    { new Guid("efe267e5-3efe-47c2-a298-8c330929e7f5"), "Makiivka", new Guid("843e9b23-ccaa-4574-890a-4a4584b0e627") },
                    { new Guid("efe5ae22-d255-4ae2-a759-54ab51f21478"), "Yenakiieve", new Guid("843e9b23-ccaa-4574-890a-4a4584b0e627") },
                    { new Guid("f093a55a-1510-4c7e-a4ee-588218fdf367"), "Tereshky", new Guid("ea6feef8-8328-4f9e-bd88-e40ad74f3506") },
                    { new Guid("f2115714-59df-4592-9c3e-a14a2443a4b1"), "Holubivske", new Guid("b047d78d-760f-4ecc-9ce7-4a956ede3ba6") },
                    { new Guid("f5167f0a-29cc-42a1-81dd-0b78b092d47a"), "Marianivka", new Guid("6b389a1c-46be-4214-8976-e654c1e19b89") },
                    { new Guid("f553b30c-54da-4c51-96d2-cdadcf97274c"), "Myrnohrad", new Guid("843e9b23-ccaa-4574-890a-4a4584b0e627") },
                    { new Guid("f56da975-24a0-4b5f-b68c-d14c38a1a8e9"), "Antratsyt", new Guid("b047d78d-760f-4ecc-9ce7-4a956ede3ba6") },
                    { new Guid("f635ec1c-3982-4b3c-ad3b-51293a2533c7"), "Chornotysiv", new Guid("60062e61-8215-4016-a6f5-d66241791949") },
                    { new Guid("f7521f6a-4bf8-4e76-829c-967bd808ce4e"), "Chabany", new Guid("8271b2b5-cdc3-4ddb-82cb-479cec96a5fa") },
                    { new Guid("f7c9fb71-d988-4747-ac58-0af0e9d1af40"), "Bilhorod-Dnistrovskyi", new Guid("4a62f755-ade2-4151-96bc-f9e705df4660") },
                    { new Guid("fe28fc6b-cce1-41ed-be42-5b37dcb080b3"), "Kerch", new Guid("a1099927-b4f8-4154-ac4e-fc170784468a") },
                    { new Guid("ffc4391b-2977-472f-ae9c-01b9e868da30"), "Chukaluvka", new Guid("580d250d-74e2-435d-b446-a9f961d0aa0b") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_RegionId",
                table: "Cities",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractorProfiles_ContactInfos_UserId",
                table: "ContractorProfiles_ContactInfos",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ServiceId",
                table: "Orders",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_CustomerId",
                table: "Requests",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_ServiceId",
                table: "Requests",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ServiceId",
                table: "Reviews",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_CityId",
                table: "Services",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_ContractorId",
                table: "Services",
                column: "ContractorId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ContractorProfileId",
                table: "Users",
                column: "ContractorProfileId",
                unique: true,
                filter: "[ContractorProfileId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContractorProfiles_ContactInfos");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "ContractorProfiles");

            migrationBuilder.DropTable(
                name: "Regions");
        }
    }
}
