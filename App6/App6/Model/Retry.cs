using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace App6.Model
{
    public  class Retry
    {
        public void DoWithRetry(Action action, TimeSpan retryInterval, int maxTryCount = 3)
        {
            if (maxTryCount <= 0)
                throw new ArgumentOutOfRangeException(nameof(maxTryCount));

            while (true)
            {
                try
                {
                    action();
                    break; // success!
                }
                catch
                {
                    if (--maxTryCount == 0)
                        throw;
                    Thread.Sleep(retryInterval);
                }
            }
        }

     

        //    public static void Do(
        //        Action action,
        //        TimeSpan retryInterval,
        //        int maxAttemptCount = 3)
        //    {
        //        Do<object>(() =>
        //        {
        //            action();
        //            return null;
        //        }, retryInterval, maxAttemptCount);
        //    }

        //    public static T Do<T>(
        //        Func<T> action,
        //        TimeSpan retryInterval,
        //        int maxAttemptCount = 3)
        //    {
        //        var exceptions = new List<Exception>();

        //        for (int attempted = 0; attempted < maxAttemptCount; attempted++)
        //        {
        //            try
        //            {
        //                if (attempted > 0)
        //                {
        //                    Thread.Sleep(retryInterval);
        //                }
        //                return action();
        //            }
        //            catch (Exception ex)
        //            {
        //                exceptions.Add(ex);
        //            }
        //        }
        //        throw new AggregateException(exceptions);
        //    }
    }
}
