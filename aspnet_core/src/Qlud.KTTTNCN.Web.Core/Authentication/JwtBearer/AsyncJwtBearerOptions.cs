using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Qlud.KTTTNCN.Web.Authentication.JwtBearer
{
    public class AsyncJwtBearerOptions : JwtBearerOptions
    {
        public readonly List<IAsyncSecurityTokenValidator> AsyncSecurityTokenValidators;

        public AsyncJwtBearerOptions()
        {
            AsyncSecurityTokenValidators = new List<IAsyncSecurityTokenValidator>();
        }
    }

}
