//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//     Website: http://www.freesql.net
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;
using System.ComponentModel;

namespace WebApi.Module {

	[JsonObject(MemberSerialization.OptIn)]
	public class Tbiz_DepartmentInfo {

		[JsonProperty, Column(IsPrimary = true, IsIdentity = true)]
		public long Id { get; set; }

		/// <summary>
		/// 部门路径名称
		/// </summary>
		[JsonProperty, Column(DbType = "nvarchar(200)")]
		public string AllName { get; set; } = string.Empty;

		/// <summary>
		/// 部门类型
		/// </summary>
		[JsonProperty, Column(DbType = "nvarchar(50)")]
		public string AType { get; set; } = string.Empty;

		/// <summary>
		/// 批次号
		/// </summary>
		[JsonProperty, Column(DbType = "nvarchar(50)")]
		public string BatchNum { get; set; } = string.Empty;

		/// <summary>
		/// 业务子类
		/// </summary>
		[JsonProperty, Column(DbType = "nvarchar(50)")]
		public string CbusinessSub { get; set; } = string.Empty;

		/// <summary>
		/// 业务类型
		/// </summary>
		[JsonProperty, Column(DbType = "nvarchar(50)")]
		public string CbusinessType { get; set; } = string.Empty;

		/// <summary>
		/// 部门子类
		/// </summary>
		[JsonProperty, Column(DbType = "nvarchar(50)")]
		public string CdeptStype { get; set; } = string.Empty;

		/// <summary>
		/// 财务编码
		/// </summary>
		[JsonProperty, Column(DbType = "nvarchar(100)")]
		public string CfinanceCd { get; set; } = string.Empty;

		/// <summary>
		/// 编码
		/// </summary>
		[JsonProperty, Column(DbType = "nvarchar(50)")]
		public string Code { get; set; } = string.Empty;

		/// <summary>
		/// 公司id
		/// </summary>
		[JsonProperty, Column(DbType = "nvarchar(50)")]
		public string CompanyId { get; set; } = string.Empty;

		/// <summary>
		/// 实体店ID
		/// </summary>
		[JsonProperty, Column(DbType = "nvarchar(50)")]
		public string CphysiStore { get; set; } = string.Empty;

		/// <summary>
		/// 创建生效时间
		/// </summary>
		[JsonProperty]
		public DateTime? CreateDate { get; set; }

		/// <summary>
		/// 部门id
		/// </summary>
		[JsonProperty, Column(DbType = "nvarchar(50)")]
		public string DepartmentId { get; set; } = string.Empty;

		[JsonProperty, Column(DbType = "date")]
		public DateTime? Effdt { get; set; }

		/// <summary>
		/// 有效
		/// </summary>
		[JsonProperty, Column(DbType = "nvarchar(50)")]
		public string Enabled { get; set; } = string.Empty;

		/// <summary>
		/// 备注
		/// </summary>
		[JsonProperty, Column(DbType = "nvarchar(50)")]
		public string FullName { get; set; } = string.Empty;

		/// <summary>
		/// 部门负责人ID
		/// </summary>
		[JsonProperty, Column(DbType = "nvarchar(50)")]
		public string ManagerId { get; set; } = string.Empty;

		/// <summary>
		/// 部门负责人岗位
		/// </summary>
		[JsonProperty, Column(DbType = "nvarchar(50)")]
		public string ManagerPosn { get; set; } = string.Empty;

		[JsonProperty, Column(DbType = "date")]
		public DateTime? ModifyDate { get; set; }

		/// <summary>
		/// 集合id
		/// </summary>
		[JsonProperty, Column(DbType = "nvarchar(50)")]
		public string SetId { get; set; } = string.Empty;

		/// <summary>
		/// 简称
		/// </summary>
		[JsonProperty, Column(DbType = "nvarchar(50)")]
		public string ShortName { get; set; } = string.Empty;

	}

}
