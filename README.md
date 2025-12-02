# Professor TI Onboarding

API simples de chatbot para onboarding em TI usando OpenAI.

## Como Rodar o Projeto

### 1. Pré-requisitos
- .NET 8.0 ou superior
- Conta na OpenAI (para obter API Key)

### 2. Configuração

Clone o repositório:
```bash
git clone https://github.com/seu-usuario/Professor-TI-Onboarding.git
cd Professor-TI-Onboarding
```

Instale as dependências:
```bash
dotnet restore
```

### 3. Configurar a API Key

Crie um arquivo `.env` na raiz do projeto:
```
OPENAI_API_KEY=sua-chave-aqui
```

### 4. Executar
```bash
dotnet run
```

Acesse o Swagger em: `https://localhost:PORTA/swagger`

## Estrutura do Projeto
```
├── Controllers/      # Endpoints da API
├── Services/         # Lógica de negócio
├── Models/           # Modelos de dados
├── Data/             # Base de conhecimento
└── Program.cs        # Configuração inicial
```

## Tecnologias

- ASP.NET Core Web API
- OpenAI API (GPT-4o-mini)
- DotNetEnv

## Licença

MIT