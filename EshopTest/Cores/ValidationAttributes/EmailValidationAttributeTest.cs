using EShopAPI.Validations;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EshopTest.Cores.ValidationAttributes
{
    /// <summary>
    /// 測試信箱驗證屬性
    /// </summary>
    [TestFixture]
    public class EmailValidationAttributeTest
    {
        private static readonly object[] _emailErrorCases =
        {
            new object[]
            {
                "abc@gm ail.com"
            },
            new object[]
            {
                "chin.com"
            },
            new object[]
            {
                "chin!$%@gg.com"
            },
            new object[]
            {
                "chin.com@gmail"
            },
            new object[]
            {
                "chin.com@gmail.comsa"
            }
        };

        private static readonly object[] _emailSuccessCases =
        {
            new object[]
            {
                "chin@gmail.com"
            },
            new object[]
            {
                "chin.test@gmail.com"
            },
            new object[]
            {
                "chin-test@gmail.com"
            },
            new object[]
            {
                "chin-test@gmail.co-m"
            }
        };

        /// <summary>
        /// Setup 
        /// </summary>
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// 測試Email驗證(失敗)
        /// </summary>
        /// <param name="email">要測試的email</param>
        /// <returns></returns>
        [TestCaseSource(nameof(_emailErrorCases))]
        public void TaskInsertDtoNumberValidationError(string email)
        {
            var validation = new EmailValidationAttribute();
            var result = validation.IsValid(email);
            Assert.That(result, Is.False);
        }

        /// <summary>
        /// 測試Email驗證(成功)
        /// </summary>
        /// <param name="email">要測試的email</param>
        /// <returns></returns>
        [TestCaseSource(nameof(_emailSuccessCases))]
        public void TaskInsertDtoNumberValidationSuccess(string email)
        {
            var validation = new EmailValidationAttribute();
            var result = validation.IsValid(email);
            Assert.That(result, Is.True);
        }
    }
}
