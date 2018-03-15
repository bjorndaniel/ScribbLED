using Ooui;
using Xamarin.Forms;

namespace ScribbLED
{
    class Program
    {
        static void Main(string[] args)
        {
            Forms.Init();
            new Mirror().Publish();
        }
    }
}