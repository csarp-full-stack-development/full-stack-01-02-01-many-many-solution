using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Kreta.Desktop.ViewModels.Base;
using Kreta.HttpService.Services;
using Kreta.Shared.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Kreta.Desktop.ViewModels.SchoolClasses
{
    public partial class SchoolClassesManagmentViewModel : BaseViewModel
    {
        private ISchoolClassService? _schoolClassService;
        private ISubjectService? _subjectService { get; set; }
        
        [ObservableProperty]
        private SchoolClass _selectedSchoolClass = new SchoolClass();

        [ObservableProperty]
        private ObservableCollection<SchoolClass> _schoolClasses = new ObservableCollection<SchoolClass>();

        [ObservableProperty]
        private ObservableCollection<Subject> _subjectWhoNotStudySchoolClass = new ObservableCollection<Subject>();
        public SchoolClassesManagmentViewModel()
        {            
        }
        public SchoolClassesManagmentViewModel(ISchoolClassService schoolClassService,
                                               ISubjectService subjectService)
        {
            _schoolClassService = schoolClassService;
            _subjectService = subjectService;
        }

        public string Title { get; set; } = "Osztályok kezelése";

        public override async Task InitializeAsync()        
        {
            await UpdateView();
            await base.InitializeAsync();
        }

        [RelayCommand]
        private async Task GetSubjectNotStudiedInTheSchoolClass()
        {
            if (_schoolClassService is not null && SelectedSchoolClass.HasId)
            {
                List<Subject> subjects = await _schoolClassService.GetSubjectNotStudiedInTheSchoolClass(SelectedSchoolClass.Id);
                SubjectWhoNotStudySchoolClass = new ObservableCollection<Subject>(subjects);
            }
        }

        private async Task UpdateView()
        {
            if (_schoolClassService!=null)
            {
                List<SchoolClass> schoolClasses = await _schoolClassService.GetAllSchoolClassWithSubjectsAsync();
                SchoolClasses =new ObservableCollection<SchoolClass>(schoolClasses);
            }
        }
    }
}
