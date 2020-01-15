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
    public class FreeSqlConfig
    {
        /// <summary>
        /// 数据库名称
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// 主库
        /// </summary>
        public string MasterConnetion { get; set; }

        /// <summary>
        /// 从库链接
        /// </summary>
        public List<SlaveConnection> SlaveConnections { get; set; } = new List<SlaveConnection>();

        /// <summary>
        /// 数据库类型
        /// </summary>
        public DataType DataType { get; set; }

        /// <summary>
        /// 显示sql语句
        /// </summary>
        public bool DebugShowSql { get; set; } = true;

        /// <summary>
        /// 显示sql语句中传递参数
        /// </summary>
        public bool DebugShowSqlPparameters { get; set; } = false;

        /// <summary>
        ///是否同步结构
        /// </summary>
        public bool IsSyncStructure { get; set; } = false;

        /// <summary>
        /// Command超时时间(秒)
        /// </summary>
        public int CommandTimeout { get; set; } = 30;
    }

    /// <summary>
    /// SQL日志配置
    /// </summary>
    public class SqlLogs
    {
        public bool IsShowLog { get; set; }
        public LogLevel ShowLevel { get; set; }
    }

    /// <summary>
    /// 日志级别枚举
    /// </summary>
    public enum LogLevel
    {
        Debug, Info, Trace, Error, Warnging
    }

    /// <summary>
    /// 从库链接
    /// </summary>
    public class SlaveConnection
    {
        public string ConnectionString { get; set; }
    }
}