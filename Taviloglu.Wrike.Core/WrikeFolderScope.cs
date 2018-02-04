using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taviloglu.Wrike.Core
{
    public enum WrikeFolderScope
    {
        /// <summary>
        ///   Virtual root folder of account
        /// </summary>
        WsRoot,
        /// <summary>
        ///   Virtual Recycle Bin folder of account
        /// </summary>
        RbRoot,
        /// <summary>
        ///     Folder in account
        /// </summary>
        WsFolder,
        /// <summary>
        ///     Folder is in Recycle Bin (deleted folder)
        /// </summary>
        RbFolder,
        /// <summary>
        ///   Task in account
        /// </summary>
        WsTask,
        /// <summary>
        /// Task is in Recycle Bin (deleted task)
        /// </summary>
        RbTask
    }
}
