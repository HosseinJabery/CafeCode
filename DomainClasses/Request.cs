using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainClasses
{
    public class Request
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RequestId { get; set; }

        [Required(ErrorMessage = "فیلد نام الزامی است")]
        [MaxLength(40)]
        [MinLength(3)]
        [Display (Name = "نام و نام خانوادگی")]
        public string Name { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9]+[-_\.!]*.*@.+\.[a-z]{2,4}$",ErrorMessage = "ایمیل وارد شده معتبر نمیباشد")]
        [Required(ErrorMessage = "فیلد ایمیل الزامی است")]
        [Display(Name = "ایمیل")]
        public string Email { get; set; }

        [MaxLength(11,ErrorMessage = "اعداد وارد شده بیشتر از حد استاندارد می باشد")]
        [Display(Name = "تلفن")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "فیلد موضوع الزامی است")]
        [MaxLength(80)]
        [Display(Name = "موضوع")]
        public string Subject { get; set; }

       

        [Required(ErrorMessage = "شرح موضوع الزامی است")]
        [Display(Name = "شرح درخواست")]
        public string Description { get; set; }
        [Display(Name = "مدت زمانی برای تحویل پروژه")]
        public string DeliveryDays { get; set; }

        [Display(Name = "کد رهگیری")]
        public string InterceptionCode { get; set; }

        [Display(Name = "فایل پیوستی")]
        public string UploadPath { get; set; }

        

        public string Price { get; set; }

        public bool? RequestStatus { get; set; }

        public string RejectReason { get; set; }

        public int? Progress { get; set; }

        public string DeadLine { get; set; }
    }
}
