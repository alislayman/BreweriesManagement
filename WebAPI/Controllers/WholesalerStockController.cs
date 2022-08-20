using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Entities;
using Business;
using System.Web.Routing;

namespace WebAPI.Controllers
{
    public class WholesalerStockController : ApiController
    {
        [HttpPut]
        [Route("~/api/wholesalerstock")]
        public APIResponse<WholesalerStock> AddOrUpdateStock([FromBody] WholesalerStock wholesalerStock)
        {
            APIResponse<WholesalerStock> apiResponse = new APIResponse<WholesalerStock>()
            {
                responseCode = APIResponseCodeEnum.Success,
                result = new APIResponseResult<WholesalerStock>()
            };

            try
            {
                AddItemOutput<WholesalerStock> addWholesalerStockOutput = WholesalerStockManager.Instance.AddOrUpdateStock(wholesalerStock);
                switch (addWholesalerStockOutput.Result)
                {
                    case ActionResult.Succeeded:
                        apiResponse.result.data = addWholesalerStockOutput.Item; break;
                    case ActionResult.Failed:
                        apiResponse.responseCode = APIResponseCodeEnum.Conflict;
                        apiResponse.result.errorMessage = addWholesalerStockOutput.Message;
                        apiResponse.result.errorCode = ErrorCode.FailedCode;
                        break;
                }
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