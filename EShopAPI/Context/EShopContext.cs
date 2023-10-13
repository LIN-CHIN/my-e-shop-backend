using EShopAPI.Cores.CompositeProductDetails;
using EShopAPI.Cores.CompositeProductItems;
using EShopAPI.Cores.CompositeProductMasters;
using EShopAPI.Cores.DeliveryCategories;
using EShopAPI.Cores.DeliveryPreferences;
using EShopAPI.Cores.EShopUnits;
using EShopAPI.Cores.MapCompositeProductDeliveries;
using EShopAPI.Cores.MapPermissionActions;
using EShopAPI.Cores.MapProductCategories;
using EShopAPI.Cores.MapProductDeliveryCategorys;
using EShopAPI.Cores.MapRolePermissions;
using EShopAPI.Cores.MapUserRoles;
using EShopAPI.Cores.OrderForCompositeDetails;
using EShopAPI.Cores.OrderForCompositeItems;
using EShopAPI.Cores.OrderForProducts;
using EShopAPI.Cores.OrderMasters;
using EShopAPI.Cores.PaymentCategories;
using EShopAPI.Cores.ProductCategories;
using EShopAPI.Cores.ProductDetails;
using EShopAPI.Cores.ProductMasters;
using EShopAPI.Cores.RecordOrderForCompositeDetails;
using EShopAPI.Cores.RecordOrderForCompositeItems;
using EShopAPI.Cores.RecordOrderForProducts;
using EShopAPI.Cores.RecordOrderMasters;
using EShopAPI.Cores.ShopActions;
using EShopAPI.Cores.ShopCarts;
using EShopAPI.Cores.ShopCoupons;
using EShopAPI.Cores.ShopInventories;
using EShopAPI.Cores.ShopPermissions;
using EShopAPI.Cores.ShopRoles;
using EShopAPI.Cores.ShopUsers;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Numerics;
using System.Xml.Linq;

namespace EShopAPI.Context
{
    /// <summary>
    /// Shop DbContext
    /// </summary>
    public class EShopContext : DbContext
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="options"></param>
        public EShopContext(DbContextOptions options) : base(options) { }

        /// <summary>
        /// 使用者實體
        /// </summary>
        public DbSet<ShopUser> ShopUsers => Set<ShopUser>();

        /// <summary>
        /// 角色實體
        /// </summary>
        public DbSet<ShopRole> ShopRoles => Set<ShopRole>();

        /// <summary>
        /// 權限實體
        /// </summary>
        public DbSet<ShopPermission> ShopPermissions => Set<ShopPermission>();

        /// <summary>
        /// Action實體
        /// </summary>
        public DbSet<ShopAction> ShopActions => Set<ShopAction>();

        /// <summary>
        /// 使用者與角色關聯的實體
        /// </summary>
        public DbSet<MapUserRole> MapUserRoles => Set<MapUserRole>();

        /// <summary>
        /// 角色與權限關聯的實體
        /// </summary>
        public DbSet<MapRolePermission> MapRolePermissions => Set<MapRolePermission>();

        /// <summary>
        /// 權限與功能關聯的實體
        /// </summary>
        public DbSet<MapPermissionAction> MapPermissionActions => Set<MapPermissionAction>();

        /// <summary>
        /// 產品主檔的實體
        /// </summary>
        public DbSet<ProductMaster> ProductMasters => Set<ProductMaster>();

        /// <summary>
        /// 產品子檔的實體
        /// </summary>
        public DbSet<ProductDetail> ProductDetails => Set<ProductDetail>();

        /// <summary>
        /// 組合產品主檔的實體
        /// </summary>
        public DbSet<CompositeProductMaster> CompositeProductMasters => Set<CompositeProductMaster>();

        /// <summary>
        /// 組合產品子檔的實體
        /// </summary>
        public DbSet<CompositeProductDetail> CompositeProductDetails => Set<CompositeProductDetail>();

        /// <summary>
        /// 商店單位的實體
        /// </summary>
        public DbSet<EShopUnit> EShopUnits => Set<EShopUnit>();

