using pleaseAnswer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using User;

namespace pleaseAnswer.Controllers
{
    public class AnswerController : Controller
    {
        #region 答题页面
        // GET: Answer
        public ActionResult Index()
        {
            List<QuesModel> quesModel = new List<QuesModel>();
            // 获取题目
            QuesBankManager quesBankManager = new QuesBankManager();
            List<Hub.QuesBank> quess = quesBankManager.getRandomQuess();
            foreach (var quessItem in quess)
            {
                quesModel.Add(new Models.QuesModel()
                {
                    ID = quessItem.ID,
                    Class = quessItem.Class,
                    Ques = quessItem.Ques,
                    OptionA = quessItem.OptionA,
                    OptionB = quessItem.OptionB,
                    OptionC = quessItem.OptionC,
                    OptionD = quessItem.OptionD,
                    Answer = quessItem.Answer,
                    UserAnswer = null
                });
            }
            Session["quesList"] = quesModel;
            return View(quesModel);
        }
        #endregion

        #region 移动端答题页面
        // GET: Answer
        public ActionResult Indexm()
        {
            List<QuesModel> quesModel = new List<QuesModel>();
            // 获取题目
            QuesBankManager quesBankManager = new QuesBankManager();
            List<Hub.QuesBank> quess = quesBankManager.getRandomQuess();
            foreach (var quessItem in quess)
            {
                quesModel.Add(new Models.QuesModel()
                {
                    ID = quessItem.ID,
                    Class = quessItem.Class,
                    Ques = quessItem.Ques,
                    OptionA = quessItem.OptionA,
                    OptionB = quessItem.OptionB,
                    OptionC = quessItem.OptionC,
                    OptionD = quessItem.OptionD,
                    Answer = quessItem.Answer,
                    UserAnswer = null
                });
            }
            Session["quesList"] = quesModel;
            return View(quesModel);
        }
        #endregion

        #region 结果及答案页面
        // POST:Result
        // 从页面获取用户选择答案 List无返回值。。。。。。。。 用了以下蠢方法
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Result(string ques_0, string ques_1, string ques_2, string ques_3, string ques_4, string ques_5, string ques_6, string ques_7, string ques_8, string ques_9, string ques_10, string ques_11, string ques_12, string ques_13, string ques_14)
        {
            float accuracy = 0;
            int correctNum = 0;
            List<QuesModel> quesModel = (List<QuesModel>)Session["quesList"];

            quesModel[0].UserAnswer = ques_0;
            quesModel[1].UserAnswer = ques_1;
            quesModel[2].UserAnswer = ques_2;
            quesModel[3].UserAnswer = ques_3;
            quesModel[4].UserAnswer = ques_4;
            quesModel[5].UserAnswer = ques_5;
            quesModel[6].UserAnswer = ques_6;
            quesModel[7].UserAnswer = ques_7;
            quesModel[8].UserAnswer = ques_8;
            quesModel[9].UserAnswer = ques_9;
            quesModel[10].UserAnswer = ques_10;
            quesModel[11].UserAnswer = ques_11;
            quesModel[12].UserAnswer = ques_12;
            quesModel[13].UserAnswer = ques_13;
            quesModel[14].UserAnswer = ques_14;

            foreach (var quessItem in quesModel)
            {
                if (quessItem.Answer == quessItem.UserAnswer)
                {
                    correctNum++;
                }
            }
            accuracy = correctNum * 100 / 15;   // 百分制
            Session["accuracy"] = accuracy;

            return View(quesModel);
        }
        #endregion

        #region 移动端结果及答案页面
        // POST:Resultm
        // 从页面获取用户选择答案 List无返回值。。。。。。。。 用了以下蠢方法
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Resultm(string ques_0, string ques_1, string ques_2, string ques_3, string ques_4, string ques_5, string ques_6, string ques_7, string ques_8, string ques_9, string ques_10, string ques_11, string ques_12, string ques_13, string ques_14)
        {
            float accuracy = 0;
            int correctNum = 0;
            List<QuesModel> quesModel = (List<QuesModel>)Session["quesList"];

            quesModel[0].UserAnswer = ques_0;
            quesModel[1].UserAnswer = ques_1;
            quesModel[2].UserAnswer = ques_2;
            quesModel[3].UserAnswer = ques_3;
            quesModel[4].UserAnswer = ques_4;
            quesModel[5].UserAnswer = ques_5;
            quesModel[6].UserAnswer = ques_6;
            quesModel[7].UserAnswer = ques_7;
            quesModel[8].UserAnswer = ques_8;
            quesModel[9].UserAnswer = ques_9;
            quesModel[10].UserAnswer = ques_10;
            quesModel[11].UserAnswer = ques_11;
            quesModel[12].UserAnswer = ques_12;
            quesModel[13].UserAnswer = ques_13;
            quesModel[14].UserAnswer = ques_14;

            foreach (var quessItem in quesModel)
            {
                if (quessItem.Answer == quessItem.UserAnswer)
                {
                    correctNum++;
                }
            }
            accuracy = correctNum * 100 / 15;   // 百分制
            Session["accuracy"] = accuracy;

            return View(quesModel);
        }
        #endregion
    }
}