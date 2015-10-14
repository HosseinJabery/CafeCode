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
        public string Price { get; set; }
        public bool? RequestStatus { get; set; }
        public string RejectReason { get; set; }
        public int?  Progress { get; set; }
        public string DeadLine { get; set; }
       
    }
}
