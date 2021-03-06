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
	public class Tbiz_Cascadedata {

		[JsonProperty, Column(IsPrimary = true, IsIdentity = true)]
		public long Id { get; set; }

		/// <summary>
		/// 批次号
		/// </summary>
		[JsonProperty, Column(DbType = "nvarchar(50)")]
		public string BatchNum { get; set; } = string.Empty;

		/// <summary>
		/// 对象分类
		/// </summary>
		[JsonProperty, Column(DbType = "nvarchar(50)")]
		public string Category { get; set; } = string.Empty;

		/// <summary>
		/// 部门编码
		/// </summary>
		[JsonProperty, Column(DbType = "nvarchar(50)")]
		public string CdeptIdType { get; set; } = string.Empty;

		/// <summary>
		/// 父值描述
		/// </summary>
		[JsonProperty, Column(DbType = "nvarchar(50)")]
		public string CfatherDescr { get; set; } = string.Empty;

		/// <summary>
		/// 父值
		/// </summary>
		[JsonProperty, Column(DbType = "nvarchar(50)")]
		public string CfatherVal { get; set; } = string.Empty;

		[JsonProperty]
		public DateTime? CreateDate { get; set; }

		/// <summary>
		/// 子值描述
		/// </summary>
		[JsonProperty, Column(DbType = "nvarchar(50)")]
		public string CsonDescr { get; set; } = string.Empty;

		/// <summary>
		/// 子值
		/// </summary>
		[JsonProperty, Column(DbType = "nvarchar(50)")]
		public string CsonVal { get; set; } = string.Empty;

		/// <summary>
		/// 部门类型描述
		/// </summary>
		[JsonProperty, Column(DbType = "nvarchar(50)")]
		public string Descr4 { get; set; } = string.Empty;

		/// <summary>
		/// 集合id
		/// </summary>
		[JsonProperty, Column(DbType = "nvarchar(50)")]
		public string SetId { get; set; } = string.Empty;

	}

}
