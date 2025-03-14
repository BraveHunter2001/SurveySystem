using Microsoft.AspNetCore.Mvc;
using Services;


namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InterviewsController(IInterviewService interviewService) : ControllerBase
{
    [HttpPost("{interviewId}/next")]
    public IActionResult MoveOnNextQuestion([FromRoute]int interviewId, [FromForm]int choosedAnswerId)
    {
        var interview = interviewService.GetInterviewId(interviewId);
        if (interview is null) return NotFound("interview not found");

        var result = interviewService.MoveOnNextQuestion(interview, choosedAnswerId);

        return !result.IsInterviewFinished ? Ok(new { result.NextQuestionId}) : NoContent();
    }
}
