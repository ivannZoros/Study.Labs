using System;

namespace CoffeeMachineLibrary
{
    public class Container
    {
        private const int MaxCapacity = 3000;
        private int _value;
        private int _capacity;
        public int Capacity  { get;}

        public int GetCapacity => _capacity;
        public int GetValue => _value;
        public Container(int capacity)
        {
            if (capacity <= 0 || capacity > MaxCapacity)
                throw new ArgumentException("Емкость меньше 0 или больше 3000");

            Capacity = capacity;
            _capacity = 0;
        }
        public int LoadResourse(int value)
        {
            if (value <= 0)
                throw new ArgumentException("Значение должно быть больше 0");

            if (_capacity + value > Capacity)
                throw new ArgumentException("Значение емкости больше 3000");

            _capacity += value;
            return value;
        }
        public int GetResourse(int value)
        {
            if (value <= 0)
                throw new ArgumentException("Значение должно быть больше 0");

            if (_capacity + value > Capacity)
                throw new ArgumentException("Значение емкости больше 3000");

            _capacity -= value;
            return value;
        }
        
        
    }
}
