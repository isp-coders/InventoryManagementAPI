using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace InventoryManagement.Utils.Helpers
{
    public static class EnumHelpers
    {
        public static List<EnumDto> ReturnEnumAsList<T>() where T : System.Enum
        {
            return ((T[])System.Enum.GetValues(typeof(T)))
                .Select(c => new EnumDto()
                {
                    Id = Convert.ToInt32(c),
                    Text = ToDisplayName(c),
                    Translate = $"ENUMS.{typeof(T).Name}.{ToDisplayName(c)}"
                }).ToList();
        }
        public static string ToDisplayName(this Enum value)
        {
            var attribute = value.GetAttribute<DisplayAttribute>();
            return attribute == null ? value.ToString() : attribute.Name;
        }
        public static T GetAttribute<T>(this Enum value) where T : Attribute
        {
            var type = value.GetType();
            var memberInfo = type.GetMember(value.ToString());
            var attributes = memberInfo[0].GetCustomAttributes(typeof(T), false);
            return (T)attributes.FirstOrDefault();
        }
    }
    public class EnumDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Translate { get; set; }
    }
}
