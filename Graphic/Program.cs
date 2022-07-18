using System;
using System.Windows.Forms;

namespace GEdit
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //DynamicPropertyManager<ThreeColumns> propertyManager;

            //propertyManager = new DynamicPropertyManager<ThreeColumns>();
            //propertyManager.Properties.Add(
            //    DynamicPropertyManager<ThreeColumns>.CreateProperty<ThreeColumns, string>(
            //        "FourProperty",
            //        t => "Four",
            //        null
            //    ));

            //var p = TypeDescriptor.GetProperties(typeof(ThreeColumns));
            //Console.WriteLine(p.Count); // outputs 4 instead of the 3 real properties

            //var provider = TypeDescriptor.GetProvider(typeof(ThreeColumns));

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Editor());
        }
    }
}
