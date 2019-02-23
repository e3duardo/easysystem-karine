using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Connection
{
    public static class Connection
    {
        public static string String()
        {
            return "Data Source=127.0.0.1;Initial Catalog=KarineBD;Persist Security Info=True;User ID=sa;Password=temporal";
        }
        public static string StringPostgree()
        {
            return "Server=127.0.0.1;Port=5432;User Id=postgres;Password=temporal;Database=KarineBD;";
            //return "Server=192.168.1.102;Port=5432;User Id=postgres;Password=temporal;Database=KarineBD;";
        }
    }
}
