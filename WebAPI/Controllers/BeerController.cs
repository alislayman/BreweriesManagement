using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Entities;
using Business;

namespace WebAPI.Controllers
{
    public class BeerController : ApiController
    {
        [HttpGet]
        public APIResponse<GetBeersByBreweryOutput> GetBeersByBrewery(Guid breweryID)
        {
            APIResponse<GetBeersByBreweryOutput> apiResponse = new APIResponse<GetBeersByBreweryOutput>()
            {
                responseCode = APIResponseCodeEnum.Success,
                result = new APIResponseResult<GetBeersByBreweryOutput>()
                {
                }
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

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}