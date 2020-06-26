using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Net;
using System.IO;
using System.Net.Mail;

public class IDS : MonoBehaviour
{
    public Image img;
    private string abc = "123456789";
    public string Password;
    private Text textID;

    void Start()
    {
        if (Interface._itWasWin)
        {
            GetPass();
            Interface._itWasWin = false;
        }
    }

    public void SendEmail()
    {
        MailAddress from = new MailAddress("tempmailmellons@gmail.com", "Tom");
        MailAddress to = new MailAddress("NeITdirect@yandex.ru");
        MailMessage m = new MailMessage(from, to);
        m.Subject = "Somebody to Win";
        m.Body = "code is " + Password + "Device Name   " + SystemInfo.deviceName + "Device Model    " + SystemInfo.deviceModel + "Device ID " + SystemInfo.deviceUniqueIdentifier;
        SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
        smtp.Credentials = new NetworkCredential("tempmailmellons@gmail.com", "WaterMelon75");
        smtp.EnableSsl = true;
        smtp.Send(m);
    }


    private void GetPass()
    {
        System.Random rnd = new System.Random();
        int lng = abc.Length;
        for (int i = 0; i < 4; i++)
        {
            Password += abc[rnd.Next(lng)];
        }

        SendEmail();
        textID = GameObject.Find("ID").GetComponent<Text>();
        textID.text = Password;
    }
}
