using SimpleContents;
using SimpleWebServer.DBSQL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Http;

namespace SimpleWebServer.Controller
{
    public class AccountController : ApiController
    {
        /// <summary>
        /// 클라이언트가 호출하는 로그인 함수
        /// HttpPost 설정을 해줘야 호출된다.
        /// </summary>
        /// <param name="model"></param>
        [System.Web.Http.HttpPost]
        public void OnRequestLogin(AccountData model)
        {
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@UID", model.Uid));
                parameters.Add(new SqlParameter("@Name", model.name));

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
