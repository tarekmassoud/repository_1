using MediatR;
using Microsoft.AspNetCore.Mvc;
using UMS.Application.Entities.Course.Commands.InsertCourse;
using UMS.Application;
using UMS.Application.Entities.Course.Commands;
using UMS.Domain.Models;
using UMS.Persistence.Models;
using Course = UMS.Domain.Models.Course;

namespace UMS.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]

public class UMSController : ControllerBase
{

    private readonly IMediator _mediator;

    public UMSController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    

    
        
    [HttpPost("InsertCourseID")]
    public async Task<IActionResult> InsertCourse([FromRoute] Course id)
    {
        return Ok(await _mediator.Send(new InsertCourseCommand(id)));
    }
    
}