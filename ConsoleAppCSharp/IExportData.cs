using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCSharp
{
    public interface IExportData
    {
        string Export();
        int ProductInsert();
        int ProductUpdate();
    }
}
