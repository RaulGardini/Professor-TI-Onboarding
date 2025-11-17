using Microsoft.AspNetCore.Mvc;
using Professor_TI_Onboarding.Models;
using Professor_TI_Onboarding.Services;

namespace Professor_TI_Onboarding.Controllers
{
    [ApiController]
    [Route("api/chat")]
    public class ChatController : ControllerBase
    {
        private readonly OpenAIAgentService _agent;

        public ChatController(OpenAIAgentService agent)
        {
            _agent = agent;
        }

        [HttpPost]
        public async Task<IActionResult> Ask([FromBody] ChatRequest req)
        {
            if (req == null || string.IsNullOrWhiteSpace(req.Question))
                return BadRequest(new { error = "A pergunta é obrigatória." });

            var answer = await _agent.AskAsync(req.Question);

            return Ok(new { answer });
        }
    }
}
