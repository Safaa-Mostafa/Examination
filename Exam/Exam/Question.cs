using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
    public abstract class Question
    {
        public string _body { get; set; }
        public string _header { get; set; }
        public int Marks { get; set; }
        public List<Answer> modelAnswer { get; set; }
        public List<Answer> options { get; set; }


        public Question(string _body, string _header, int Marks, List<Answer> modelAnswer, List<Answer> options)
        {
            this._body = _body;
            this._header = _header;
            this.Marks = Marks;
            this.modelAnswer = modelAnswer;
            this.options = options;

        }
        public Question(string _body, string _header, int Marks, List<Answer> options)
        {
            this._body = _body;
            this._header = _header;
            this.Marks = Marks;
            this.options = options;

        }
        public abstract void showQuestion();

    }

    public class QuestionTrueOrFalse : Question
    {
        public QuestionTrueOrFalse(string _body, string _header, int Marks, List<Answer> modelAnswer, List<Answer> options) : base(_body, _header, Marks, modelAnswer, options)
        {

            if (modelAnswer[0]._body != "true" && modelAnswer[1]._body != "false")
            {
                throw new ArgumentException("Model answer for TrueFalseQuestion must 'true' or 'false'.");
            }
        }

        public override void showQuestion()
        {
            Console.WriteLine($"{_header}\n{_body}");
        }

    }

    public class chooseOneAnswer : Question
    {

        public chooseOneAnswer(string _body, string _header, int Marks, List<Answer> modelAnswer, List<Answer> options) : base(_body, _header, Marks, modelAnswer, options)
        {

            if (options.Count != 4)
            {
                throw new Exception(" must have 4 options only");
            }
        }

        public override void showQuestion()
        {

            Console.WriteLine($"{_header}\n{_body}");
            for (int i = 0; i < options.Count; i++)
            {
                Console.WriteLine($"{options[i]._letter}. {options[i]._body}");

            }
        }
    }

    public class ChooseAllQuestion : Question
    {

        public ChooseAllQuestion(string header, string body, int marks, List<Answer> modelAnswer, List<Answer> options)
            : base(header, body, marks, options, modelAnswer)
        {
        }

        public override void showQuestion()
        {
            Console.WriteLine($"{_header}\n{_body}");
            for (int i = 0; i < options.Count; i++)
            {
                Console.WriteLine($"{options[i]._letter}. {options[i]._body}");
            }
        }
    }
}
