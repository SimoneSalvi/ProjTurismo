using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjTurismo.Services
{
    //classe de herança para conexão com o banco de
    //dados e utilizar a mesma instancia para todos os contextos

    public  class SqlConnect
    {
        protected readonly SqlConnection _con; 

        public SqlConnect(string conn)
        {
            _con = new SqlConnection(conn);
            _con.OpenAsync();
        }

        public void Disposible()
        {
            _con.Close();
        }
    }
}
