// See https://aka.ms/new-console-template for more information
using ConsoleApp1;
using System.Diagnostics;

Console.WriteLine("テストはじめ！");


// りんご


string appleInitail = "Apple";
FruitsModel apple = new FruitsModel(appleInitail);

ProcessingState ps = await ProcessingVariable.SetupAsync<string?>(
    initial: appleInitail,
    current: apple.Name,
    next: "Pineapple",
    apple.hasNameInitialized,
    onChange: async (args) =>
    {
        apple.Name = args.NewValue;
        apple.hasNameInitialized = args.HasInitialized;
    });
System.Console.WriteLine($"apple.Name = {apple.Name}, apple.hasNameInitialized = {apple.hasNameInitialized}, ps = {ps}");
Debug.Assert(apple.Name == "Pineapple", "りんごの名前はパイナップルだ");
Debug.Assert(apple.hasNameInitialized, "初期化だ");
Debug.Assert(ps == ProcessingState.Initialized, "初期化だ");


// バナナ


string bananaInitail = null;
FruitsModel banana = new FruitsModel(bananaInitail);

ps = await ProcessingVariable.SetupAsync<string?>(
    initial: bananaInitail,
    current: banana.Name,
    next: "Banana",
    banana.hasNameInitialized,
    onChange: async (args) =>
    {
        banana.Name = args.NewValue;
        banana.hasNameInitialized = args.HasInitialized;
    });
System.Console.WriteLine($"banana.Name = {banana.Name}, banana.hasNameInitialized = {banana.hasNameInitialized}, ps = {ps}");
Debug.Assert(banana.Name == "Banana", "バナナの名前はバナナだ");
Debug.Assert(banana.hasNameInitialized, "初期化だ");
Debug.Assert(ps == ProcessingState.Initialized, "初期化だ");


// おわり


System.Console.WriteLine($"テスト完了！");


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
