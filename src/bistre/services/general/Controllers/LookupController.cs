using Bistre.Data.Models;
using Bistre.Data.Models.Commands.Lookup;
using Bistre.Data.Models.Queries.Lookup;
using Bistre.Data.Models.Results.Base;
using LiteBus.Commands.Abstractions;
using LiteBus.Queries.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Bistre.Services.General.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class LookupController(ICommandMediator commandMediator, IQueryMediator queryMediator, ILogger<LookupController> logger) : ControllerBase
    {
        private readonly ICommandMediator _commandMediator = commandMediator;
        private readonly IQueryMediator _queryMediator = queryMediator;
        private readonly ILogger<LookupController> _logger = logger;

        [HttpPost, Route("Create")]
        [ProducesResponseType((int)HttpStatusCode.Created, Type = typeof(StatusCodeResult)), ProducesErrorResponseType(typeof(StatusCodeResult))]
        public async Task<ActionResult> CreateAsync([FromBody] CreateLookupCommandModel model)
        {
            BaseCommandResult result = new();

            try
            {
                await _commandMediator.SendAsync(model);
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
            }

            var status = result.Success
                ? StatusCode(result.Status, null)
                : StatusCode(result.Status, result.Message);

            return status;

        }

        [HttpGet, Route("Get/{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(StatusCodeResult)), ProducesErrorResponseType(typeof(StatusCodeResult))]
        public async Task<ActionResult> GetByIdAsync(int id)
        {
            GetLookupQueryModel queryModel = new()
            {
                Id = id
            };

            BaseQueryResult<LookupModel> queryResult = new();

            try
            {
                queryResult = await _queryMediator.QueryAsync(queryModel);
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
            }

            var status = queryResult.Success
                ? StatusCode(queryResult.Status, queryResult.Data)
                : StatusCode(queryResult.Status, queryResult.Message);

            return status;
        }


        [HttpGet, Route("List/{limit}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(StatusCodeResult)), ProducesErrorResponseType(typeof(StatusCodeResult))]
        public async Task<ActionResult> ListAsync(int limit)
        {
            ListLookupQueryModel queryModel = new()
            {
                Limit = limit
            };

            BaseQueryResult<IReadOnlyList<LookupModel>> queryResult = new();

            try
            {
                queryResult = await _queryMediator.QueryAsync(queryModel);
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
            }

            var status = queryResult.Success
                ? StatusCode(queryResult.Status, queryResult.Data)
                : StatusCode(queryResult.Status, queryResult.Message);

            return status;
        }

        [HttpPut, Route("Update")]
        [ProducesResponseType((int)HttpStatusCode.Accepted, Type = typeof(StatusCodeResult)), ProducesErrorResponseType(typeof(StatusCodeResult))]
        public async Task<ActionResult> UpdateAsync([FromBody] UpdateLookupCommandModel model)
        {
            BaseCommandResult queryResult = new();

            try
            {
                queryResult = await _commandMediator.SendAsync(model);
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
            }

            var status = queryResult.Success
                ? StatusCode(queryResult.Status, null)
                : StatusCode(queryResult.Status, queryResult.Message);

            return status;
        }

        [HttpDelete, Route("Delete/{id}")]
        [ProducesResponseType((int)HttpStatusCode.Accepted, Type = typeof(StatusCodeResult)), ProducesErrorResponseType(typeof(StatusCodeResult))]
        public async Task<ActionResult> DeleteByIdAsync(int id)
        {
            DeleteLookupCommandModel model = new()
            {
                Id = id
            };

            BaseCommandResult queryResult = new();

            try
            {
                queryResult = await _commandMediator.SendAsync(model);
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
            }

            var status = queryResult.Success
                ? StatusCode(queryResult.Status, null)
                : StatusCode(queryResult.Status, queryResult.Message);

            return status;
        }

    }
}
