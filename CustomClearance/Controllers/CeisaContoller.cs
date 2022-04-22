using System;
using System.Threading.Tasks;
using CustomClearance.Context;
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
        public CeisaController(GoLogsContext context)
        {
            Context = context;
        }

        private GoLogsContext Context;
        
        [HttpPost()]
        public async Task<IActionResult> DocImport(
            PostImporRequest request,
            [FromQuery] bool isFinal
        )
        {
            try
            {
                var accessToken = Request.Headers[HeaderNames.Authorization];
                var token = accessToken.ToString()[7..];
                var decodeJwtToken = Common.Helper.DecodeJwtToken(accessToken.ToString()[7..]);
                var authSession = await Precheck3rdPartySession();
                var impor = new PostImpor(Context);
                impor.IsFinal = isFinal;
                impor.Token = authSession.AccessToken;
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
                Username = "gologs", // "userdemoscs", // "userdemo",
                Password = "GoLogs@123"// "Scs123456" // "Aa12345678"
            });
            authResponse.Item.ExpiredDateTime = DateTime.Now.AddSeconds(authResponse.Item.ExpiresIn);
            return authResponse.Item;
        }

        [HttpGet]
        public async Task<IActionResult> CheckStatus([FromQuery] string nomorAju)
        {
            try
            {
                var accessToken = Request.Headers[HeaderNames.Authorization];
                var token = accessToken.ToString()[7..];
                var decodeJwtToken = Common.Helper.DecodeJwtToken(accessToken.ToString()[7..]);
                var authSession = await Precheck3rdPartySession();
                var impor = new PostImpor(Context);
                impor.Token = authSession.AccessToken;
                var response = await impor.CheckStatus(nomorAju);
                var result = Newtonsoft.Json.JsonConvert.DeserializeObject(response);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}