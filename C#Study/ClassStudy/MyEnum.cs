using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassStudy
{
    internal class MyEnum
    {

    }
    //[Flags]
    enum FilePermissions
    {
        Read = 1,//0001
        Load = 2,//0010
        Execute = 4,//0100
        Delete = 8,//1000

        FullControl = Read | Load | Execute |Delete,//所有操作的集合
    }
}
