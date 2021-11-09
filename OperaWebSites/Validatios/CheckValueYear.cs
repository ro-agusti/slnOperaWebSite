using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace OperaWebSites.Validatios
{
    public class CheckValueYear:ValidationAttribute 
    {
        //constructor
        public CheckValueYear()
        {
            ErrorMessage = "The earliest opera is Daphne, 1598, by Corsi, Peri, and Rinuccini";
        }
        //polimorfismo 
        public override bool IsValid(object value)
        {
            int year = (int) value;
            if (year < 1598)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}