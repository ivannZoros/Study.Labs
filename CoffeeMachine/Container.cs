using System;

namespace CoffeeMachineLibrary
{
    public class Container
    {
        private const int MaxCapacity = 3000;
        private int _value;
        private int _capacity;
        public int Capacity  { get;}

        public int GetCapacity() => _capacity;
        public int GetValue() => _value;
        public Container(int capacity)
        {
            if (capacity <= 0 || capacity > MaxCapacity)
                throw new ArgumentException("Емкость меньше 0 или больше 3000");
            _capacity = capacity;
            Capacity = capacity;
            _value = 0;
        }
        public int LoadResource(int value)
        {
            if (value <= 0)
                throw new ArgumentException("Значение должно быть больше 0");

            if (_value + value > _capacity)
                throw new ArgumentException("Недостаточно места в контейнере");

            _value += value;
            return value;
        }
         public int GetResource(int value)
    {
        if (value < 0)
            throw new ArgumentException("Значение должно быть положительным");
            
        if (_value < value)
            throw new ArgumentException("Недостаточно ресурса");
            
        _value -= value;
        return value;
    }
        
        
    }
}
