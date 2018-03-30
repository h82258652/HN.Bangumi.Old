using System;
using HN.Bangumi.Uwp.Models;

namespace HN.Bangumi.Uwp.Services
{
    public class BangumiException : Exception
    {
        public ErrorResult Result { get; }

        public BangumiException(ErrorResult errorResult)
        {
            if (errorResult == null)
            {
                throw new ArgumentNullException(nameof(errorResult));
            }

            Result = errorResult;
        }
    }
}