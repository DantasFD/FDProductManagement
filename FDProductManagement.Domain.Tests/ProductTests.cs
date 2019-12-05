using FDProductManagement.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace FDProductManagement.Domain.Tests
{
    [TestClass]
    public class ProductTests
    {
        private readonly Brand _brand = new Brand("Teste");

        [TestMethod]
        [TestCategory("Patrimony - new Patrimony")]
        public void GivenAValidPatrimonyShouldCreateValidPatrimony()
        {
            var product = new Product("Patrominio 1", "Desc 1", _brand);

            Assert.IsTrue(product.Valid);
        }

        [TestMethod]
        [TestCategory("Patrimony - new Patrimony")]
        public void GivenAnInvalidNameShouldReturnANotification()
        {
            var product = new Product("", "Desc 1", _brand);

            Assert.IsFalse(product.Valid);
        }

        [TestMethod]
        [TestCategory("Patrimony - new Patrimony")]
        public void GivenAnInvalidDescritionShouldReturnANotification()
        {
            var product = new Product("Teste", "D", _brand);

            Assert.IsFalse(product.Valid);
        }
    }
}