        /// <summary>
        /// 物流種類的實體
        /// </summary>
        public DbSet<DeliveryCategory> DeliveryCategorys => Set<DeliveryCategory>();

        /// <summary>
        /// 組合產品與物流種類關聯的實體
        /// </summary>
        public DbSet<MapCompositeProductDelivery> MapCompositeProductDeliverys => Set<MapCompositeProductDelivery>();

        /// <summary>
        /// 產品主表與物流種類關聯的實體
        /// </summary>
        public DbSet<MapProductDeliveryCategory> MapProductDeliveryCategories => Set<MapProductDeliveryCategory>();

        /// <summary>
        /// 產品類別實體
        /// </summary>
        public DbSet<ProductCategory> ProductCategories => Set<ProductCategory>();

        /// <summary>
        /// 產品主表與產品類別關聯的實體
        /// </summary>
        public DbSet<MapProductCategory> MapProductCategories => Set<MapProductCategory>();

        /// <summary>
        /// 商品庫存的實體
        /// </summary>
        public DbSet<ShopInventory> ShopInventories => Set<ShopInventory>();

        /// <summary>
        /// 組合產品項目的實體
        /// </summary>
        public DbSet<CompositeProductItem> CompositeProductItems => Set<CompositeProductItem>();

        /// <summary>
        /// 組合產品項目的實體
        /// </summary>
        public DbSet<ShopCart> ShopCarts => Set<ShopCart>();

        /// <summary>
        /// 組合產品項目的實體
        /// </summary>
        public DbSet<DeliveryPreference> DeliveryPreferences => Set<DeliveryPreference>();

        /// <summary>
        /// 組合產品項目的實體
        /// </summary>
        public DbSet<PaymentCategory> PaymentCategories => Set<PaymentCategory>();

        /// <summary>
        /// 組合產品項目的實體
        /// </summary>
        public DbSet<OrderMaster> OrderMasters => Set<OrderMaster>();

        /// <summary>
        /// 訂單 (針對組合產品detail)的實體
        /// </summary>
        public DbSet<OrderForCompositeDetail> OrderForCompositeDetails => Set<OrderForCompositeDetail>();

        /// <summary>
        /// 訂單 (針對組合產品item)的實體
        /// </summary>
        public DbSet<OrderForCompositeItem> OrderForCompositeItems => Set<OrderForCompositeItem>();

        /// <summary>
        /// 訂單 (針對非組合產品)的實體
        /// </summary>
        public DbSet<OrderForProduct> OrderForProducts => Set<OrderForProduct>();

        /// <summary>
        /// 訂單主檔紀錄的實體
        /// </summary>
        public DbSet<RecordOrderMaster> RecordOrderMasters => Set<RecordOrderMaster>();

        /// <summary>
        /// 訂單紀錄(針對組合產品detail)的實體
        /// </summary>
        public DbSet<RecordOrderForCompositeDetail> RecordOrderForCompositeDetails => Set<RecordOrderForCompositeDetail>();

        /// <summary>
        /// 訂單紀錄(針對組合產品item)的實體
        /// </summary>
        public DbSet<RecordOrderForCompositeItem> RecordOrderForCompositeItems => Set<RecordOrderForCompositeItem>();

        /// <summary>
        /// 訂單紀錄(針對非組合產品)的實體
        /// </summary>
        public DbSet<RecordOrderForProduct> RecordOrderForProducts => Set<RecordOrderForProduct>();

        /// <summary>
        /// 訂單紀錄(針對非組合產品)的實體
        /// </summary>
        public DbSet<ShopCoupon> ShopCoupons => Set<ShopCoupon>();

        ///<inheritdoc/>
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            #region Add Unique key
            modelBuilder.Entity<ShopUser>()
                .HasIndex(x => new { x.Number })
                .IsUnique();

            modelBuilder.Entity<ShopRole>()
                .HasIndex(x => new { x.Number })
                .IsUnique();

            modelBuilder.Entity<ShopPermission>()
                .HasIndex(x => new { x.Number })
                .IsUnique();

