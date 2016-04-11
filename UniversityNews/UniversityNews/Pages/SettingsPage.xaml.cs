using System;
using UniversityNews.Controls;
using UniversityNews.Helpers;
using UniversityNews.ViewModels;

namespace UniversityNews.Pages
{
    public class SettingsPageBase : ViewPage<SettingsViewModel>
    {
    }

    public partial class SettingsPage
    {
        public SettingsPage()
        {
            InitializeComponent();

        }

        private void Faculty_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            ViewModel.FacultyIndex = ((BindablePicker) sender).SelectedIndex;
        }

        private void Cource_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            ViewModel.CourseIndex = ((BindablePicker)sender).SelectedIndex;
        }

        private void Group_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            ViewModel.GroupIndex = ((BindablePicker)sender).SelectedIndex;
        }
    }
}
