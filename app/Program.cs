using System.Threading.Tasks;
using CSnakes.Runtime;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace app;

class Program
{
    static async Task Main(string[] args)
    {
        var builder = Host.CreateApplicationBuilder(args);
        var pythonHome = Path.Join(Environment.CurrentDirectory, "../PythonFiles");

        builder.Services.WithPython().WithHome(pythonHome).FromRedistributable().WithPipInstaller().WithVirtualEnvironment(Path.Join(pythonHome, ".venv"));

        var app = builder.Build();

        var pythonEnvironment = app.Services.GetRequiredService<IPythonEnvironment>();

        // var pythonModule = pythonEnvironment.Example();

        // var ollamaModule = pythonEnvironment.OllamaTest();

        var chromaDbModule = pythonEnvironment.ChromadbTest();


        // Console.WriteLine(pythonModule.SumTwoNumbers(1, 2));

        /*
                Console.WriteLine("Please write a prompt to talk to deepseek.");
                string userEntry = "";

                while (userEntry != "exit")
                {
                    userEntry = Console.ReadLine();

                    if (userEntry != "exit")
                    {

                        var response = await ollamaModule.Prompt(userEntry);

                        Console.WriteLine(response);

                        Console.WriteLine("Please write a new prompt, or exit to quit.");
                    }
                }
        */
        var chromaTest = chromaDbModule.CreateAndFetchFromChromadb("Which document contains information about fruits?");

        Console.WriteLine(chromaTest);


    }
}
