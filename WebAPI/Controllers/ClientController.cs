using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Entities;
using Business;
using System.Web.Routing;
using System.Web.Http.Description;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/Client")]
    public class ClientController : ApiController
    {
        [HttpGet]
        [Route("~/api/client/quote")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public APIResponse<ClientOrderOutput> RequestQuote([FromBody] ClientOrder clientOrder)
        {
            APIResponse<ClientOrderOutput> apiResponse = new APIResponse<ClientOrderOutput>()
            {
                responseCode = APIResponseCodeEnum.Success,
                result = new APIResponseResult<ClientOrderOutput>()
            };

            try
            {
                var clientOrderOutput = ClientOrderManager.Instance.RequestQuote(clientOrder);
                apiResponse.result.data = clientOrderOutput;
            }
            catch (Exception ex)
            {
                apiResponse.responseCode = APIResponseCodeEnum.InternalServerError;
                apiResponse.result.errorMessage = ex.Message;
                apiResponse.result.errorCode = ErrorCode.FailedCode;
            }

            return apiResponse;
        }
    }
}