using System;
using System.Threading.Tasks;
using GoLogs.CustomClearance.Ceisa;
using GoLogs.CustomClearance.Models;
using GoLogs.CustomClearance.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

namespace GoLogs.CustomClearance.Controllers
{
    [ApiController, Authorize, Route("[controller]/[action]")]
    public class CeisaController : Controller
    {
        public CeisaController()
        {

        }
        
        [HttpPost]
        public async Task<IActionResult> DocImport(PostImporRequest request)
        {
            try
            {
                var accessToken = Request.Headers[HeaderNames.Authorization];
                var token = accessToken.ToString()[7..];
                var decodeJwtToken = Common.Helper.DecodeJwtToken(accessToken.ToString()[7..]);
                var authSession = await Precheck3rdPartySession();
                var impor = new PostImpor(authSession.AccessToken);
                return Ok(await impor.Execute(request));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private async Task<AuthSession> Precheck3rdPartySession()
        {
            var postLogin = new PostLogin();
            var authResponse = await postLogin.Execute(new AuthRequest()
            {
                Username = "userdemo",
                Password = "Aa12345678"
            });
            authResponse.Item.ExpiredDateTime = DateTime.Now.AddSeconds(authResponse.Item.ExpiresIn);
            return authResponse.Item;
        }
    }
}