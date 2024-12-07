namespace AK_47
{
    public class Magazine
    {
        private int _capacity;
        private List<Ammo> ammos = new();

        
        public Magazine(int capacity = 30) 
        { 
           this._capacity = capacity;
        }
        public Ammo? ExtractAmmo()
        {
            if(ammos.Count == 0)
            {
                return null;
            }
            Ammo ammo = ammos.Last();// [ammos.Count -1];
            ammos.Remove(ammo);//At(ammos.Count - 1);
            return ammo;
        }
        public void AddAmmo(Ammo ammo)
        {
            if(ammos.Count >= _capacity)
            {
                throw new ArgumentException("Magazine is full");
            }
            if(ammos.Contains(ammo))
            {
                throw new InvalidOperationException("This ammo is already loaded");
            }
            ammos.Add(ammo);
        }

        public int GetAmmoCount()
        {
            return ammos.Count;
        }
        

    }
}
