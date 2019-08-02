<%@ WebHandler Language="C#" Class="VCode" %>

using System;
using System.Drawing;
using System.Web;

public class VCode : IHttpHandler, System.Web.SessionState.IRequiresSessionState
{
    
    public void ProcessRequest (HttpContext context) {
        string str = GenerateCheckCode();
        context.Session.Add(context.Request["type"] ?? "login", str);
        context.Session.Timeout = 60;
        
        this.CreateCheckCodeImage(str, context);
    }

    /// <summary>
    /// 随机生成验证码
    /// </summary>
    /// <returns></returns>
    private string GenerateCheckCode()
    {
        int number;
        char code;
        string checkCode = String.Empty;

        Random random = new Random();

        for (int i = 0; i < 4; i++)
        {
            number = random.Next();

            // 只生成数字
            code = (char)('0' + (char)(number % 10));
            //if (number % 2 == 0)
            //    code = (char)('0' + (char)(number % 10));
            //else
            //    code = (char)('A' + (char)(number % 26));
            checkCode += code.ToString();
        }
        return checkCode;
    }

    /// <summary>
    /// 生成图片
    /// </summary>
    /// <param name="checkCode">验证码</param>
    /// <param name="context"></param>
    private void CreateCheckCodeImage(string checkCode, HttpContext context)
    {
        if (checkCode == null || checkCode.Trim() == String.Empty)
            return;

        Bitmap image =context.Request["reg"]==null ? new Bitmap((int)Math.Ceiling(checkCode.Length * 14.1), 25):
            new Bitmap((int)Math.Ceiling(checkCode.Length * 20.1), 35);
        Graphics g = Graphics.FromImage(image);

        try
        {
            //生成随机生成器
            Random random = new Random();

            //清空图片背景色
            g.Clear(Color.White);

            //画图片的背景噪音线
            for (int i = 0; i < 25; i++)
            {
                int x1 = random.Next(image.Width);
                int x2 = random.Next(image.Width);
                int y1 = random.Next(image.Height);
                int y2 = random.Next(image.Height);

                g.DrawLine(new Pen(Color.Silver), x1, y1, x2, y2);
            }

            Font font = new System.Drawing.Font("Arial", context.Request["reg"] == null ? 14 : 20, (System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic));
            System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height),
                Color.FromArgb(10 * 2, 10 * 8 + 10, 10 * 3 + 10), Color.FromArgb(33, 33, 33), 1.5f, true);
            g.DrawString(checkCode, font, brush, -1, -1);

            //画图片的前景噪音点
            for (int i = 0; i < 100; i++)
            {
                int x = random.Next(image.Width);
                int y = random.Next(image.Height);

                image.SetPixel(x, y, Color.FromArgb(random.Next()));
            }

            //画图片的边框线
            g.DrawRectangle(new Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1);

            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            context.Response.ClearContent();
            context.Response.ContentType = "image/Gif";
            context.Response.BinaryWrite(ms.ToArray());
        }
        finally
        {
            g.Dispose();
            image.Dispose();
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}