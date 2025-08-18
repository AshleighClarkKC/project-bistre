using Latte.Models.Lookups;
using Latte.Models.Results.Base;
using Microsoft.AspNetCore.Mvc;

namespace Latte.API.Controllers;

[ApiController, Route("api/[controller]")]
public class LookupController : ControllerBase
{
    [HttpPost, Route("Create")]
    public Task<BaseResult> CreateAsync(LookupModel model)
    {
        throw new NotImplementedException();
    }

    [HttpGet, Route("Get/{id}")]
    public Task<BaseContentResult<LookupModel>> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    [HttpGet, Route("List/{count}")]
    public Task<BaseContentResult<IEnumerable<LookupModel>>> ListAsync(int count)
    {
        throw new NotImplementedException();
    }

    [HttpPut, Route("Update")]
    public Task<BaseResult> UpdateAsync(LookupModel model) 
    {
        throw new NotImplementedException();
    }

    [HttpDelete, Route("Delete/{id}")]
    public Task<BaseResult> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}