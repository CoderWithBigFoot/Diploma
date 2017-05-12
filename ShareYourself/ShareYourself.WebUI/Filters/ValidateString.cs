using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ShareYourself.WebUI.Filters
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ValidateString : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var casted = value as string;
            if(casted == null)
            {
                return false;
            }

            if(casted.Length == 0)
            {
                return false;
            }

            char[] separators = new char[]
           {
                ',', '.', '/', '*', '-', '+', '!', '@', '#', '№', '$', '%', '^', '&', '(', ')', ':', ';', ' ',
                '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', '{', '}', '[', ']'
           };

            foreach(var current in casted)
            {
                if (separators.Contains(current))
                {
                    return false;
                }
            }

            return true;
        }
    }
}