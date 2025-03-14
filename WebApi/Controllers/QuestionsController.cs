using Microsoft.AspNetCore.Mvc;
using Services;
using WebApi.ViewModels;


namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class QuestionsController(IQuestionService questionService) : ControllerBase
{
    [HttpGet("{id}")]
    public IActionResult GetQuestionById([FromRoute] int id)
    {
        var question = questionService.GetQuestionById(id);
        if (question is null) return NotFound("Question not fount");

        var questionViewModel = new QuestionViewModel(question);
        return Ok(questionViewModel);
    }
}
