using MakeMyTripAPI.Interfaces;
using MakeMyTripAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakeMyTripAPI.Services
{
    public class LoginService:Repository<LoginInfo>,ILogin
    {
        public LoginService(MakeMyTripDBContext context):base(context)
        {

        }
    }
}
