using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication4.Models
{
    public class Example
    {
        public int Number1 { get; set; }
        public int Number2 { get; set; }
        public string Operation { get; set; }
        public string Result { get; set; }

        public void Get_Result()
        {
            if (Operation == "+")
            {
                Result = "" + Number1 +" + "+ Number2 +" = "+ (Number1+Number2);
            }
            else if (Operation == "-")
            {
                Result = "" + Number1 + " - " + Number2 +" = " + (Number1 - Number2);
            }
            else if (Operation == "*")
            {
                Result = "" + Number1 + " * " + Number2 +" = " + (Number1 * Number2);
            }
            else if (Operation == "/"&&Number2!=0)
            {
                Result = "" + Number1 + " / " + Number2 +" = " + (Number1 / Number2);
            }
            else if (Operation == "/" && Number2 == 0)
            {
                Result = "Error: DIVISION BY ZERO";
            }

        }
    }
}
