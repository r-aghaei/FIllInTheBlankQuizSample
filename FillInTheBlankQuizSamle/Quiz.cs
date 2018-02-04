using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FillInTheBlankQuizSamle
{
    public class Quiz
    {
        public Quiz() { Ranges = new List<SelectionRange>(); }
        public string Text { get; set; }
        public List<SelectionRange> Ranges { get; private set; }
        public string Render()
        {
            var content = new StringBuilder(Text);
            for (int i = Ranges.Count - 1; i >= 0; i--)
            {
                content.Remove(Ranges[i].Start, Ranges[i].Length);
                var length = Ranges[i].Length;
                var replacement = $@"<input id=""q{i}"" 
                    type=""text"" class=""editable""
                    maxlength=""{length}"" 
                    style=""width: {length*1.162}ch;"" />";
                content.Insert(Ranges[i].Start, replacement);
            }
            var result = $@"
<html>
  <head>
    <meta http-equiv=""X-UA-Compatible"" content=""IE=11"" />
    <script>
      function setCorrect(id){{document.getElementById(id).className = 'editable correct';}}
      function setWrong(id){{document.getElementById(id).className = 'editable wrong';}}
    </script>
    <style>
      div {{
        line-height: 1.5;
        font-family: calibri;
      }}
      .editable {{
        border-width: 0px;
        border-bottom: 1px solid #cccccc;
        font-family: monospace;
        display: inline-block;
        outline: 0;
        color: #0000ff;
        font-size: 105%;
      }}
      .editable.correct
      {{    
        color: #00ff00;
        border-bottom: 1px solid #00ff00;
      }}
      .editable.wrong
      {{    
        color: #ff0000;
        border-bottom: 1px solid #ff0000;
      }}
     .editable::-ms-clear {{
       width: 0;
       height: 0;
     }}
    </style>
  </head>
  <body>
    <div>
    {content}
    </div>
  </body>
</html>
";
            return result;
        }
    }

    public class SelectionRange
    {
        public SelectionRange(int start, int length)
        {
            Start = start;
            Length = length;
        }
        public int Start { get; set; }
        public int Length { get; set; }
    }
}
