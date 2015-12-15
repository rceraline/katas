using System;
using NUnit.Framework;

namespace LcdKata
{
    [TestFixture]
    public class Test
    {
        private Lcd _lcd;

        [SetUp]
        public void SetUp()
        {
            _lcd = new Lcd();
        }

        [Test]
        public void When_Input_Is_Not_A_Number_Throw_Exception()
        {
            Assert.Throws<NotSupportedException>(() => _lcd.Generate("test"));
        }

        [Test]
        public void When_Input_Is_0_Show_0()
        {
            var result = _lcd.Generate("0");
            var expected = string.Concat("._.", Environment.NewLine, "|.|", Environment.NewLine, "|_|");
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void When_Input_Is_1_Show_1()
        {
            var result = _lcd.Generate("1");
            var expected = string.Concat("...", Environment.NewLine, "..|", Environment.NewLine, "..|");
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void When_Input_Is_2_Show_2()
        {
            var result = _lcd.Generate("2");
            var expected = string.Concat("._.", Environment.NewLine, "._|", Environment.NewLine, "|_.");
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void When_Input_Is_3_Show_3()
        {
            var result = _lcd.Generate("3");
            var expected = string.Concat("._.", Environment.NewLine, "._|", Environment.NewLine, "._|");
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void When_Input_Is_4_Show_4()
        {
            var result = _lcd.Generate("4");
            var expected = string.Concat("...", Environment.NewLine, "|_|", Environment.NewLine, "..|");
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void When_Input_Is_5_Show_5()
        {
            var result = _lcd.Generate("5");
            var expected = string.Concat("._.", Environment.NewLine, "|_.", Environment.NewLine, "._|");
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void When_Input_Is_6_Show_6()
        {
            var result = _lcd.Generate("6");
            var expected = string.Concat("._.", Environment.NewLine, "|_.", Environment.NewLine, "|_|");
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void When_Input_Is_7_Show_7()
        {
            var result = _lcd.Generate("7");
            var expected = string.Concat("._.", Environment.NewLine, "..|", Environment.NewLine, "..|");
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void When_Input_Is_8_Show_8()
        {
            var result = _lcd.Generate("8");
            var expected = string.Concat("._.", Environment.NewLine, "|_|", Environment.NewLine, "|_|");
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void When_Input_Is_9_Show_9()
        {
            var result = _lcd.Generate("9");
            var expected = string.Concat("._.", Environment.NewLine, "|_|", Environment.NewLine, "..|");
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void When_Input_Is_10_Show_10()
        {
            var result = _lcd.Generate("10");
            var expected = string.Concat("... ._.", Environment.NewLine, "..| |.|", Environment.NewLine, "..| |_|");
            Assert.AreEqual(expected, result);
        }
    }
}
