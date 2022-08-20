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
        [Route("~/api/beers")]
        public APIResponse<GetBeersByBreweryOutput> GetBeersByBreweryID(Guid breweryID)
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
        [Route("~/api/beer")]
        public APIResponse<Beer> AddBeer([FromBody] Beer beer)
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
        [Route("~/api/beer")]
        public APIResponse<Beer> DeleteBeer(Guid beerID)
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