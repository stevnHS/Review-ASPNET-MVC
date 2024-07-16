//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Review_ASPNET_MVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class tEmployee
    {
        [DisplayName("員工編號")]
        [Required(ErrorMessage ="員工編號不可空白")]
        [StringLength(7, ErrorMessage ="員工編號必須是4-7個字元", MinimumLength=4)]
        public string fEmpId { get; set; }

        [DisplayName("姓名")]
        [Required(ErrorMessage = "姓名不可空白")]
        public string fName { get; set; }

        [DisplayName("性別")]
        public string fGender { get; set; }

        [DisplayName("信箱")]
        [EmailAddress(ErrorMessage ="E-Mail 格式有誤")]
        public string fMail { get; set; }

        [DisplayName("薪資")]
        [Range(23000, 65000, ErrorMessage ="薪資必須介於23000~65000")]
        public Nullable<int> fSalary { get; set; }

        [DisplayName("雇用日期")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> fEmploymentDate { get; set; }
    }
}
