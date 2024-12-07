namespace AK_47.Tests
{
    public class MagazineTest
    {
        [Fact]
        public void ExtractAmmo_WhenEmpty_ReturnNull()
        {
            //Arrange
            var magazine = new Magazine();
            //act
            var result = magazine.ExtractAmmo();
            //Assert
            Assert.Null(result);

        }
        [Fact]
        public void AddAmmo_WhenEmpty_IncreaceCapacity()
        {
            //Arrange 
            var magazine = new Magazine();
            var ammo = new Ammo();
            //Act
            magazine.AddAmmo(ammo);
            var count = magazine.GetAmmoCount();
            //Assert
            Assert.Equal(1, count);
        }
        [Fact]
        public void ExtractAmmo_WhenPartlyFilledIn_DecreaseAmmo() {
            //Arrange
            var magazine = new Magazine(30);
            magazine.AddAmmo(new Ammo());
            magazine.AddAmmo(new Ammo());
            var initialCount = magazine.GetAmmoCount();
            
            //Act
            Ammo? extractedAmmo = magazine.ExtractAmmo();

            //Assert
            Assert.Equal(initialCount - 1, magazine.GetAmmoCount());

        }
        [Fact]
        public void AddAmmo_WhenFullAmmo_ThrowException()
        {
            //Arrange
            var magazine = new Magazine(1);
            magazine.AddAmmo(new Ammo());

            //Act + Assert
            Assert.Throws<ArgumentException>(() => magazine.AddAmmo(new Ammo()));

        }

        [Fact]
        public void NonEmptyMagazine_ExtractAmmo_MatchesFirstAdded()
        {
            // Arrange.
            var magazine = new Magazine();
            var sampleAmmo = new Ammo();

            for (var i = 0; i < 10; i++)
                magazine.AddAmmo(new Ammo());

            magazine.AddAmmo(sampleAmmo);

            // Act.
            var extractedAmmo = magazine.ExtractAmmo();

            // Assert.
            Assert.Equal(sampleAmmo, extractedAmmo);
        }

        [Fact]
        public void AddSameAmmo_Throws()
        {
            // Arrange.
            var magazine = new Magazine();
            var sampleAmmo = new Ammo();

            // Act + Assert.
            Assert.Throws<InvalidOperationException>(() =>
            {
                magazine.AddAmmo(sampleAmmo);
                magazine.AddAmmo(sampleAmmo);
            });
        }

    }
}