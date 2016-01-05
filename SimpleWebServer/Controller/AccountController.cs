using SimpleWebServer.DBSQL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Http;

namespace SimpleWebServer.Controller
{
    public class AccountController : ApiController
    {
        [System.Web.Http.HttpPost]
        public void OnRequestExistUser([FromBody]Int64 uid)
        {
            /// HttpPost 를 붙여줘야, 커스텀한 Url 이 호출 가능하다.
            /// 클래스를 데이터로 보내면, 그냥 받을 수 있으나, int 등을 보내고 싶다면 [FromBody]를 붙이자!
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@uid", uid));

                int result = SqlEx.ExecuteQuery("EXIST_USER", parameters);

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
