using System;
using Sytem.net;

namespace csharpfunc
{
    public static class Extentions
    {
        public static T WithRetry<T> (this. Func<T> action)
        {
            var result = default(T);
            int retryCount = 0;

            bool succesful = false;
            do
            {
                try
                {
                    result = action()
                    succesful = true;

                }
                catch (WebException ex)
                {
                    retryCount ++;

                }
            }while (retryCount < 3 && !succesful);

            return result;
        }
    }
}