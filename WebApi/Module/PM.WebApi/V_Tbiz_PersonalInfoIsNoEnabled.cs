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
	public class V_Tbiz_PersonalInfoIsNoEnabled {

		[JsonProperty, Column(DbType = "nvarchar(50)")]
		public string AcctLock { get; set; } = string.Empty;

		[JsonProperty, Column(DbType = "nvarchar(50)")]
		public string BatchNum { get; set; } = string.Empty;

		[JsonProperty, Column(DbType = "nvarchar(50)")]
		public string Birthday { get; set; } = string.Empty;

		[JsonProperty, Column(DbType = "nvarchar(500)")]
		public string CaddressHome { get; set; } = string.Empty;

		[JsonProperty, Column(DbType = "nvarchar(500)")]
		public string CaddressNid { get; set; } = string.Empty;

		[JsonProperty, Column(DbType = "nvarchar(50)")]
		public string CapproveStatus { get; set; } = string.Empty;

		[JsonProperty, Column(DbType = "varchar(6)")]
		public string CapproveStatusName { get; set; } = string.Empty;

		[JsonProperty, Column(DbType = "nvarchar(50)")]
		public string CcompEmail { get; set; } = string.Empty;

		[JsonProperty, Column(DbType = "nvarchar(50)")]
		public string CompanyId { get; set; } = string.Empty;

		[JsonProperty, Column(DbType = "nvarchar(120)")]
		public string CountryNmForm { get; set; } = string.Empty;

		[JsonProperty]
		public DateTime? CreateDate { get; set; }

		[JsonProperty, Column(DbType = "nvarchar(50)")]
		public string Email { get; set; } = string.Empty;

		[JsonProperty, Column(DbType = "varchar(1)")]
		public string Enabled { get; set; } = string.Empty;

		[JsonProperty, Column(DbType = "nvarchar(50)")]
		public string Gender { get; set; } = string.Empty;

		[JsonProperty, Column(DbType = "nvarchar(50)")]
		public string HighestEducLvl { get; set; } = string.Empty;

		[JsonProperty]
		public long Id { get; set; }

		[JsonProperty, Column(DbType = "nvarchar(50)")]
		public string IsDimission { get; set; } = string.Empty;

		[JsonProperty, Column(DbType = "varchar(12)")]
		public string IsDimissionName { get; set; } = string.Empty;

		[JsonProperty, Column(DbType = "nvarchar(50)")]
		public string MarStatus { get; set; } = string.Empty;

		[JsonProperty, Column(DbType = "nvarchar(50)")]
		public string MarStatusDt { get; set; } = string.Empty;

		[JsonProperty, Column(DbType = "nvarchar(50)")]
		public string Mobile { get; set; } = string.Empty;

		[JsonProperty, Column(DbType = "nvarchar(50)")]
		public string NationalId { get; set; } = string.Empty;

		[JsonProperty, Column(DbType = "nvarchar(50)")]
		public string Operator { get; set; } = string.Empty;

		[JsonProperty, Column(DbType = "nvarchar(120)")]
		public string RealName { get; set; } = string.Empty;

		[JsonProperty, Column(DbType = "nvarchar(50)")]
		public string SetId { get; set; } = string.Empty;

		[JsonProperty, Column(DbType = "nvarchar(50)")]
		public string Telephone { get; set; } = string.Empty;

		[JsonProperty, Column(DbType = "nvarchar(50)")]
		public string UserId { get; set; } = string.Empty;

	}

}