            modelBuilder.Entity<ShopAction>()
                .HasIndex(x => new { x.Number })
                .IsUnique();

            modelBuilder.Entity<MapUserRole>()
                .HasIndex(x => new { x.UserId, x.RoleId } )
                .IsUnique();

            modelBuilder.Entity<MapRolePermission>()
                .HasIndex(x => new { x.RoleId, x.PermissionId })
                .IsUnique();

            modelBuilder.Entity<MapPermissionAction>()
                .HasIndex(x => new { x.PermissionId, x.ActionId })
                .IsUnique();

            modelBuilder.Entity<ProductMaster>()
                .HasIndex(x => new { x.Number })
                .IsUnique();

            modelBuilder.Entity<ProductDetail>()
                .HasIndex(x => new { x.ShopInventoryId })
                .IsUnique();

            modelBuilder.Entity<CompositeProductMaster>()
                .HasIndex(x => new { x.Number })
                .IsUnique();

            modelBuilder.Entity<EShopUnit>()
                .HasIndex(x => new { x.Number })
                .IsUnique();

            modelBuilder.Entity<DeliveryCategory>()
               .HasIndex(x => new { x.Number })
               .IsUnique();

            modelBuilder.Entity<MapCompositeProductDelivery>()
               .HasIndex(x => new { x.CompositeProductMasterId, x.DeliveryCategoryId })
               .IsUnique();

            modelBuilder.Entity<MapProductDeliveryCategory>()
              .HasIndex(x => new { x.ProductMasterId, x.DeliveryCategoryId })
              .IsUnique();

            modelBuilder.Entity<ProductCategory>()
              .HasIndex(x => new { x.Number })
              .IsUnique();

            modelBuilder.Entity<MapProductCategory>()
             .HasIndex(x => new { x.ProductMasterId, x.ProductCategoryId })
             .IsUnique();

            modelBuilder.Entity<ShopInventory>()
                .HasIndex(x => new { x.Number })
                .IsUnique();

            modelBuilder.Entity<CompositeProductItem>()
                .HasIndex(x => new { x.DetailId, x.ShopInventoryId })
                .IsUnique();

            modelBuilder.Entity<ShopCart>()
                .HasIndex(x => new { x.UserId, x.ProductEntityType, x.ObjectId })
                .IsUnique();

            modelBuilder.Entity<DeliveryPreference>()
                .HasIndex(x => new { x.UserId, x.DeliveryCategoryId })
                .IsUnique();

            modelBuilder.Entity<PaymentCategory>()
                .HasIndex(x => new { x.Number })
                .IsUnique();

            modelBuilder.Entity<OrderMaster>()
             .HasIndex(x => new { x.Number })
             .IsUnique();

            modelBuilder.Entity<OrderForCompositeDetail>()
             .HasIndex(x => new { x.MasterId, x.ShopInventoryId })
             .IsUnique();

            modelBuilder.Entity<OrderForCompositeItem>()
             .HasIndex(x => new { x.DetailId, x.ShopInventoryId })
             .IsUnique();

            modelBuilder.Entity<OrderForProduct>()
             .HasIndex(x => new { x.MasterId, x.ShopInventoryId })
             .IsUnique();

            modelBuilder.Entity<ShopCoupon>()
             .HasIndex(x => new { x.Number })
             .IsUnique();

            #endregion

            #region Setting Constraints
            //User & Role
            modelBuilder.Entity<MapUserRole>()
                .HasOne(map => map.ShopUser)
                .WithMany(user => user.MapUserRoles)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<MapUserRole>()
                .HasOne(map => map.ShopRole)
                .WithMany(role => role.MapUserRoles)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            //Role & Permission
            modelBuilder.Entity<MapRolePermission>()
               .HasOne(map => map.ShopRole)
               .WithMany(role => role.MapRolePermissions)
               .IsRequired()
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<MapRolePermission>()
               .HasOne(map => map.ShopPermission)
               .WithMany(role => role.MapRolePermissions)
               .IsRequired()
               .OnDelete(DeleteBehavior.Cascade);

