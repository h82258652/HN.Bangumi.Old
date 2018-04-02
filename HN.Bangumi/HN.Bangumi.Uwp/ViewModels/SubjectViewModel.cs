using GalaSoft.MvvmLight;
using HN.Bangumi.Models;
using HN.Bangumi.Services;

namespace HN.Bangumi.Uwp.ViewModels
{
    public class SubjectViewModel : ViewModelBase
    {
        private readonly SubjectService _subjectService;
        private Subject _subject;

        public SubjectViewModel(SubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        public Subject Subject
        {
            get => _subject;
            set => Set(ref _subject, value);
        }
    }
}