using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CImage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.AddHeader("p3p", "CP=\"CAO PSA OUR\"");

        Color myColor = System.Drawing.Color.BlueViolet;

        Bitmap objBMP = new System.Drawing.Bitmap(160, 40);
        Graphics objGraphics = System.Drawing.Graphics.FromImage(objBMP);
        objGraphics.Clear(Color.AntiqueWhite);

        Font objFont = new Font("Arial", 16, FontStyle.Regular);

        string randomStr = "";

        Random r = new Random();

        //int a = r.Next(1, 9);
        //int b = r.Next(1, 9);
        string[] num_words = { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
        string[] nums = { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        int mIndex = r.Next(num_words.Length);
        int nIndex = r.Next(nums.Length);
        //Console.WriteLine(num_words[mIndex]);
        //Console.WriteLine(num_words[nIndex]);
        string s1 = num_words[mIndex];
        string s2 = nums[nIndex];
        string[] s = { s1, s2 };
        for (int i = 0; i < s.Length - 1; i++)
        {
            int j = r.Next(i, s.Length);
            string temp = s[i];
            s[i] = s[j];
            s[j] = temp;
        }
        int a = 0;
        int b = 0;
        switch (s[0])
        {
            case "1":
            case "one":
                a += 1;
                break;
            case "2":
            case "two":
                a += 2;
                break;
            case "3":
            case "three":
                a += 3;
                break;
            case "4":
            case "four":
                a += 4;
                break;
            case "5":
            case "five":
                a += 5;
                break;
            case "6":
            case "six":
                a += 6;
                break;
            case "7":
            case "seven":
                a += 7;
                break;
            case "8":
            case "eight":
                a += 8;
                break;
            case "9":
            case "nine":
                a += 9;
                break;

        }
        //Console.WriteLine(a);
        switch (s[1])
        {
            case "1":
            case "one":
                b += 1;
                break;
            case "2":
            case "two":
                b += 2;
                break;
            case "3":
            case "three":
                b += 3;
                break;
            case "4":
            case "four":
                b += 4;
                break;
            case "5":
            case "five":
                b += 5;
                break;
            case "6":
            case "six":
                b += 6;
                break;
            case "7":
            case "seven":
                b += 7;
                break;
            case "8":
            case "eight":
                b += 8;
                break;
            case "9":
            case "nine":
                b += 9;
                break;

        }
        string randomOp = "";
        int c = 0;
        int op = r.Next(1, 4);// 1 = add, 2 = minus, 3 = multiply
        switch (op)
        {
            case 1:
                c = a + b;
                randomOp = "+";
                break;
            case 2:
                c = a - b;
                randomOp = "-";
                break;
            case 3:
                c = a * b;
                randomOp = "*";
                break;
            default:
                break;
        }
        //if (operators == 1)
        //{
        //    Console.WriteLine("{0} + {1} = ", number1, number2);

        //}
        //else if (operators == 2)
        //{
        //    Console.WriteLine("{0} - {1} = ", number1, number2);
        //}
        //else if (operators == 3)
        //{
        //    Console.WriteLine("{0} * {1} = ", number1, number2);
        //}
        //else if (operators == 4)
        //{
        //    Console.WriteLine("{0} / {1} = ", number1, number2);
        //}
        //break;

        //int c = a + b;

        randomStr = s[0] + " " + randomOp.ToString() + " " + s[1] + " =  ?";

        Session["CaptchaImageText"] = c.ToString();

        SolidBrush myBrush = new SolidBrush(myColor);

        objGraphics.DrawString(randomStr, objFont, myBrush, 3, 3);

        Response.ContentType = "image/png";

        MemoryStream mem = new MemoryStream();

        objBMP.Save(mem, ImageFormat.Png);
        mem.WriteTo(Response.OutputStream);

        objFont.Dispose();
        objGraphics.Dispose();
        objBMP.Dispose();
    }
}