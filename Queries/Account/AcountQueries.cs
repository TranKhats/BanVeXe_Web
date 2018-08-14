using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using BanVeXe_Web.Models;
using Microsoft.AspNetCore.Http;
using Snickler.EFCore;

namespace BanVeXe_Web.Queries.Account
{
    public class AcountQueries
    {
        public static bool Login(string userName,string password)
        {
            var entity = new QUANLIXEContext();            
            int res=0;
            entity.LoadStoredProc("dbo.log_in")
                .WithSqlParam("@username",userName)
                .WithSqlParam("@password",password)
                .ExecuteStoredProc((handler) =>
                {
                    res =(int) handler.ReadToValue<int>();
                });
            //var result = (from account in entity.Account
            //               where account.Username == userName && account.Password==passWord
            //               select account.Id).FirstOrDefault();
            //return result!=null;
            return (res == 1);
        }

       
    }
}
