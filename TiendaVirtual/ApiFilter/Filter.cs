using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TiendaVirtual.Util;

namespace TiendaVirtual.ApiFilter
{
    public class Filter :  ActionFilterAttribute
    {
        private GeneraToken Gtoken = new GeneraToken();

        public Filter()
        {
        }

        public override void OnActionExecuting(ActionExecutingContext token)
        {
            try
            {
                if(token != null)
                Gtoken.ValidateJwtToken(token.HttpContext.Request.Headers["TOKEN"].ToString());
            }
            catch (Exception)
            {
                throw;
            }
            
        }


    }
}
