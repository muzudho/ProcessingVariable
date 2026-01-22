// See https://aka.ms/new-console-template for more information
using ConsoleApp1;
using System.Diagnostics;

Console.WriteLine("テストはじめ！");
ProcessingState ps;

// りんご


string appleInitail = "Apple";
FruitsModel apple = new FruitsModel(appleInitail);


// ［未設定］を検知するテスト
ps = await ProcessingVariable.SetupAsync<string?>(
    initial: appleInitail,
    current: apple.Name,
    next: "Apple",
    apple.hasNameInitialized,
    onChange: async (args) =>
    {
        apple.Name = args.NewValue;
        apple.hasNameInitialized = args.HasInitialized;
    });
System.Console.WriteLine($"apple.Name = {apple.Name}, apple.hasNameInitialized = {apple.hasNameInitialized}, ps = {ps}");
Debug.Assert(apple.Name == "Apple", "りんごの名前はアップルだ");
Debug.Assert(!apple.hasNameInitialized, "未設定だ");
Debug.Assert(ps == ProcessingState.NotSet, "未設定だ");


// ［初期化］を検知するテスト
ps = await ProcessingVariable.SetupAsync<string?>(
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
Debug.Assert(apple.hasNameInitialized, "初期化済みだ");
Debug.Assert(ps == ProcessingState.Initialized, "初期化だ");


// ［修正］を検知するテスト
ps = await ProcessingVariable.SetupAsync<string?>(
    initial: appleInitail,
    current: apple.Name,
    next: "リンゴ",
    apple.hasNameInitialized,
    onChange: async (args) =>
    {
        apple.Name = args.NewValue;
        apple.hasNameInitialized = args.HasInitialized;
    });
System.Console.WriteLine($"apple.Name = {apple.Name}, apple.hasNameInitialized = {apple.hasNameInitialized}, ps = {ps}");
Debug.Assert(apple.Name == "リンゴ", "りんごの名前はリンゴだ");
Debug.Assert(apple.hasNameInitialized, "初期化済みだ");
Debug.Assert(ps == ProcessingState.Modified, "修正だ");


// 未設定値に戻しても［修正］と判定されるテスト
ps = await ProcessingVariable.SetupAsync<string?>(
    initial: appleInitail,
    current: apple.Name,
    next: appleInitail,
    apple.hasNameInitialized,
    onChange: async (args) =>
    {
        apple.Name = args.NewValue;
        apple.hasNameInitialized = args.HasInitialized;
    });
System.Console.WriteLine($"apple.Name = {apple.Name}, apple.hasNameInitialized = {apple.hasNameInitialized}, ps = {ps}");
Debug.Assert(apple.Name == appleInitail, "りんごの名前はアップルだ");
Debug.Assert(apple.hasNameInitialized, "初期化済みだ");
Debug.Assert(ps == ProcessingState.Modified, "修正だ");


// 未設定値から設定しても［修正］と判定されるテスト
ps = await ProcessingVariable.SetupAsync<string?>(
    initial: appleInitail,
    current: apple.Name,
    next: "みかん",
    apple.hasNameInitialized,
    onChange: async (args) =>
    {
        apple.Name = args.NewValue;
        apple.hasNameInitialized = args.HasInitialized;
    });
System.Console.WriteLine($"apple.Name = {apple.Name}, apple.hasNameInitialized = {apple.hasNameInitialized}, ps = {ps}");
Debug.Assert(apple.Name == "みかん", "りんごの名前はみかんだ");
Debug.Assert(apple.hasNameInitialized, "初期化済みだ");
Debug.Assert(ps == ProcessingState.Modified, "修正だ");    // 初期化ではない


// バナナ


string bananaInitail = null;
FruitsModel banana = new FruitsModel(bananaInitail);


// ［未設定］を検知するテスト
ps = await ProcessingVariable.SetupAsync<string?>(
    initial: bananaInitail,
    current: banana.Name,
    next: bananaInitail,
    banana.hasNameInitialized,
    onChange: async (args) =>
    {
        banana.Name = args.NewValue;
        banana.hasNameInitialized = args.HasInitialized;
    });
System.Console.WriteLine($"banana.Name = {banana.Name}, banana.hasNameInitialized = {banana.hasNameInitialized}, ps = {ps}");
Debug.Assert(banana.Name == bananaInitail, "バナナの名前はヌルだ");
Debug.Assert(!banana.hasNameInitialized, "未設定だ");
Debug.Assert(ps == ProcessingState.NotSet, "未設定だ");


// ［初期化］を検知するテスト
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
Debug.Assert(banana.hasNameInitialized, "初期化済みだ");
Debug.Assert(ps == ProcessingState.Initialized, "初期化だ");


// ［修正］を検知するテスト
ps = await ProcessingVariable.SetupAsync<string?>(
    initial: bananaInitail,
    current: banana.Name,
    next: "ブーメラン",
    banana.hasNameInitialized,
    onChange: async (args) =>
    {
        banana.Name = args.NewValue;
        banana.hasNameInitialized = args.HasInitialized;
    });
System.Console.WriteLine($"banana.Name = {banana.Name}, banana.hasNameInitialized = {banana.hasNameInitialized}, ps = {ps}");
Debug.Assert(banana.Name == "ブーメラン", "バナナの名前はブーメランだ");
Debug.Assert(banana.hasNameInitialized, "初期化済みだ");
Debug.Assert(ps == ProcessingState.Modified, "修正だ");


// 未設定値に戻しても［修正］と判定されるテスト
ps = await ProcessingVariable.SetupAsync<string?>(
    initial: bananaInitail,
    current: banana.Name,
    next: bananaInitail,
    banana.hasNameInitialized,
    onChange: async (args) =>
    {
        banana.Name = args.NewValue;
        banana.hasNameInitialized = args.HasInitialized;
    });
System.Console.WriteLine($"banana.Name = {banana.Name}, banana.hasNameInitialized = {banana.hasNameInitialized}, ps = {ps}");
Debug.Assert(banana.Name == bananaInitail, "バナナの名前はヌルだ");
Debug.Assert(banana.hasNameInitialized, "初期化済みだ");
Debug.Assert(ps == ProcessingState.Modified, "修正だ");


// 未設定値から設定しても［修正］と判定されるテスト
ps = await ProcessingVariable.SetupAsync<string?>(
    initial: bananaInitail,
    current: banana.Name,
    next: "モンキーバナナ",
    banana.hasNameInitialized,
    onChange: async (args) =>
    {
        banana.Name = args.NewValue;
        banana.hasNameInitialized = args.HasInitialized;
    });
System.Console.WriteLine($"banana.Name = {banana.Name}, banana.hasNameInitialized = {banana.hasNameInitialized}, ps = {ps}");
Debug.Assert(banana.Name == "モンキーバナナ", "バナナの名前はモンキーバナナだ");
Debug.Assert(banana.hasNameInitialized, "初期化済みだ");
Debug.Assert(ps == ProcessingState.Modified, "修正だ");    // 初期化ではない


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
