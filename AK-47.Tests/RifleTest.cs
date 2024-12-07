namespace AK_47.Tests
{
    public class RifleTest
    {
        [Fact]
        public void ReloadWithOneBullet_BulletGoInChamber()
        {
            //Arrange
            Rifle rifle = new Rifle();
            Magazine magazine = new Magazine(1);
            magazine.AddAmmo(new Ammo());



            //Act
            rifle.ToggleSafety();
            rifle.AttachedMagazine(magazine);  
            rifle.Reload();

            //Assert
            Assert.True(rifle.HasBulletInChamber);
        }
        [Fact]
        public void ReloadWithOneBullet_ExtractedAmmo()
        {
            //Arrange
            Rifle rifle = new Rifle();
            Magazine magazine = new Magazine(1);
            magazine.AddAmmo(new Ammo());

            //Act
            rifle.ToggleSafety();
            rifle.AttachedMagazine(magazine);  
            rifle.Reload();

            //Assert
            Assert.Equal(0, magazine.GetAmmoCount());
        }
        [Fact]
        public void ShootWhenToggleSafetyTurnUp_NothingHappens ()
        {
            //Arrange
            Rifle rifle = new Rifle();
            Magazine magazine = new Magazine();
            magazine.AddAmmo(new Ammo());
            rifle.AttachedMagazine(magazine);


            //Act
            rifle.ToggleSafety();
            rifle.Reload();
            rifle.ToggleSafety();
            var exception = Assert.Throws<ArgumentException>(() => rifle.PullTrigger());

            //Assert
            Assert.Equal("Fuse is turned up",exception.Message);
        }
        [Fact]
        public void RifleWithAttachedMagazine_TryReload_ThrowException()
        {
            //Arrange
            Rifle rifle = new Rifle();
            Magazine magazine = new Magazine();

            //Act 
            rifle.AttachedMagazine(magazine);

            var exception = Assert.Throws<ArgumentException>(() => rifle.Reload());

            //Assert
            Assert.Equal("Check fuse", exception.Message);

        }
        [Fact]
        public void RifleWithAttachedMagazine_ButWithoutReload_TryShoot_ThrowException()
        {
            //Arrange
            Rifle rifle = new Rifle();
            Magazine magazine = new Magazine();
            magazine.AddAmmo(new Ammo());
            rifle.AttachedMagazine(magazine);
            rifle.ToggleSafety();

            //Act
            rifle.PullTrigger();

            //Assert
            Assert.Equal(0, rifle.ShotsFired);
        }
        [Fact]
        public void RifleTryShoot_Success()
        {
            //Arrange
            Rifle rifle = new Rifle();
            Magazine magazine = new Magazine();
            magazine.AddAmmo(new Ammo());
            rifle.AttachedMagazine(magazine);
            rifle.ToggleSafety();
            rifle.Reload();

            //Act
            rifle.PullTrigger();

            //Assert
            Assert.Equal(1, rifle.ShotsFired);
            
        }
    }
}
