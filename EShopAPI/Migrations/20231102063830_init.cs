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
                name: "custom_variant_attribute",
                schema: "eshop",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, comment: "系統id")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    number = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, comment: "屬性代碼"),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, comment: "屬性名稱"),
                    attribute_type = table.Column<int>(type: "integer", nullable: false, comment: "屬性類型"),
                    is_system_default = table.Column<bool>(type: "boolean", nullable: false, comment: "是否為系統預設"),
                    is_enable = table.Column<bool>(type: "boolean", nullable: false, comment: "是否啟用"),
                    options = table.Column<JsonDocument>(type: "jsonb", nullable: false, comment: "屬性的選項清單"),
                    create_user = table.Column<string>(type: "varchar(50)", nullable: false, comment: "建立者"),
                    create_date = table.Column<long>(type: "bigint", nullable: false, comment: "建立日期"),
                    update_user = table.Column<string>(type: "varchar(50)", nullable: true, comment: "更新者"),
                    update_date = table.Column<long>(type: "bigint", nullable: true, comment: "更新日期"),
                    remarks = table.Column<string>(type: "text", nullable: true, comment: "備註"),
                    language = table.Column<JsonDocument>(type: "jsonb", nullable: true, comment: "多國語系")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_custom_variant_attribute", x => x.id);
                },
                comment: "自訂變種屬性");

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
                    product_type = table.Column<int>(type: "integer", nullable: false, comment: "產品類型"),
                    is_composite = table.Column<bool>(type: "boolean", nullable: false, comment: "是否為組合產品"),
                    is_composite_only = table.Column<bool>(type: "boolean", nullable: false, comment: "是否只能讓組合產品使用"),
                    is_enable = table.Column<bool>(type: "boolean", nullable: false, comment: "是否啟用"),
                    variant_attribute = table.Column<JsonDocument>(type: "jsonb", nullable: true, comment: "變種屬性, 這個產品有哪個變種屬性? 值是是什麼 ex: color: red, size: s"),
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
                name: "composite_product",
                schema: "eshop",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, comment: "系統id")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    shop_inventory_id = table.Column<long>(type: "bigint", nullable: false, comment: "庫存id"),
                    eshop_unit_id = table.Column<long>(type: "bigint", nullable: false, comment: "商店單位id"),
                    is_use_coupon = table.Column<bool>(type: "boolean", nullable: false, comment: "是否可以使用優惠券"),
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
                    table.PrimaryKey("PK_composite_product", x => x.id);
                    table.ForeignKey(
                        name: "FK_composite_product_eshop_unit_eshop_unit_id",
                        column: x => x.eshop_unit_id,
                        principalSchema: "eshop",
                        principalTable: "eshop_unit",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_composite_product_shop_inventory_shop_inventory_id",
                        column: x => x.shop_inventory_id,
                        principalSchema: "eshop",
                        principalTable: "shop_inventory",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "要販售的組合產品");

            migrationBuilder.CreateTable(
                name: "product",
                schema: "eshop",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, comment: "系統id")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    shop_inventory_id = table.Column<long>(type: "bigint", nullable: false, comment: "庫存id"),
                    price = table.Column<int>(type: "integer", nullable: false, comment: "價格"),
                    eshop_unit_id = table.Column<long>(type: "bigint", nullable: false, comment: "商店單位id"),
                    status = table.Column<int>(type: "integer", nullable: true, comment: "產品狀態, 暫無想法，保留欄位"),
                    is_always_sale = table.Column<bool>(type: "boolean", nullable: false, comment: "是否總是特價"),
                    is_enable = table.Column<bool>(type: "boolean", nullable: false, comment: "是否啟用"),
                    discount = table.Column<double>(type: "double precision", nullable: true, comment: "折扣數"),
                    sale_start_date = table.Column<long>(type: "bigint", nullable: true, comment: "特價起始日期"),
                    sale_end_date = table.Column<long>(type: "bigint", nullable: true, comment: "特價結束日期"),
                    is_use_coupon = table.Column<bool>(type: "boolean", nullable: false, comment: "是否可以使用優惠券"),
                    variant_attribute = table.Column<JsonDocument>(type: "jsonb", nullable: true, comment: "變種屬性, 這個產品的變種屬性分別對應的值?"),
                    create_user = table.Column<string>(type: "varchar(50)", nullable: false, comment: "建立者"),
                    create_date = table.Column<long>(type: "bigint", nullable: false, comment: "建立日期"),
                    update_user = table.Column<string>(type: "varchar(50)", nullable: true, comment: "更新者"),
                    update_date = table.Column<long>(type: "bigint", nullable: true, comment: "更新日期"),
                    remarks = table.Column<string>(type: "text", nullable: true, comment: "備註"),
                    language = table.Column<JsonDocument>(type: "jsonb", nullable: true, comment: "多國語系")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product", x => x.id);
                    table.ForeignKey(
                        name: "FK_product_eshop_unit_eshop_unit_id",
                        column: x => x.eshop_unit_id,
                        principalSchema: "eshop",
                        principalTable: "eshop_unit",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_product_shop_inventory_shop_inventory_id",
                        column: x => x.shop_inventory_id,
                        principalSchema: "eshop",
                        principalTable: "shop_inventory",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "要販售的產品");

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
                    is_create_permission = table.Column<bool>(type: "boolean", nullable: false, comment: "是否有新增的權限"),
                    is_read_permission = table.Column<bool>(type: "boolean", nullable: false, comment: "是否有讀取的權限"),
                    is_update_permission = table.Column<bool>(type: "boolean", nullable: false, comment: "是否有編輯的權限"),
                    is_delete_permission = table.Column<bool>(type: "boolean", nullable: false, comment: "是否有刪除的權限"),
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
                    composite_product_id = table.Column<long>(type: "bigint", nullable: false, comment: "組合產品detail的id"),
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
                        name: "FK_composite_product_item_composite_product_composite_product_~",
                        column: x => x.composite_product_id,
                        principalSchema: "eshop",
                        principalTable: "composite_product",
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
                name: "map_composite_product_delivery",
                schema: "eshop",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, comment: "系統id")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    composite_product_id = table.Column<long>(type: "bigint", nullable: false, comment: "組合產品id"),
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
                        name: "FK_map_composite_product_delivery_composite_product_composite_~",
                        column: x => x.composite_product_id,
                        principalSchema: "eshop",
                        principalTable: "composite_product",
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
                comment: "組合產品與物流種類關聯的實體");

            migrationBuilder.CreateTable(
                name: "map_product_category",
                schema: "eshop",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, comment: "系統id")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    product_id = table.Column<long>(type: "bigint", nullable: false, comment: "產品id"),
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
                        name: "FK_map_product_category_product_product_id",
                        column: x => x.product_id,
                        principalSchema: "eshop",
                        principalTable: "product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "產品與產品類別關聯的實體");

            migrationBuilder.CreateTable(
                name: "map_product_delivery_category",
                schema: "eshop",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, comment: "系統id")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    product_id = table.Column<long>(type: "bigint", nullable: false, comment: "產品id"),
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
                        name: "FK_map_product_delivery_category_product_product_id",
                        column: x => x.product_id,
                        principalSchema: "eshop",
                        principalTable: "product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "產品與物流種類關係的實體");

            migrationBuilder.CreateTable(
                name: "order_composite_product",
                schema: "eshop",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, comment: "系統id")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    master_id = table.Column<long>(type: "bigint", nullable: false, comment: "訂單主檔id"),
                    shop_inventory_id = table.Column<long>(type: "bigint", nullable: false, comment: "商店產品庫存id"),
                    count = table.Column<int>(type: "integer", nullable: false, comment: "數量"),
                    create_user = table.Column<string>(type: "varchar(50)", nullable: false, comment: "建立者"),
                    create_date = table.Column<long>(type: "bigint", nullable: false, comment: "建立日期"),
                    update_user = table.Column<string>(type: "varchar(50)", nullable: true, comment: "更新者"),
                    update_date = table.Column<long>(type: "bigint", nullable: true, comment: "更新日期"),
                    remarks = table.Column<string>(type: "text", nullable: true, comment: "備註"),
                    language = table.Column<JsonDocument>(type: "jsonb", nullable: true, comment: "多國語系")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order_composite_product", x => x.id);
                    table.ForeignKey(
                        name: "FK_order_composite_product_order_master_master_id",
                        column: x => x.master_id,
                        principalSchema: "eshop",
                        principalTable: "order_master",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_order_composite_product_shop_inventory_shop_inventory_id",
                        column: x => x.shop_inventory_id,
                        principalSchema: "eshop",
                        principalTable: "shop_inventory",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "訂單 (針對組合產品)");

            migrationBuilder.CreateTable(
                name: "order_product",
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
                    table.PrimaryKey("PK_order_product", x => x.id);
                    table.ForeignKey(
                        name: "FK_order_product_order_master_master_id",
                        column: x => x.master_id,
                        principalSchema: "eshop",
                        principalTable: "order_master",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_order_product_shop_inventory_shop_inventory_id",
                        column: x => x.shop_inventory_id,
                        principalSchema: "eshop",
                        principalTable: "shop_inventory",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "訂單 (針對非組合產品)");

            migrationBuilder.CreateTable(
                name: "record_order_composite_product",
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
                    table.PrimaryKey("PK_record_order_composite_product", x => x.id);
                    table.ForeignKey(
                        name: "FK_record_order_composite_product_record_order_master_master_id",
                        column: x => x.master_id,
                        principalSchema: "eshop",
                        principalTable: "record_order_master",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "訂單紀錄(針對組合產品)");

            migrationBuilder.CreateTable(
                name: "record_order_product",
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
                    table.PrimaryKey("PK_record_order_product", x => x.id);
                    table.ForeignKey(
                        name: "FK_record_order_product_record_order_master_master_id",
                        column: x => x.master_id,
                        principalSchema: "eshop",
                        principalTable: "record_order_master",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "訂單紀錄(針對非組合產品)");

            migrationBuilder.CreateTable(
                name: "order_composite_product_item",
                schema: "eshop",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, comment: "系統id")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    order_composite_product_id = table.Column<long>(type: "bigint", nullable: false, comment: "訂單(針對組合產品)的id"),
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
                    table.PrimaryKey("PK_order_composite_product_item", x => x.id);
                    table.ForeignKey(
                        name: "FK_order_composite_product_item_order_composite_product_order_~",
                        column: x => x.order_composite_product_id,
                        principalSchema: "eshop",
                        principalTable: "order_composite_product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_order_composite_product_item_shop_inventory_shop_inventory_~",
                        column: x => x.shop_inventory_id,
                        principalSchema: "eshop",
                        principalTable: "shop_inventory",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "訂單 (針對組合產品項目)");

            migrationBuilder.CreateTable(
                name: "record_order_composite_product_item",
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
                    table.PrimaryKey("PK_record_order_composite_product_item", x => x.id);
                    table.ForeignKey(
                        name: "FK_record_order_composite_product_item_record_order_composite_~",
                        column: x => x.detail_id,
                        principalSchema: "eshop",
                        principalTable: "record_order_composite_product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "訂單紀錄(針對組合產品item)");

            migrationBuilder.InsertData(
                schema: "eshop",
                table: "custom_variant_attribute",
                columns: new[] { "id", "attribute_type", "create_date", "create_user", "is_enable", "is_system_default", "language", "name", "number", "options", "remarks", "update_date", "update_user" },
                values: new object[,]
                {
                    { 1L, 3, 1695285957713L, "shopAdmin", true, true, null, "顏色", "color", System.Text.Json.JsonDocument.Parse("[{\"id\":\"3a6d7129-b3a3-450c-80cf-e3bf51ab1851\",\"name\":\"\\u9ED1\\u8272\",\"value\":\"#000000\"},{\"id\":\"0b2afd62-c05b-4d64-8bed-99cbd232c8ad\",\"name\":\"\\u767D\\u8272\",\"value\":\"#FFFFFF\"},{\"id\":\"146d0dcf-048c-4ca1-bcb0-2c66a84fc6b8\",\"name\":\"\\u7D05\\u8272\",\"value\":\"#FF0000\"},{\"id\":\"cc2c6e43-5c11-4ed9-97dc-0379f934370f\",\"name\":\"\\u7DA0\\u8272\",\"value\":\"#00FF00\"},{\"id\":\"6e717c63-3722-4c5e-b0ea-a444b14e663b\",\"name\":\"\\u85CD\\u8272\",\"value\":\"#0000FF\"}]", new System.Text.Json.JsonDocumentOptions()), null, null, null },
                    { 2L, 1, 1695285957713L, "shopAdmin", true, true, null, "尺寸", "size", System.Text.Json.JsonDocument.Parse("[{\"id\":\"0b6ab0eb-b2e7-4679-80fc-b63b31725b65\",\"name\":\"XS\",\"value\":\"XS\"},{\"id\":\"a7ac7a9d-7da8-4bbb-8731-6f51be57b7b6\",\"name\":\"S\",\"value\":\"S\"},{\"id\":\"f3c17846-c299-4dce-b029-d79d02279c0e\",\"name\":\"M\",\"value\":\"M\"},{\"id\":\"cc0a7bc4-61be-41b4-abb0-7bcbbc78ed87\",\"name\":\"L\",\"value\":\"L\"},{\"id\":\"4444a8b0-1189-42cd-b653-b6cbb576f7e8\",\"name\":\"XL\",\"value\":\"XL\"},{\"id\":\"ce754faf-a16a-491b-ba1b-2ef73a62d747\",\"name\":\"XXL\",\"value\":\"XXL\"}]", new System.Text.Json.JsonDocumentOptions()), null, null, null }
                });

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
                table: "shop_permission",
                columns: new[] { "id", "create_date", "create_user", "is_enable", "language", "name", "number", "remarks", "update_date", "update_user" },
                values: new object[,]
                {
                    { 1L, 1695285957713L, "shopAdmin", true, null, "商店使用者", "ShopUser", null, null, null },
                    { 2L, 1695285957713L, "shopAdmin", true, null, "商店角色", "ShopRole", null, null, null },
                    { 3L, 1695285957713L, "shopAdmin", true, null, "商店使用者與角色關係", "MapUserRole", null, null, null },
                    { 4L, 1695285957713L, "shopAdmin", true, null, "商店權限", "ShopPermission", null, null, null },
                    { 5L, 1695285957713L, "shopAdmin", true, null, "商店角色與權限關係", "MapRolePermission", null, null, null },
                    { 6L, 1695285957713L, "shopAdmin", true, null, "產品主檔", "ProductMaster", null, null, null },
                    { 7L, 1695285957713L, "shopAdmin", true, null, "產品細項", "ProductDetail", null, null, null },
                    { 8L, 1695285957713L, "shopAdmin", true, null, "組合產品主檔", "CompositeProductMaster", null, null, null },
                    { 9L, 1695285957713L, "shopAdmin", true, null, "組合產品細項", "CompositeProductDetail", null, null, null },
                    { 10L, 1695285957713L, "shopAdmin", true, null, "組合產品細項的項目", "CompositeProductItem", null, null, null },
                    { 11L, 1695285957713L, "shopAdmin", true, null, "商店庫存", "ShopInventory", null, null, null },
                    { 12L, 1695285957713L, "shopAdmin", true, null, "商店單位", "EshopUnit", null, null, null },
                    { 13L, 1695285957713L, "shopAdmin", true, null, "產品類型", "ProductCategory", null, null, null },
                    { 14L, 1695285957713L, "shopAdmin", true, null, "產品與產品類型的關係", "MapProductCategory", null, null, null },
                    { 15L, 1695285957713L, "shopAdmin", true, null, "物流類型", "DeliveryCategory", null, null, null },
                    { 16L, 1695285957713L, "shopAdmin", true, null, "組合產品與物流的關係", "MapCompositeProductDelivery", null, null, null },
                    { 17L, 1695285957713L, "shopAdmin", true, null, "產品與物流的關係", "MapProductDeliveryCategory", null, null, null },
                    { 18L, 1695285957713L, "shopAdmin", true, null, "物流偏好", "DeliveryPreference", null, null, null },
                    { 19L, 1695285957713L, "shopAdmin", true, null, "訂單主檔", "OrderMaster", null, null, null },
                    { 20L, 1695285957713L, "shopAdmin", true, null, "產品訂單", "OrderForProduct", null, null, null },
                    { 21L, 1695285957713L, "shopAdmin", true, null, "組合產品訂單細項", "OrderForCompositeDetail", null, null, null },
                    { 22L, 1695285957713L, "shopAdmin", true, null, "組合產品訂單細項的項目", "OrderForCompositeItem", null, null, null },
                    { 23L, 1695285957713L, "shopAdmin", true, null, "購物車", "ShopCart", null, null, null },
                    { 24L, 1695285957713L, "shopAdmin", true, null, "訂單主檔紀錄", "RecordOrderMaster", null, null, null },
                    { 25L, 1695285957713L, "shopAdmin", true, null, "產品訂單紀錄", "RecordOrderForProduct", null, null, null },
                    { 26L, 1695285957713L, "shopAdmin", true, null, "組合產品訂單細項紀錄", "RecordOrderForCompositeDetail", null, null, null },
                    { 27L, 1695285957713L, "shopAdmin", true, null, "組合產品訂單細項的項目紀錄", "RecordOrderForCompositeItem", null, null, null },
                    { 28L, 1695285957713L, "shopAdmin", true, null, "商店優惠券", "ShopCoupon", null, null, null },
                    { 29L, 1695285957713L, "shopAdmin", true, null, "付款類型", "PaymentCategory", null, null, null }
                });

            migrationBuilder.InsertData(
                schema: "eshop",
                table: "shop_role",
                columns: new[] { "id", "create_date", "create_user", "is_enable", "language", "name", "number", "remarks", "update_date", "update_user" },
                values: new object[,]
                {
                    { 1L, 1695285957713L, "shopAdmin", true, null, "商店員工角色", "shop_employee", "員工角色", null, null },
                    { 2L, 1695285957713L, "shopAdmin", true, null, "一般客戶角色", "custom", "一般客戶角色", null, null },
                    { 3L, 1695285957713L, "shopAdmin", true, null, "VIP客戶角色", "vip_custom", "VIP客戶角色", null, null }
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
                values: new object[,]
                {
                    { 2L, null, 1695285957713L, "shopAdmin", null, true, null, "員工1(測試用)", "shopEmployee1", null, "shopEmployee1", "預設的員工(測試用)", null, null },
                    { 3L, null, 1695285957713L, "shopAdmin", null, true, null, "一般客戶1(測試用)", "shopUser", null, "shopUser", "預設的一般使用者(測試用)", null, null },
                    { 4L, null, 1695285957713L, "shopAdmin", null, true, null, "VIP客戶1(測試用)", "shopVipUser", null, "shopVipUser", "預設的VIP使用者(測試用)", null, null }
                });

            migrationBuilder.InsertData(
                schema: "eshop",
                table: "map_role_permission",
                columns: new[] { "id", "create_date", "create_user", "is_create_permission", "is_delete_permission", "is_read_permission", "is_update_permission", "language", "permission_id", "remarks", "role_id", "update_date", "update_user" },
                values: new object[,]
                {
                    { 1L, 1695285957713L, "shopAdmin", true, false, true, true, null, 6L, null, 1L, null, null },
                    { 2L, 1695285957713L, "shopAdmin", true, false, true, true, null, 7L, null, 1L, null, null },
                    { 3L, 1695285957713L, "shopAdmin", true, false, true, true, null, 8L, null, 1L, null, null },
                    { 4L, 1695285957713L, "shopAdmin", true, false, true, true, null, 9L, null, 1L, null, null },
                    { 5L, 1695285957713L, "shopAdmin", true, false, true, true, null, 10L, null, 1L, null, null },
                    { 6L, 1695285957713L, "shopAdmin", false, false, true, false, null, 6L, null, 2L, null, null },
                    { 7L, 1695285957713L, "shopAdmin", false, false, true, false, null, 7L, null, 2L, null, null },
                    { 8L, 1695285957713L, "shopAdmin", false, false, true, false, null, 8L, null, 2L, null, null },
                    { 9L, 1695285957713L, "shopAdmin", false, false, true, false, null, 9L, null, 2L, null, null },
                    { 10L, 1695285957713L, "shopAdmin", false, false, true, false, null, 10L, null, 2L, null, null }
                });

            migrationBuilder.InsertData(
                schema: "eshop",
                table: "map_user_role",
                columns: new[] { "id", "create_date", "create_user", "language", "remarks", "role_id", "update_date", "update_user", "user_id" },
                values: new object[,]
                {
                    { 1L, 1695285957713L, "shopAdmin", null, "員工測試帳號對應的員工角色", 1L, null, null, 2L },
                    { 2L, 1695285957713L, "shopUser", null, "一般使用者帳號對應的基礎使用者角色", 2L, null, null, 3L },
                    { 3L, 1695285957713L, "shopUser", null, "VIP帳號對應的VIP使用者角色", 3L, null, null, 4L }
                });

            migrationBuilder.CreateIndex(
                name: "IX_composite_product_eshop_unit_id",
                schema: "eshop",
                table: "composite_product",
                column: "eshop_unit_id");

            migrationBuilder.CreateIndex(
                name: "IX_composite_product_shop_inventory_id",
                schema: "eshop",
                table: "composite_product",
                column: "shop_inventory_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_composite_product_item_composite_product_id_shop_inventory_~",
                schema: "eshop",
                table: "composite_product_item",
                columns: new[] { "composite_product_id", "shop_inventory_id" },
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
                name: "IX_custom_variant_attribute_number",
                schema: "eshop",
                table: "custom_variant_attribute",
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
                name: "IX_map_composite_product_delivery_composite_product_id_deliver~",
                schema: "eshop",
                table: "map_composite_product_delivery",
                columns: new[] { "composite_product_id", "delivery_category_id" },
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
                name: "IX_map_product_category_product_id_product_category_id",
                schema: "eshop",
                table: "map_product_category",
                columns: new[] { "product_id", "product_category_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_map_product_delivery_category_delivery_category_id",
                schema: "eshop",
                table: "map_product_delivery_category",
                column: "delivery_category_id");

            migrationBuilder.CreateIndex(
                name: "IX_map_product_delivery_category_product_id_delivery_category_~",
                schema: "eshop",
                table: "map_product_delivery_category",
                columns: new[] { "product_id", "delivery_category_id" },
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
                name: "IX_order_composite_product_master_id_shop_inventory_id",
                schema: "eshop",
                table: "order_composite_product",
                columns: new[] { "master_id", "shop_inventory_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_order_composite_product_shop_inventory_id",
                schema: "eshop",
                table: "order_composite_product",
                column: "shop_inventory_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_composite_product_item_order_composite_product_id_sho~",
                schema: "eshop",
                table: "order_composite_product_item",
                columns: new[] { "order_composite_product_id", "shop_inventory_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_order_composite_product_item_shop_inventory_id",
                schema: "eshop",
                table: "order_composite_product_item",
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
                name: "IX_order_product_master_id_shop_inventory_id",
                schema: "eshop",
                table: "order_product",
                columns: new[] { "master_id", "shop_inventory_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_order_product_shop_inventory_id",
                schema: "eshop",
                table: "order_product",
                column: "shop_inventory_id");

            migrationBuilder.CreateIndex(
                name: "IX_payment_category_number",
                schema: "eshop",
                table: "payment_category",
                column: "number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_product_eshop_unit_id",
                schema: "eshop",
                table: "product",
                column: "eshop_unit_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_shop_inventory_id",
                schema: "eshop",
                table: "product",
                column: "shop_inventory_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_product_category_number",
                schema: "eshop",
                table: "product_category",
                column: "number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_record_order_composite_product_master_id",
                schema: "eshop",
                table: "record_order_composite_product",
                column: "master_id");

            migrationBuilder.CreateIndex(
                name: "IX_record_order_composite_product_item_detail_id",
                schema: "eshop",
                table: "record_order_composite_product_item",
                column: "detail_id");

            migrationBuilder.CreateIndex(
                name: "IX_record_order_master_user_id",
                schema: "eshop",
                table: "record_order_master",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_record_order_product_master_id",
                schema: "eshop",
                table: "record_order_product",
                column: "master_id");

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
                name: "custom_variant_attribute",
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
                name: "order_composite_product_item",
                schema: "eshop");

            migrationBuilder.DropTable(
                name: "order_product",
                schema: "eshop");

            migrationBuilder.DropTable(
                name: "record_order_composite_product_item",
                schema: "eshop");

            migrationBuilder.DropTable(
                name: "record_order_product",
                schema: "eshop");

            migrationBuilder.DropTable(
                name: "shop_cart",
                schema: "eshop");

            migrationBuilder.DropTable(
                name: "shop_coupon",
                schema: "eshop");

            migrationBuilder.DropTable(
                name: "composite_product",
                schema: "eshop");

            migrationBuilder.DropTable(
                name: "shop_action",
                schema: "eshop");

            migrationBuilder.DropTable(
                name: "product_category",
                schema: "eshop");

            migrationBuilder.DropTable(
                name: "product",
                schema: "eshop");

            migrationBuilder.DropTable(
                name: "shop_permission",
                schema: "eshop");

            migrationBuilder.DropTable(
                name: "shop_role",
                schema: "eshop");

            migrationBuilder.DropTable(
                name: "order_composite_product",
                schema: "eshop");

            migrationBuilder.DropTable(
                name: "record_order_composite_product",
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
