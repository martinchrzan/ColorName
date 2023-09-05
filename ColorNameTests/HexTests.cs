
namespace ColorNameTests
{
    public class HexTests
    {
        [Test]
        public void WhiteColorFullWithHash()
        {
            var result = ColorNameProvider.GetColorNameFromHex("#FFFFFF");
            Assert.That(result.exactMatch, Is.EqualTo(true));
            Assert.That(result.colorName, Is.EqualTo("White"));
        }

        [Test]
        public void WhiteColorFullWithoutHash()
        {
            var result = ColorNameProvider.GetColorNameFromHex("FFFFFF");
            Assert.That(result.exactMatch, Is.EqualTo(true));
            Assert.That(result.colorName, Is.EqualTo("White"));
        }

        [Test]
        public void WhiteColorShortWithHash()
        {
            var result = ColorNameProvider.GetColorNameFromHex("#FFF");
            Assert.That(result.exactMatch, Is.EqualTo(true));
            Assert.That(result.colorName, Is.EqualTo("White"));
        }

        [Test]
        public void WhiteColorShortWithoutHash()
        {
            var result = ColorNameProvider.GetColorNameFromHex("FFF");
            Assert.That(result.exactMatch, Is.EqualTo(true));
            Assert.That(result.colorName, Is.EqualTo("White"));
        }


        [Test]
        public void CloseColorWhite()
        {
            var result = ColorNameProvider.GetColorNameFromHex("FFFFFE");
            Assert.That(result.exactMatch, Is.EqualTo(false));
            Assert.That(result.colorName, Is.EqualTo("Black White"));
        }

        [Test]
        public void CloseColor()
        {
            var result = ColorNameProvider.GetColorNameFromHex("41AD82");
            Assert.That(result.exactMatch, Is.EqualTo(false));
            Assert.That(result.colorName, Is.EqualTo("Ocean Green"));
        }


        [Test]
        public void InvalidColor()
        {
            var result = ColorNameProvider.GetColorNameFromHex("GGG");
            Assert.That(result.exactMatch, Is.EqualTo(false));
            Assert.That(result.colorName, Is.EqualTo(ColorNameProvider.InvalidColor));
        }

        [Test]
        public void InvalidColor2()
        {
            var result = ColorNameProvider.GetColorNameFromHex("FFFFFFF");
            Assert.That(result.exactMatch, Is.EqualTo(false));
            Assert.That(result.colorName, Is.EqualTo(ColorNameProvider.InvalidColor));
        }

        [Test]
        public void InvalidColor3()
        {
            var result = ColorNameProvider.GetColorNameFromHex("12345G");
            Assert.That(result.exactMatch, Is.EqualTo(false));
            Assert.That(result.colorName, Is.EqualTo(ColorNameProvider.InvalidColor));
        }

        [Test]
        public void InvalidColor4()
        {
            var result = ColorNameProvider.GetColorNameFromHex("FG GA");
            Assert.That(result.exactMatch, Is.EqualTo(false));
            Assert.That(result.colorName, Is.EqualTo(ColorNameProvider.InvalidColor));
        }

        [Test]
        public void InvalidColor5()
        {
            var result = ColorNameProvider.GetColorNameFromHex("  ");
            Assert.That(result.exactMatch, Is.EqualTo(false));
            Assert.That(result.colorName, Is.EqualTo(ColorNameProvider.InvalidColor));
        }

        [Test]
        public void InvalidColor6()
        {
            var result = ColorNameProvider.GetColorNameFromHex("!FFF");
            Assert.That(result.exactMatch, Is.EqualTo(false));
            Assert.That(result.colorName, Is.EqualTo(ColorNameProvider.InvalidColor));
        }

        [Test]
        public void InvalidColor7()
        {
            var result = ColorNameProvider.GetColorNameFromHex("-153");
            Assert.That(result.exactMatch, Is.EqualTo(false));
            Assert.That(result.colorName, Is.EqualTo(ColorNameProvider.InvalidColor));
        }


    }
}