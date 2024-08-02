using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
    public class Answer
    {
        public char _letter { get; set; }
        public string _body { get; set; }



        public Answer(char _letter, string _body)
        {
            this._letter = _letter;
            this._body = _body;
        }
    }
}
