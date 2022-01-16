using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IQTestConsoleApp
{
    public class Question
    {
        public string QuestionText { get; set; }
        public int Answer { get; set; }

        public Question (string text, int answer)
        {
            QuestionText = text;
            Answer = answer;
        }
        
    }
}
