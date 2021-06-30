using System;

namespace Lesson11_Event
{
    class StepUpdateService
    {
        public delegate void UpdateDelegate(string sender, string text);

        public event UpdateDelegate Update = new UpdateDelegate((a, b) => { });

        public void Publish(string text)
        {
            Update("STEP IT", text);
        }
    }

    class Email
    {
        public void GetEmail(string sender, string text)
        {
            Console.WriteLine("You have got email");
            Console.WriteLine($"From : {sender}");
            Console.WriteLine($"Date : {DateTime.Now}");
            Console.WriteLine("No Subject");
            Console.WriteLine($"Body : {text}");
        }
    }

    class MobileClient
    {
        public void Notification(string sender, string text)
        {
            Console.Beep(5000, 900);
            Console.Beep(5000, 200);
            Console.WriteLine($"Sender : {sender} : {text}");
        }
    }

    class SMS
    {
        public void GetSMS(string sender, string text)
        {
            Console.WriteLine($"New SMS : {sender}  -  {text}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var updateService = new StepUpdateService();

            var email = new Email();
            var sms = new SMS();
            var mobile = new MobileClient();

            bool emailActive = false;
            bool smsActive = false;
            bool mobileActive = false;


            int ch = 0;
            while (ch != 5)
            {
                Console.Clear();
                Console.WriteLine("1.Publish Something");
                Console.WriteLine($"2.Email : {(emailActive ? "Unsubscribe" : "Subscribe")}");
                Console.WriteLine($"3.SMS : {(smsActive ? "Unsubscribe" : "Subscribe")}");
                Console.WriteLine($"4.Mobile : {(mobileActive ? "Unsubscribe" : "Subscribe")}");

                ch = Console.ReadKey().KeyChar;

                switch (ch)
                {
                    case '1':
                    {
                        Console.Clear();
                        Console.WriteLine("Write Text");
                        string text = Console.ReadLine();
                        updateService.Publish(text);
                        Console.ReadKey(true);
                        break;
                    }

                    case '2':
                    {
                        if (emailActive)
                        {
                            updateService.Update -= email.GetEmail;
                        }
                        else
                        {
                            updateService.Update += email.GetEmail;
                        }

                        emailActive = !emailActive;
                        break;
                    }
                    case '3':
                    {
                        if (smsActive)
                        {
                            updateService.Update -= sms.GetSMS;
                        }
                        else
                        {
                            updateService.Update += sms.GetSMS;
                        }

                        smsActive = !smsActive;
                        break;
                    }
                    case '4':
                    {
                        if (mobileActive)
                        {
                            updateService.Update -= mobile.Notification;
                        }
                        else
                        {
                            updateService.Update += mobile.Notification;
                        }

                        mobileActive = !mobileActive;
                        break;
                    }
                    default:
                        break;
                }
            }
        }
    }
}