            //Permission & Action
            modelBuilder.Entity<MapPermissionAction>()
               .HasOne(map => map.ShopPermission)
               .WithMany(role => role.MapPermissionActions)
               .IsRequired()
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<MapPermissionAction>()
               .HasOne(map => map.ShopAction)
               .WithMany(role => role.MapPermissionActions)
               .IsRequired()
               .OnDelete(DeleteBehavior.Cascade);

            //ProductMaster & ProductDetail
            modelBuilder.Entity<ProductDetail>()
               .HasOne(detail => detail.ProductMaster)
               .WithMany(master => master.ProductDetails)
               .IsRequired()
               .OnDelete(DeleteBehavior.Restrict);

            //ProductDetail & EShopUnit
            modelBuilder.Entity<ProductDetail>()
               .HasOne(product => product.EShopUnit)
               .WithMany(unit => unit.ProductDetails)
               .IsRequired()
               .OnDelete(DeleteBehavior.Restrict);

            //ProductDetail & ShopInventory
            modelBuilder.Entity<ProductDetail>()
               .HasOne(detail => detail.ShopInventory)
               .WithOne(inventory => inventory.ProductDetail)
               .IsRequired()
               .OnDelete(DeleteBehavior.Restrict);

            //CompositeProductDetail & EShopUnit
            modelBuilder.Entity<CompositeProductDetail>()
               .HasOne(composite => composite.EShopUnit)
               .WithMany(unit => unit.CompositeProductDetails)
               .IsRequired()
               .OnDelete(DeleteBehavior.Restrict);

            //CompositeProductDetail & CompositeProductMaster
            modelBuilder.Entity<CompositeProductDetail>()
               .HasOne(detail => detail.CompositeProductMaster)
               .WithMany(master => master.CompositeProductDetails)
               .IsRequired()
               .OnDelete(DeleteBehavior.Restrict);

            //CompositeProductDetail & CompositeProductMaster
            modelBuilder.Entity<CompositeProductDetail>()
               .HasOne(detail => detail.ShopInventory)
               .WithOne(inventory => inventory.CompositeProductDetail)
               .IsRequired()
               .OnDelete(DeleteBehavior.Restrict);

            //MapCompositeProductDelivery & CompositeProductMaster
            modelBuilder.Entity<MapCompositeProductDelivery>()
               .HasOne(map => map.CompositeProductMaster)
               .WithMany(master => master.MapCompositeProductDeliveries)
               .IsRequired()
               .OnDelete(DeleteBehavior.Cascade);

            //MapCompositeProductDelivery & DeliveryCategory
            modelBuilder.Entity<MapCompositeProductDelivery>()
               .HasOne(map => map.DeliveryCategory)
               .WithMany(master => master.MapCompositeProductDeliveries)
               .IsRequired()
               .OnDelete(DeleteBehavior.Cascade);

            //MapProductDeliveryCategory & ProductMaster
            modelBuilder.Entity<MapProductDeliveryCategory>()
               .HasOne(map => map.ProductMaster)
               .WithMany(master => master.MapProductDeliveryCategories)
               .IsRequired()
               .OnDelete(DeleteBehavior.Cascade);

            //MapProductDeliveryCategory & DeliveryCategory
            modelBuilder.Entity<MapProductDeliveryCategory>()
               .HasOne(map => map.DeliveryCategory)
               .WithMany(master => master.MapProductDeliveryCategories)
               .IsRequired()
               .OnDelete(DeleteBehavior.Cascade);

            //MapProductCategory & ProductMaster
            modelBuilder.Entity<MapProductCategory>()
               .HasOne(map => map.ProductMaster)
               .WithMany(master => master.MapProductCategories)
               .IsRequired()
               .OnDelete(DeleteBehavior.Cascade);

            //MapProductCategory & ProductCategory
            modelBuilder.Entity<MapProductCategory>()
               .HasOne(map => map.ProductCategory)
               .WithMany(master => master.MapProductCategories)
               .IsRequired()
               .OnDelete(DeleteBehavior.Cascade);

