using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace NurRealEstateWebApp.Migrations
{
    /// <inheritdoc />
    public partial class InititalMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

/*            migrationBuilder.CreateTable(
                name: "account",
                columns: table => new
                {
                    account_id = table.Column<Guid>(type: "char(36)", maxLength: 36, nullable: false),
                    first_name = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    last_name = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    password = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    role = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.account_id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "address",
                columns: table => new
                {
                    address_id = table.Column<Guid>(type: "char(36)", maxLength: 36, nullable: false),
                    house_no = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    city = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    sub_city = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.address_id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");*/

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    Name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    AccountId = table.Column<Guid>(type: "char(36)", nullable: false),
                    FirstName = table.Column<string>(type: "longtext", nullable: false),
                    LastName = table.Column<string>(type: "longtext", nullable: false),
                    Role = table.Column<string>(type: "longtext", nullable: false),
                    UserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: true),
                    SecurityStamp = table.Column<string>(type: "longtext", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

/*            migrationBuilder.CreateTable(
                name: "contact",
                columns: table => new
                {
                    contact_id = table.Column<Guid>(type: "char(36)", maxLength: 36, nullable: false),
                    phone_no = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    email = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    whatsapp_no = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.contact_id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");*/

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(type: "varchar(255)", nullable: false),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "varchar(255)", nullable: false),
                    ProviderKey = table.Column<string>(type: "varchar(255)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "longtext", nullable: true),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false),
                    RoleId = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false),
                    LoginProvider = table.Column<string>(type: "varchar(255)", nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false),
                    Value = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            /*            migrationBuilder.CreateTable(
                            name: "admin",
                            columns: table => new
                            {
                                admin_id = table.Column<Guid>(type: "char(36)", maxLength: 36, nullable: false),
                                account_id = table.Column<Guid>(type: "char(36)", nullable: false),
                                contact_id = table.Column<Guid>(type: "char(36)", nullable: false)
                            },
                            constraints: table =>
                            {
                                table.PrimaryKey("PRIMARY", x => x.admin_id);
                                table.ForeignKey(
                                    name: "admin_ibfk_1",
                                    column: x => x.contact_id,
                                    principalTable: "contact",
                                    principalColumn: "contact_id");
                                table.ForeignKey(
                                    name: "admin_ibfk_3",
                                    column: x => x.account_id,
                                    principalTable: "account",
                                    principalColumn: "account_id");
                            })
                            .Annotation("MySQL:Charset", "utf8mb4");*/

            /*            migrationBuilder.CreateTable(
                            name: "user",
                            columns: table => new
                            {
                                user_id = table.Column<Guid>(type: "char(36)", maxLength: 36, nullable: false),
                                account_id = table.Column<Guid>(type: "char(36)", nullable: false),
                                contact_id = table.Column<Guid>(type: "char(36)", nullable: false)
                            },
                            constraints: table =>
                            {
                                table.PrimaryKey("PRIMARY", x => x.user_id);
                                table.ForeignKey(
                                    name: "user_ibfk_2",
                                    column: x => x.account_id,
                                    principalTable: "account",
                                    principalColumn: "account_id");
                                table.ForeignKey(
                                    name: "user_ibfk_3",
                                    column: x => x.contact_id,
                                    principalTable: "contact",
                                    principalColumn: "contact_id");
                            })
                            .Annotation("MySQL:Charset", "utf8mb4");

                        migrationBuilder.CreateTable(
                            name: "agent",
                            columns: table => new
                            {
                                agent_id = table.Column<Guid>(type: "char(36)", maxLength: 36, nullable: false),
                                nationality = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                                languages = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                                experience_since = table.Column<DateTime>(type: "datetime", nullable: false),
                                account_id = table.Column<Guid>(type: "char(36)", nullable: false),
                                admin_id = table.Column<Guid>(type: "char(36)", nullable: false),
                                contact_id = table.Column<Guid>(type: "char(36)", nullable: false)
                            },
                            constraints: table =>
                            {
                                table.PrimaryKey("PRIMARY", x => x.agent_id);
                                table.ForeignKey(
                                    name: "agent_ibfk_1",
                                    column: x => x.contact_id,
                                    principalTable: "contact",
                                    principalColumn: "contact_id");
                                table.ForeignKey(
                                    name: "agent_ibfk_3",
                                    column: x => x.account_id,
                                    principalTable: "account",
                                    principalColumn: "account_id");
                                table.ForeignKey(
                                    name: "agent_ibfk_4",
                                    column: x => x.admin_id,
                                    principalTable: "admin",
                                    principalColumn: "admin_id");
                            })
                            .Annotation("MySQL:Charset", "utf8mb4");

                        migrationBuilder.CreateTable(
                            name: "property",
                            columns: table => new
                            {
                                property_id = table.Column<Guid>(type: "char(36)", maxLength: 36, nullable: false),
                                title = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                                description = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                                price = table.Column<float>(type: "float", nullable: false),
                                property_type = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                                property_size = table.Column<int>(type: "int(11)", nullable: false),
                                no_bedrooms = table.Column<int>(type: "int(11)", nullable: false),
                                no_bathrooms = table.Column<int>(type: "int(11)", nullable: false),
                                has_maidsRoom = table.Column<bool>(type: "tinyint(1)", nullable: false),
                                no_parking = table.Column<int>(type: "int(11)", nullable: false),
                                listed_date = table.Column<DateTime>(type: "datetime", nullable: false),
                                status = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                                address_id = table.Column<Guid>(type: "char(36)", nullable: false),
                                agent_id = table.Column<Guid>(type: "char(36)", nullable: false),
                                user_id = table.Column<Guid>(type: "char(36)", nullable: false)
                            },
                            constraints: table =>
                            {
                                table.PrimaryKey("PRIMARY", x => x.property_id);
                                table.ForeignKey(
                                    name: "property_ibfk_1",
                                    column: x => x.user_id,
                                    principalTable: "user",
                                    principalColumn: "user_id");
                                table.ForeignKey(
                                    name: "property_ibfk_2",
                                    column: x => x.agent_id,
                                    principalTable: "agent",
                                    principalColumn: "agent_id");
                                table.ForeignKey(
                                    name: "property_ibfk_3",
                                    column: x => x.address_id,
                                    principalTable: "address",
                                    principalColumn: "address_id");
                            })
                            .Annotation("MySQL:Charset", "utf8mb4"); */

/*            migrationBuilder.CreateIndex(
                name: "IX_admin_account_id",
                table: "admin",
                column: "account_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_admin_contact_id",
                table: "admin",
                column: "contact_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_agent_account_id",
                table: "agent",
                column: "account_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_agent_admin_id",
                table: "agent",
                column: "admin_id");

            migrationBuilder.CreateIndex(
                name: "IX_agent_contact_id",
                table: "agent",
                column: "contact_id",
                unique: true);*/

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

/*            migrationBuilder.CreateIndex(
                name: "IX_property_address_id",
                table: "property",
                column: "address_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_property_agent_id",
                table: "property",
                column: "agent_id");

            migrationBuilder.CreateIndex(
                name: "IX_property_user_id",
                table: "property",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_account_id",
                table: "user",
                column: "account_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_user_contact_id",
                table: "user",
                column: "contact_id",
                unique: true);*/
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

/*            migrationBuilder.DropTable(
                name: "property");*/

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

/*            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "agent");

            migrationBuilder.DropTable(
                name: "address");

            migrationBuilder.DropTable(
                name: "admin");

            migrationBuilder.DropTable(
                name: "contact");

            migrationBuilder.DropTable(
                name: "account");*/
        }
    }
}
