using FDProductManagement.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace FDProductManagement.Domain.Tests
{
    [TestClass]
    public class BrandTests
    {
        [TestMethod]
        [TestCategory("Brand - new Brand")]
        public void GivenAValidNameShouldCreateValidBrand()
        {
            var brand = new Brand("Brand 1");

            Assert.IsTrue(brand.Valid);
        }

        [TestMethod]
        [TestCategory("Brand - new Brand")]
        public void GivenAInvalidNameShouldReturnNotifications()
        {
            var brand = new Brand("");

            Assert.IsFalse(brand.Valid);
        }
    }
}
