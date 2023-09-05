namespace ColorNameTests
{
    public class RgbTests
    {
        [Test]
        public void WhiteColor()
        {
            var result = ColorNameProvider.GetColorNameFromRGB(255, 255, 255);
            Assert.That(result.exactMatch, Is.EqualTo(true));
            Assert.That(result.colorName, Is.EqualTo("White"));
        }

        [Test]
        public void BlackColor()
        {
            var result = ColorNameProvider.GetColorNameFromRGB(0, 0, 0);
            Assert.That(result.exactMatch, Is.EqualTo(true));
            Assert.That(result.colorName, Is.EqualTo("Black"));
        }

        [Test]
        public void CloseColor()
        {
            var result = ColorNameProvider.GetColorNameFromRGB(21, 42, 0);
            Assert.That(result.exactMatch, Is.EqualTo(false));
            Assert.That(result.colorName, Is.EqualTo("Deep Fir"));
        }

        [Test]
        public void CloseColor2()
        {
            var result = ColorNameProvider.GetColorNameFromRGB(55, 55, 210);
            Assert.That(result.exactMatch, Is.EqualTo(false));
            Assert.That(result.colorName, Is.EqualTo("Cerulean Blue"));
        }

        [Test]
        public void CloseColor3()
        {
            var result = ColorNameProvider.GetColorNameFromRGB(255, 255, 253);
            Assert.That(result.exactMatch, Is.EqualTo(false));
            Assert.That(result.colorName, Is.EqualTo("Black White"));
        }
    }
}