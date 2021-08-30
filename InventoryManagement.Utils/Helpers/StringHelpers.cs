using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Utils.Helpers
{
    public static class StringHelpers
    {

        public static string ReplaceTurkishCharacter(this string stringValue)
        {
            var source = "ığüşöçäĞÜŞİÖÇ";
            var destination = "igusocaGUSIOC";
            for (var i = 0; i < source.Length; i++)
            {
                stringValue = stringValue.Replace(source[i], destination[i]);
            }
            return stringValue;
        }
    }
}
