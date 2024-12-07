namespace AK_47
{
    public class Rifle
    {
        private bool _bulletInChamber;
        private bool _SafeMode;
        private Magazine? _magazine;
        private int _shotsFired;
        public Rifle()
        {
            _SafeMode = true; 
            _shotsFired = 0;
            _bulletInChamber = false;
        }
        public void Reload()
        {
            Ammo? extractedAmmo = _magazine?.ExtractAmmo();
            if (extractedAmmo != null)
            {
                _bulletInChamber = true;
            }
            if(_SafeMode)
            {
                throw new ArgumentException("Check fuse");
            }
        }
        public void AttachedMagazine(Magazine magazine)
        {
            _magazine = magazine;
        }
        public void ToggleSafety()
        {
            _SafeMode = !_SafeMode;
        }
        public void PullTrigger()
        {
            if( _SafeMode == false)
            {
                _magazine?.ExtractAmmo();
            }
            else
            {
                throw new ArgumentException("Fuse is turned up");
            }
            if (_bulletInChamber)
            {
                _shotsFired++;
                _bulletInChamber = false;

            }
        }
        public bool HasBulletInChamber {  get { return _bulletInChamber; } } 
        public int ShotsFired { get { return _shotsFired; } }


    }
}
