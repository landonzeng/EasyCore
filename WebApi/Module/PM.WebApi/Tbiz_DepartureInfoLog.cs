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
	public class Tbiz_DepartureInfoLog {

		[JsonProperty, Column(IsPrimary = true, IsIdentity = true)]
		public long Id { get; set; }

		/// <summary>
		/// 批次号
		/// </summary>
		[JsonProperty, Column(DbType = "nvarchar(50)")]
		public string BatchNum { get; set; } = string.Empty;

		/// <summary>
		/// 流程状态
		/// </summary>
		[JsonProperty, Column(DbType = "nvarchar(50)")]
		public string CapproveStatus { get; set; } = string.Empty;

		[JsonProperty]
		public DateTime? CreateDate { get; set; }

		/// <summary>
		/// 员工ID
		/// </summary>
		[JsonProperty, Column(DbType = "nvarchar(50)")]
		public string EmployeeId { get; set; } = string.Empty;

		/// <summary>
		/// 离职状态
		/// </summary>
		[JsonProperty, Column(DbType = "nvarchar(50)")]
		public string IsDimission { get; set; } = string.Empty;

		/// <summary>
		/// 集合id
		/// </summary>
		[JsonProperty, Column(DbType = "nvarchar(50)")]
		public string Setid { get; set; } = string.Empty;

	}

}
