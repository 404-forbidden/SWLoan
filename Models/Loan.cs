using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SWLoan.Models
{
    public class Loan
    {
        /// <summary>
        /// 신청 번호
        /// </summary>
        [Key]
        public int No { get; set; }

        /// <summary>
        /// 신청 금액
        /// </summary>
        [Required(ErrorMessage = "금액을 입력하세요.")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public int? Cost { get; set; }

        /// <summary>
        /// 계좌번호
        /// </summary>
        [Required(ErrorMessage = "계좌번호(토스는 휴대폰 번호)를 입력하세요.")]
        public int? AccountNo { get; set; }

        /// <summary>
        /// 대출금 받을 곳 
        /// </summary>
        [Required(ErrorMessage = "은행을 선택하세요.")]
        public string? Bank { get; set; }

        /// <summary>
        /// 신청일
        /// </summary>
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd-hh-mm-ss}", ApplyFormatInEditMode = true)]
        public DateTime LoanDate { get; set; }

        /// <summary>
        /// 상환일
        /// </summary>
        [Required(ErrorMessage = "상환일을 입력하세요.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? RepaymentDate { get; set; }

        /// <summary>
        /// 신청자 번호
        /// </summary>
        [Required]
        public int UserNo { get; set; }

        /// <summary>
        /// 신청자 이름
        /// </summary>
        [Required]
        public string UserName { get; set; }
    }
}
