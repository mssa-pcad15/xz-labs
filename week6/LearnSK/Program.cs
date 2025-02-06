using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel;

ILoggerFactory logger = NullLoggerFactory.Instance;
var builder = Kernel.CreateBuilder();
builder.Services.AddSingleton(logger);

Kernel.CreateBuilder()
    .AddAzureOpenAIChatCompletion(
    "gpt-4o-mini",                   // Azure OpenAI *Deployment Name*
    "https://pcadai.openai.azure.com/",    // Azure OpenAI *Endpoint*
    "...your Azure OpenAI Key...",          // Azure OpenAI *Key*
    serviceId: "Azure_curie"                // alias used in the prompt templates' config.json

);

