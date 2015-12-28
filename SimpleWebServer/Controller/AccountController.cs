using SimpleWebServer.DBSQL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace SimpleWebServer.Controller
{
    public class AccountController : ApiController
    {
        [System.Web.Http.HttpGet]
        public void OnRequestLogin(UInt64 uid, string name)
        {
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@UID", uid));
                parameters.Add(new SqlParameter("@Name", name));

                int result = SqlEx.ExecuteQuery("LOGIN_PROCEDURE", parameters);

                switch (result)
                {
                    case 0:
                        {
                            Console.WriteLine("로그인 성공!");
                            break;
                        }

                    case 1:
                        {
                            Console.WriteLine("존재하지 않는 아이디!");
                            break;
                        }

                    default:
                        throw new Exception(string.Format("[Login Exception] Error Code : {0}", result));
                }
            }
            catch (Exception e)
            {
                throw new Exception(string.Format("[Login Exception] Message : {0}", e.Message));
            }
        }
    }
}
