using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AK_47
{
    public class Magazine
    {
        private int _capacity;
        private List<Ammo> ammos = new();

        public int GetCapacity() => _capacity;

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
            Ammo ammo = ammos[0];
            ammos.RemoveAt(0);
            return ammo;
        }
        public void AddAmmo(Ammo ammo)
        {
            if(ammos.Count >= _capacity)
            {
                throw new ArgumentException("Magazine is full");
            }
            ammos.Add(ammo);
        }
        public void RemoveAmmo(int amount)
        {
            
            if(ammos.Count == 0)
            {
                throw new ArgumentException("Magazine is empty");
            }
            if (amount <= 0)
            {
                throw new ArgumentException("Amount must be positive");
            }
            ammos.RemoveAt(0);
            
        }
        public int GetAmmoCount()
        {
            return ammos.Count;
        }
        

    }
}
