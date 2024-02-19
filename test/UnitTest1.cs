using JsonMask;

namespace JsonMaskTest1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var json = @$"{{""SP"":""Limit"",""info"":{{""text"":""SISKKK""}}}}";
            string[] blacklist = { "text" };
            var ans = $@"{{""SP"":""Limit"",""info"":{{""text"":""U0lTS0tL""}}}}".Replace("\n", "").Replace(" ", "").Replace("\t", "").Replace("\r", "");
            var result = json.EncryptFields(blacklist).Replace("\n", "").Replace(" ", "").Replace("\t", "").Replace("\r", "");
            Assert.AreEqual(result, ans);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var json = @$"[
                          {{
                           ""text"": ""89849455""
                          }}
                        ]";
            string[] blacklist = { "text" };
            var mask = "*******";
            var ans = $@"[
                          {{
                           ""text"": ""*******""
                          }}
                        ]".Replace("\n", "").Replace(" ", "").Replace("\t", "").Replace("\r", "");
            var result = json.MaskFields(blacklist, mask).Replace("\n", "").Replace(" ", "").Replace("\t", "").Replace("\r", "");
            Assert.AreEqual(result, ans);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var json = @$"[{{""text"": ""This is the text""}}]";
            string[] blacklist = { "text" };
            var ans = $@"[
                          {{
                           ""text"": ""VGhpcyBpcyB0aGUgdGV4dA==""
                          }}
                        ]".Replace("\n", "").Replace(" ", "").Replace("\t", "").Replace("\r", "");
            var result = json.EncryptFields(blacklist).Replace("\n", "").Replace(" ", "").Replace("\t", "").Replace("\r", "");
            Assert.AreEqual(result, ans);
        }
    }


}