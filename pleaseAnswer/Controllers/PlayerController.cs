using pleaseAnswer.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using User;

namespace pleaseAnswer.Controllers
{
    public class PlayerController : Controller
    {

        #region 选手展示页面
        // GET: Player
        public ActionResult Index()
        {
            List<PlayerModel> PlayerModel = new List<PlayerModel>();
            // 获取
            PlayerBankManager playerBankManager = new PlayerBankManager();
            List<Hub.PlayerBank> players = playerBankManager.getPlayers();
            foreach (var playerItem in players)
            {
                string[] arrStr = playerItem.Pic.Split('/');
                Console.WriteLine(arrStr[2]);
                PlayerModel.Add(new Models.PlayerModel()
                {
                    ID = playerItem.ID,
                    Pic = arrStr[2],
                    Name = playerItem.Name,
                    School = playerItem.School,
                    Motto = playerItem.Motto,
                    Vote = playerItem.Vote,
                });
            }
            Session["playerList"] = PlayerModel;
            return View(PlayerModel);
        }
        #endregion

        #region 投票
        // POST: Player
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(int playerID)
        {
            List<PlayerModel> PlayerModel = new List<PlayerModel>();
            // 获取
            PlayerBankManager playerBankManager = new PlayerBankManager();
            List<Hub.PlayerBank> players = playerBankManager.getPlayers();
            foreach (var playerItem in players)
            {
                string[] arrStr = playerItem.Pic.Split('/');
                Console.WriteLine(arrStr[2]);
                PlayerModel.Add(new Models.PlayerModel()
                {
                    ID = playerItem.ID,
                    Pic = arrStr[2],
                    Name = playerItem.Name,
                    School = playerItem.School,
                    Motto = playerItem.Motto,
                    Vote = playerItem.Vote,
                });
            }
            Session["playerList"] = PlayerModel;

            VoteBankManger voteMange = new VoteBankManger();
            if (Session["stuNum"] != null)
            {
                int stuNum = Int32.Parse(Session["stuNum"].ToString());
                // 获取用户今日投票记录
                List<Hub.VoteBank> votes = voteMange.GetVoteByDB(stuNum);
                if (votes.Count() > 0)
                {
                    // 用户今日已投票
                    ModelState.AddModelError("", "每天只能投一票哦");
                    return View();
                }
                else
                {
                    if (voteMange.InsertVoteToDB(stuNum, playerID) == 1)
                    {
                        // 投票成功
                        ModelState.AddModelError("", "投票成功");
                        return View();
                    }
                    else
                    {
                        // 投票失败
                        ModelState.AddModelError("", "投票失败");
                        return View();
                    }
                }
            }
            else
            {
                // 返回登录
                ModelState.AddModelError("", "登录");
                return View(PlayerModel);
            }
        }
        #endregion

        #region 登录页面
        // GET: Player
        public ActionResult Login()
        {
            return View();
        }
        #endregion
        #region 登录
        // POST: Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            VoteBankManger voteMange = new VoteBankManger();
            if (voteMange.ValidStuNumber(model.StuNumber, model.Password) == 1)
            {
                // 验证通过
                return View();
            }
            else
            {
                // 验证失败
                ModelState.AddModelError("", "学号或密码错误");
                return View();
            }
        }
        #endregion
    }
}