using EShopAPI.Common.Enums;
using EShopAPI.Cores.CompositeProductItems;
using EShopAPI.Cores.CompositeProducts;
using EShopAPI.Cores.DeliveryCategories;
using EShopAPI.Cores.DeliveryPreferences;
using EShopAPI.Cores.EShopUnits;
using EShopAPI.Cores.MapCompositeProductDeliveries;
using EShopAPI.Cores.MapPermissionActions;
using EShopAPI.Cores.MapProductCategories;
using EShopAPI.Cores.MapProductDeliveryCategorys;
using EShopAPI.Cores.MapRolePermissions;
using EShopAPI.Cores.MapUserRoles;
using EShopAPI.Cores.OrderCompositeProducts;
using EShopAPI.Cores.OrderForCompositeItems;
using EShopAPI.Cores.OrderProducts;
using EShopAPI.Cores.OrderMasters;
using EShopAPI.Cores.PaymentCategories;
using EShopAPI.Cores.ProductCategories;
using EShopAPI.Cores.Products;
using EShopAPI.Cores.RecordOrderProducts;
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
using EShopAPI.Cores.RecordOrderCompositeProductItems;
using EShopAPI.Cores.RecordOrderCompositeProducts;

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
        /// 產品的實體
        /// </summary>
        public DbSet<Product> Product => Set<Product>();

        /// <summary>
        /// 組合產品的實體
        /// </summary>
        public DbSet<CompositeProduct> CompositeProduct => Set<CompositeProduct>();

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
        /// 訂單 (針對組合產品)的實體
        /// </summary>
        public DbSet<OrderCompositeProduct> OrderCompositeProducts => Set<OrderCompositeProduct>();

        /// <summary>
        /// 訂單 (針對組合產品item)的實體
        /// </summary>
        public DbSet<OrderCompositeProductItem> OrderCompositeProductItems => Set<OrderCompositeProductItem>();

        /// <summary>
        /// 訂單 (針對非組合產品)的實體
        /// </summary>
        public DbSet<OrderProduct> OrderProducts => Set<OrderProduct>();

        /// <summary>
        /// 訂單主檔紀錄的實體
        /// </summary>
        public DbSet<RecordOrderMaster> RecordOrderMasters => Set<RecordOrderMaster>();

        /// <summary>
        /// 訂單紀錄(針對組合產品detail)的實體
        /// </summary>
        public DbSet<RecordOrderCompositeProduct> RecordOrderCompositeProducts => Set<RecordOrderCompositeProduct>();

        /// <summary>
        /// 訂單紀錄(針對組合產品item)的實體
        /// </summary>
        public DbSet<RecordOrderCompositeProductItem> RecordOrderCompositeProductItems => Set<RecordOrderCompositeProductItem>();

        /// <summary>
        /// 訂單紀錄(針對非組合產品)的實體
        /// </summary>
        public DbSet<RecordOrderProduct> RecordOrderProducts => Set<RecordOrderProduct>();

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

            modelBuilder.Entity<Product>()
                .HasIndex(x => new { x.ShopInventoryId })
                .IsUnique();

            modelBuilder.Entity<EShopUnit>()
                .HasIndex(x => new { x.Number })
                .IsUnique();

            modelBuilder.Entity<DeliveryCategory>()
               .HasIndex(x => new { x.Number })
               .IsUnique();

            modelBuilder.Entity<MapCompositeProductDelivery>()
               .HasIndex(x => new { x.CompositeProductId, x.DeliveryCategoryId })
               .IsUnique();

            modelBuilder.Entity<MapProductDeliveryCategory>()
              .HasIndex(x => new { x.ProductId, x.DeliveryCategoryId })
              .IsUnique();

            modelBuilder.Entity<ProductCategory>()
              .HasIndex(x => new { x.Number })
              .IsUnique();

            modelBuilder.Entity<MapProductCategory>()
             .HasIndex(x => new { x.ProductId, x.ProductCategoryId })
             .IsUnique();

            modelBuilder.Entity<ShopInventory>()
                .HasIndex(x => new { x.Number })
                .IsUnique();

            modelBuilder.Entity<CompositeProductItem>()
                .HasIndex(x => new { x.CompositeProductId, x.ShopInventoryId })
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

            modelBuilder.Entity<OrderCompositeProduct>()
             .HasIndex(x => new { x.MasterId, x.ShopInventoryId })
             .IsUnique();

            modelBuilder.Entity<OrderCompositeProductItem>()
             .HasIndex(x => new { x.OrderCompositeProductId, x.ShopInventoryId })
             .IsUnique();

            modelBuilder.Entity<OrderProduct>()
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

            //Product & EShopUnit
            modelBuilder.Entity<Product>()
               .HasOne(product => product.EShopUnit)
               .WithMany(unit => unit.Product)
               .IsRequired()
               .OnDelete(DeleteBehavior.Restrict);

            //Product & ShopInventory
            modelBuilder.Entity<Product>()
               .HasOne(product => product.ShopInventory)
               .WithOne(inventory => inventory.Product)
               .IsRequired()
               .OnDelete(DeleteBehavior.Restrict);

            //CompositeProduct & EShopUnit
            modelBuilder.Entity<CompositeProduct>()
               .HasOne(composite => composite.EShopUnit)
               .WithMany(unit => unit.CompositeProduct)
               .IsRequired()
               .OnDelete(DeleteBehavior.Restrict);

            //CompositeProduct & ShopInventory
            modelBuilder.Entity<CompositeProduct>()
               .HasOne(composite => composite.ShopInventory)
               .WithOne(inventory => inventory.CompositeProduct)
               .IsRequired()
               .OnDelete(DeleteBehavior.Restrict);

            //MapCompositeProductDelivery & CompositeProduct
            modelBuilder.Entity<MapCompositeProductDelivery>()
               .HasOne(map => map.CompositeProduct)
               .WithMany(composite => composite.MapCompositeProductDeliveries)
               .IsRequired()
               .OnDelete(DeleteBehavior.Cascade);

            //MapCompositeProductDelivery & DeliveryCategory
            modelBuilder.Entity<MapCompositeProductDelivery>()
               .HasOne(map => map.DeliveryCategory)
               .WithMany(delivery => delivery.MapCompositeProductDeliveries)
               .IsRequired()
               .OnDelete(DeleteBehavior.Cascade);

            //MapProductDeliveryCategory & Product
            modelBuilder.Entity<MapProductDeliveryCategory>()
               .HasOne(map => map.Product)
               .WithMany(product => product.MapProductDeliveryCategories)
               .IsRequired()
               .OnDelete(DeleteBehavior.Cascade);

            //MapProductDeliveryCategory & DeliveryCategory
            modelBuilder.Entity<MapProductDeliveryCategory>()
               .HasOne(map => map.DeliveryCategory)
               .WithMany(delivery => delivery.MapProductDeliveryCategories)
               .IsRequired()
               .OnDelete(DeleteBehavior.Cascade);

            //MapProductCategory & Product
            modelBuilder.Entity<MapProductCategory>()
               .HasOne(map => map.Product)
               .WithMany(product => product.MapProductCategories)
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
               .HasOne(item => item.CompositeProduct)
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

            //OrderCompositeProduct & ShopInventory
            modelBuilder.Entity<OrderCompositeProduct>()
               .HasOne(composite => composite.ShopInventory)
               .WithMany(inventory => inventory.OrderCompositeProducts)
               .IsRequired()
               .OnDelete(DeleteBehavior.Restrict);

            //OrderCompositeProduct & OrderMaster
            modelBuilder.Entity<OrderCompositeProduct>()
               .HasOne(composite => composite.OrderMaster)
               .WithMany(master => master.OrderCompositeProducts)
               .IsRequired()
               .OnDelete(DeleteBehavior.Cascade);

            //OrderCompositeProductItem & OrderForCompositeDetail
            modelBuilder.Entity<OrderCompositeProductItem>()
               .HasOne(item => item.OrderCompositeProduct)
               .WithMany(composite => composite.OrderCompositeProductItems)
               .IsRequired()
               .OnDelete(DeleteBehavior.Cascade);

            //OrderCompositeProductItem & ShopInventory
            modelBuilder.Entity<OrderCompositeProductItem>()
               .HasOne(item => item.ShopInventory)
               .WithMany(inventory => inventory.OrderCompositeProductItems)
               .IsRequired()
               .OnDelete(DeleteBehavior.Restrict);

            //OrderProduct & OrderMaster
            modelBuilder.Entity<OrderProduct>()
               .HasOne(order => order.OrderMaster)
               .WithMany(master => master.OrderProducts)
               .IsRequired()
               .OnDelete(DeleteBehavior.Cascade);

            //OrderProduct & ShopInventory
            modelBuilder.Entity<OrderProduct>()
               .HasOne(order => order.ShopInventory)
               .WithMany(inventory => inventory.OrderProducts)
               .IsRequired()
               .OnDelete(DeleteBehavior.Restrict);

            //RecordOrderMaster & ShopUser
            modelBuilder.Entity<RecordOrderMaster>()
               .HasOne(record => record.ShopUser)
               .WithMany(user => user.RecordOrderMasters)
               .IsRequired()
               .OnDelete(DeleteBehavior.Restrict);

            //RecordOrderForCompositeDetails & RecordOrderMaster
            modelBuilder.Entity<RecordOrderCompositeProduct>()
               .HasOne(record => record.RecordOrderMaster)
               .WithMany(master => master.RecordOrderCompositeProducts)
               .IsRequired()
               .OnDelete(DeleteBehavior.Cascade);

            //RecordOrderForCompositeItem & RecordOrderForCompositeDetail
            modelBuilder.Entity<RecordOrderCompositeProductItem>()
               .HasOne(item => item.RecordOrderCompositeProduct)
               .WithMany(detail => detail.RecordOrderCompositeProductItems)
               .IsRequired()
               .OnDelete(DeleteBehavior.Cascade);

            //RecordOrderForProduct & RecordOrderMaster
            modelBuilder.Entity<RecordOrderProduct>()
               .HasOne(record => record.RecordOrderMaster)
               .WithMany(master => master.RecordOrderProducts)
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

            modelBuilder.Entity<MapUserRole>()
              .HasData(GetDefaultMapUserRoles());

            modelBuilder.Entity<ShopPermission>()
               .HasData(GetDefaultPermissions());

            modelBuilder.Entity<MapRolePermission>()
               .HasData(GetDefaultMapRolePermissions());
            
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
                    CreateUser = "shopAdmin",
                    CreateDate = 1695285957713,
                    UpdateUser = null,
                    UpdateDate = null,
                    Remarks = "預設的員工(測試用)",
                    Language = null,
                    Number = "shopEmployee1",
                    Name = "員工1(測試用)",
                    Pwd = "shopEmployee1",
                    Address = null,
                    Email = null,
                    Phone = null,
                    IsEnable = true,
                    IsAdmin = false
                },
                new ShopUser
                {
                    Id = 3,
                    CreateUser = "shopAdmin",
                    CreateDate = 1695285957713,
                    UpdateUser = null,
                    UpdateDate = null,
                    Remarks = "預設的一般使用者(測試用)",
                    Language = null,
                    Number = "shopUser",
                    Name = "一般客戶1(測試用)",
                    Pwd = "shopUser",
                    Address = null,
                    Email = null,
                    Phone = null,
                    IsEnable = true,
                    IsAdmin = false
                },
                new ShopUser
                {
                    Id = 4,
                    CreateUser = "shopAdmin",
                    CreateDate = 1695285957713,
                    UpdateUser = null,
                    UpdateDate = null,
                    Remarks = "預設的VIP使用者(測試用)",
                    Language = null,
                    Number = "shopVipUser",
                    Name = "VIP客戶1(測試用)",
                    Pwd = "shopVipUser",
                    Address = null,
                    Email = null,
                    Phone = null,
                    IsEnable = true,
                    IsAdmin = false
                }
            };
        }

        /// <summary>
        /// 取得預設的使用者與角色的關係清單
        /// </summary>
        /// <returns></returns>
        private static IList<MapUserRole> GetDefaultMapUserRoles()
        {
            return new List<MapUserRole>
            {
                new MapUserRole
                {
                    Id = 1,
                    CreateUser = "shopAdmin",
                    CreateDate = 1695285957713,
                    UpdateUser = null,
                    UpdateDate = null,
                    Remarks = "員工測試帳號對應的員工角色",
                    Language = null,
                    UserId = 2,
                    RoleId = 1
                },
                new MapUserRole
                {
                    Id = 2,
                    CreateUser = "shopUser",
                    CreateDate = 1695285957713,
                    UpdateUser = null,
                    UpdateDate = null,
                    Remarks = "一般使用者帳號對應的基礎使用者角色",
                    Language = null,
                    UserId = 3,
                    RoleId = 2
                },
                new MapUserRole
                {
                    Id = 3,
                    CreateUser = "shopUser",
                    CreateDate = 1695285957713,
                    UpdateUser = null,
                    UpdateDate = null,
                    Remarks = "VIP帳號對應的VIP使用者角色",
                    Language = null,
                    UserId = 4,
                    RoleId = 3
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
                    Remarks = "員工角色",
                    Language = null,
                    Number = "shop_employee",
                    Name = "商店員工角色",
                    IsEnable = true
                },
                new ShopRole
                {
                    Id = 2,
                    CreateUser = "shopAdmin",
                    CreateDate = 1695285957713,
                    UpdateUser = null,
                    UpdateDate = null,
                    Remarks = "一般客戶角色",
                    Language = null,
                    Number = "custom",
                    Name = "一般客戶角色",
                    IsEnable = true
                },
                new ShopRole
                {
                    Id = 3,
                    CreateUser = "shopAdmin",
                    CreateDate = 1695285957713,
                    UpdateUser = null,
                    UpdateDate = null,
                    Remarks = "VIP客戶角色",
                    Language = null,
                    Number = "vip_custom",
                    Name = "VIP客戶角色",
                    IsEnable = true
                },
            };
        }

        /// <summary>
        /// 取得預設的權限清單
        /// </summary>
        /// <returns></returns>
        private static IList<ShopPermission> GetDefaultPermissions()
        {
            return new List<ShopPermission>
            {
                new ShopPermission
                {
                    Id = 1,
                    CreateUser = "shopAdmin",
                    CreateDate = 1695285957713,
                    UpdateUser = null,
                    UpdateDate = null,
                    Remarks = null,
                    Language = null,
                    Number = "ShopUser",
                    Name = "商店使用者",
                    IsEnable = true
                },
                new ShopPermission
                {
                    Id = 2,
                    CreateUser = "shopAdmin",
                    CreateDate = 1695285957713,
                    UpdateUser = null,
                    UpdateDate = null,
                    Remarks = null,
                    Language = null,
                    Number = "ShopRole",
                    Name = "商店角色",
                    IsEnable = true
                },
                new ShopPermission
                {
                    Id = 3,
                    CreateUser = "shopAdmin",
                    CreateDate = 1695285957713,
                    UpdateUser = null,
                    UpdateDate = null,
                    Remarks = null,
                    Language = null,
                    Number = "MapUserRole",
                    Name = "商店使用者與角色關係",
                    IsEnable = true
                },
                new ShopPermission
                {
                    Id = 4,
                    CreateUser = "shopAdmin",
                    CreateDate = 1695285957713,
                    UpdateUser = null,
                    UpdateDate = null,
                    Remarks = null,
                    Language = null,
                    Number = "ShopPermission",
                    Name = "商店權限",
                    IsEnable = true
                },
                new ShopPermission
                {
                    Id = 5,
                    CreateUser = "shopAdmin",
                    CreateDate = 1695285957713,
                    UpdateUser = null,
                    UpdateDate = null,
                    Remarks = null,
                    Language = null,
                    Number = "MapRolePermission",
                    Name = "商店角色與權限關係",
                    IsEnable = true
                },
                new ShopPermission
                {
                    Id = 6,
                    CreateUser = "shopAdmin",
                    CreateDate = 1695285957713,
                    UpdateUser = null,
                    UpdateDate = null,
                    Remarks = null,
                    Language = null,
                    Number = "ProductMaster",
                    Name = "產品主檔",
                    IsEnable = true
                },
                new ShopPermission
                {
                    Id = 7,
                    CreateUser = "shopAdmin",
                    CreateDate = 1695285957713,
                    UpdateUser = null,
                    UpdateDate = null,
                    Remarks = null,
                    Language = null,
                    Number = "ProductDetail",
                    Name = "產品細項",
                    IsEnable = true
                },
                new ShopPermission
                {
                    Id = 8,
                    CreateUser = "shopAdmin",
                    CreateDate = 1695285957713,
                    UpdateUser = null,
                    UpdateDate = null,
                    Remarks = null,
                    Language = null,
                    Number = "CompositeProductMaster",
                    Name = "組合產品主檔",
                    IsEnable = true
                },
                new ShopPermission
                {
                    Id = 9,
                    CreateUser = "shopAdmin",
                    CreateDate = 1695285957713,
                    UpdateUser = null,
                    UpdateDate = null,
                    Remarks = null,
                    Language = null,
                    Number = "CompositeProductDetail",
                    Name = "組合產品細項",
                    IsEnable = true
                },
                new ShopPermission
                {
                    Id = 10,
                    CreateUser = "shopAdmin",
                    CreateDate = 1695285957713,
                    UpdateUser = null,
                    UpdateDate = null,
                    Remarks = null,
                    Language = null,
                    Number = "CompositeProductItem",
                    Name = "組合產品細項的項目",
                    IsEnable = true
                },
                new ShopPermission
                {
                    Id = 11,
                    CreateUser = "shopAdmin",
                    CreateDate = 1695285957713,
                    UpdateUser = null,
                    UpdateDate = null,
                    Remarks = null,
                    Language = null,
                    Number = "ShopInventory",
                    Name = "商店庫存",
                    IsEnable = true
                },
                new ShopPermission
                {
                    Id = 12,
                    CreateUser = "shopAdmin",
                    CreateDate = 1695285957713,
                    UpdateUser = null,
                    UpdateDate = null,
                    Remarks = null,
                    Language = null,
                    Number = "EshopUnit",
                    Name = "商店單位",
                    IsEnable = true
                },
                new ShopPermission
                {
                    Id = 13,
                    CreateUser = "shopAdmin",
                    CreateDate = 1695285957713,
                    UpdateUser = null,
                    UpdateDate = null,
                    Remarks = null,
                    Language = null,
                    Number = "ProductCategory",
                    Name = "產品類型",
                    IsEnable = true
                },
                new ShopPermission
                {
                    Id = 14,
                    CreateUser = "shopAdmin",
                    CreateDate = 1695285957713,
                    UpdateUser = null,
                    UpdateDate = null,
                    Remarks = null,
                    Language = null,
                    Number = "MapProductCategory",
                    Name = "產品與產品類型的關係",
                    IsEnable = true
                },
                new ShopPermission
                {
                    Id = 15,
                    CreateUser = "shopAdmin",
                    CreateDate = 1695285957713,
                    UpdateUser = null,
                    UpdateDate = null,
                    Remarks = null,
                    Language = null,
                    Number = "DeliveryCategory",
                    Name = "物流類型",
                    IsEnable = true
                },
                new ShopPermission
                {
                    Id = 16,
                    CreateUser = "shopAdmin",
                    CreateDate = 1695285957713,
                    UpdateUser = null,
                    UpdateDate = null,
                    Remarks = null,
                    Language = null,
                    Number = "MapCompositeProductDelivery",
                    Name = "組合產品與物流的關係",
                    IsEnable = true
                },
                new ShopPermission
                {
                    Id = 17,
                    CreateUser = "shopAdmin",
                    CreateDate = 1695285957713,
                    UpdateUser = null,
                    UpdateDate = null,
                    Remarks = null,
                    Language = null,
                    Number = "MapProductDeliveryCategory",
                    Name = "產品與物流的關係",
                    IsEnable = true
                },
                new ShopPermission
                {
                    Id = 18,
                    CreateUser = "shopAdmin",
                    CreateDate = 1695285957713,
                    UpdateUser = null,
                    UpdateDate = null,
                    Remarks = null,
                    Language = null,
                    Number = "DeliveryPreference",
                    Name = "物流偏好",
                    IsEnable = true
                },
                new ShopPermission
                {
                    Id = 19,
                    CreateUser = "shopAdmin",
                    CreateDate = 1695285957713,
                    UpdateUser = null,
                    UpdateDate = null,
                    Remarks = null,
                    Language = null,
                    Number = "OrderMaster",
                    Name = "訂單主檔",
                    IsEnable = true
                },
                new ShopPermission
                {
                    Id = 20,
                    CreateUser = "shopAdmin",
                    CreateDate = 1695285957713,
                    UpdateUser = null,
                    UpdateDate = null,
                    Remarks = null,
                    Language = null,
                    Number = "OrderForProduct",
                    Name = "產品訂單",
                    IsEnable = true
                },
                new ShopPermission
                {
                    Id = 21,
                    CreateUser = "shopAdmin",
                    CreateDate = 1695285957713,
                    UpdateUser = null,
                    UpdateDate = null,
                    Remarks = null,
                    Language = null,
                    Number = "OrderForCompositeDetail",
                    Name = "組合產品訂單細項",
                    IsEnable = true
                },
                new ShopPermission
                {
                    Id = 22,
                    CreateUser = "shopAdmin",
                    CreateDate = 1695285957713,
                    UpdateUser = null,
                    UpdateDate = null,
                    Remarks = null,
                    Language = null,
                    Number = "OrderForCompositeItem",
                    Name = "組合產品訂單細項的項目",
                    IsEnable = true
                },
                new ShopPermission
                {
                    Id = 23,
                    CreateUser = "shopAdmin",
                    CreateDate = 1695285957713,
                    UpdateUser = null,
                    UpdateDate = null,
                    Remarks = null,
                    Language = null,
                    Number = "ShopCart",
                    Name = "購物車",
                    IsEnable = true
                },
                new ShopPermission
                {
                    Id = 24,
                    CreateUser = "shopAdmin",
                    CreateDate = 1695285957713,
                    UpdateUser = null,
                    UpdateDate = null,
                    Remarks = null,
                    Language = null,
                    Number = "RecordOrderMaster",
                    Name = "訂單主檔紀錄",
                    IsEnable = true
                },
                new ShopPermission
                {
                    Id = 25,
                    CreateUser = "shopAdmin",
                    CreateDate = 1695285957713,
                    UpdateUser = null,
                    UpdateDate = null,
                    Remarks = null,
                    Language = null,
                    Number = "RecordOrderForProduct",
                    Name = "產品訂單紀錄",
                    IsEnable = true
                },
                new ShopPermission
                {
                    Id = 26,
                    CreateUser = "shopAdmin",
                    CreateDate = 1695285957713,
                    UpdateUser = null,
                    UpdateDate = null,
                    Remarks = null,
                    Language = null,
                    Number = "RecordOrderForCompositeDetail",
                    Name = "組合產品訂單細項紀錄",
                    IsEnable = true
                },
                new ShopPermission
                {
                    Id = 27,
                    CreateUser = "shopAdmin",
                    CreateDate = 1695285957713,
                    UpdateUser = null,
                    UpdateDate = null,
                    Remarks = null,
                    Language = null,
                    Number = "RecordOrderForCompositeItem",
                    Name = "組合產品訂單細項的項目紀錄",
                    IsEnable = true
                },
                new ShopPermission
                {
                    Id = 28,
                    CreateUser = "shopAdmin",
                    CreateDate = 1695285957713,
                    UpdateUser = null,
                    UpdateDate = null,
                    Remarks = null,
                    Language = null,
                    Number = "ShopCoupon",
                    Name = "商店優惠券",
                    IsEnable = true
                },
                new ShopPermission
                {
                    Id = 29,
                    CreateUser = "shopAdmin",
                    CreateDate = 1695285957713,
                    UpdateUser = null,
                    UpdateDate = null,
                    Remarks = null,
                    Language = null,
                    Number = "PaymentCategory",
                    Name = "付款類型",
                    IsEnable = true
                }
            };
        }

        /// <summary>
        /// 取得預設的清單
        /// </summary>
        /// <returns></returns>
        private static IList<MapRolePermission> GetDefaultMapRolePermissions()
        {
            return new List<MapRolePermission>
            {
                new MapRolePermission
                {
                    Id = 1,
                    CreateUser = "shopAdmin",
                    CreateDate = 1695285957713,
                    UpdateUser = null,
                    UpdateDate = null,
                    Remarks = null,
                    Language = null,
                    RoleId = 1,
                    PermissionId = (long)ShopPermissionType.ProductMaster,
                    IsCreatePermission = true,
                    IsReadPermission = true,
                    IsUpdatePermission = true,
                    IsDeletePermission = false
                },
                new MapRolePermission
                {
                    Id = 2,
                    CreateUser = "shopAdmin",
                    CreateDate = 1695285957713,
                    UpdateUser = null,
                    UpdateDate = null,
                    Remarks = null,
                    Language = null,
                    RoleId = 1,
                    PermissionId = (long)ShopPermissionType.ProductDetail,
                    IsCreatePermission = true,
                    IsReadPermission = true,
                    IsUpdatePermission = true,
                    IsDeletePermission = false
                },
                new MapRolePermission
                {
                    Id = 3,
                    CreateUser = "shopAdmin",
                    CreateDate = 1695285957713,
                    UpdateUser = null,
                    UpdateDate = null,
                    Remarks = null,
                    Language = null,
                    RoleId = 1,
                    PermissionId = (long)ShopPermissionType.CompositeProductMaster,
                    IsCreatePermission = true,
                    IsReadPermission = true,
                    IsUpdatePermission = true,
                    IsDeletePermission = false
                },
                new MapRolePermission
                {
                    Id = 4,
                    CreateUser = "shopAdmin",
                    CreateDate = 1695285957713,
                    UpdateUser = null,
                    UpdateDate = null,
                    Remarks = null,
                    Language = null,
                    RoleId = 1,
                    PermissionId = (long)ShopPermissionType.CompositeProductDetail,
                    IsCreatePermission = true,
                    IsReadPermission = true,
                    IsUpdatePermission = true,
                    IsDeletePermission = false
                },
                new MapRolePermission
                {
                    Id = 5,
                    CreateUser = "shopAdmin",
                    CreateDate = 1695285957713,
                    UpdateUser = null,
                    UpdateDate = null,
                    Remarks = null,
                    Language = null,
                    RoleId = 1,
                    PermissionId = (long)ShopPermissionType.CompositeProductItem,
                    IsCreatePermission = true,
                    IsReadPermission = true,
                    IsUpdatePermission = true,
                    IsDeletePermission = false
                },
                new MapRolePermission
                {
                    Id = 6,
                    CreateUser = "shopAdmin",
                    CreateDate = 1695285957713,
                    UpdateUser = null,
                    UpdateDate = null,
                    Remarks = null,
                    Language = null,
                    RoleId = 2,
                    PermissionId = (long)ShopPermissionType.ProductMaster,
                    IsCreatePermission = false,
                    IsReadPermission = true,
                    IsUpdatePermission = false,
                    IsDeletePermission = false
                },
                new MapRolePermission
                {
                    Id = 7,
                    CreateUser = "shopAdmin",
                    CreateDate = 1695285957713,
                    UpdateUser = null,
                    UpdateDate = null,
                    Remarks = null,
                    Language = null,
                    RoleId = 2,
                    PermissionId = (long)ShopPermissionType.ProductDetail,
                    IsCreatePermission = false,
                    IsReadPermission = true,
                    IsUpdatePermission = false,
                    IsDeletePermission = false
                },
                new MapRolePermission
                {
                    Id = 8,
                    CreateUser = "shopAdmin",
                    CreateDate = 1695285957713,
                    UpdateUser = null,
                    UpdateDate = null,
                    Remarks = null,
                    Language = null,
                    RoleId = 2,
                    PermissionId = (long)ShopPermissionType.CompositeProductMaster,
                    IsCreatePermission = false,
                    IsReadPermission = true,
                    IsUpdatePermission = false,
                    IsDeletePermission = false
                },
                new MapRolePermission
                {
                    Id = 9,
                    CreateUser = "shopAdmin",
                    CreateDate = 1695285957713,
                    UpdateUser = null,
                    UpdateDate = null,
                    Remarks = null,
                    Language = null,
                    RoleId = 2,
                    PermissionId = (long)ShopPermissionType.CompositeProductDetail,
                    IsCreatePermission = false,
                    IsReadPermission = true,
                    IsUpdatePermission = false,
                    IsDeletePermission = false
                },
                new MapRolePermission
                {
                    Id = 10,
                    CreateUser = "shopAdmin",
                    CreateDate = 1695285957713,
                    UpdateUser = null,
                    UpdateDate = null,
                    Remarks = null,
                    Language = null,
                    RoleId = 2,
                    PermissionId = (long)ShopPermissionType.CompositeProductItem,
                    IsCreatePermission = false,
                    IsReadPermission = true,
                    IsUpdatePermission = false,
                    IsDeletePermission = false
                }
            };
        }
    }
}
