using System.Text.Json;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EShopAPI.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "eshop");

            migrationBuilder.CreateTable(
                name: "composite_product_master",
                schema: "eshop",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, comment: "系統id")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    number = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false, comment: "組合產品代碼"),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, comment: "組合產品名稱"),
                    composite_product_type = table.Column<int>(type: "integer", nullable: false, comment: "組合產品類型"),
                    is_enable = table.Column<bool>(type: "boolean", nullable: false, comment: "是否啟用"),
                    variant_attribute = table.Column<JsonDocument>(type: "jsonb", nullable: true, comment: "變種屬性, 這些變種屬性有哪些值? ex: color:[red, blue], size[S,M]"),
                    create_user = table.Column<string>(type: "varchar(50)", nullable: false, comment: "建立者"),
                    create_date = table.Column<long>(type: "bigint", nullable: false, comment: "建立日期"),
                    update_user = table.Column<string>(type: "varchar(50)", nullable: true, comment: "更新者"),
                    update_date = table.Column<long>(type: "bigint", nullable: true, comment: "更新日期"),
                    remarks = table.Column<string>(type: "text", nullable: true, comment: "備註"),
                    language = table.Column<JsonDocument>(type: "jsonb", nullable: true, comment: "多國語系")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_composite_product_master", x => x.id);
                },
                comment: "組合產品主檔");

            migrationBuilder.CreateTable(
                name: "delivery_category",
                schema: "eshop",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, comment: "系統id")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    number = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, comment: "物流種類代碼"),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, comment: "物流種類名稱"),
                    create_user = table.Column<string>(type: "varchar(50)", nullable: false, comment: "建立者"),
                    create_date = table.Column<long>(type: "bigint", nullable: false, comment: "建立日期"),
                    update_user = table.Column<string>(type: "varchar(50)", nullable: true, comment: "更新者"),
                    update_date = table.Column<long>(type: "bigint", nullable: true, comment: "更新日期"),
                    remarks = table.Column<string>(type: "text", nullable: true, comment: "備註"),
                    language = table.Column<JsonDocument>(type: "jsonb", nullable: true, comment: "多國語系")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_delivery_category", x => x.id);
                },
                comment: "物流種類");

            migrationBuilder.CreateTable(
                name: "eshop_unit",
                schema: "eshop",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, comment: "系統id")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    number = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, comment: "單位代碼"),
                    name = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false, comment: "單位名稱"),
                    is_enable = table.Column<bool>(type: "boolean", nullable: false, comment: "是否啟用"),
                    is_system_default = table.Column<bool>(type: "boolean", nullable: false, comment: "是否為系統預設"),
                    create_user = table.Column<string>(type: "varchar(50)", nullable: false, comment: "建立者"),
                    create_date = table.Column<long>(type: "bigint", nullable: false, comment: "建立日期"),
                    update_user = table.Column<string>(type: "varchar(50)", nullable: true, comment: "更新者"),
                    update_date = table.Column<long>(type: "bigint", nullable: true, comment: "更新日期"),
                    remarks = table.Column<string>(type: "text", nullable: true, comment: "備註"),
                    language = table.Column<JsonDocument>(type: "jsonb", nullable: true, comment: "多國語系")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_eshop_unit", x => x.id);
                },
                comment: "eShop單位總表");

            migrationBuilder.CreateTable(
                name: "payment_category",
                schema: "eshop",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, comment: "系統id")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    number = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, comment: "支付類型代碼"),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, comment: "支付類型名稱"),
                    create_user = table.Column<string>(type: "varchar(50)", nullable: false, comment: "建立者"),
                    create_date = table.Column<long>(type: "bigint", nullable: false, comment: "建立日期"),
                    update_user = table.Column<string>(type: "varchar(50)", nullable: true, comment: "更新者"),
                    update_date = table.Column<long>(type: "bigint", nullable: true, comment: "更新日期"),
                    remarks = table.Column<string>(type: "text", nullable: true, comment: "備註"),
                    language = table.Column<JsonDocument>(type: "jsonb", nullable: true, comment: "多國語系")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payment_category", x => x.id);
                },
                comment: "支付類型實體");

            migrationBuilder.CreateTable(
                name: "product_category",
                schema: "eshop",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, comment: "系統id")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    number = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, comment: "產品類別代碼"),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, comment: "產品類別名稱"),
                    is_enable = table.Column<bool>(type: "boolean", nullable: false, comment: "是否啟用"),
                    create_user = table.Column<string>(type: "varchar(50)", nullable: false, comment: "建立者"),
                    create_date = table.Column<long>(type: "bigint", nullable: false, comment: "建立日期"),
                    update_user = table.Column<string>(type: "varchar(50)", nullable: true, comment: "更新者"),
                    update_date = table.Column<long>(type: "bigint", nullable: true, comment: "更新日期"),
                    remarks = table.Column<string>(type: "text", nullable: true, comment: "備註"),
                    language = table.Column<JsonDocument>(type: "jsonb", nullable: true, comment: "多國語系")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_category", x => x.id);
                },
                comment: "產品類別");

            migrationBuilder.CreateTable(
                name: "product_master",
                schema: "eshop",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, comment: "系統id")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    number = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false, comment: "產品主編號"),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, comment: "產品主名稱"),
                    product_type = table.Column<int>(type: "integer", nullable: false, comment: "產品類型"),
                    is_enable = table.Column<bool>(type: "boolean", nullable: false, comment: "是否啟用"),
                    variant_attribute = table.Column<JsonDocument>(type: "jsonb", nullable: true, comment: "變種屬性, 這些變種屬性有哪些值? ex: color:[red, blue], size[S,M]"),
                    create_user = table.Column<string>(type: "varchar(50)", nullable: false, comment: "建立者"),
                    create_date = table.Column<long>(type: "bigint", nullable: false, comment: "建立日期"),
                    update_user = table.Column<string>(type: "varchar(50)", nullable: true, comment: "更新者"),
                    update_date = table.Column<long>(type: "bigint", nullable: true, comment: "更新日期"),
                    remarks = table.Column<string>(type: "text", nullable: true, comment: "備註"),
                    language = table.Column<JsonDocument>(type: "jsonb", nullable: true, comment: "多國語系")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_master", x => x.id);
                },
                comment: "產品主檔");

            migrationBuilder.CreateTable(
                name: "shop_action",
                schema: "eshop",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, comment: "系統id")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    number = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, comment: "功能代碼"),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, comment: "功能名稱"),
                    is_enable = table.Column<bool>(type: "boolean", nullable: false, comment: "是否啟用"),
                    create_user = table.Column<string>(type: "varchar(50)", nullable: false, comment: "建立者"),
                    create_date = table.Column<long>(type: "bigint", nullable: false, comment: "建立日期"),
                    update_user = table.Column<string>(type: "varchar(50)", nullable: true, comment: "更新者"),
                    update_date = table.Column<long>(type: "bigint", nullable: true, comment: "更新日期"),
                    remarks = table.Column<string>(type: "text", nullable: true, comment: "備註"),
                    language = table.Column<JsonDocument>(type: "jsonb", nullable: true, comment: "多國語系")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shop_action", x => x.id);
                },
                comment: "商店Action(功能)實體, 存角色權限可以用哪些API (Controller Action)");

            migrationBuilder.CreateTable(
                name: "shop_coupon",
                schema: "eshop",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, comment: "系統id")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    number = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, comment: "角色代碼"),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, comment: "角色名稱"),
                    coupon_type = table.Column<int>(type: "integer", nullable: false, comment: "優惠券類型"),
                    use_start_date = table.Column<long>(type: "bigint", nullable: true, comment: "有效期限(起)"),
                    use_end_date = table.Column<long>(type: "bigint", nullable: true, comment: "有效期限(起)"),
                    is_enable = table.Column<bool>(type: "boolean", nullable: false, comment: "是否啟用"),
                    create_user = table.Column<string>(type: "varchar(50)", nullable: false, comment: "建立者"),
                    create_date = table.Column<long>(type: "bigint", nullable: false, comment: "建立日期"),
                    update_user = table.Column<string>(type: "varchar(50)", nullable: true, comment: "更新者"),
                    update_date = table.Column<long>(type: "bigint", nullable: true, comment: "更新日期"),
                    remarks = table.Column<string>(type: "text", nullable: true, comment: "備註"),
                    language = table.Column<JsonDocument>(type: "jsonb", nullable: true, comment: "多國語系")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shop_coupon", x => x.id);
                },
                comment: "商店優惠券");

            migrationBuilder.CreateTable(
                name: "shop_inventory",
                schema: "eshop",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, comment: "系統id")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    number = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, comment: "商品代碼"),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, comment: "商品名稱"),
                    inventory_quantity = table.Column<int>(type: "integer", nullable: false, comment: "商品庫存數量"),
                    inventory_alert = table.Column<int>(type: "integer", nullable: false, comment: "商品庫存警告數"),
                    supplier = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, comment: "供應商"),
                    brand = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, comment: "品牌"),
                    is_enable = table.Column<bool>(type: "boolean", nullable: false, comment: "是否啟用"),
                    create_user = table.Column<string>(type: "varchar(50)", nullable: false, comment: "建立者"),
                    create_date = table.Column<long>(type: "bigint", nullable: false, comment: "建立日期"),
                    update_user = table.Column<string>(type: "varchar(50)", nullable: true, comment: "更新者"),
                    update_date = table.Column<long>(type: "bigint", nullable: true, comment: "更新日期"),
                    remarks = table.Column<string>(type: "text", nullable: true, comment: "備註"),
                    language = table.Column<JsonDocument>(type: "jsonb", nullable: true, comment: "多國語系")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shop_inventory", x => x.id);
                },
                comment: "商店庫存");

            migrationBuilder.CreateTable(
                name: "shop_permission",
                schema: "eshop",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, comment: "系統id")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    number = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, comment: "權限代碼"),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, comment: "權限名稱"),
                    is_enable = table.Column<bool>(type: "boolean", nullable: false, comment: "是否啟用"),
                    create_user = table.Column<string>(type: "varchar(50)", nullable: false, comment: "建立者"),
                    create_date = table.Column<long>(type: "bigint", nullable: false, comment: "建立日期"),
                    update_user = table.Column<string>(type: "varchar(50)", nullable: true, comment: "更新者"),
                    update_date = table.Column<long>(type: "bigint", nullable: true, comment: "更新日期"),
                    remarks = table.Column<string>(type: "text", nullable: true, comment: "備註"),
                    language = table.Column<JsonDocument>(type: "jsonb", nullable: true, comment: "多國語系")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shop_permission", x => x.id);
                },
                comment: "商店權限實體");

            migrationBuilder.CreateTable(
                name: "shop_role",
                schema: "eshop",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, comment: "系統id")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    number = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, comment: "角色代碼"),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, comment: "角色名稱"),
                    is_enable = table.Column<bool>(type: "boolean", nullable: false, comment: "是否啟用"),
                    create_user = table.Column<string>(type: "varchar(50)", nullable: false, comment: "建立者"),
                    create_date = table.Column<long>(type: "bigint", nullable: false, comment: "建立日期"),
                    update_user = table.Column<string>(type: "varchar(50)", nullable: true, comment: "更新者"),
                    update_date = table.Column<long>(type: "bigint", nullable: true, comment: "更新日期"),
                    remarks = table.Column<string>(type: "text", nullable: true, comment: "備註"),
                    language = table.Column<JsonDocument>(type: "jsonb", nullable: true, comment: "多國語系")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shop_role", x => x.id);
                },
                comment: "商店角色實體");

            migrationBuilder.CreateTable(
                name: "shop_user",
                schema: "eshop",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, comment: "系統id")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    number = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, comment: "使用者代碼/帳號"),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, comment: "使用者名稱"),
                    pwd = table.Column<string>(type: "text", nullable: false, comment: "密碼"),
                    address = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, comment: "地址"),
                    email = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, comment: "Email"),
                    phone = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true, comment: "手機"),
                    is_enable = table.Column<bool>(type: "boolean", nullable: false, comment: "是否啟用"),
                    is_admin = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false, comment: "是否為管理員"),
                    create_user = table.Column<string>(type: "varchar(50)", nullable: false, comment: "建立者"),
                    create_date = table.Column<long>(type: "bigint", nullable: false, comment: "建立日期"),
                    update_user = table.Column<string>(type: "varchar(50)", nullable: true, comment: "更新者"),
                    update_date = table.Column<long>(type: "bigint", nullable: true, comment: "更新日期"),
                    remarks = table.Column<string>(type: "text", nullable: true, comment: "備註"),
                    language = table.Column<JsonDocument>(type: "jsonb", nullable: true, comment: "多國語系")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shop_user", x => x.id);
                },
                comment: "商店使用者實體");

            migrationBuilder.CreateTable(
                name: "map_composite_product_delivery",
                schema: "eshop",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, comment: "系統id")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    composite_product_master_id = table.Column<long>(type: "bigint", nullable: false, comment: "組合產品主表id"),
                    delivery_category_id = table.Column<long>(type: "bigint", nullable: false, comment: "物流種類id"),
                    create_user = table.Column<string>(type: "varchar(50)", nullable: false, comment: "建立者"),
                    create_date = table.Column<long>(type: "bigint", nullable: false, comment: "建立日期"),
                    update_user = table.Column<string>(type: "varchar(50)", nullable: true, comment: "更新者"),
                    update_date = table.Column<long>(type: "bigint", nullable: true, comment: "更新日期"),
                    remarks = table.Column<string>(type: "text", nullable: true, comment: "備註"),
                    language = table.Column<JsonDocument>(type: "jsonb", nullable: true, comment: "多國語系")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_map_composite_product_delivery", x => x.id);
                    table.ForeignKey(
                        name: "FK_map_composite_product_delivery_composite_product_master_com~",
                        column: x => x.composite_product_master_id,
                        principalSchema: "eshop",
                        principalTable: "composite_product_master",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_map_composite_product_delivery_delivery_category_delivery_c~",
                        column: x => x.delivery_category_id,
                        principalSchema: "eshop",
                        principalTable: "delivery_category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "組合產品主表與物流種類關聯的實體");

            migrationBuilder.CreateTable(
                name: "map_product_category",
                schema: "eshop",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, comment: "系統id")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    product_master_id = table.Column<long>(type: "bigint", nullable: false, comment: "組合產品主表id"),
                    product_category_id = table.Column<long>(type: "bigint", nullable: false, comment: "產品種類id"),
                    create_user = table.Column<string>(type: "varchar(50)", nullable: false, comment: "建立者"),
                    create_date = table.Column<long>(type: "bigint", nullable: false, comment: "建立日期"),
                    update_user = table.Column<string>(type: "varchar(50)", nullable: true, comment: "更新者"),
                    update_date = table.Column<long>(type: "bigint", nullable: true, comment: "更新日期"),
                    remarks = table.Column<string>(type: "text", nullable: true, comment: "備註"),
                    language = table.Column<JsonDocument>(type: "jsonb", nullable: true, comment: "多國語系")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_map_product_category", x => x.id);
                    table.ForeignKey(
                        name: "FK_map_product_category_product_category_product_category_id",
                        column: x => x.product_category_id,
                        principalSchema: "eshop",
                        principalTable: "product_category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_map_product_category_product_master_product_master_id",
                        column: x => x.product_master_id,
                        principalSchema: "eshop",
                        principalTable: "product_master",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "產品主表與產品類別關聯的實體");

            migrationBuilder.CreateTable(
                name: "map_product_delivery_category",
                schema: "eshop",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, comment: "系統id")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    product_master_id = table.Column<long>(type: "bigint", nullable: false, comment: "組合產品主表id"),
                    delivery_category_id = table.Column<long>(type: "bigint", nullable: false, comment: "物流種類id"),
                    create_user = table.Column<string>(type: "varchar(50)", nullable: false, comment: "建立者"),
                    create_date = table.Column<long>(type: "bigint", nullable: false, comment: "建立日期"),
                    update_user = table.Column<string>(type: "varchar(50)", nullable: true, comment: "更新者"),
                    update_date = table.Column<long>(type: "bigint", nullable: true, comment: "更新日期"),
                    remarks = table.Column<string>(type: "text", nullable: true, comment: "備註"),
                    language = table.Column<JsonDocument>(type: "jsonb", nullable: true, comment: "多國語系")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_map_product_delivery_category", x => x.id);
                    table.ForeignKey(
                        name: "FK_map_product_delivery_category_delivery_category_delivery_ca~",
                        column: x => x.delivery_category_id,
                        principalSchema: "eshop",
                        principalTable: "delivery_category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_map_product_delivery_category_product_master_product_master~",
                        column: x => x.product_master_id,
                        principalSchema: "eshop",
                        principalTable: "product_master",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "產品主表與物流種類關係的實體");

            migrationBuilder.CreateTable(
                name: "composite_product_detail",
                schema: "eshop",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, comment: "系統id")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    master_id = table.Column<long>(type: "bigint", nullable: false, comment: "組合產品主檔id"),
                    shop_inventory_id = table.Column<long>(type: "bigint", nullable: false, comment: "庫存id"),
                    eshop_unit_id = table.Column<long>(type: "bigint", nullable: false, comment: "商店單位id"),
                    price = table.Column<int>(type: "integer", nullable: false, comment: "單件價格(原價)"),
                    discount = table.Column<double>(type: "double precision", nullable: false, comment: "折扣數"),
                    sale_start_date = table.Column<long>(type: "bigint", nullable: true, comment: "特價起始日期"),
                    sale_end_date = table.Column<long>(type: "bigint", nullable: true, comment: "特價結束日期"),
                    is_use_coupon = table.Column<bool>(type: "boolean", nullable: false, comment: "是否可以使用優惠券"),
                    create_user = table.Column<string>(type: "varchar(50)", nullable: false, comment: "建立者"),
                    create_date = table.Column<long>(type: "bigint", nullable: false, comment: "建立日期"),
                    update_user = table.Column<string>(type: "varchar(50)", nullable: true, comment: "更新者"),
                    update_date = table.Column<long>(type: "bigint", nullable: true, comment: "更新日期"),
                    remarks = table.Column<string>(type: "text", nullable: true, comment: "備註"),
                    language = table.Column<JsonDocument>(type: "jsonb", nullable: true, comment: "多國語系")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_composite_product_detail", x => x.id);
                    table.ForeignKey(
                        name: "FK_composite_product_detail_composite_product_master_master_id",
                        column: x => x.master_id,
                        principalSchema: "eshop",
                        principalTable: "composite_product_master",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_composite_product_detail_eshop_unit_eshop_unit_id",
                        column: x => x.eshop_unit_id,
                        principalSchema: "eshop",
                        principalTable: "eshop_unit",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_composite_product_detail_shop_inventory_shop_inventory_id",
                        column: x => x.shop_inventory_id,
                        principalSchema: "eshop",
                        principalTable: "shop_inventory",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "組合產品子檔");

            migrationBuilder.CreateTable(
                name: "product_detail",
                schema: "eshop",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, comment: "系統id")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    master_id = table.Column<long>(type: "bigint", nullable: false, comment: "產品主檔id"),
                    shop_inventory_id = table.Column<long>(type: "bigint", nullable: false, comment: "庫存id"),
                    price = table.Column<int>(type: "integer", nullable: false, comment: "價格"),
                    eshop_unit_id = table.Column<long>(type: "bigint", nullable: false, comment: "商店單位id"),
                    status = table.Column<int>(type: "integer", nullable: true, comment: "產品狀態, 暫無想法，保留欄位"),
                    is_always_sale = table.Column<bool>(type: "boolean", nullable: false, comment: "是否總是特價"),
                    discount = table.Column<double>(type: "double precision", nullable: true, comment: "折扣數"),
                    sale_start_date = table.Column<long>(type: "bigint", nullable: true, comment: "特價起始日期"),
                    sale_end_date = table.Column<long>(type: "bigint", nullable: true, comment: "特價結束日期"),
                    is_enable = table.Column<bool>(type: "boolean", nullable: false, comment: "是否啟用"),
                    is_use_coupon = table.Column<bool>(type: "boolean", nullable: false, comment: "是否可以使用優惠券"),
                    variant_attribute = table.Column<JsonDocument>(type: "jsonb", nullable: true, comment: "變種屬性, 這個產品變種屬性有哪一些值? 包含產品(細項)自己本身的屬性值 ex: color:[red, blue], size[S,M]"),
                    create_user = table.Column<string>(type: "varchar(50)", nullable: false, comment: "建立者"),
                    create_date = table.Column<long>(type: "bigint", nullable: false, comment: "建立日期"),
                    update_user = table.Column<string>(type: "varchar(50)", nullable: true, comment: "更新者"),
                    update_date = table.Column<long>(type: "bigint", nullable: true, comment: "更新日期"),
                    remarks = table.Column<string>(type: "text", nullable: true, comment: "備註"),
                    language = table.Column<JsonDocument>(type: "jsonb", nullable: true, comment: "多國語系")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_detail", x => x.id);
                    table.ForeignKey(
                        name: "FK_product_detail_eshop_unit_eshop_unit_id",
                        column: x => x.eshop_unit_id,
                        principalSchema: "eshop",
                        principalTable: "eshop_unit",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_product_detail_product_master_master_id",
                        column: x => x.master_id,
                        principalSchema: "eshop",
                        principalTable: "product_master",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_product_detail_shop_inventory_shop_inventory_id",
                        column: x => x.shop_inventory_id,
                        principalSchema: "eshop",
                        principalTable: "shop_inventory",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "產品子檔, 產品的細節、變種");

            migrationBuilder.CreateTable(
                name: "map_permission_action",
                schema: "eshop",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, comment: "系統id")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    permisstion_id = table.Column<long>(type: "bigint", nullable: false, comment: "權限id"),
                    action_id = table.Column<long>(type: "bigint", nullable: false, comment: "功能id"),
                    create_user = table.Column<string>(type: "varchar(50)", nullable: false, comment: "建立者"),
                    create_date = table.Column<long>(type: "bigint", nullable: false, comment: "建立日期"),
                    update_user = table.Column<string>(type: "varchar(50)", nullable: true, comment: "更新者"),
                    update_date = table.Column<long>(type: "bigint", nullable: true, comment: "更新日期"),
                    remarks = table.Column<string>(type: "text", nullable: true, comment: "備註"),
                    language = table.Column<JsonDocument>(type: "jsonb", nullable: true, comment: "多國語系")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_map_permission_action", x => x.id);
                    table.ForeignKey(
                        name: "FK_map_permission_action_shop_action_action_id",
                        column: x => x.action_id,
                        principalSchema: "eshop",
                        principalTable: "shop_action",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_map_permission_action_shop_permission_permisstion_id",
                        column: x => x.permisstion_id,
                        principalSchema: "eshop",
                        principalTable: "shop_permission",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "權限與功能的實體");

            migrationBuilder.CreateTable(
                name: "map_role_permission",
                schema: "eshop",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, comment: "系統id")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    role_id = table.Column<long>(type: "bigint", nullable: false, comment: "角色id"),
                    permission_id = table.Column<long>(type: "bigint", nullable: false, comment: "權限id"),
                    create_user = table.Column<string>(type: "varchar(50)", nullable: false, comment: "建立者"),
                    create_date = table.Column<long>(type: "bigint", nullable: false, comment: "建立日期"),
                    update_user = table.Column<string>(type: "varchar(50)", nullable: true, comment: "更新者"),
                    update_date = table.Column<long>(type: "bigint", nullable: true, comment: "更新日期"),
                    remarks = table.Column<string>(type: "text", nullable: true, comment: "備註"),
                    language = table.Column<JsonDocument>(type: "jsonb", nullable: true, comment: "多國語系")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_map_role_permission", x => x.id);
                    table.ForeignKey(
                        name: "FK_map_role_permission_shop_permission_permission_id",
                        column: x => x.permission_id,
                        principalSchema: "eshop",
                        principalTable: "shop_permission",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_map_role_permission_shop_role_role_id",
                        column: x => x.role_id,
                        principalSchema: "eshop",
                        principalTable: "shop_role",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "角色與權限關聯的實體");

            migrationBuilder.CreateTable(
                name: "delivery_preference",
                schema: "eshop",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, comment: "系統id")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<long>(type: "bigint", nullable: false, comment: "使用者id"),
                    delivery_category_id = table.Column<long>(type: "bigint", nullable: false, comment: "物流類型id"),
                    is_primary = table.Column<bool>(type: "boolean", nullable: false, comment: "是否為主要的運送方式"),
                    address = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, comment: "地址"),
                    ShopUserId = table.Column<long>(type: "bigint", nullable: false),
                    create_user = table.Column<string>(type: "varchar(50)", nullable: false, comment: "建立者"),
                    create_date = table.Column<long>(type: "bigint", nullable: false, comment: "建立日期"),
                    update_user = table.Column<string>(type: "varchar(50)", nullable: true, comment: "更新者"),
                    update_date = table.Column<long>(type: "bigint", nullable: true, comment: "更新日期"),
                    remarks = table.Column<string>(type: "text", nullable: true, comment: "備註"),
                    language = table.Column<JsonDocument>(type: "jsonb", nullable: true, comment: "多國語系")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_delivery_preference", x => x.id);
                    table.ForeignKey(
                        name: "FK_delivery_preference_delivery_category_delivery_category_id",
                        column: x => x.delivery_category_id,
                        principalSchema: "eshop",
                        principalTable: "delivery_category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_delivery_preference_shop_user_ShopUserId",
                        column: x => x.ShopUserId,
                        principalSchema: "eshop",
                        principalTable: "shop_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "物流偏好實體");

            migrationBuilder.CreateTable(
                name: "map_user_role",
                schema: "eshop",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, comment: "系統id")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<long>(type: "bigint", nullable: false, comment: "使用者id"),
                    role_id = table.Column<long>(type: "bigint", nullable: false, comment: "角色id"),
                    create_user = table.Column<string>(type: "varchar(50)", nullable: false, comment: "建立者"),
                    create_date = table.Column<long>(type: "bigint", nullable: false, comment: "建立日期"),
                    update_user = table.Column<string>(type: "varchar(50)", nullable: true, comment: "更新者"),
                    update_date = table.Column<long>(type: "bigint", nullable: true, comment: "更新日期"),
                    remarks = table.Column<string>(type: "text", nullable: true, comment: "備註"),
                    language = table.Column<JsonDocument>(type: "jsonb", nullable: true, comment: "多國語系")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_map_user_role", x => x.id);
                    table.ForeignKey(
                        name: "FK_map_user_role_shop_role_role_id",
                        column: x => x.role_id,
                        principalSchema: "eshop",
                        principalTable: "shop_role",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_map_user_role_shop_user_user_id",
                        column: x => x.user_id,
                        principalSchema: "eshop",
                        principalTable: "shop_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "使用者與角色關聯的實體");

            migrationBuilder.CreateTable(
                name: "order_master",
                schema: "eshop",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, comment: "系統id")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    number = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, comment: "訂單編號"),
                    user_id = table.Column<long>(type: "bigint", nullable: false, comment: "使用者id"),
                    delivery_category_id = table.Column<long>(type: "bigint", nullable: false, comment: "物流類型id"),
                    payment_category_id = table.Column<long>(type: "bigint", nullable: false, comment: "支付類型id"),
                    is_composite_product = table.Column<int>(type: "integer", nullable: false, comment: "是否為組合產品, true = 是組合產品 , false = 不是組合產品"),
                    is_pay = table.Column<int>(type: "integer", nullable: false, comment: "是否已付款"),
                    status = table.Column<int>(type: "integer", nullable: false, comment: "訂單狀態"),
                    create_user = table.Column<string>(type: "varchar(50)", nullable: false, comment: "建立者"),
                    create_date = table.Column<long>(type: "bigint", nullable: false, comment: "建立日期"),
                    update_user = table.Column<string>(type: "varchar(50)", nullable: true, comment: "更新者"),
                    update_date = table.Column<long>(type: "bigint", nullable: true, comment: "更新日期"),
                    remarks = table.Column<string>(type: "text", nullable: true, comment: "備註"),
                    language = table.Column<JsonDocument>(type: "jsonb", nullable: true, comment: "多國語系")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order_master", x => x.id);
                    table.ForeignKey(
                        name: "FK_order_master_delivery_category_delivery_category_id",
                        column: x => x.delivery_category_id,
                        principalSchema: "eshop",
                        principalTable: "delivery_category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_order_master_payment_category_payment_category_id",
                        column: x => x.payment_category_id,
                        principalSchema: "eshop",
                        principalTable: "payment_category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_order_master_shop_user_user_id",
                        column: x => x.user_id,
                        principalSchema: "eshop",
                        principalTable: "shop_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "訂單主檔");

            migrationBuilder.CreateTable(
                name: "record_order_master",
                schema: "eshop",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, comment: "系統id")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    order_number = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, comment: "訂單編號"),
                    user_id = table.Column<long>(type: "bigint", nullable: false, comment: "使用者id"),
                    delivery_category_number = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, comment: "物流類型代碼"),
                    delivery_category_name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, comment: "物流類型名稱"),
                    payment_category_number = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, comment: "支付類型代碼"),
                    payment_category_name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, comment: "支付類型代碼"),
                    is_composite_product = table.Column<bool>(type: "boolean", nullable: false, comment: "是否為組合產品"),
                    status = table.Column<int>(type: "integer", nullable: false, comment: "訂單狀態"),
                    create_user = table.Column<string>(type: "varchar(50)", nullable: false, comment: "建立者"),
                    create_date = table.Column<long>(type: "bigint", nullable: false, comment: "建立日期"),
                    update_user = table.Column<string>(type: "varchar(50)", nullable: true, comment: "更新者"),
                    update_date = table.Column<long>(type: "bigint", nullable: true, comment: "更新日期"),
                    remarks = table.Column<string>(type: "text", nullable: true, comment: "備註"),
                    language = table.Column<JsonDocument>(type: "jsonb", nullable: true, comment: "多國語系")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_record_order_master", x => x.id);
                    table.ForeignKey(
                        name: "FK_record_order_master_shop_user_user_id",
                        column: x => x.user_id,
                        principalSchema: "eshop",
                        principalTable: "shop_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "訂單主檔紀錄");

            migrationBuilder.CreateTable(
                name: "shop_cart",
                schema: "eshop",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, comment: "系統id")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<long>(type: "bigint", nullable: false, comment: "使用者id"),
                    product_entity_type = table.Column<int>(type: "integer", nullable: false, comment: "產品實體類型"),
                    object_id = table.Column<long>(type: "bigint", nullable: false, comment: "物件id (根據ProductEntityType不同而對應的實體id)"),
                    count = table.Column<int>(type: "integer", nullable: false, comment: "數量"),
                    ShopUserId = table.Column<long>(type: "bigint", nullable: false),
                    create_user = table.Column<string>(type: "varchar(50)", nullable: false, comment: "建立者"),
                    create_date = table.Column<long>(type: "bigint", nullable: false, comment: "建立日期"),
                    update_user = table.Column<string>(type: "varchar(50)", nullable: true, comment: "更新者"),
                    update_date = table.Column<long>(type: "bigint", nullable: true, comment: "更新日期"),
                    remarks = table.Column<string>(type: "text", nullable: true, comment: "備註"),
                    language = table.Column<JsonDocument>(type: "jsonb", nullable: true, comment: "多國語系")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shop_cart", x => x.id);
                    table.ForeignKey(
                        name: "FK_shop_cart_shop_user_ShopUserId",
                        column: x => x.ShopUserId,
                        principalSchema: "eshop",
                        principalTable: "shop_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "購物車實體");

            migrationBuilder.CreateTable(
                name: "composite_product_item",
                schema: "eshop",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, comment: "系統id")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    detail_id = table.Column<long>(type: "bigint", nullable: false, comment: "組合產品detail的id"),
                    shop_inventory_id = table.Column<long>(type: "bigint", nullable: false, comment: "庫存id"),
                    price = table.Column<int>(type: "integer", nullable: false, comment: "單筆價格"),
                    count = table.Column<int>(type: "integer", nullable: false, comment: "數量"),
                    is_always_sale = table.Column<bool>(type: "boolean", nullable: false, comment: "是否總是特價"),
                    discount = table.Column<double>(type: "double precision", nullable: false, comment: "折扣數"),
                    sale_start_date = table.Column<long>(type: "bigint", nullable: true, comment: "特價起始日期"),
                    sale_end_date = table.Column<long>(type: "bigint", nullable: true, comment: "特價結束日期"),
                    eshop_unit_id = table.Column<long>(type: "bigint", nullable: false, comment: "單位"),
                    create_user = table.Column<string>(type: "varchar(50)", nullable: false, comment: "建立者"),
                    create_date = table.Column<long>(type: "bigint", nullable: false, comment: "建立日期"),
                    update_user = table.Column<string>(type: "varchar(50)", nullable: true, comment: "更新者"),
                    update_date = table.Column<long>(type: "bigint", nullable: true, comment: "更新日期"),
                    remarks = table.Column<string>(type: "text", nullable: true, comment: "備註"),
                    language = table.Column<JsonDocument>(type: "jsonb", nullable: true, comment: "多國語系")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_composite_product_item", x => x.id);
                    table.ForeignKey(
                        name: "FK_composite_product_item_composite_product_detail_detail_id",
                        column: x => x.detail_id,
                        principalSchema: "eshop",
                        principalTable: "composite_product_detail",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_composite_product_item_eshop_unit_eshop_unit_id",
                        column: x => x.eshop_unit_id,
                        principalSchema: "eshop",
                        principalTable: "eshop_unit",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_composite_product_item_shop_inventory_shop_inventory_id",
                        column: x => x.shop_inventory_id,
                        principalSchema: "eshop",
                        principalTable: "shop_inventory",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "組合產品實際的內容物");

            migrationBuilder.CreateTable(
                name: "order_for_composite_detail",
                schema: "eshop",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, comment: "系統id")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    master_id = table.Column<long>(type: "bigint", nullable: false, comment: "訂單主檔id"),
                    shop_inventory_id = table.Column<long>(type: "bigint", nullable: false, comment: "商店產品庫存id"),
                    count = table.Column<int>(type: "integer", nullable: false, comment: "數量"),
                    price = table.Column<int>(type: "integer", nullable: false, comment: "單筆價格(原價)"),
                    is_sale = table.Column<bool>(type: "boolean", nullable: false, comment: "是否特價"),
                    discount = table.Column<double>(type: "double precision", nullable: true, comment: "折扣數"),
                    create_user = table.Column<string>(type: "varchar(50)", nullable: false, comment: "建立者"),
                    create_date = table.Column<long>(type: "bigint", nullable: false, comment: "建立日期"),
                    update_user = table.Column<string>(type: "varchar(50)", nullable: true, comment: "更新者"),
                    update_date = table.Column<long>(type: "bigint", nullable: true, comment: "更新日期"),
                    remarks = table.Column<string>(type: "text", nullable: true, comment: "備註"),
                    language = table.Column<JsonDocument>(type: "jsonb", nullable: true, comment: "多國語系")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order_for_composite_detail", x => x.id);
                    table.ForeignKey(
                        name: "FK_order_for_composite_detail_order_master_master_id",
                        column: x => x.master_id,
                        principalSchema: "eshop",
                        principalTable: "order_master",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_order_for_composite_detail_shop_inventory_shop_inventory_id",
                        column: x => x.shop_inventory_id,
                        principalSchema: "eshop",
                        principalTable: "shop_inventory",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "訂單 (針對組合產品detail)");

            migrationBuilder.CreateTable(
                name: "order_for_product",
                schema: "eshop",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, comment: "系統id")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    master_id = table.Column<long>(type: "bigint", nullable: false, comment: "訂單主檔id"),
                    shop_inventory_id = table.Column<long>(type: "bigint", nullable: false, comment: "商店產品庫存id"),
                    count = table.Column<int>(type: "integer", nullable: false, comment: "數量"),
                    price = table.Column<int>(type: "integer", nullable: false, comment: "單筆價格(原價)"),
                    is_sale = table.Column<bool>(type: "boolean", nullable: false, comment: "是否特價"),
                    discount = table.Column<double>(type: "double precision", nullable: true, comment: "折扣數"),
                    create_user = table.Column<string>(type: "varchar(50)", nullable: false, comment: "建立者"),
                    create_date = table.Column<long>(type: "bigint", nullable: false, comment: "建立日期"),
                    update_user = table.Column<string>(type: "varchar(50)", nullable: true, comment: "更新者"),
                    update_date = table.Column<long>(type: "bigint", nullable: true, comment: "更新日期"),
                    remarks = table.Column<string>(type: "text", nullable: true, comment: "備註"),
                    language = table.Column<JsonDocument>(type: "jsonb", nullable: true, comment: "多國語系")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order_for_product", x => x.id);
                    table.ForeignKey(
                        name: "FK_order_for_product_order_master_master_id",
                        column: x => x.master_id,
                        principalSchema: "eshop",
                        principalTable: "order_master",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_order_for_product_shop_inventory_shop_inventory_id",
                        column: x => x.shop_inventory_id,
                        principalSchema: "eshop",
                        principalTable: "shop_inventory",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "訂單 (針對非組合產品)");

            migrationBuilder.CreateTable(
                name: "record_order_for_composite_detail",
                schema: "eshop",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, comment: "系統id")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    master_id = table.Column<long>(type: "bigint", nullable: false, comment: "訂單紀錄主檔id"),
                    product_number = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, comment: "產品代碼"),
                    product_name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, comment: "產品名稱"),
                    supplier = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, comment: "供應商"),
                    brand = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, comment: "品牌"),
                    count = table.Column<int>(type: "integer", nullable: false, comment: "數量"),
                    price = table.Column<int>(type: "integer", nullable: false, comment: "單筆價格(原價)"),
                    is_sale = table.Column<bool>(type: "boolean", nullable: false, comment: "是否特價"),
                    discount = table.Column<double>(type: "double precision", nullable: true, comment: "折扣數"),
                    create_user = table.Column<string>(type: "varchar(50)", nullable: false, comment: "建立者"),
                    create_date = table.Column<long>(type: "bigint", nullable: false, comment: "建立日期"),
                    update_user = table.Column<string>(type: "varchar(50)", nullable: true, comment: "更新者"),
                    update_date = table.Column<long>(type: "bigint", nullable: true, comment: "更新日期"),
                    remarks = table.Column<string>(type: "text", nullable: true, comment: "備註"),
                    language = table.Column<JsonDocument>(type: "jsonb", nullable: true, comment: "多國語系")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_record_order_for_composite_detail", x => x.id);
                    table.ForeignKey(
                        name: "FK_record_order_for_composite_detail_record_order_master_maste~",
                        column: x => x.master_id,
                        principalSchema: "eshop",
                        principalTable: "record_order_master",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "訂單紀錄(針對組合產品detail)");

            migrationBuilder.CreateTable(
                name: "record_order_for_product",
                schema: "eshop",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, comment: "系統id")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    master_id = table.Column<long>(type: "bigint", nullable: false, comment: "訂單紀錄主檔id"),
                    product_number = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, comment: "產品代碼"),
                    product_name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, comment: "產品名稱"),
                    supplier = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, comment: "供應商"),
                    brand = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, comment: "品牌"),
                    count = table.Column<int>(type: "integer", nullable: false, comment: "數量"),
                    price = table.Column<int>(type: "integer", nullable: false, comment: "單筆價格(原價)"),
                    is_sale = table.Column<bool>(type: "boolean", nullable: false, comment: "是否特價"),
                    discount = table.Column<double>(type: "double precision", nullable: true, comment: "折扣數"),
                    create_user = table.Column<string>(type: "varchar(50)", nullable: false, comment: "建立者"),
                    create_date = table.Column<long>(type: "bigint", nullable: false, comment: "建立日期"),
                    update_user = table.Column<string>(type: "varchar(50)", nullable: true, comment: "更新者"),
                    update_date = table.Column<long>(type: "bigint", nullable: true, comment: "更新日期"),
                    remarks = table.Column<string>(type: "text", nullable: true, comment: "備註"),
                    language = table.Column<JsonDocument>(type: "jsonb", nullable: true, comment: "多國語系")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_record_order_for_product", x => x.id);
                    table.ForeignKey(
                        name: "FK_record_order_for_product_record_order_master_master_id",
                        column: x => x.master_id,
                        principalSchema: "eshop",
                        principalTable: "record_order_master",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "訂單紀錄(針對非組合產品)");

            migrationBuilder.CreateTable(
                name: "order_for_composite_item",
                schema: "eshop",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, comment: "系統id")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    detail_id = table.Column<long>(type: "bigint", nullable: false, comment: "訂單(針對組合產品detail)的id"),
                    shop_inventory_id = table.Column<long>(type: "bigint", nullable: false, comment: "商店產品庫存id"),
                    count = table.Column<int>(type: "integer", nullable: false, comment: "數量"),
                    price = table.Column<int>(type: "integer", nullable: false, comment: "單筆價格(原價)"),
                    is_sale = table.Column<bool>(type: "boolean", nullable: false, comment: "是否特價"),
                    discount = table.Column<double>(type: "double precision", nullable: true, comment: "折扣數"),
                    create_user = table.Column<string>(type: "varchar(50)", nullable: false, comment: "建立者"),
                    create_date = table.Column<long>(type: "bigint", nullable: false, comment: "建立日期"),
                    update_user = table.Column<string>(type: "varchar(50)", nullable: true, comment: "更新者"),
                    update_date = table.Column<long>(type: "bigint", nullable: true, comment: "更新日期"),
                    remarks = table.Column<string>(type: "text", nullable: true, comment: "備註"),
                    language = table.Column<JsonDocument>(type: "jsonb", nullable: true, comment: "多國語系")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order_for_composite_item", x => x.id);
                    table.ForeignKey(
                        name: "FK_order_for_composite_item_order_for_composite_detail_detail_~",
                        column: x => x.detail_id,
                        principalSchema: "eshop",
                        principalTable: "order_for_composite_detail",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_order_for_composite_item_shop_inventory_shop_inventory_id",
                        column: x => x.shop_inventory_id,
                        principalSchema: "eshop",
                        principalTable: "shop_inventory",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "訂單 (針對組合產品item)");

            migrationBuilder.CreateTable(
                name: "record_order_for_composite_item",
                schema: "eshop",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, comment: "系統id")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    detail_id = table.Column<long>(type: "bigint", nullable: false, comment: "訂單紀錄(針對組合產品detail)的id"),
                    product_number = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, comment: "產品代碼"),
                    product_name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, comment: "產品名稱"),
                    supplier = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, comment: "供應商"),
                    brand = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, comment: "品牌"),
                    count = table.Column<int>(type: "integer", nullable: false, comment: "數量"),
                    price = table.Column<int>(type: "integer", nullable: false, comment: "單筆價格(原價)"),
                    is_sale = table.Column<bool>(type: "boolean", nullable: false, comment: "是否特價"),
                    discount = table.Column<double>(type: "double precision", nullable: true, comment: "折扣數"),
                    create_user = table.Column<string>(type: "varchar(50)", nullable: false, comment: "建立者"),
                    create_date = table.Column<long>(type: "bigint", nullable: false, comment: "建立日期"),
                    update_user = table.Column<string>(type: "varchar(50)", nullable: true, comment: "更新者"),
                    update_date = table.Column<long>(type: "bigint", nullable: true, comment: "更新日期"),
                    remarks = table.Column<string>(type: "text", nullable: true, comment: "備註"),
                    language = table.Column<JsonDocument>(type: "jsonb", nullable: true, comment: "多國語系")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_record_order_for_composite_item", x => x.id);
                    table.ForeignKey(
                        name: "FK_record_order_for_composite_item_record_order_for_composite_~",
                        column: x => x.detail_id,
                        principalSchema: "eshop",
                        principalTable: "record_order_for_composite_detail",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "訂單紀錄(針對組合產品item)");

            migrationBuilder.InsertData(
                schema: "eshop",
                table: "eshop_unit",
                columns: new[] { "id", "create_date", "create_user", "is_enable", "is_system_default", "language", "name", "number", "remarks", "update_date", "update_user" },
                values: new object[,]
                {
                    { 1L, 1695285957713L, "shopAdmin", true, true, null, "顆", "Piece", null, null, null },
                    { 2L, 1695285957713L, "shopAdmin", true, true, null, "件", "Unit", null, null, null },
                    { 3L, 1695285957713L, "shopAdmin", true, true, null, "雙/副", "Pair", null, null, null },
                    { 4L, 1695285957713L, "shopAdmin", true, true, null, "套/台/架", "Set", null, null, null },
                    { 5L, 1695285957713L, "shopAdmin", true, true, null, "打", "Dozen", null, null, null },
                    { 6L, 1695285957713L, "shopAdmin", true, true, null, "卷", "Roll", null, null, null },
                    { 7L, 1695285957713L, "shopAdmin", true, true, null, "袋", "Bag", null, null, null },
                    { 8L, 1695285957713L, "shopAdmin", true, true, null, "瓶", "Bottle", null, null, null }
                });

            migrationBuilder.InsertData(
                schema: "eshop",
                table: "shop_role",
                columns: new[] { "id", "create_date", "create_user", "is_enable", "language", "name", "number", "remarks", "update_date", "update_user" },
                values: new object[,]
                {
                    { 1L, 1695285957713L, "shopAdmin", true, null, "商店管理者權限", "shopAdminRole", "商店管理者權限", null, null },
                    { 2L, 1695285957713L, "shopUser", true, null, "商店使用者(測試用)", "shopUser", "預設的一般使用者(測試用)", null, null },
                    { 3L, 1695285957713L, "shopUser", true, null, "一般客戶", "custom", "一般客戶", null, null },
                    { 4L, 1695285957713L, "shopUser", true, null, "VIP客戶", "vip_custom", "VIP客戶", null, null }
                });

            migrationBuilder.InsertData(
                schema: "eshop",
                table: "shop_user",
                columns: new[] { "id", "address", "create_date", "create_user", "email", "is_admin", "is_enable", "language", "name", "number", "phone", "pwd", "remarks", "update_date", "update_user" },
                values: new object[] { 1L, null, 1695285957713L, "shopAdmin", null, true, true, null, "商店管理員", "shopAdmin", null, "shopAdmin", "預設的最高權限帳號", null, null });

            migrationBuilder.InsertData(
                schema: "eshop",
                table: "shop_user",
                columns: new[] { "id", "address", "create_date", "create_user", "email", "is_enable", "language", "name", "number", "phone", "pwd", "remarks", "update_date", "update_user" },
                values: new object[] { 2L, null, 1695285957713L, "shopUser", null, true, null, "商店使用者(測試用)", "shopUser", null, "shopUser", "預設的一般使用者(測試用)", null, null });

            migrationBuilder.CreateIndex(
                name: "IX_composite_product_detail_eshop_unit_id",
                schema: "eshop",
                table: "composite_product_detail",
                column: "eshop_unit_id");

            migrationBuilder.CreateIndex(
                name: "IX_composite_product_detail_master_id",
                schema: "eshop",
                table: "composite_product_detail",
                column: "master_id");

            migrationBuilder.CreateIndex(
                name: "IX_composite_product_detail_shop_inventory_id",
                schema: "eshop",
                table: "composite_product_detail",
                column: "shop_inventory_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_composite_product_item_detail_id_shop_inventory_id",
                schema: "eshop",
                table: "composite_product_item",
                columns: new[] { "detail_id", "shop_inventory_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_composite_product_item_eshop_unit_id",
                schema: "eshop",
                table: "composite_product_item",
                column: "eshop_unit_id");

            migrationBuilder.CreateIndex(
                name: "IX_composite_product_item_shop_inventory_id",
                schema: "eshop",
                table: "composite_product_item",
                column: "shop_inventory_id");

            migrationBuilder.CreateIndex(
                name: "IX_composite_product_master_number",
                schema: "eshop",
                table: "composite_product_master",
                column: "number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_delivery_category_number",
                schema: "eshop",
                table: "delivery_category",
                column: "number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_delivery_preference_delivery_category_id",
                schema: "eshop",
                table: "delivery_preference",
                column: "delivery_category_id");

            migrationBuilder.CreateIndex(
                name: "IX_delivery_preference_ShopUserId",
                schema: "eshop",
                table: "delivery_preference",
                column: "ShopUserId");

            migrationBuilder.CreateIndex(
                name: "IX_delivery_preference_user_id_delivery_category_id",
                schema: "eshop",
                table: "delivery_preference",
                columns: new[] { "user_id", "delivery_category_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_eshop_unit_number",
                schema: "eshop",
                table: "eshop_unit",
                column: "number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_map_composite_product_delivery_composite_product_master_id_~",
                schema: "eshop",
                table: "map_composite_product_delivery",
                columns: new[] { "composite_product_master_id", "delivery_category_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_map_composite_product_delivery_delivery_category_id",
                schema: "eshop",
                table: "map_composite_product_delivery",
                column: "delivery_category_id");

            migrationBuilder.CreateIndex(
                name: "IX_map_permission_action_action_id",
                schema: "eshop",
                table: "map_permission_action",
                column: "action_id");

            migrationBuilder.CreateIndex(
                name: "IX_map_permission_action_permisstion_id_action_id",
                schema: "eshop",
                table: "map_permission_action",
                columns: new[] { "permisstion_id", "action_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_map_product_category_product_category_id",
                schema: "eshop",
                table: "map_product_category",
                column: "product_category_id");

            migrationBuilder.CreateIndex(
                name: "IX_map_product_category_product_master_id_product_category_id",
                schema: "eshop",
                table: "map_product_category",
                columns: new[] { "product_master_id", "product_category_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_map_product_delivery_category_delivery_category_id",
                schema: "eshop",
                table: "map_product_delivery_category",
                column: "delivery_category_id");

            migrationBuilder.CreateIndex(
                name: "IX_map_product_delivery_category_product_master_id_delivery_ca~",
                schema: "eshop",
                table: "map_product_delivery_category",
                columns: new[] { "product_master_id", "delivery_category_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_map_role_permission_permission_id",
                schema: "eshop",
                table: "map_role_permission",
                column: "permission_id");

            migrationBuilder.CreateIndex(
                name: "IX_map_role_permission_role_id_permission_id",
                schema: "eshop",
                table: "map_role_permission",
                columns: new[] { "role_id", "permission_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_map_user_role_role_id",
                schema: "eshop",
                table: "map_user_role",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_map_user_role_user_id_role_id",
                schema: "eshop",
                table: "map_user_role",
                columns: new[] { "user_id", "role_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_order_for_composite_detail_master_id_shop_inventory_id",
                schema: "eshop",
                table: "order_for_composite_detail",
                columns: new[] { "master_id", "shop_inventory_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_order_for_composite_detail_shop_inventory_id",
                schema: "eshop",
                table: "order_for_composite_detail",
                column: "shop_inventory_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_for_composite_item_detail_id_shop_inventory_id",
                schema: "eshop",
                table: "order_for_composite_item",
                columns: new[] { "detail_id", "shop_inventory_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_order_for_composite_item_shop_inventory_id",
                schema: "eshop",
                table: "order_for_composite_item",
                column: "shop_inventory_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_for_product_master_id_shop_inventory_id",
                schema: "eshop",
                table: "order_for_product",
                columns: new[] { "master_id", "shop_inventory_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_order_for_product_shop_inventory_id",
                schema: "eshop",
                table: "order_for_product",
                column: "shop_inventory_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_master_delivery_category_id",
                schema: "eshop",
                table: "order_master",
                column: "delivery_category_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_master_number",
                schema: "eshop",
                table: "order_master",
                column: "number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_order_master_payment_category_id",
                schema: "eshop",
                table: "order_master",
                column: "payment_category_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_master_user_id",
                schema: "eshop",
                table: "order_master",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_payment_category_number",
                schema: "eshop",
                table: "payment_category",
                column: "number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_product_category_number",
                schema: "eshop",
                table: "product_category",
                column: "number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_product_detail_eshop_unit_id",
                schema: "eshop",
                table: "product_detail",
                column: "eshop_unit_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_detail_master_id",
                schema: "eshop",
                table: "product_detail",
                column: "master_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_detail_shop_inventory_id",
                schema: "eshop",
                table: "product_detail",
                column: "shop_inventory_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_product_master_number",
                schema: "eshop",
                table: "product_master",
                column: "number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_record_order_for_composite_detail_master_id",
                schema: "eshop",
                table: "record_order_for_composite_detail",
                column: "master_id");

            migrationBuilder.CreateIndex(
                name: "IX_record_order_for_composite_item_detail_id",
                schema: "eshop",
                table: "record_order_for_composite_item",
                column: "detail_id");

            migrationBuilder.CreateIndex(
                name: "IX_record_order_for_product_master_id",
                schema: "eshop",
                table: "record_order_for_product",
                column: "master_id");

            migrationBuilder.CreateIndex(
                name: "IX_record_order_master_user_id",
                schema: "eshop",
                table: "record_order_master",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_shop_action_number",
                schema: "eshop",
                table: "shop_action",
                column: "number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_shop_cart_ShopUserId",
                schema: "eshop",
                table: "shop_cart",
                column: "ShopUserId");

            migrationBuilder.CreateIndex(
                name: "IX_shop_cart_user_id_product_entity_type_object_id",
                schema: "eshop",
                table: "shop_cart",
                columns: new[] { "user_id", "product_entity_type", "object_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_shop_coupon_number",
                schema: "eshop",
                table: "shop_coupon",
                column: "number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_shop_inventory_number",
                schema: "eshop",
                table: "shop_inventory",
                column: "number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_shop_permission_number",
                schema: "eshop",
                table: "shop_permission",
                column: "number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_shop_role_number",
                schema: "eshop",
                table: "shop_role",
                column: "number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_shop_user_number",
                schema: "eshop",
                table: "shop_user",
                column: "number",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "composite_product_item",
                schema: "eshop");

            migrationBuilder.DropTable(
                name: "delivery_preference",
                schema: "eshop");

            migrationBuilder.DropTable(
                name: "map_composite_product_delivery",
                schema: "eshop");

            migrationBuilder.DropTable(
                name: "map_permission_action",
                schema: "eshop");

            migrationBuilder.DropTable(
                name: "map_product_category",
                schema: "eshop");

            migrationBuilder.DropTable(
                name: "map_product_delivery_category",
                schema: "eshop");

            migrationBuilder.DropTable(
                name: "map_role_permission",
                schema: "eshop");

            migrationBuilder.DropTable(
                name: "map_user_role",
                schema: "eshop");

            migrationBuilder.DropTable(
                name: "order_for_composite_item",
                schema: "eshop");

            migrationBuilder.DropTable(
                name: "order_for_product",
                schema: "eshop");

            migrationBuilder.DropTable(
                name: "product_detail",
                schema: "eshop");

            migrationBuilder.DropTable(
                name: "record_order_for_composite_item",
                schema: "eshop");

            migrationBuilder.DropTable(
                name: "record_order_for_product",
                schema: "eshop");

            migrationBuilder.DropTable(
                name: "shop_cart",
                schema: "eshop");

            migrationBuilder.DropTable(
                name: "shop_coupon",
                schema: "eshop");

            migrationBuilder.DropTable(
                name: "composite_product_detail",
                schema: "eshop");

            migrationBuilder.DropTable(
                name: "shop_action",
                schema: "eshop");

            migrationBuilder.DropTable(
                name: "product_category",
                schema: "eshop");

            migrationBuilder.DropTable(
                name: "shop_permission",
                schema: "eshop");

            migrationBuilder.DropTable(
                name: "shop_role",
                schema: "eshop");

            migrationBuilder.DropTable(
                name: "order_for_composite_detail",
                schema: "eshop");

            migrationBuilder.DropTable(
                name: "product_master",
                schema: "eshop");

            migrationBuilder.DropTable(
                name: "record_order_for_composite_detail",
                schema: "eshop");

            migrationBuilder.DropTable(
                name: "composite_product_master",
                schema: "eshop");

            migrationBuilder.DropTable(
                name: "eshop_unit",
                schema: "eshop");

            migrationBuilder.DropTable(
                name: "order_master",
                schema: "eshop");

            migrationBuilder.DropTable(
                name: "shop_inventory",
                schema: "eshop");

            migrationBuilder.DropTable(
                name: "record_order_master",
                schema: "eshop");

            migrationBuilder.DropTable(
                name: "delivery_category",
                schema: "eshop");

            migrationBuilder.DropTable(
                name: "payment_category",
                schema: "eshop");

            migrationBuilder.DropTable(
                name: "shop_user",
                schema: "eshop");
        }
    }
}
