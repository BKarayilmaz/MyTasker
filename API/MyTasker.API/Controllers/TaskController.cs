using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using MyTasker.API.Repositories.Abstract;
using MyTasker.API.Repositories.Concrete;
using MyTasker.Core.Models;
using System.Linq;
using System.Security.Cryptography.Xml;

namespace MyTasker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskModelRepository _taskModelRepository;

        public TaskController(ITaskModelRepository taskModelRepository)
        {
            _taskModelRepository = taskModelRepository;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllTask()
        {
            var result =await _taskModelRepository.GetAllAsync(x => x.IsActive);
            return Ok(result?.OrderBy(x=>x.TaskDate));
        }
        [HttpGet("GetTrash")]
        public async Task<IActionResult> GetTrashTask()
        {
            var result = await _taskModelRepository.GetAllAsync(x=>!x.IsActive);
            return Ok(result);
        }
        [HttpGet("RestoreTask/{id}")]
        public async Task<IActionResult> GetRestoreTask(int id)
        {
            var model=await _taskModelRepository.GetSingleAsync(x=>x.Id==id);
            if (model is null)
                return NotFound();
            model.IsActive = true;
            var result = await _taskModelRepository.UpdateAsync(model);
            return Ok(result);
        }
        [HttpGet("GetFavorite")]
        public async Task<IActionResult> GetFavoritesTask()
        {
            var result = await _taskModelRepository.GetAllAsync(x => x.IsActive && x.IsFavorite);
            return Ok(result);
        }
        [HttpGet("GetAll/{status}")]
        public async Task<IActionResult> GetAllTask(int status)
        {
            var result = await _taskModelRepository.GetAllAsync(x=>(int)x.Status==status && x.IsActive);
            return Ok(result);
        }
        [HttpGet("GetAllSearch/{search}")]
        public async Task<IActionResult> GetAllTask(string search)
        {
            var result = await _taskModelRepository.GetAllAsync(x => (x.Title.ToLower().Contains(search)
            || x.Content.ToLower().Contains(search))&& x.IsActive);
            return Ok(result);
        }
        [HttpGet("GetAllWithDay")]
        public async Task<IActionResult> GetAllWithDayTask()
        {
            var result = await _taskModelRepository.GetAllAsync(x=>x.TaskDate.Date==DateTime.Now.Date &&x.IsActive);
            return Ok(result);
        }
        [HttpGet("GetAllWithDay/{date}")]
        public async Task<IActionResult> GetAllWithDayTask(string date)
        {
            if(DateTime.TryParse(date,out DateTime dateTime))
            {
                var result = await _taskModelRepository.GetAllAsync(x=>x.TaskDate.Date==dateTime.Date && x.IsActive);
                return Ok(result);
            }
            return BadRequest();
           
        }
        [HttpGet("GetThisMonthTaskCount")]
        public async Task<IActionResult> GetThisMonthTaskCount()
        {
            var date=DateTime.Now;
            var dateMin = new DateTime(date.Year, date.Month, 1);
            var dateMax = new DateTime(date.Year, date.Month + 1, 1).AddDays(-1);
            var result = await _taskModelRepository.GetCountAsync(x => x.TaskDate >= dateMin&& x.TaskDate <= dateMax && x.IsActive);
            return Ok(result);
        }
        [HttpGet("id")]
        public async Task<IActionResult> GetTask(int id)
        {
            var result = await _taskModelRepository.GetSingleAsync(x => x.Id == id);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> AddTask([FromBody] TaskModel model)
        {
            var result = await _taskModelRepository.InsertAsync(model);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateTask([FromBody] TaskModel model)
        {
            var result = await _taskModelRepository.UpdateAsync(model);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var result = await _taskModelRepository.RemoveAsync(id);
            return Ok(result);
        }
        [HttpDelete("DeleteRange")]
        public async Task<IActionResult> DeleteTask(List<int> ids)
        {
            var result = await _taskModelRepository.RemoveRangeAsync(ids);
            return Ok(result);
        }
    }
}
