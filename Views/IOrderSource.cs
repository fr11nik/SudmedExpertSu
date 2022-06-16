using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudExpertSU.Views
{
    interface IOrderSource
    {
        DataTable Data { get; set; }
    }
}
