using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using User.cn.edu.swufe.oam;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            DateTime time = DateTime.Now.Date;
            Console.WriteLine(time);
        }

        // 测试学号验证接口
        // 成功1 失败0
        [TestMethod]
        public void TestMethod2()
        {
            using (getUserAuthWSDL client = new getUserAuthWSDL())
            {
                client.Credentials = new System.Net.NetworkCredential("userauth", "oamswufe123");
                //if ("2000".Equals(client.chg_ldaps(stunumber, password, 1, " ", "ldap1")))
                //    return 1;
                //else return 0;
                var test = client.userAuth("41416084","jzbq1995");
            }
        }
    }
}
