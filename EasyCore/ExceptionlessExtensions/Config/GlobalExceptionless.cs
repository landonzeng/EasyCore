using Exceptionless;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyCore.ExceptionlessExtensions.Config
{
    public class GlobalExceptionless
    {
        /// <summary>
        /// 忽略404
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void OnSubmittingEvent(object sender, EventSubmittingEventArgs e)
        {
            // 忽略404错误
            if (e.Event.IsNotFound())
            {
                e.Cancel = true;
                return;
            }
        }
    }
}