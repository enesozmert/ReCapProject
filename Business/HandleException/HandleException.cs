using System;
using System.Collections.Generic;
using System.Text;

namespace Business.HandleException
{
    public class HandleException : IException
    {
        public static string HandleExMessage { get; set; }
        public static string Error(Action action)
        {
            try
            {
                action.Invoke();
            }
            catch (Exception ex)
            {
                HandleExMessage = ex.Message.ToString();
            }
            finally
            {

            }
            return HandleExMessage;
        }
    }
}
