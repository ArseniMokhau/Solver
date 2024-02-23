using Microsoft.Extensions.Options;
using Solver.Commands;
using Solver.Model;
using Solver.Services;
using Solver.View;
using Solver.ViewModel.BaseClass;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;

namespace Solver.ViewModel
{
    public class MainViewModel : Base
    {
        private bool _isStartButtonEnabled;
        private bool _isStopButtonEnabled;
        private bool _isSubmitButtonEnabled;
        private bool _isListViewEnabled = true;
        private List<Question> _questionsList;
        private List<Quiz> _quizesList;
        private int _currentQuestionIndex;
        private Question _currentQuestion;
        private Quiz _selectedQuiz;
        private CountUpTimer _timer;
        private List<bool> checkboxValues;

        public StartCommand StartQuizCommand { get; }
        public StopCommand StopQuizCommand { get; }
        public SubmitAnswerCommand SubmitAnswerCommand { get; }

        public List<string> QuestionsId { get; set; }
        public string Result { get; set; }
        public Question CurrentQuestion { get; set; }
        public string QuizName { get; set; }
        public string QuestionText { get; set; }
        public List<string> Quizes { get; set; }
        public List<string> Options { get; set; }
        public List<bool> Answers { get; set; }
        public bool IsStopButtonEnabled
        {
            get { return _isStopButtonEnabled; }
            set
            {
                _isStopButtonEnabled = value;
                onPropertyChange(nameof(IsStopButtonEnabled));
            }
        }


        public bool IsStartButtonEnabled
        {
            get { return _isStartButtonEnabled; }
            set
            {
                _isStartButtonEnabled = value;
                onPropertyChange(nameof(IsStartButtonEnabled));
            }
        }

        public bool IsSubmitButtonEnabled
        {
            get { return _isSubmitButtonEnabled; }
            set
            {
                _isSubmitButtonEnabled = value;
                onPropertyChange(nameof(IsSubmitButtonEnabled));
            }
        }

        public bool IsListViewEnabled
        {
            get { return _isListViewEnabled; }
            set
            {
                _isListViewEnabled = value;
                onPropertyChange(nameof(IsListViewEnabled));
            }
        }

        public List<string> QuizesL
        {
            get { return Quizes; }
            set
            {
                Quizes = value;
                onPropertyChange(nameof(QuizesL));
            }
        }

        public CountUpTimer Timer
        {
            get { return _timer; }
            set
            {
                _timer = value;
                onPropertyChange(nameof(Timer));
            }
        }

        public List<bool> CheckboxValues
        {
            get { return checkboxValues; }
            set
            {
                checkboxValues = value;
                onPropertyChange(nameof(CheckboxValues));
            }
        }

        public List<Question> QuestionsList
        {
            get { return _questionsList; }
            set
            {
                _questionsList = value;
                onPropertyChange(nameof(QuestionsList));
            }
        }

        public List<Quiz> QuizesList
        {
            get { return _quizesList; }
            set
            {
                _quizesList = value;
                onPropertyChange(nameof(QuizesList));
            }
        }

        public int CurrentQuestionIndex
        {
            get { return _currentQuestionIndex; }
            set
            {
                _currentQuestionIndex = value;
                onPropertyChange(nameof(CurrentQuestionIndex));
            }
        }

        public Quiz SelectedQuiz
        {
            get { return _selectedQuiz; }
            set
            {
                if (_selectedQuiz != value)
                {
                    _selectedQuiz = value;

                    // Check if the quiz is unselected through Ctrl + LMB
                    if (_selectedQuiz == null)
                    {
                        QuizName = string.Empty;
                        QuestionsId = new List<string>();
                        QuestionsList.Clear();
                        IsStartButtonEnabled = false;
                    }
                    else
                    {
                        QuizName = SelectedQuiz.Name;
                        UpdateQuestionsId();
                        QuestionsList = DataAccess.ReadData(QuestionsId);
                        IsStartButtonEnabled = true;
                    }

                    onPropertyChange(nameof(QuizName));
                    onPropertyChange(nameof(SelectedQuiz));
                    onPropertyChange(nameof(QuestionsList));
                    onPropertyChange(nameof(IsStartButtonEnabled));
                }
            }
        }

        private void UpdateQuestionsId()
        {
            QuestionsId = new List<string>();

            if (SelectedQuiz != null)
            {
                string[] pom = SelectedQuiz.IdPyt.Split(",");
                foreach(string s in pom)
                {
                    if(s!="")
                        QuestionsId.Add(s);
                }
            }
        }
        public void UpdateCurrentQuestion()
        {
            if (CurrentQuestionIndex >= 0 && CurrentQuestionIndex < QuestionsList.Count)
            {
                CurrentQuestion = QuestionsList[CurrentQuestionIndex];
                UpdateQuestionValues();
                onPropertyChange(nameof(CurrentQuestion));
            }
        }

        public void UpdateResult()
        {
            onPropertyChange(nameof(Result));
        }

        public void UpdateQuestionValues()
        {
            Options = CurrentQuestion.Options;
            Answers = CurrentQuestion.Answers;
            QuestionText = CurrentQuestion.QuestionText;

            onPropertyChange(nameof(Options));
            onPropertyChange(nameof(Answers));
            onPropertyChange(nameof(QuestionText));
        }

        public void SubmitAnswer()
        {
            Window mainWindow = Application.Current.MainWindow;
            if (Enumerable.Range(0, 3).All(i => CheckBoxChecker.IsCheckboxChecked($"Checkbox{i}", mainWindow) == CurrentQuestion.Answers[i]))
            {
                Result += $"{CurrentQuestionIndex + 1}✓";
            }
            else Result += $"{CurrentQuestionIndex + 1}X";
            ClearCheckboxes();
            UpdateResult();
        }

        public void ClearCheckboxes()
        {
            Window mainWindow = Application.Current.MainWindow;
            for (int i = 0; i <= 3; i++)
            {
                CheckBox checkbox = (CheckBox)mainWindow.FindName($"Checkbox{i}");
                checkbox.IsChecked = false;
            }
        }

        public MainViewModel()
        {
            _currentQuestionIndex = 0;
            _questionsList = new List<Question>();
            _quizesList = new List<Quiz>();
            QuestionsId = new List<string>();
            Timer = new CountUpTimer();
            StopQuizCommand = new StopCommand(this);
            StartQuizCommand = new StartCommand(this);
            SubmitAnswerCommand = new SubmitAnswerCommand(this);
            CheckboxValues = new List<bool> { false, false, false, false };
            QuizesList = QuizesDBAccess.ReadData();
        }
    }
}
