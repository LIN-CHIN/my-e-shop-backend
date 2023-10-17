using System.ComponentModel;

namespace EShopAPI.Common.Enums
{
    /// <summary>
    /// 商店權限類型
    /// </summary>
    /// <remarks>
    /// 當資料庫多一個table時就要來新增
    /// 即使不做權限控管
    /// </remarks>
    public enum ShopPermissionType
    {
        /// <summary>
        /// 商店使用者
        /// </summary>
        [Description("商店使用者商店使用者")]
        ShopUser = 1,

        /// <summary>
        /// 商店角色
        /// </summary>
        [Description("商店角色商店角色")]
        ShopRole = 2,

        /// <summary>
        /// 商店使用者與角色關係
        /// </summary>
        [Description("商店使用者與角色關係商店使用者與角色關係")]
        MapUserRole = 3,

        /// <summary>
        /// 商店權限
        /// </summary>
        [Description("商店權限商店權限")]
        ShopPermission = 4,

        /// <summary>
        /// 商店角色與權限關係
        /// </summary>
        [Description("商店角色與權限關係商店角色與權限關係")]
        MapRolePermission = 5,

        /// <summary>
        /// 產品主檔
        /// </summary>
        [Description("產品主檔產品主檔")]
        ProductMaster = 6,
        
        /// <summary>
        /// 產品細項
        /// </summary>
        [Description("產品細項產品細項")]
        ProductDetail = 7,
        
        /// <summary>
        /// 組合產品主檔
        /// </summary>
        [Description("組合產品主檔組合產品主檔")]
        CompositeProductMaster = 8,
        
        /// <summary>
        /// 組合產品細項
        /// </summary>
        [Description("組合產品細項組合產品細項")]
        CompositeProductDetail = 9,
        
        /// <summary>
        /// 組合產品細項的項目
        /// </summary>
        [Description("組合產品細項的項目組合產品細項的項目")]
        CompositeProductItem = 10,
        
        /// <summary>
        /// 商店庫存
        /// </summary>
        [Description("商店庫存商店庫存")]
        ShopInventory = 11,
        
        /// <summary>
        /// 商店單位
        /// </summary>
        [Description("商店單位商店單位")]
        EshopUnit = 12,
        
        /// <summary>
        /// 產品類型
        /// </summary>
        [Description("產品類型產品類型")]
        ProductCategory = 13,
        
        /// <summary>
        /// 產品與產品類型的關係
        /// </summary>
        [Description("產品與產品類型的關係產品與產品類型的關係")]
        MapProductCategory = 14,
        
        /// <summary>
        /// 物流類型
        /// </summary>
        [Description("物流類型物流類型")]
        DeliveryCategory = 15,
        
        /// <summary>
        /// 組合產品與物流的關係
        /// </summary>
        [Description("組合產品與物流的關係組合產品與物流的關係")]
        MapCompositeProductDelivery = 16,
        
        /// <summary>
        /// 產品與物流的關係
        /// </summary>
        [Description("產品與物流的關係產品與物流的關係")]
        MapProductDeliveryCategory = 17,
        
        /// <summary>
        /// 物流偏好
        /// </summary>
        [Description("物流偏好物流偏好")]
        DeliveryPreference = 18,
        
        /// <summary>
        /// 訂單主檔
        /// </summary>
        [Description("訂單主檔訂單主檔")]
        OrderMaster = 19,
        
        /// <summary>
        /// 產品訂單
        /// </summary>
        [Description("產品訂單產品訂單")]
        OrderForProduct = 20,
        
        /// <summary>
        /// 組合產品訂單細項
        /// </summary>
        [Description("組合產品訂單細項組合產品訂單細項")]
        OrderForCompositeDetail = 21,
        
        /// <summary>
        /// 組合產品訂單細項的項目
        /// </summary>
        [Description("組合產品訂單細項的項目組合產品訂單細項的項目")]
        OrderForCompositeItem = 22,
        
        /// <summary>
        /// 購物車
        /// </summary>
        [Description("購物車購物車")]
        ShopCart = 23,
        
        /// <summary>
        /// 訂單主檔紀錄
        /// </summary>
        [Description("訂單主檔紀錄訂單主檔紀錄")]
        RecordOrderMaster = 24,
        
        /// <summary>
        /// 產品訂單紀錄
        /// </summary>
        [Description("產品訂單紀錄產品訂單紀錄")]
        RecordOrderForProduct = 25,
        
        /// <summary>
        /// 組合產品訂單細項紀錄
        /// </summary>
        [Description("組合產品訂單細項紀錄組合產品訂單細項紀錄")]
        RecordOrderForCompositeDetail = 26,
        
        /// <summary>
        /// 組合產品訂單細項的項目紀錄
        /// </summary>
        [Description("組合產品訂單細項的項目紀錄組合產品訂單細項的項目紀錄")]
        RecordOrderForCompositeItem = 27,
        
        /// <summary>
        /// 商店優惠券
        /// </summary>
        [Description("商店優惠券商店優惠券")]
        ShopCoupon = 28,

        /// <summary>
        /// 付款類型
        /// </summary>
        [Description("付款類型付款類型")]
        PaymentCategory = 29,
    }
}
