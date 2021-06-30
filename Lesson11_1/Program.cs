using System;

namespace Lesson11_1
{
    class NumberControl
    {
        public delegate void NumberControlHandler();
        public event NumberControlHandler NumberStatus;

        public int number;
        public int Number
        {
            get { return number; }
            set
            {
                number= value;
                if (number < 10)
                {
                    if (NumberStatus != null)
                    {
                        NumberStatus.Invoke();
                    }
                }
            }
        }
    }
    
    class Program
    {
        static void Control()
        {
            Console.WriteLine("Number 10-dan kicik ola bilmez");
        }
        
        static void Main(string[] args)
        {
            NumberControl numberControl = new NumberControl();
            numberControl.NumberStatus += Control;
            numberControl.Number = 5;
        }
    }
}