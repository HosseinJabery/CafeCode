using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class AdminRequestViewModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RequestId { get; set; }
        public NewRequestViewModel RequestViewModel { get; set; }

        [Display(Name = "مبلغ پرداختی")]
        public string Price { get; set; }

        [Display(Name = "وضعیت درخواست")]
        public bool? RequestStatus { get; set; }


        [Display(Name = "دلیل رد درخواست")]
        public string RejectReason { get; set; }


        [Display(Name = "درصد پیشرفت پروژه")]
        public int?  Progress { get; set; }

        [Display(Name = "زمان تحویل پروژه")]
        public string DeadLine { get; set; }
       
    }
}
