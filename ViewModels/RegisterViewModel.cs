using System.ComponentModel.DataAnnotations;

namespace SWLoan.Models
{
    public class RegisterViewModel
    {
        /// <summary>
        /// 사용자 번호
        /// </summary>
        [Key]
        public int No { get; set; }

        /// <summary>
        /// 사용자 이름
        /// </summary>
        [Required(ErrorMessage = "이름을 입력해주세요.")]
        public string Name { get; set; }

        /// <summary>
        /// 사용자 ID
        /// </summary>
        [Required(ErrorMessage = "아이디를 입력해주세요.")]
        public string Id { get; set; }

        /// <summary>
        /// 사용자 비밀번호
        /// </summary>
        [Required(ErrorMessage = "비밀번호를 입력해주세요.")]
        [StringLength(20, ErrorMessage = "비밀번호는 최소 {2}, 최대 {1} 글자여야 합니다.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "비밀번호를 다시 입력해주세요.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "비밀번호가 일치하지 않습니다.")]
        public string ConfirmPassword { get; set; }
    }
}
