using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Raaj.CarPark.Entities
{
    public class Vehicle
    {
        protected StringBuilder stringBuilder = new StringBuilder();
        public int Id { get; set; }
        public float Weight { get; set; }
        public int OutstandingFee { get; set; }
        public bool IsFeePaid 
        {
            get 
            {
                return OutstandingFee == 0;
            }
        }

        public Vehicle()
        {
            // All vehicles have a fee for parking in the car park. This vehicle fee is $2
            OutstandingFee = 2;
        }

        public void PayFee()
        {
            OutstandingFee = 0;
        }

        public override string ToString()
        {
            stringBuilder.Clear();
            return stringBuilder
                .Append(Id)
                .Append(" -- ")
                .Append(Weight)
                .Append(" kg -- ")
                .Append(OutstandingFee)
                .Append(" $ -- ")
                .ToString();
        }
    }
}
