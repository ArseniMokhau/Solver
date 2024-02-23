using Solver.ViewModel;
using Solver.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Solver.Model;
using System.Windows.Controls;

namespace Solver.Commands
{
    public class SubmitAnswerCommand : ICommand
    {
        private readonly MainViewModel _viewModel;
        private int result;

        public SubmitAnswerCommand(MainViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {

            if (_viewModel.QuestionsList.Count > 0 && _viewModel.CurrentQuestionIndex < _viewModel.QuestionsList.Count)
            {
                _viewModel.SubmitAnswer();
                _viewModel.CurrentQuestionIndex += 1;
                _viewModel.UpdateCurrentQuestion();
                if (_viewModel.CurrentQuestionIndex == _viewModel.QuestionsList.Count)
                {
                    _viewModel.UpdateResult();
                    _viewModel.IsStopButtonEnabled = false;
                    _viewModel.IsSubmitButtonEnabled = false;
                    _viewModel.IsListViewEnabled = true;
                    _viewModel.IsStartButtonEnabled = true;
                    _viewModel.Timer.Stop();
                    _viewModel.CurrentQuestionIndex = 0;
                }
            }
        }
    }
}