            //CompositeProductItem & CompositeProductItems
            modelBuilder.Entity<CompositeProductItem>()
               .HasOne(item => item.CompositeProductDetail)
               .WithMany(detail => detail.CompositeProductItems)
               .IsRequired()
               .OnDelete(DeleteBehavior.Restrict);

            //CompositeProductItem & EShopUnit
            modelBuilder.Entity<CompositeProductItem>()
               .HasOne(item => item.EShopUnit)
               .WithMany(unit => unit.CompositeProductItems)
               .IsRequired()
               .OnDelete(DeleteBehavior.Restrict);

            //CompositeProductItem & ShopInventory
            modelBuilder.Entity<CompositeProductItem>()
               .HasOne(item => item.ShopInventory)
               .WithMany(inventory => inventory.CompositeProductItems)
               .IsRequired()
               .OnDelete(DeleteBehavior.Restrict);

            //ShopCart & ShopUser
            modelBuilder.Entity<ShopCart>()
               .HasOne(cart => cart.ShopUser)
               .WithMany(user => user.ShopCarts)
               .IsRequired()
               .OnDelete(DeleteBehavior.Cascade);

            //DeliveryPreference & ShopUser
            modelBuilder.Entity<DeliveryPreference>()
               .HasOne(delivery => delivery.ShopUser)
               .WithMany(user => user.DeliveryPreferences)
               .IsRequired()
               .OnDelete(DeleteBehavior.Cascade);

            //DeliveryPreference & DeliveryCategory
            modelBuilder.Entity<DeliveryPreference>()
               .HasOne(delivery => delivery.DeliveryCategory)
               .WithMany(category => category.DeliveryPreferences)
               .IsRequired()
               .OnDelete(DeleteBehavior.Cascade);

            //OrderMaster & ShopUser
            modelBuilder.Entity<OrderMaster>()
               .HasOne(master => master.ShopUser)
               .WithMany(user => user.OrderMasters)
               .IsRequired()
               .OnDelete(DeleteBehavior.Restrict);

            //OrderMaster & DeliveryCategory
            modelBuilder.Entity<OrderMaster>()
               .HasOne(master => master.DeliveryCategory)
               .WithMany(delivery => delivery.OrderMasters)
               .IsRequired()
               .OnDelete(DeleteBehavior.Restrict);

            //OrderMaster & PaymentCategory
            modelBuilder.Entity<OrderMaster>()
               .HasOne(master => master.PaymentCategory)
               .WithMany(payment => payment.OrderMasters)
               .IsRequired()
               .OnDelete(DeleteBehavior.Restrict);

            //OrderForCompositeDetail & ShopInventory
            modelBuilder.Entity<OrderForCompositeDetail>()
               .HasOne(detail => detail.ShopInventory)
               .WithMany(inventory => inventory.OrderForCompositeDetails)
               .IsRequired()
               .OnDelete(DeleteBehavior.Restrict);

            //OrderForCompositeDetail & OrderMaster
            modelBuilder.Entity<OrderForCompositeDetail>()
               .HasOne(detail => detail.OrderMaster)
               .WithMany(master => master.OrderForCompositeDetails)
               .IsRequired()
               .OnDelete(DeleteBehavior.Cascade);

            //OrderForCompositeItem & OrderForCompositeDetail
            modelBuilder.Entity<OrderForCompositeItem>()
               .HasOne(item => item.OrderForCompositeDetail)
               .WithMany(detail => detail.OrderForCompositeItems)
               .IsRequired()
               .OnDelete(DeleteBehavior.Cascade);

            //OrderForCompositeItem & ShopInventory
            modelBuilder.Entity<OrderForCompositeItem>()
               .HasOne(item => item.ShopInventory)
               .WithMany(inventory => inventory.OrderForCompositeItems)
               .IsRequired()
               .OnDelete(DeleteBehavior.Restrict);

            //OrderForProduct & OrderMaster
            modelBuilder.Entity<OrderForProduct>()
               .HasOne(order => order.OrderMaster)
               .WithMany(master => master.OrderForProducts)
               .IsRequired()
               .OnDelete(DeleteBehavior.Cascade);

