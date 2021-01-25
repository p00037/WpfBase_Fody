using System;

namespace WpfBase.UseCase.Exceptions
{
    public class SaveErrorMessageExcenption : Exception
    {
        public SaveErrorMessageExcenption(string message) : base(message)
        {
        }
    }
}
