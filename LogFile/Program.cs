using System.Text.Json;
using System.Runtime.Serialization.Json;
using System.Text;
using System.IO;

public class FileExample
{
    class User
    {
        public int Password { get; set; }
        public string UserName { get; set; }
    }
    private class Log
    {
        public int UserId { get; set; }
        public string UserN { get; set; }
        public DateTime LogInDate { get; set; }
        public DateTime LogOutDate { get; set; }
    }

    public static void Main(string[] args)
    {
        #region Kullanıcı bilgilerinin json formatında oluşrulması
        User user = new User();
        user.UserName = "onur";
        user.Password = 1234;
        string userinfo = JsonSerializer.Serialize(user);
        FileStream userwrite = new FileStream(@"D:\deneme\userinfo\UserInfo.json", FileMode.OpenOrCreate, FileAccess.Write);
        StreamWriter sw = new StreamWriter(userwrite);
        sw.WriteLine(userinfo);
        sw.Flush();
        sw.Close();
        userwrite.Close();
        #endregion

        var UserInfo = System.IO.File.ReadAllText(@"D:\deneme\userinfo\UserInfo.json");
        var result = JsonSerializer.Deserialize<User>(UserInfo);
        if (result.UserName == user.UserName && result.Password == user.Password)
        {
            Console.WriteLine("Erişim izni verildi...\n");
            Console.Write("Log Bilgilerini Görüntülemek İçin Herhangi Bir Tuşa Basın");
            Console.ReadKey();
            Console.Clear();
            Log log = new Log();
            log.UserId = 100;
            log.UserN = "onur";
            log.LogInDate = DateTime.Today;
            log.LogOutDate = DateTime.Now;

            string loginfo = JsonSerializer.Serialize(log);
            //Console.WriteLine(loginfo);

            #region Json bilgileri dosyaya yazdırma

            FileStream logwrite = new FileStream(@"D:\deneme\logs\LogInfo.json", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter swr = new StreamWriter(logwrite);
            swr.WriteLine(loginfo);
            swr.Flush();
            swr.Close();
            logwrite.Close();
            #endregion

            #region Json Deserialize işlemi ve bilgileri yazdırma

            var LogInfo = System.IO.File.ReadAllText(@"D:\deneme\logs\LogInfo.json");
            var result2 = JsonSerializer.Deserialize<Log>(LogInfo);
            Console.WriteLine("Kulllanıcı Log bilgileri şu şekildedir :\n ");
            Console.WriteLine("Kullanıcı Id    = " + result2.UserId);
            Console.WriteLine("Kullanıcı Adı   = " + result2.UserN);
            Console.WriteLine("Kullanıcı Giriş = " + result2.LogInDate);
            Console.WriteLine("Kullanıcı Çıkış = " + result2.LogOutDate);
            #endregion
        }
        else
            Console.WriteLine("Erişim izniniz yok");
    }
}
