using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User
{
   /// <summary>
   /// 题库处理类
   /// </summary>
    public class QuesBankManager
    {
        // 试卷题目数量
        private const int QUES_NUM = 15;

        #region 随机获取题目
        public List<Hub.QuesBank> getRandomQuess()
        {
            using (var db = new Hub.StandingEntities()) {
                var quess = (from o in db.QuesBank orderby Guid.NewGuid() select o).Take(QUES_NUM);
                return quess.ToList();
            }
        }
        #endregion
    }
}
