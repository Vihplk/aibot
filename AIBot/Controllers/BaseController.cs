using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AIBot.Core.Utility;
using Microsoft.AspNetCore.Mvc;

namespace AIBot.Controllers
{
    public class BaseController: Controller
    {
        protected async Task<IActionResult> HandleException(Exception ex)
        {
            switch (ex)
            {
                case RecordNotFound _:
                    return StatusCode(400,ex.Message);

                default:
                    return StatusCode(500, ex.Message);
            }
        }
        protected int UserId
        {
            get
            {
                try
                {
                    return int.Parse(GetClaim(GlobalConfig.Claims.UserId));
                }
                catch (Exception)
                {
                    return 1;
                    throw new UnauthorizedAccessException();
                }
            }
        }

        protected string ApplyRegx(string question)
        {
            return question.Replace("#name#", DisplayName);
        }

        protected string DisplayName
        {
            get
            {
                try
                {
                    return "Hirusha";
                    return  GetClaim(GlobalConfig.Claims.Name);
                }
                catch (Exception)
                {
                    return "Hirusha";
                    throw new UnauthorizedAccessException();
                }
            }
        }
        public string GetClaim(string want)
        {
            var identity = (ClaimsIdentity)User.Identity;
            var claims = identity.Claims;
            for (var i = 0; i < claims.Count(); i++)
            {
                var c = claims.ElementAt(i);
                if (c.Type.Contains(want))
                {
                    return c.Value;
                }
            }
            return null;
        }
    }
}
