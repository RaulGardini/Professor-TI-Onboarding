using OpenAI.Chat;

namespace Professor_TI_Onboarding.Services
{
    public class OpenAIAgentService
    {
        private readonly ChatClient _chatClient;
        private readonly string _knowledgeBase;

        public OpenAIAgentService(IConfiguration config)
        {
            var apiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY")
                         ?? config["OpenAI:ApiKey"];

            if (string.IsNullOrWhiteSpace(apiKey))
                throw new InvalidOperationException("API KEY não encontrada.");

            // Na versão 2.7.0, usamos ChatClient diretamente
            _chatClient = new ChatClient("gpt-4o-mini", apiKey);

            var kbPath = Path.Combine(AppContext.BaseDirectory, "Data", "KnowledgeBase.txt");
            _knowledgeBase = File.Exists(kbPath)
                ? File.ReadAllText(kbPath)
                : "Nenhuma base de conhecimento encontrada.";
        }

        public async Task<string> AskAsync(string question)
        {
            var systemPrompt = $@"
Você é o PROFESSOR TI ONBOARDING.
Explique de forma simples e direta.
Use a base de conhecimento abaixo sempre que possível:

BASE DE CONHECIMENTO:
{_knowledgeBase}
";

            // Na versão 2.7.0, a API mudou completamente
            var messages = new List<ChatMessage>
            {
                new SystemChatMessage(systemPrompt),
                new UserChatMessage(question)
            };

            var completion = await _chatClient.CompleteChatAsync(messages);

            return completion.Value.Content[0].Text;
        }
    }
}