using EShopAPI.Validations;
using EShopCores.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EshopTest.Cores.ValidationAttributes
{
    /// <summary>
    /// 測試Enum驗證屬性
    /// </summary>
    [TestFixture]
    public class EnumValidationAttributeTest
    {
        private static readonly object[] _productTypeErrorCases =
        {
            new object[]
            {
                (ProductType)100
            },
            new object[]
            {
                (ProductType)99
            },
            new object[]
            {
                (ProductType)500
            }
        };
        private static readonly object[] _productTypeSuccessCases =
        {
            new object[]
            {
                ProductType.Fiexd
            },
            new object[]
            {
                ProductType.Variant
            },
            new object[]
            {
                ProductType.Software
            }
        };

        /// <summary>
        /// 測試productType的 Enum驗證(失敗)
        /// </summary>
        /// <param name="productType">要測試的產品類型</param>
        /// <returns></returns>
        [TestCaseSource(nameof(_productTypeErrorCases))]
        public void TaskEnumValidationError(ProductType productType)
        {
            var validation = new EnumValidationAttribute();
            var result = validation.IsValid(productType);
            Assert.That(result, Is.False);
        }

        /// <summary>
        /// 測試productType的 Enum驗證(成功)
        /// </summary>
        /// <param name="productType">要測試的產品類型</param>
        /// <returns></returns>
        [TestCaseSource(nameof(_productTypeSuccessCases))]
        public void TaskEnumValidationSuccess(ProductType productType)
        {
            var validation = new EnumValidationAttribute();
            var result = validation.IsValid(productType);
            Assert.That(result, Is.True);
        }
    }
}
