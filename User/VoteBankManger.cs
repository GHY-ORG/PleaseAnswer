using Hub;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.cn.edu.swufe.oam;

namespace User
{
    /// <summary>
    /// 投票处理类
    /// </summary>
    public class VoteBankManger
    {
        /// <summary>
        /// 验证学号
        /// </summary>
        /// <param name="stunumber">学号</param>
        /// <param name="password">上网密码</param>
        /// <returns>1成功 0失败</returns>
        public int ValidStuNumber(string stunumber, string password)
        {
            using (getUserAuthWSDL client = new getUserAuthWSDL())
            {
                client.Credentials = new System.Net.NetworkCredential("userauth", "oamswufe123");
                if ("1".Equals(client.userAuth(stunumber, password)))
                    return 1;
                else return 0;
            }
        }

        /// <summary>
        /// 从数据库中获取当日Vote
        /// </summary>
        /// <param name="voterNum">投票人学号</param>
        /// <returns></returns>
        public List<Hub.VoteBank> GetVoteByDB(int voterNum)
        {
            using (var db = new StandingEntities())
            {
                var votes = from o in db.VoteBank
                            where o.VoterNum.Equals(voterNum) && o.VoteTime.Equals(DateTime.Now.Date)
                            select o;
                return votes.ToList();
            }
        }

        /// <summary>
        /// 数据库中插入Vote
        /// </summary>
        /// <param name="voterNum">投票人学号</param>
        /// <param name="playerID">被投票选手ID</param>
        /// <returns>影响行数</returns>
        public int InsertVoteToDB(int voterNum,int playerID)
        {
            Hub.VoteBank one = new VoteBank
            {
                VoterNum = voterNum,
                PlayerID = playerID,
                VoteTime = DateTime.Now.Date
            };
            using (var db = new StandingEntities())
            {
                db.VoteBank.Add(one);
                return db.SaveChanges();
            }
        }

    }
}
