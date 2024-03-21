using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Kreta.Desktop.ViewModels.Base;
using Kreta.HttpService.Services;
using Kreta.Shared.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Kreta.Desktop.ViewModels.SchoolSubjects
{
    public partial class SubjectsManagmentViewModel : BaseViewModel
    {
        private ISubjectService? _subjectService { get; set; }
        private ISchoolClassService? _schoolClassService { get; set; }

        [ObservableProperty]
        private Subject _selectedSubject = new Subject();

        [ObservableProperty]
        private ObservableCollection<Subject> _subjects = new ObservableCollection<Subject>();

        [ObservableProperty]
        private ObservableCollection<SchoolClass> _schoolClassesWhoNotStudySubject = new ObservableCollection<SchoolClass>();

        public SubjectsManagmentViewModel()
        {
        }

        public string Title { get; set; } = "Tantárgyak kezelése";

        public SubjectsManagmentViewModel(ISubjectService subjectService,
                                          ISchoolClassService schoolClassService)
        {
            _subjectService = subjectService;
            _schoolClassService = schoolClassService;
        }

        public override async Task InitializeAsync()
        {
            await UpdateView();
            await base.InitializeAsync();
        }

        [RelayCommand]
        private async Task GetSchoolClassWhoNotStudySubject()
        {
            if (_subjectService is not null && SelectedSubject.HasId)
            {
                List<SchoolClass> schoolClasses = await _subjectService.GetSchoolClassWhoNotStudyingSubject(SelectedSubject.Id);
                SchoolClassesWhoNotStudySubject = new ObservableCollection<SchoolClass>(schoolClasses);
            }
        }

        private async Task UpdateView()
        {
            if (_subjectService!= null)
            {
                List<Subject> subjects= await _subjectService.GetAllSubjectWithSchoolClassAsync();
                Subjects= new ObservableCollection<Subject>(subjects);
            }

        }
    }
}
