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
	public class V_Effective_Tbiz_PositionLevel {

		[JsonProperty, Column(DbType = "nvarchar(50)")]
		public string BatchNum { get; set; } = string.Empty;

		[JsonProperty, Column(DbType = "nvarchar(50)")]
		public string CholdingRank { get; set; } = string.Empty;

		[JsonProperty, Column(DbType = "nvarchar(50)")]
		public string Code { get; set; } = string.Empty;

		[JsonProperty, Column(DbType = "nvarchar(50)")]
		public string CrankCode { get; set; } = string.Empty;

		[JsonProperty]
		public DateTime? CreateDate { get; set; }

		[JsonProperty, Column(DbType = "nvarchar(50)")]
		public string DescrShort { get; set; } = string.Empty;

		[JsonProperty, Column(DbType = "date")]
		public DateTime? Effdt { get; set; }

		[JsonProperty, Column(DbType = "nvarchar(50)")]
		public string Enabled { get; set; } = string.Empty;

		[JsonProperty, Column(DbType = "nvarchar(50)")]
		public string FullName { get; set; } = string.Empty;

		[JsonProperty]
		public long Id { get; set; }

		[JsonProperty, Column(DbType = "nvarchar(50)")]
		public string SetId { get; set; } = string.Empty;

	}

}
