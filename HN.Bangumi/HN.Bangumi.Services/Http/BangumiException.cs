using System;
using HN.Bangumi.Models;

namespace HN.Bangumi.Http
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

        public override string Message => Result.Error;
    }
}