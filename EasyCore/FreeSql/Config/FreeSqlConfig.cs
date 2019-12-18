using System;
using System.Collections.Generic;
using System.Text;
using FreeSql;
using Microsoft.Extensions.Options;

//using Microsoft.Extensions.Options;

namespace EasyCore.FreeSql.Config
{
    public class FreeSqlCollectionConfig : IOptions<FreeSqlCollectionConfig>
    {
        public List<FreeSqlConfig> FreeSqlCollections { get; set; }
        public FreeSqlCollectionConfig Value => this;
    }

    /// <summary>
    /// FreeSql配置类
    /// </summary>
    public class FreeSqlConfig : IOptions<FreeSqlConfig>
    {
        /// <summary>
        /// 数据库名称
        /// </summary>
        public string DataTableName { get; set; }
        /// <summary>
        /// 主库
        /// </summary>
        public string MasterConnetion { get; set; }
        /// <summary>
        /// 从库链接
        /// </summary>
        public List<SlaveConnection> SlaveConnections { get; set; }
        /// <summary>
        /// 数据库类型
        /// </summary>
        public DataType DataType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsSyncStructure { get; set; } = false;
        /// <summary>
        /// 
        /// </summary>
        public FreeSqlConfig Value => this;
    }
    /// <summary>
    /// 从库链接
    /// </summary>
    public class SlaveConnection
    {
        public string ConnectionString { get; set; }
    }

}
