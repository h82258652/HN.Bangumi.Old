using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using HN.Bangumi.Models;
using HN.Bangumi.Services;

namespace HN.Bangumi.Uwp.ViewModels
{
    public class SubjectViewModel : ViewModelBase
    {
        private readonly SubjectService _subjectService;

        public SubjectViewModel(SubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        public Subject Subject
        {
            get { return _subject; }
            set { Set(ref _subject, value); }
        }

        private Subject _subject;
    }
}