using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using Sample.Application.Interfaces;
using Sample.Domain.Filter;
using Sample.Dto;
using Common.API;
using System.Threading.Tasks;

namespace Sample.Api.Controllers
{
	[Authorize]
    [Route("api/[controller]")]
    public class TesteController : Controller
    {

        private readonly ITesteApplicationService _app;
		private readonly ILogger _logger;


        public TesteController(ITesteApplicationService app, ILoggerFactory logger)
        {
            this._app = app;
			this._logger = logger.CreateLogger<TesteController>();
			
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]TesteFilter filters)
        {
            var result = new HttpResult<TesteDto>(this._logger);
            try
            {
                var searchResult = await this._app.GetByFilters(filters);
                return result.ReturnCustomResponse(this._app, searchResult, filters);


            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Seed - Teste", filters);
            }

        }


        [HttpGet("{id}")]
		public async Task<IActionResult> Get(int id, [FromQuery]TesteFilter filters)
		{
			var result = new HttpResult<TesteDto>(this._logger);
            try
            {
				filters.TesteId = id;
                var returnModel = await this._app.GetOne(filters);
                return result.ReturnCustomResponse(this._app, returnModel);
            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Seed - Teste", id);
            }

		}




        [HttpPost]
        public async Task<IActionResult> Post([FromBody]TesteDtoSpecialized dto)
        {
            var result = new HttpResult<TesteDto>(this._logger);
            try
            {
                var returnModel = await this._app.Save(dto);
                return result.ReturnCustomResponse(this._app, returnModel);

            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Seed - Teste", dto);
            }
        }



        [HttpPut]
        public async Task<IActionResult> Put([FromBody]TesteDtoSpecialized dto)
        {
            var result = new HttpResult<TesteDto>(this._logger);
            try
            {
                var returnModel = await this._app.SavePartial(dto);
                return result.ReturnCustomResponse(this._app, returnModel);

            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Seed - Teste", dto);
            }
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(TesteDto dto)
        {
            var result = new HttpResult<TesteDto>(this._logger);
            try
            {
                await this._app.Remove(dto);
                return result.ReturnCustomResponse(this._app);
            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Seed - Teste", dto);
            }
        }
    }
}
