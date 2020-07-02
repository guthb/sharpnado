using System;
using Sytem.net;
using System.Lync;

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

        public static Func<TResult> Partial<TParam1, TResult> (
            this Func<TParam1, TResult> func, TParam1 parameter)
        {
            retun() => func(parameter;)
        }

        public static Func<TParam1, Func<TResult<>> Curry<TParam1, TResult> 
            (this Func<TParam1, TResult> func)
        {
            retun parameter => () func(parameter)
        }

        

    }
}