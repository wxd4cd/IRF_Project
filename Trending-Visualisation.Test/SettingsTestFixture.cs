using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Trending_Visualisation.Entities;

namespace Trending_Visualisation.Test
{
    class SettingsTestFixture
    {
        [
            Test,
            TestCase("abcd1234", 2, false),
            TestCase("123", 240, false),
            TestCase("2", 24, false),
            TestCase("3", 24, true),
        ]
        public void TestCheckPoint(string text, int rownum, bool expectedResult)
        {
            var settings = new Settings();
            var list = new List<string>();
            // Arrange
            var settingDialog = new SettingsForm(list, 0, settings);

            // Act
            bool actualResult = settingDialog.CheckPoint(text, rownum);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);

        }
        
    }
}
