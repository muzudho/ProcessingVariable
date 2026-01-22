// See https://aka.ms/new-console-template for more information
using ConsoleApp1;

Console.WriteLine("Hello, World!");

FruitsModel apple = new FruitsModel("Apple");

(ProcessingState ps, apple.hasNameInitialized) = await ProcessingVariable.SetupAsync<string?>(
    current: apple.Name,
    next: "Pineapple",
    apple.hasNameInitialized,
    onChange: async (newValue) =>
    {
        apple.Name = newValue;
    });
System.Console.WriteLine($"apple.Name = {apple.Name}, apple.hasNameInitialized = {apple.hasNameInitialized}, ps = {ps}");

class FruitsModel
{
    public FruitsModel(string? name)
    {
        this.name = name;
    }

    public string? Name
    {
        get { return name; }
        set { name = value; }
    }
    string? name = null;
    public bool hasNameInitialized = false;
}
