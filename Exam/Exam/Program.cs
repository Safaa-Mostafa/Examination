namespace Exam
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<Answer> options = new List<Answer>
         {
    new Answer('a', "C#"),
    new Answer('b', "Java"),
    new Answer('c', "Python"),
    new Answer('d', "JavaScript")
    };
    List<Answer> modelAnswers = new List<Answer>
    {
        new Answer('a', "C#"),
        new Answer('b', "Java"),

    };
            List<Answer> q2modelAns = new List<Answer>
    {new Answer('a', "C#"),

    };
            List<Answer> trueorfalseoptions = new List<Answer> { new Answer('a', "true"), new Answer('b', "False") };
            List<Answer> trueorfalseq4 = new List<Answer>
    {new Answer('a', "true"),

    };
            QuestionTrueOrFalse q5 = new QuestionTrueOrFalse("is true ?","true or false", 1, trueorfalseq4, trueorfalseoptions);
            chooseOneAnswer q1 = new chooseOneAnswer("what are the oop languages:", "choose one answer", 2, modelAnswers, options);
            chooseOneAnswer q2 = new chooseOneAnswer("what are the oop languages:", "choose one answer", 2, q2modelAns, options);

            ChooseAllQuestion q3 = new ChooseAllQuestion("what are the oop languages:", "choose one answer", 2, options, modelAnswers);

            ChooseAllQuestion q4 = new ChooseAllQuestion("what are the oop languages:", "choose one answer", 2, options, modelAnswers);


            PracticeExam p1 = new PracticeExam(0, 2);

            FinalExam finalExam = new FinalExam(0, 2);
            p1.Mandatory.Add(q3, new List<Answer>());
            p1.Mandatory.Add(q5, new List<Answer>());

            p1.Mandatory.Add(q2, new List<Answer>());







            p1.ShowExam();
        }
    }
}
