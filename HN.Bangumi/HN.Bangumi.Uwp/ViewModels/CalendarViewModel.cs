using System;
using System.Net.Http;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using HN.Bangumi.Models;
using HN.Bangumi.Services;
using Polly;

namespace HN.Bangumi.Uwp.ViewModels
{
    public class CalendarViewModel : ViewModelBase
    {
        private readonly CalendarService _calendarService;
        private readonly INavigationService _navigationService;
        private Calendar[] _calendars;
        private bool _isLoading;
        private RelayCommand<Subject> _subjectClickCommand;

        public CalendarViewModel(CalendarService calendarService, INavigationService navigationService)
        {
            _calendarService = calendarService;
            _navigationService = navigationService;

            Initialize();
        }

        public Calendar[] Calendars
        {
            get => _calendars;
            private set => Set(ref _calendars, value);
        }

        public bool IsLoading
        {
            get => _isLoading;
            private set => Set(ref _isLoading, value);
        }

        public RelayCommand<Subject> SubjectClickCommand
        {
            get
            {
                _subjectClickCommand = _subjectClickCommand ?? new RelayCommand<Subject>(subject =>
                {
                    _navigationService.NavigateTo(ViewModelLocator.SubjectViewKey, subject);
                });
                return _subjectClickCommand;
            }
        }

        private async void Initialize()
        {
            var policy = Policy
                .Handle<HttpRequestException>()
                .WaitAndRetryForever(
                    retryAttempt => TimeSpan.FromSeconds(5),
                    (exception, timespan) =>
                    {
                        // TODO
                    });

            try
            {
                IsLoading = true;
                await policy.Execute(async () =>
                {
                    Calendars = await _calendarService.Get();
                });
            }
            finally
            {
                IsLoading = false;
            }
        }
    }
}