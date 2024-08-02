using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
    public abstract class Exam
    {
        public Dictionary<Question, List<Answer>> Mandatory { get; set; }
        public int _finalGrade { get; set; }
        public int noOFQuestions { get; set; }
        public Exam(int _finalGrade, int noOFQuestions)
        {
            this._finalGrade = _finalGrade;
            this.noOFQuestions = noOFQuestions;
            this.Mandatory = new Dictionary<Question, List<Answer>>();
        }
        public abstract void ShowExam();


    }
    public class FinalExam : Exam
    {
        public FinalExam(int _finalGrade, int noOFQuestions) : base(_finalGrade, noOFQuestions)
        { }
        public override void ShowExam()
        {
            foreach (var item in Mandatory)
            {
                var question = item.Key;
                var answers = item.Value;

                question.showQuestion();

                Console.Write("please answer with comma separator like a,b,c : ");

                string userAnswer = Console.ReadLine();
                if (userAnswer == null) userAnswer = " ";
                char[] userAnswerArray = userAnswer.Split(',').Select(a => a.Trim()[0]).ToArray();

                foreach (var el in userAnswerArray)
                {
                    Answer[] userAnswers =
                    {
                            new Answer(el, question._body)


                    };
                    answers.AddRange(userAnswers);
                }



                if (question is QuestionTrueOrFalse || question is chooseOneAnswer)
                {

                    if (userAnswerArray.Length == 1 && userAnswerArray[0] == question.modelAnswer[0]._letter)
                    {
                        _finalGrade += question.Marks;
                    }

                }
                else
                {

                    bool allCorrect = true;

                    foreach (var modelAnswer in question.modelAnswer)
                    {
                        bool isCorrecr = false;

                        foreach (var userAns in answers)
                        {
                            if (userAns._letter == modelAnswer._letter || userAns._body == modelAnswer._body)
                            {
                                isCorrecr = true;
                                break; 
                            }
                        }
                        if (!isCorrecr)
                        {
                            allCorrect = false;
                            break; 
                        }
                    }

                    if (allCorrect)
                    {
                        _finalGrade += question.Marks;
                    }

                }
            }

            Console.WriteLine($"Final Grade: {_finalGrade}");
        }
    }

    public class PracticeExam : Exam
    {
        public PracticeExam(int _finalGrade, int noOFQuestions) : base(_finalGrade, noOFQuestions)
        { }
        public override void ShowExam()
        {
            bool CorrectAns;
            foreach (var item in Mandatory)
            {
                var question = item.Key;
                var answers = item.Value;

                question.showQuestion();

                Console.Write("please answer with comma separator like a,b,c : ");

                string userAnswer = Console.ReadLine();
                if (userAnswer == null) userAnswer = " ";
                char[] userAnswerArray = userAnswer.Split(',').Select(a => a.Trim()[0]).ToArray();


                foreach (var el in userAnswerArray)
                {
                    Answer[] userAnswers =
                    {
                            new Answer(el, question._body)


                    };
                    answers.AddRange(userAnswers);
                }



                if (question is QuestionTrueOrFalse || question is chooseOneAnswer)
                {

                    if (userAnswerArray.Length == 1 && userAnswerArray[0] == question.modelAnswer[0]._letter)
                    {
                        _finalGrade += question.Marks;
                    }

                }
                else
                {

                    bool allCorrect = true;

                    foreach (var modelAnswer in question.modelAnswer)
                    {
                        bool isCorrecr = false;

                        foreach (var userAns in answers)
                        {
                            if (userAns._letter == modelAnswer._letter || userAns._body == modelAnswer._body)
                            {
                                isCorrecr = true;
                                break;
                            }
                        }
                        if (!isCorrecr)
                        {
                            allCorrect = false;
                            break;
                        }
                    }

                    if (allCorrect)
                    {
                        _finalGrade += question.Marks;
                    }

                }
            }


            Console.WriteLine($"Final Grade: {_finalGrade}");

            Console.WriteLine(" Model Answers:");



            foreach (var item in Mandatory)
            {
                var question = item.Key;
                question.showQuestion();

                if (question is chooseOneAnswer || question is ChooseAllQuestion || question is QuestionTrueOrFalse)
                {
                    Console.WriteLine("Options:");
                    foreach (var option in question.options)
                    {
                        Console.WriteLine($"{option._letter}: {option._body}");
                    }
                }
                for (int i = 0; i < question.modelAnswer.Count; i++)
                {


                    Console.WriteLine($"Model Answer: {question.modelAnswer[i]._letter}");


                }



            }
        }

    }
}