            //OrderForProduct & ShopInventory
            modelBuilder.Entity<OrderForProduct>()
               .HasOne(order => order.ShopInventory)
               .WithMany(inventory => inventory.OrderForProducts)
               .IsRequired()
               .OnDelete(DeleteBehavior.Restrict);

            //RecordOrderMaster & ShopUser
            modelBuilder.Entity<RecordOrderMaster>()
               .HasOne(record => record.ShopUser)
               .WithMany(user => user.RecordOrderMasters)
               .IsRequired()
               .OnDelete(DeleteBehavior.Restrict);

            //RecordOrderForCompositeDetails & RecordOrderMaster
            modelBuilder.Entity<RecordOrderForCompositeDetail>()
               .HasOne(detail => detail.RecordOrderMaster)
               .WithMany(master => master.RecordOrderForCompositeDetails)
               .IsRequired()
               .OnDelete(DeleteBehavior.Cascade);

            //RecordOrderForCompositeItem & RecordOrderForCompositeDetail
            modelBuilder.Entity<RecordOrderForCompositeItem>()
               .HasOne(item => item.RecordOrderForCompositeDetail)
               .WithMany(detail => detail.RecordOrderForCompositeItems)
               .IsRequired()
               .OnDelete(DeleteBehavior.Cascade);

            //RecordOrderForProduct & RecordOrderMaster
            modelBuilder.Entity<RecordOrderForProduct>()
               .HasOne(record => record.RecordOrderMaster)
               .WithMany(master => master.RecordOrderForProducts)
               .IsRequired()
               .OnDelete(DeleteBehavior.Cascade);
            #endregion

            #region Set Default value
            modelBuilder.Entity<ShopUser>()
                .Property(x => x.IsAdmin)
                .HasDefaultValue(false);
                
            #endregion

            #region Add Seed
            modelBuilder.Entity<EShopUnit>()
                .HasData(GetDefaultUnits());

            modelBuilder.Entity<ShopUser>()
               .HasData(GetDefaultUsers());

