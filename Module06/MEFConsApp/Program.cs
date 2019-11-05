using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel;

namespace MEFConsApp
{
    class Program
    {
        //private CompositionContainer _container;
        //private Program()
        //{
        //    var container = new Container();
        //    container.Add(typeof(CustomerBLL);
        //    _container = new CompositionContainer(catalog);
        //    try
        //    {
        //        this._container.ComposeParts(this);
        //    }
        //    catch (CompositionException compositionException)
        //    {
        //        Console.WriteLine(compositionException.ToString());
        //    }
        //}
        static void Main(string[] args)
        {
            Executer executer = new Executer();
            executer.Compose();
        }
    }
}
