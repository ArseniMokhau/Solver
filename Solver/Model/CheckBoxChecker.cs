using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace Solver.Model
{
    public static class CheckBoxChecker
    {
        public static bool IsCheckboxChecked(string checkboxName, DependencyObject view)
        {
            CheckBox checkbox = (CheckBox)LogicalTreeHelper.FindLogicalNode(view, checkboxName);
            return checkbox?.IsChecked == true;
        }
    }
}
