//using System;
//using Microsoft.AspNetCore.Mvc.Filters;
//using Microsoft.AspNetCore.Mvc;
//using System.Security.Claims;
//using Microsoft.AspNetCore.Authorization;
//using System.Threading.Tasks;

//namespace WebApi.ClaimsBased
//{
//    public class MinimumAgeHandler : AuthorizationHandler<MinimumAgeRequirement>
//    {
//        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinimumAgeRequirement requirement)
//        {
//            if (!context.User.HasClaim(c => c.Type == ClaimTypes.DateOfBirth &&
//                                  c.Issuer == "http://contoso.com"))
//            {
//                return null;
//            }


//            var dateOfBirth = Convert.ToDateTime(context.User.FindFirst(
//                c => c.Type == ClaimTypes.DateOfBirth && c.Issuer == "http://contoso.com").Value);

//            int calculatedAge = DateTime.Today.Year - dateOfBirth.Year;
//            if (dateOfBirth > DateTime.Today.AddYears(-calculatedAge))
//            {
//                calculatedAge--;
//            }

//            if (calculatedAge >= 21)
//            {
//                context.Succeed(requirement);
//            }

//            return null;
//            //throw new NotImplementedException();
//        }
//    }
//}
