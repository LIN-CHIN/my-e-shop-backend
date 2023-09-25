using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopCores.Enums
{
    /// <summary>
    /// 產品類型、組合產品類型
    /// </summary>
    public enum ProductType
    {
        /// <summary>
        /// 固定商品
        /// </summary>
        [Description("固定商品")]
        Fiexd = 1,

        /// <summary>
        /// 可變商品
        /// </summary>
        [Description("可變商品")]
        Variant = 2,

        /// <summary>
        /// 軟體
        /// </summary>
        [Description("軟體")]
        Software = 3,
    }
}
