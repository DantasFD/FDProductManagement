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
        [TestCategory("Product - new Product")]
        public void GivenAValidProductShouldCreateValidProduct()
        {
            var product = new Product("Product 1", "Desc 1", _brand);

            Assert.IsTrue(product.Valid);
        }

        [TestMethod]
        [TestCategory("Product - new Product")]
        public void GivenAnInvalidNameShouldReturnANotification()
        {
            var product = new Product("", "Desc 1", _brand);

            Assert.IsFalse(product.Valid);
        }

        [TestMethod]
        [TestCategory("Product - new Product")]
        public void GivenAnInvalidDescritionShouldReturnANotification()
        {
            var product = new Product("Teste", "D", _brand);

            Assert.IsFalse(product.Valid);
        }
    }
}
