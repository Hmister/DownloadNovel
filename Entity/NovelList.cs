using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class NovelList
    {
        public int Id { get; set; }

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
        /// 最后章节
        /// </summary>
        public string LastChapter { get; set; }

        /// <summary>
        /// 小说作者
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// 封面图
        /// </summary>
        public string Cover { get; set; }

        /// <summary>
        /// 更新状态
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public string UpdateTime { get; set; }

        /// <summary>
        /// 字数
        /// </summary>
        public string Number { get; set; }

       
        
    }
}
