using Bistre.Data.Models;
using Bistre.Data.Models.Commands.ItemMasterSummary;
using Bistre.Data.Models.Queries.ItemMasterSummary;
using Bistre.Data.Models.Results.Base;
using LiteBus.Commands.Abstractions;
using LiteBus.Queries.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace Bistre.Services.General.Controllers;

[ApiController, Route("api/[controller]")]
public class ItemMasterController(ICommandMediator commandMediator, IQueryMediator queryMediator, ILogger<ItemMasterController> logger) : ControllerBase
{
    private readonly ICommandMediator _commandMediator = commandMediator;
    private readonly IQueryMediator _queryMediator = queryMediator;
    private readonly ILogger<ItemMasterController> _logger = logger;

    [HttpPost, Route("Create")]
    [ProducesResponseType((int)HttpStatusCode.Created, Type = typeof(StatusCodeResult)), ProducesErrorResponseType(typeof(StatusCodeResult))]
    public async Task<ActionResult> CreateAsync([FromBody] CreateItemMasterSummaryCommandModel model)
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

        return StatusCode(result.Status, JsonSerializer.Serialize(result));
    }

    [HttpGet, Route("Get/{id}")]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(StatusCodeResult)), ProducesErrorResponseType(typeof(StatusCodeResult))]
    public async Task<ActionResult> GetByIdAsync(int id)
    {
        GetItemMasterSummaryQueryModel query = new()
        {
            Id = id
        };

        BaseQueryResult<ItemMasterSummaryModel> result = new();

        try
        {
            result = await _queryMediator.QueryAsync(query);
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Error, ex.Message);
        }

        return StatusCode(result.Status, JsonSerializer.Serialize(result));
    }

    [HttpGet, Route("List/{limit}")]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(StatusCodeResult)), ProducesErrorResponseType(typeof(StatusCodeResult))]
    public async Task<ActionResult> ListAsync(int limit)
    {
        ListItemMasterSummaryQueryModel query = new()
        {
            Limit = limit
        };

        BaseQueryResult<IQueryable<ItemMasterSummaryModel>> result = new ();

        try
        {
            result = await _queryMediator.QueryAsync(query);
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Error, ex.Message);
        }

        return StatusCode(result.Status, JsonSerializer.Serialize(result));
    }

    [HttpPut, Route("Update")]
    [ProducesResponseType((int)HttpStatusCode.Accepted, Type = typeof(StatusCodeResult)), ProducesErrorResponseType(typeof(StatusCodeResult))]
    public async Task<ActionResult> UpdateAsync([FromBody] UpdateItemMasterSummaryCommandModel model)
    {
        BaseCommandResult result = new ();

        try
        {
            result = await _commandMediator.SendAsync(model);
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Error, ex.Message);
        }

        return StatusCode(result.Status, JsonSerializer.Serialize(result));
    }


}