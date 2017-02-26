using System.Diagnostics;

namespace WcfEnsFx
{
    abstract class StateBase
    {
        [Conditional("DEBUG")]
        static protected void ShowError()
        {
            Debug.WriteLine("Invalid operation performed!");
        }

        [Conditional("DEBUG")]
        static protected void ShowError(string msg)
        {
            ShowError();
            Debug.WriteLine(" Message: " + msg);
        }
    }
}
