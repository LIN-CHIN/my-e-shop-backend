using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopCores.Enums
{
    /// <summary>
    /// 產品實體類型
    /// </summary>
    public enum ProductEntityType
    {
        /// <summary>
        /// 產品
        /// </summary>
        [Description("產品")]
        Product = 1,

        /// <summary>
        /// 組合產品
        /// </summary>
        [Description("組合產品")]
        CompositeProduct = 2
    }
}
