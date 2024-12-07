using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AK_47
{
    public class Ammo
    {
        private bool isUsed;
        public void Use()
        {
            if (isUsed)
            {
                throw new ArgumentException("Ammo has already ben used");
            }
            isUsed = true;
        }
        
    }
}
