using CSnakes.Runtime;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace app;

class Program
{
    static void Main(string[] args)
    {
        var builder = Host.CreateApplicationBuilder(args);
        var pythonHome = Path.Join(Environment.CurrentDirectory, "../PythonFiles");

        builder.Services.WithPython().WithHome(pythonHome).FromRedistributable().WithPipInstaller().WithVirtualEnvironment(Path.Join(pythonHome, ".venv"));

        var app = builder.Build();

        var pythonEnvironment = app.Services.GetRequiredService<IPythonEnvironment>();

        var pythonModule = pythonEnvironment.Example();

        var ollamaModule = pythonEnvironment.OllamaTest();

        string userEntry = Console.ReadLine();


        var response = ollamaModule.Prompt(userEntry);

        Console.WriteLine(pythonModule.SumTwoNumbers(1, 2));

        Console.WriteLine(response);




    }
}
