using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace PcMarket.Models
{
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
    public class PcPartProp
    {
        public int ID { get; set; }
        [Required(ErrorMessage ="*** შეიყვანეთ სახელი")]
        [Display(Name ="ნივთის სახელი")]
        public string PartName { get; set; }
        [Required(ErrorMessage ="*** აირჩიეთ მდგომარეობა")]
        [Display(Name ="მდგომარეობა")]
        public Condition PartCondition { get; set; }
        [Required(ErrorMessage ="*** აირჩიეთ კატეგორია")]
        [Display(Name ="კატეგორია")]
        public Category PartCategory{ get; set; }
        [Range(0,100000,ErrorMessage ="გთხოვთ მიუთითეთ ფასი")]
        [Display(Name ="ფასი")]
        public string PartPrice { get; set; }
        public int PartPriceWithoutC2 { get; set; }
        [Display(Name = "აღწერა")]
        [Required(ErrorMessage ="*** აუცილებელია დაწერეთ ნივთის აღწერა")]
        [MaxLength(450)]
        public string PartDescribtion { get; set; }
        public string FileName { get; set; }
        [Display(Name = "ნივთის კატეგორია კატეგორია")]
        [Required]
        public PartOrBuild PartOrBuild { get; set; }

    }
    public enum PartOrBuild
    {
        [Display(Name ="აირჩიეთ კატეგორია")]
        Choose=0,
        ნაწილი=1,
        კომპიუტერი=2
    }

    public enum Category
    {
        [Display(Name ="აირჩიეთ კატეგორია")]
         None=0,
        [Display(Name ="პროცესორები")]
        Cpu=1,
        [Display(Name ="დედაბარათები")]
        MotherBoard=2,
        [Display(Name ="ვიდეობარათები")]
        GPU=3,
        [Display(Name ="ვინჩესტერები HDD")]
        HDD=4,
        [Display(Name ="ვინჩესტერები SSD")]
        SSD=5,
        [Display(Name ="ვინჩესტერები SSD-M2")]
        M2=6,
        [Display(Name ="კვების ბლოკები")]
        PSU=7,
        [Display(Name ="მეხსიერების მოდულები")]
        RAM=8,
        [Display(Name ="კეისები")]
        Case=9,
        [Display(Name ="ქულერები")]
        Cooler=10,

    }
    public enum Condition
    {
        [Display(Name ="აირჩიეთ მდგომარეობა")]
        None,
        ახალი,
        მეორადი
    }
}
