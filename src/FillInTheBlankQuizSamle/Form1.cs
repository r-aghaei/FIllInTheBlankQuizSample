using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FillInTheBlankQuizSamle
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Quiz quiz;
        private void Form1_Load(object sender, EventArgs e)
        {
    quiz = new Quiz();
    quiz.Text = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.";
    quiz.Ranges.Add(new SelectionRange(6, 5));
    quiz.Ranges.Add(new SelectionRange(30, 7));
    quiz.Ranges.Add(new SelectionRange(61, 2));
    quiz.Ranges.Add(new SelectionRange(82, 6));

            this.webBrowser1.DocumentText = quiz.Render();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < quiz.Ranges.Count; i++)
            {
                var id = $"q{i}";
                var input = webBrowser1.Document.GetElementById(id);
                var value = input.GetAttribute("value");
                if (quiz.Text.Substring(quiz.Ranges[i].Start, quiz.Ranges[i].Length) == value)
                    this.webBrowser1.Document.InvokeScript("setCorrect", new[] { id });
                else
                    this.webBrowser1.Document.InvokeScript("setWrong", new[] { id });
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < quiz.Ranges.Count; i++)
            {
                var id = $"q{i}";
                var input = webBrowser1.Document.GetElementById(id);
                var value = input.GetAttribute("value");
                if (quiz.Text.Substring(quiz.Ranges[i].Start, quiz.Ranges[i].Length) == value)
                    this.webBrowser1.Document.InvokeScript("setCorrect", new[] { id });
                else
                    this.webBrowser1.Document.InvokeScript("setWrong", new[] { id });
            }
        }
    }
}
