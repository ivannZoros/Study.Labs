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
