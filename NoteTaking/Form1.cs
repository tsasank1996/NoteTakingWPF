using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace NoteTaking
{
    public partial class Form1 : Form
    {
        String path =  "..\\..\\..\\Notes\\";
        public Form1()
        {
            InitializeComponent();

        }
        public void ShowToastNotification(string name)
        {
            ToastNotificationManagerCompat.OnActivated += toastArgs =>
            {
                ToastArguments args = ToastArguments.Parse(toastArgs.Argument);
                seeFile(args.Get("name"));
            };
            new ToastContentBuilder().AddButton(new ToastButton().SetContent("Open File"))
            .AddArgument("action", "JJip")
            .AddArgument("name", name)
            .AddText("The File has been generated")
            .AddText("You can open the file using the below Action")
            .Show();
      
            }
        private void generateFile(object sender, EventArgs e)
        {
            
           

            using (StreamWriter sw = File.CreateText(path + textBox1.Text+".txt")) {
                StringBuilder s = new StringBuilder();
                s.Append("**********");
                s.Append("Note Added On : ");
                s.Append(DateTime.Now.ToString());
                s.Append("**********");
                sw.WriteLine(s);
                sw.WriteLine(textBox2.Text);
            }
            ShowToastNotification(textBox1.Text + ".txt");

        }

        public void seeFile(string name) {
            Process.Start("notepad.exe", path + name);
        }

        private void ValidateFileName(object sender, KeyEventArgs e)
        {
            if(textBox1.Text.Length >3)
            {
                button2.Enabled = true;
            }
        }


    }
}
