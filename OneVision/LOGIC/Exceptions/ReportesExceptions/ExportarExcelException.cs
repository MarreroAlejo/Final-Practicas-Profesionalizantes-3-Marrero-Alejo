using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Exceptions.ReportesExceptions
{
    public class ExportarExcelException : Exception
    {
        public ExportarExcelException(string message) : base(message) { }
    }
}
