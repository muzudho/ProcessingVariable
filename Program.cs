// See https://aka.ms/new-console-template for more information
using ConsoleApp1;

Console.WriteLine("Hello, World!");

AppleModel apple = new AppleModel(string.Empty);

var ps = await ProcessingVariable.SetupAsync<AppleModel>(
    current: apple,
    next: new AppleModel("Apple"),
    apple.hasAppleInitialized,
    onChange: async (newValue) =>
    {
        apple = newValue;
    });
System.Console.WriteLine($"ps = {ps}");

class AppleModel
{
    public AppleModel(string appleStr)
    {
        this.appleStr = appleStr;
    }

    public string? AppleStr
    {
        get { return appleStr; }
        set { appleStr = value; }
    }
    string? appleStr = null;
    public bool hasAppleInitialized = false;
}