            modelBuilder.Entity<ShopRole>()
               .HasData(GetDefaultRoles());
            #endregion
        }

        /// <summary>
        /// 取得預設的單位清單
        /// </summary>
        /// <returns></returns>
        private static IList<EShopUnit> GetDefaultUnits() 
        {
            return new List<EShopUnit>()
            {
                new EShopUnit {
                    Id = 1,
                    CreateUser = "shopAdmin",
                    CreateDate = 1695285957713,
                    UpdateUser = null,
                    UpdateDate = null,
                    Remarks = null,
                    Language = null,
                    Number = "Piece",
                    Name = "顆",
                    IsEnable = true,
                    IsSystemDefault = true
                },
                new EShopUnit {
                    Id = 2,
                    CreateUser = "shopAdmin",
                    CreateDate = 1695285957713,
                    UpdateUser = null,
                    UpdateDate = null,
                    Remarks = null,
                    Language = null,
                    Number = "Unit",
                    Name = "件",
                    IsEnable = true,
                    IsSystemDefault = true
                },
                new EShopUnit {
                    Id = 3,
                    CreateUser = "shopAdmin",
                    CreateDate = 1695285957713,
                    UpdateUser = null,
                    UpdateDate = null,
                    Remarks = null,
                    Language = null,
                    Number = "Pair",
                    Name = "雙/副",
                    IsEnable = true,
                    IsSystemDefault = true
                },
                new EShopUnit {
                    Id = 4,
                    CreateUser = "shopAdmin",
                    CreateDate = 1695285957713,
                    UpdateUser = null,
                    UpdateDate = null,
                    Remarks = null,
                    Language = null,
                    Number = "Set",
                    Name = "套/台/架",
                    IsEnable = true,
                    IsSystemDefault = true
                },
                new EShopUnit {
                    Id = 5,
                    CreateUser = "shopAdmin",
                    CreateDate = 1695285957713,
                    UpdateUser = null,
                    UpdateDate = null,
                    Remarks = null,
                    Language = null,
                    Number = "Dozen",
                    Name = "打",
                    IsEnable = true,
                    IsSystemDefault = true
                },
                new EShopUnit {
                    Id = 6,
                    CreateUser = "shopAdmin",
                    CreateDate = 1695285957713,
                    UpdateUser = null,
                    UpdateDate = null,
                    Remarks = null,
                    Language = null,
                    Number = "Roll",
                    Name = "卷",
                    IsEnable = true,
                    IsSystemDefault = true
                },
                new EShopUnit {
                    Id = 7,
                    CreateUser = "shopAdmin",
                    CreateDate = 1695285957713,
                    UpdateUser = null,
                    UpdateDate = null,
                    Remarks = null,
                    Language = null,
                    Number = "Bag",
                    Name = "袋",
                    IsEnable = true,
                    IsSystemDefault = true
                },
                new EShopUnit {
                    Id = 8,
                    CreateUser = "shopAdmin",
                    CreateDate = 1695285957713,
                    UpdateUser = null,
                    UpdateDate = null,
                    Remarks = null,
                    Language = null,
                    Number = "Bottle",
                    Name = "瓶",
                    IsEnable = true,
                    IsSystemDefault = true
                },
            };
        }

        /// <summary>
        /// 取得預設的使用者清單
        /// </summary>
        /// <returns></returns>
        private static IList<ShopUser> GetDefaultUsers() 
        {
            return new List<ShopUser>
            {
                new ShopUser
                {
                    Id = 1,
                    CreateUser = "shopAdmin",
                    CreateDate = 1695285957713,
                    UpdateUser = null,
                    UpdateDate = null,
                    Remarks = "預設的最高權限帳號",
                    Language = null,
                    Number = "shopAdmin",
                    Name = "商店管理員",
                    Pwd = "shopAdmin",
                    Address = null,
                    Email = null,
                    Phone = null,
                    IsEnable = true,
                    IsAdmin = true,
                },
                new ShopUser
                {
                    Id = 2,
                    CreateUser = "shopUser",
                    CreateDate = 1695285957713,
                    UpdateUser = null,
                    UpdateDate = null,
                    Remarks = "預設的一般使用者(測試用)",
                    Language = null,
                    Number = "shopUser",
                    Name = "商店使用者(測試用)",
                    Pwd = "shopUser",
                    Address = null,
                    Email = null,
                    Phone = null,
                    IsEnable = true,
                    IsAdmin = false
                }
            };
        }

        /// <summary>
        /// 取得預設的角色清單
        /// </summary>
        /// <returns></returns>
        private static IList<ShopRole> GetDefaultRoles()
        {
            return new List<ShopRole>
            {
                new ShopRole
                {
                    Id = 1,
                    CreateUser = "shopAdmin",
                    CreateDate = 1695285957713,
                    UpdateUser = null,
                    UpdateDate = null,
                    Remarks = "商店管理者權限",
                    Language = null,
                    Number = "shopAdminRole",
                    Name = "商店管理者權限",
                    IsEnable = true
                },
                new ShopRole
                {
                    Id = 2,
                    CreateUser = "shopUser",
                    CreateDate = 1695285957713,
                    UpdateUser = null,
                    UpdateDate = null,
                    Remarks = "預設的一般使用者(測試用)",
                    Language = null,
                    Number = "shopUser",
                    Name = "商店使用者(測試用)",
                    IsEnable = true
                },
                new ShopRole
                {
                    Id = 3,
                    CreateUser = "shopUser",
                    CreateDate = 1695285957713,
                    UpdateUser = null,
                    UpdateDate = null,
                    Remarks = "一般客戶",
                    Language = null,
                    Number = "custom",
                    Name = "一般客戶",
                    IsEnable = true
                },
                new ShopRole
                {
                    Id = 4,
                    CreateUser = "shopUser",
                    CreateDate = 1695285957713,
                    UpdateUser = null,
                    UpdateDate = null,
                    Remarks = "VIP客戶",
                    Language = null,
                    Number = "vip_custom",
                    Name = "VIP客戶",
                    IsEnable = true
                },
            };
        }
    }
}
