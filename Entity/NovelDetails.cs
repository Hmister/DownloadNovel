using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class NovelDetails
    {
        /// <summary>
        /// 小说的ID
        /// </summary>
        public string NovelId { get; set; }

        /// <summary>
        /// 小说地址
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 小说名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 小说作者
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// 封面图
        /// </summary>
        public string Cover { get; set; }

        /// <summary>
        /// 简介
        /// </summary>
        public string Introduction { get; set; }
    }
}
