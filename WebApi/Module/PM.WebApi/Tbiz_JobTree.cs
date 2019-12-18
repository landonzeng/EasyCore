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
	public class Tbiz_JobTree {

		[JsonProperty, Column(IsPrimary = true, IsIdentity = true)]
		public long Id { get; set; }

		/// <summary>
		/// 批次号
		/// </summary>
		[JsonProperty, Column(DbType = "nvarchar(50)")]
		public string BatchNum { get; set; } = string.Empty;

		[JsonProperty]
		public DateTime? CreateDate { get; set; }

		/// <summary>
		/// 生效日期
		/// </summary>
		[JsonProperty, Column(DbType = "date")]
		public DateTime? Effdt { get; set; }

		/// <summary>
		/// 父部门ID
		/// </summary>
		[JsonProperty, Column(DbType = "nvarchar(50)")]
		public string ParentNodeName { get; set; } = string.Empty;

		/// <summary>
		/// 集合ID
		/// </summary>
		[JsonProperty, Column(DbType = "nvarchar(50)")]
		public string SetId { get; set; } = string.Empty;

		/// <summary>
		/// 树层级
		/// </summary>
		[JsonProperty, Column(DbType = "nvarchar(50)")]
		public string TreeLevelNum { get; set; } = string.Empty;

		/// <summary>
		/// 树名称
		/// </summary>
		[JsonProperty, Column(DbType = "nvarchar(50)")]
		public string TreeName { get; set; } = string.Empty;

		/// <summary>
		/// 部门ID
		/// </summary>
		[JsonProperty, Column(DbType = "nvarchar(50)")]
		public string TreeNode { get; set; } = string.Empty;

	}

}
