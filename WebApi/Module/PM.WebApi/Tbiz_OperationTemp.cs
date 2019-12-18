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
	public class Tbiz_OperationTemp {

		/// <summary>
		/// 创建时间
		/// </summary>
		[JsonProperty]
		public DateTime? CreateDate { get; set; }

		/// <summary>
		/// 员工ID/部门ID
		/// </summary>
		[JsonProperty, Column(DbType = "varchar(50)")]
		public string ObjectId { get; set; } = string.Empty;

		/// <summary>
		/// 操作(0更新、1插入)
		/// </summary>
		[JsonProperty]
		public int? Operation { get; set; }

		/// <summary>
		/// 处理优先级，越小优先级越大
		/// </summary>
		[JsonProperty]
		public int? OrderByNum { get; set; }

		/// <summary>
		/// 类型(0部门、1员工)
		/// </summary>
		[JsonProperty]
		public int? Type { get; set; }

	}

}
