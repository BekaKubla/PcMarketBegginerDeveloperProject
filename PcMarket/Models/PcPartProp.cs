using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace PcMarket.Models
{
    public class PcPartProp
    {
        public int ID { get; set; }
        [Required]
        [Display(Name ="ნივთის სახელი")]
        public string PartName { get; set; }
        [Required]
        [Display(Name ="მდგომარეობა")]
        public Condition PartCondition { get; set; }
        [Required]
        [Display(Name ="კატეგორია")]
        public Category PartCategory{ get; set; }
        [Required]
        [Display(Name ="ფასი")]
        public int PartPrice { get; set; }
        [Display(Name = "აღწერა")]
        [Required]
        [MaxLength(450)]
        public string PartDescribtion { get; set; }
        public string FileName { get; set; }

    }

    public enum Category
    {
         None,
        [Display(Name ="პროცესორები")]
        Cpu,
        [Display(Name ="დედაბარათები")]
        MotherBoard,
        [Display(Name ="ვიდეობარათები")]
        GPU,
        [Display(Name ="ვინჩესტერები HDD")]
        HDD,
        [Display(Name ="ვინჩესტერები SSD")]
        SSD,
        [Display(Name ="ვინჩესტერები SSD-M2")]
        M2,
        [Display(Name ="კვების ბლოკები")]
        PSU,
        [Display(Name ="მექსიერების მოდულები")]
        RAM,
        [Display(Name ="ქეისები")]
        Case,
        [Display(Name ="ქულერები")]
        Cooler,

    }
    public enum Condition
    {
        None,
        ახალი,
        მეორადი
    }
    public static class temp
    {

        public static string DisplayName(this Enum value)
        {
            Type enumType = value.GetType();
            var enumValue = Enum.GetName(enumType, value);
            MemberInfo member = enumType.GetMember(enumValue)[0];

            var attrs = member.GetCustomAttributes(typeof(DisplayAttribute), false);
            var outString = ((DisplayAttribute)attrs[0]).Name;

            if (((DisplayAttribute)attrs[0]).ResourceType != null)
            {
                outString = ((DisplayAttribute)attrs[0]).GetName();
            }

            return outString;
        }

    }
}
