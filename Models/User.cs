using System.ComponentModel.DataAnnotations;

namespace SWLoan.Models
{
    public class User
    {
        /// <summary>
        /// 사용자 번호
        /// </summary>
        [Key]
        public int No { get; set; }

        /// <summary>
        /// 사용자 이름
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// 사용자 ID
        /// </summary>
        [Required]
        public string Id { get; set; }

        /// <summary>
        /// 사용자 비밀번호
        /// </summary>
        [Required]
        public string Password { get; set; }
    }
}
