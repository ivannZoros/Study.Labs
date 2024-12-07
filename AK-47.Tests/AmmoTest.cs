namespace AK_47.Tests
{
    public class AmmoTest
    {
        [Fact]
        public void Use_WhenAlreadyUsed_ThrowException()
        {
            //Arrange
            var ammo = new Ammo();
            ammo.Use();
            //Act + Asserts
            Assert.Throws<ArgumentException> (() => ammo.Use());
        }
    }
}
