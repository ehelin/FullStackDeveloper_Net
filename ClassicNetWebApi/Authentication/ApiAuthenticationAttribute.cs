using System;
using System.Threading;
using System.Threading.Tasks;
using ClassicNetWebApi.Authentication;
using System.Web.Http.Filters;

namespace ClassicNetWebApi
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class ApiAuthenticationAttribute : Attribute, IAuthenticationFilter
    {
        public bool AllowMultiple => throw new NotImplementedException();

        public Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            var auth = context.Request.Headers.Authorization;

            if (auth == null 
                   || string.IsNullOrEmpty(auth.Scheme) 
                        || string.IsNullOrEmpty(auth.Parameter) 
                           ||  auth.Scheme != "ClassicNetScheme"
                                || auth.Parameter != "ClassicNetToken") 
            {
                context.ErrorResult = new AuthenticationFailureResult();
                return Task.FromResult(0);
            }

            return Task.FromResult(0);
        }

        public Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            return Task.FromResult(0);
        }
    }
}