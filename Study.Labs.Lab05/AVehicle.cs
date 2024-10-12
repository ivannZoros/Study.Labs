using System;

namespace Study.Labs.Lab05
{
    class AVehicle
    {
        public virtual int GetSpeed() {
            return 0;
        }
        public AVehicle(){
            Random rng = new Random();
            int rndplate = rng.Next(100, 1000);
            Plate = rndplate.ToString();

            var enumLengthColor = Enum.GetNames(typeof(VehicleColor)).Length;
            var randomElementColor = (VehicleColor)new Random().Next(enumLengthColor);
            Color = randomElementColor.ToString();

            var enumLengthBody = Enum.GetNames(typeof(VehicleBodyType)).Length;
            var randomElementBody = (VehicleBodyType)new Random().Next(enumLengthBody);
            BodyType = randomElementBody.ToString();

            int compare = rng.Next(2);
            if (compare == 1)
            {
                HasPassanger = true;
            } else 
            {
                HasPassanger = false;
             }

        }
        public string Plate { get; set; }
       
        public string Color { get; set; }
        
        public string BodyType { get; set; }
        public bool HasPassanger { get; set; }
    
        public enum VehicleColor { White,Black,Red,Blue,Brown}


        public enum VehicleBodyType { SportCar,Hatchback,Van,PickUpTruck}
    }





    class Car : AVehicle
    {
        public override int GetSpeed()
        {
            Random rng = new Random();
            int speed = rng.Next(90, 151);
            return speed;
        }
    }
    class Bus: AVehicle
    {
        public override int GetSpeed()
        {
            Random rng = new Random();
            int speed = rng.Next(80, 111);
            return speed;
        }
    }
    class Truck : AVehicle
    {
        public override int GetSpeed()
        {
            Random rng = new Random();
            int speed = rng.Next(70, 101);
            return speed;
        }
    }
}
