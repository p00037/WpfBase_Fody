using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WpfBase.Infrastructure.Framework;

namespace WpfBase.Domain.Models.Accounts
{
    public partial class M_AccountEntity : EntityBase
    {      
        [Required(ErrorMessage = "ログインIDは必須です。")]
        [StringLength(20, ErrorMessage = "ログインIDの最大文字数は20です。")]
        public string LoginId { get; set; }

        [Required(ErrorMessage = "パスワードは必須です。")]
        [StringLength(20, ErrorMessage = "パスワードの最大文字数は20です。")]
        public string Password { get; set; }
    }
}
