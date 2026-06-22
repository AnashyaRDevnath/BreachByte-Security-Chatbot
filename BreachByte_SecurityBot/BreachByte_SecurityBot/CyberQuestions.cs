using System;
using System.Collections.Generic;
using System.Text;

namespace BreachByte_SecurityBot
{
    public enum QuestionType
    {
        MultipleChoice,
        TrueFalse,
        FillInTheBlank
    }
    public class CyberQuestions
    {
        public string QuestionText { get; set; }
        public List<string> Options { get; set; }
        public string CorrectAnswer { get; set; }
        public string Explanation { get; set; }
        public QuestionType Type { get; set; }

        public CyberQuestions(string questionText, List<string> options, string correctAnswer, string explanation, QuestionType type)
        {
            QuestionText = questionText;
            Options = options;
            CorrectAnswer = correctAnswer;
            Explanation = explanation;
            Type = type;
        }
    }
}
