using System;
using NUnit.Framework;

namespace MineFields
{
    [TestFixture]
    public class MineFieldsTests
    {
        [Test]
        public void WhenInputIsNull_ResultIsNull()
        {
            var mineFields = MineFieldsBuilder.Build(null);
            Assert.IsNull(mineFields);
        }

        [Test]
        public void WhenInputIsEmpty_ResultIsEmpty()
        {
            var mineFields = MineFieldsBuilder.Build("");
            Assert.AreEqual("", mineFields);
        }

        [Test]
        public void WhenThereIs4NoMine_ResultIs4Zeros()
        {
            var mineFields = MineFieldsBuilder.Build("....");
            Assert.AreEqual("0000", mineFields);
        }

        [Test]
        public void WhenThereIs10NoMine_ResultIs10Zeros()
        {
            var mineFields = MineFieldsBuilder.Build("..........");
            Assert.AreEqual("0000000000", mineFields);
        }

        [Test]
        public void WhenThereIs4Mine_ResultIs4Mine()
        {
            var mineFields = MineFieldsBuilder.Build("****");
            Assert.AreEqual("****", mineFields);
        }

        [Test]
        public void WhenThereIs10Mine_ResultIs10Mines()
        {
            var mineFields = MineFieldsBuilder.Build("**********");
            Assert.AreEqual("**********", mineFields);
        }

        [Test]
        public void WhenThereIs2LinesOf4NoMine_ResultIs2LinesOf4Zeros()
        {
            var mineFields = MineFieldsBuilder.Build(CreateMultiLinesField("....", "...."));
            Assert.AreEqual(CreateMultiLinesField("0000", "0000"), mineFields);
        }

        [Test]
        public void WhenThereIs1LineOf4CharAndFirstCharIsAMine_ResultIsCorrect()
        {
            var mineFields = MineFieldsBuilder.Build("*...");
            Assert.AreEqual("*100", mineFields);
        }

        [Test]
        public void WhenThereIs1LineOf4CharAndLastCharIsAMine_ResultIsCorrect()
        {
            var mineFields = MineFieldsBuilder.Build("...*");
            Assert.AreEqual("001*", mineFields);
        }

        [Test]
        public void WhenThereIs2LineOf4CharAndFirstCharIsAMine_ResultIsCorrect()
        {
            var mineFields = MineFieldsBuilder.Build(CreateMultiLinesField("*...", "...."));
            Assert.AreEqual(CreateMultiLinesField("*100", "1100"), mineFields);
        }

        [Test]
        public void WhenThereIs2LineOf4CharAndSecondCharIsAMine_ResultIsCorrect()
        {
            var mineFields = MineFieldsBuilder.Build(CreateMultiLinesField(".*..", "...."));
            Assert.AreEqual(CreateMultiLinesField("1*10", "1110"), mineFields);
        }

        [Test]
        public void WhenThereIs3LineOf4CharAndSecondCharIsAMine_ResultIsCorrect()
        {
            var mineFields = MineFieldsBuilder.Build(CreateMultiLinesField(".*..", "....", "...."));
            Assert.AreEqual(CreateMultiLinesField("1*10", "1110", "0000"), mineFields);
        }

        [Test]
        public void WhenThereIs3LineOf4CharAndSecondLineCharIsAMine_ResultIsCorrect()
        {
            var mineFields = MineFieldsBuilder.Build(CreateMultiLinesField("....", ".*..", "...."));
            Assert.AreEqual(CreateMultiLinesField("1110", "1*10", "1110"), mineFields);
        }

        [Test]
        public void WhenThereIs1LineOf4CharAnd2CharIsAMine_ResultIsCorrect()
        {
            var mineFields = MineFieldsBuilder.Build(CreateMultiLinesField(".**."));
            Assert.AreEqual(CreateMultiLinesField("1**1"), mineFields);
        }

        [Test]
        public void WhenThereIs2LineOf4CharAndSecondCharIsAMineOn2Lines_ResultIsCorrect()
        {
            var mineFields = MineFieldsBuilder.Build(CreateMultiLinesField(".*..", ".*.."));
            Assert.AreEqual(CreateMultiLinesField("2*20", "2*20"), mineFields);
        }

        [Test]
        public void WhenThereIs3LineOf4CharAndSecondCharIsAMineOn2Lines_ResultIsCorrect()
        {
            var mineFields = MineFieldsBuilder.Build(CreateMultiLinesField("....", ".*..", ".*.."));
            Assert.AreEqual(CreateMultiLinesField("1110", "2*20", "2*20"), mineFields);
        }

        [Test]
        public void WhenThereIs2LineOf4CharAnd2Mines_ResultIsCorrect()
        {
            var mineFields = MineFieldsBuilder.Build(CreateMultiLinesField("...*", "**.."));
            Assert.AreEqual(CreateMultiLinesField("222*", "**21"), mineFields);
        }

        private static MineFieldsBuilder MineFieldsBuilder
        {
            get
            {
                var mineFieldsBuilder = new MineFieldsBuilder();
                return mineFieldsBuilder;
            }
        }

        private static string CreateMultiLinesField(params string[] lines)
        {
            return string.Join(Environment.NewLine, lines);
        }
    }
}
