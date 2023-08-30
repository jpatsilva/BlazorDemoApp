using BlazorDemoApp.DataAccessLayer;
using BlazorDemoApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;

namespace BlazorDemoApp.Controller
{
	[Route("api/[controller]")]
	[ApiController]
	public class GPUController : ControllerBase
	{
		GPUDataAccessLayer objGPU = new GPUDataAccessLayer();

		[HttpGet]
		public async Task<object> Get()
		{
			var data = objGPU.GetAllGPUs().Result.ToList();
			var queryString = Request.Query;
			if(queryString.Keys.Contains("$inlinecount"))
			{
				StringValues Skip;
				StringValues Take;
				int skip = (queryString.TryGetValue("$skip", out Skip)) ? Convert.ToInt32(Skip[0]) : 0;
				int top = (queryString.TryGetValue("$top", out Take)) ? Convert.ToInt32(Take[0]) : data.Count();
				var count = data.Count();
				return new { Items = data.Skip(skip).Take(top), Count = count };

			}
			else
			{
				return data;
			}
		}

		[HttpPost]
		public void Post([FromBody] GPU gpu)
		{
			objGPU.AddGPU(gpu);
		}

		[HttpPut]
		public void Put([FromBody] GPU gpu)
		{
			objGPU.UpdateGPU(gpu);
		}

		[HttpDelete("{id}")]
		public void Delete(string id) 
		{
			objGPU.DeleteGPU(id);
		}
	}
}
