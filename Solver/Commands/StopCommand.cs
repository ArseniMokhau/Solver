using Solver.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Solver.Commands
{
    public class StopCommand : ICommand
    {
        private readonly MainViewModel _viewModel;

        public StopCommand(MainViewModel viewModel)
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
            _viewModel.IsStopButtonEnabled = false;
            _viewModel.IsSubmitButtonEnabled = false;
            _viewModel.IsListViewEnabled = true;
            _viewModel.IsStartButtonEnabled = true;
            _viewModel.Timer.Stop();
        }
    }
}