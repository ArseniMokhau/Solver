using Solver.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Solver.Commands
{
    public class StartCommand : ICommand
    {
        private readonly MainViewModel _viewModel;

        public StartCommand(MainViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            // Add your own logic here if needed
            return true;
        }

        public void Execute(object parameter)
        {
            // Perform the start quiz logic

            // Enable the Stop button
            _viewModel.IsStopButtonEnabled = true;
            _viewModel.IsSubmitButtonEnabled = true;
            _viewModel.IsStartButtonEnabled = false;
            _viewModel.IsListViewEnabled = false;
            _viewModel.Timer.ElapsedTime = TimeSpan.Zero;
            _viewModel.Timer.Start();
            _viewModel.Result = "";
            _viewModel.UpdateResult();
            _viewModel.ClearCheckboxes();

            if (_viewModel.QuestionsList.Count > 0)
            {
                _viewModel.CurrentQuestionIndex = 0;
                _viewModel.UpdateCurrentQuestion();
            }
        }
    }
}
