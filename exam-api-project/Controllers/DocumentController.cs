using ExamAPI.Common;
using ExamAPI.Models.ViewModels;
using ExamAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace ExamAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly IDocumentRepository repository;

        public DocumentController(IDocumentRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet("{dataareaid}")]
        public async Task<IActionResult> Get(string dataareaid)
        {
            var data = await repository.Get(dataareaid);
            return Ok(new ResponseData<List<DocumentViewModel>>
            {
                code = HttpStatusCode.OK,
                data = data
            });
        }
    }
}