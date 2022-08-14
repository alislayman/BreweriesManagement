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
    public class BeerController : ApiController
    {
        [HttpGet]
        public APIResponse<GetBeersByBreweryOutput> Get(Guid breweryID)
        {
            APIResponse<GetBeersByBreweryOutput> apiResponse = new APIResponse<GetBeersByBreweryOutput>()
            {
                responseCode = APIResponseCodeEnum.Success,
                result = new APIResponseResult<GetBeersByBreweryOutput>()
            };

            try
            {
                var getBeersByBreweryOutput = BeerManager.Instance.GetBeersByBrewery(new GetBeersByBreweryInput()
                {
                    BreweryID = breweryID
                });

                apiResponse.result.data = getBeersByBreweryOutput;
            }
            catch (Exception ex)
            {
                apiResponse.responseCode = APIResponseCodeEnum.InternalServerError;
                apiResponse.result.errorMessage = ex.Message;
                apiResponse.result.errorCode = ErrorCode.FailedCode;
            }

            return apiResponse;
        }

        [HttpPost]
        public APIResponse<Beer> Post([FromBody] Beer beer)
        {
            APIResponse<Beer> apiResponse = new APIResponse<Beer>()
            {
                responseCode = APIResponseCodeEnum.Success,
                result = new APIResponseResult<Beer>()
            };

            try
            {
                AddItemOutput<Beer> addBeerOutput = BeerManager.Instance.AddBeer(beer);
                switch (addBeerOutput.Result)
                {
                    case ActionResult.Succeeded:
                        apiResponse.result.data = addBeerOutput.Item; break;
                    case ActionResult.Failed:
                        apiResponse.responseCode = APIResponseCodeEnum.Conflict;
                        apiResponse.result.errorMessage = addBeerOutput.Message;
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

        [HttpDelete]
        public APIResponse<Beer> Delete(Guid beerID)
        {
            APIResponse<Beer> apiResponse = new APIResponse<Beer>()
            {
                responseCode = APIResponseCodeEnum.Success,
                result = new APIResponseResult<Beer>()
            };

            try
            {
                DeleteItemOutput<Beer> deletedBeerOutput = BeerManager.Instance.DeleteBeer(beerID);
                switch (deletedBeerOutput.Result)
                {
                    case ActionResult.Succeeded:
                        apiResponse.result.data = deletedBeerOutput.Item; break;
                    case ActionResult.Failed:
                        apiResponse.responseCode = APIResponseCodeEnum.NotFound;
                        apiResponse.result.errorMessage = deletedBeerOutput.Message;
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