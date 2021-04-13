using FreeSql.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.Module
{
    /// <summary>
    /// 核验结果
    /// </summary>
    public class VerifyApplyResultDto
    {
        /// <summary>
        /// V+房源编号
        /// </summary>
        public string HouseId { get; set; }

        /// <summary>
        /// 产证编号
        /// </summary>
        public string CertificateNumber { get; set; }

        /// <summary>
        /// 产证对应的二维码图片
        /// </summary>
        public string VerifyApplyResultImage { get; set; }

        /// <summary>
        /// 核验编号
        /// </summary>
        public string VerifyApplyNumber { get; set; }

        /// <summary>
        /// 核验状态
        /// </summary>
        public string ProcessStatus { get; set; }

        /// <summary>
        /// 理由
        /// </summary>
        public string Reason { get; set; }

        /// <summary>
        /// 核验时间
        /// </summary>
        public DateTime? VerificationTime { get; set; }

        /// <summary>
        /// 二维码Url
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// V+待备案主键
        /// </summary>
        public string Reg_Id { get; set; }
    }
}