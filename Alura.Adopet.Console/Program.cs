using Alura.Adopet.Console.Commands;

Console.ForegroundColor = ConsoleColor.Green;

try
{
    var commands = new Commands();
    var command = args[0].Trim();
    var commandToBeExecuted = commands[command];

    if (commandToBeExecuted is null)
        Console.WriteLine("Comando inválido!");
    else
        await commandToBeExecuted.ExecuteAsync(args);
}
catch (Exception ex)
{
    // mostra a exceção em vermelho
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"Aconteceu um exceção: {ex.Message}");
}
finally
{
    Console.ForegroundColor = ConsoleColor.White;
}