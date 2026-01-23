// See https://aka.ms/new-console-template for more information
using ConsoleApp1;
using System.Diagnostics;

Console.WriteLine("テストはじめ！");
ProcessingState ps;


// りんご


string? appleInitail = "Apple";
FruitsModel<string?> apple = new FruitsModel<string?>(appleInitail);


// ［未設定］を検知するテスト
ps = await ProcessingVariable.SetupAsync<string?>(
    initial: appleInitail,
    current: apple.Value,
    next: "Apple",
    apple.hasValueInitialized,
    onChange: async (args) =>
    {
        System.Console.WriteLine($"{args.OldValue}→{args.NewValue}。 initial:{args.InitialValue}, initialized:{args.HasInitialized}");
        apple.Value = args.NewValue;
        apple.hasValueInitialized = args.HasInitialized;
    });
System.Console.WriteLine($"apple.Value = {apple.Value}, apple.hasValueInitialized = {apple.hasValueInitialized}, ps = {ps}, ps.IsChanged() = {ps.IsChanged()}");
Debug.Assert(apple.Value == "Apple", "りんごの名前はアップルだ");
Debug.Assert(!apple.hasValueInitialized, "未設定だ");
Debug.Assert(ps == ProcessingState.NotSet, "未設定だ");
Debug.Assert(!ps.IsChanged(), "変更無し");


// ［初期化］を検知するテスト
ps = await ProcessingVariable.SetupAsync<string?>(
    initial: appleInitail,
    current: apple.Value,
    next: "Pineapple",
    apple.hasValueInitialized,
    onChange: async (args) =>
    {
        System.Console.WriteLine($"{args.OldValue}→{args.NewValue}。 initial:{args.InitialValue}, initialized:{args.HasInitialized}");
        apple.Value = args.NewValue;
        apple.hasValueInitialized = args.HasInitialized;
    });
System.Console.WriteLine($"apple.Value = {apple.Value}, apple.hasValueInitialized = {apple.hasValueInitialized}, ps = {ps}, ps.IsChanged() = {ps.IsChanged()}");
Debug.Assert(apple.Value == "Pineapple", "りんごの名前はパイナップルだ");
Debug.Assert(apple.hasValueInitialized, "初期化済みだ");
Debug.Assert(ps == ProcessingState.Initialized, "初期化だ");
Debug.Assert(ps.IsChanged(), "変更だ");


// ［変更無し］を検知するテスト
ps = await ProcessingVariable.SetupAsync<string?>(
    initial: appleInitail,
    current: apple.Value,
    next: "Pineapple",
    apple.hasValueInitialized,
    onChange: async (args) =>
    {
        System.Console.WriteLine($"{args.OldValue}→{args.NewValue}。 initial:{args.InitialValue}, initialized:{args.HasInitialized}");
        apple.Value = args.NewValue;
        apple.hasValueInitialized = args.HasInitialized;
    });
System.Console.WriteLine($"apple.Value = {apple.Value}, apple.hasValueInitialized = {apple.hasValueInitialized}, ps = {ps}, ps.IsChanged() = {ps.IsChanged()}");
Debug.Assert(apple.Value == "Pineapple", "りんごの名前はパイナップルだ");
Debug.Assert(apple.hasValueInitialized, "初期化済みだ");
Debug.Assert(ps == ProcessingState.Unchanged, "変更無し");
Debug.Assert(!ps.IsChanged(), "変更無し");


// ［修正］を検知するテスト
ps = await ProcessingVariable.SetupAsync<string?>(
    initial: appleInitail,
    current: apple.Value,
    next: "リンゴ",
    apple.hasValueInitialized,
    onChange: async (args) =>
    {
        System.Console.WriteLine($"{args.OldValue}→{args.NewValue}。 initial:{args.InitialValue}, initialized:{args.HasInitialized}");
        apple.Value = args.NewValue;
        apple.hasValueInitialized = args.HasInitialized;
    });
System.Console.WriteLine($"apple.Value = {apple.Value}, apple.hasValueInitialized = {apple.hasValueInitialized}, ps = {ps}, ps.IsChanged() = {ps.IsChanged()}");
Debug.Assert(apple.Value == "リンゴ", "りんごの名前はリンゴだ");
Debug.Assert(apple.hasValueInitialized, "初期化済みだ");
Debug.Assert(ps == ProcessingState.Modified, "修正だ");
Debug.Assert(ps.IsChanged(), "変更だ");


// 未設定値に戻しても［修正］と判定されるテスト
ps = await ProcessingVariable.SetupAsync<string?>(
    initial: appleInitail,
    current: apple.Value,
    next: appleInitail,
    apple.hasValueInitialized,
    onChange: async (args) =>
    {
        System.Console.WriteLine($"{args.OldValue}→{args.NewValue}。 initial:{args.InitialValue}, initialized:{args.HasInitialized}");
        apple.Value = args.NewValue;
        apple.hasValueInitialized = args.HasInitialized;
    });
System.Console.WriteLine($"apple.Value = {apple.Value}, apple.hasValueInitialized = {apple.hasValueInitialized}, ps = {ps}, ps.IsChanged() = {ps.IsChanged()}");
Debug.Assert(apple.Value == appleInitail, "りんごの名前はアップルだ");
Debug.Assert(apple.hasValueInitialized, "初期化済みだ");
Debug.Assert(ps == ProcessingState.Modified, "修正だ");
Debug.Assert(ps.IsChanged(), "変更だ");


// 未設定値から設定しても［修正］と判定されるテスト
ps = await ProcessingVariable.SetupAsync<string?>(
    initial: appleInitail,
    current: apple.Value,
    next: "みかん",
    apple.hasValueInitialized,
    onChange: async (args) =>
    {
        System.Console.WriteLine($"{args.OldValue}→{args.NewValue}。 initial:{args.InitialValue}, initialized:{args.HasInitialized}");
        apple.Value = args.NewValue;
        apple.hasValueInitialized = args.HasInitialized;
    });
System.Console.WriteLine($"apple.Value = {apple.Value}, apple.hasValueInitialized = {apple.hasValueInitialized}, ps = {ps}, ps.IsChanged() = {ps.IsChanged()}");
Debug.Assert(apple.Value == "みかん", "りんごの名前はみかんだ");
Debug.Assert(apple.hasValueInitialized, "初期化済みだ");
Debug.Assert(ps == ProcessingState.Modified, "修正だ");    // 初期化ではない
Debug.Assert(ps.IsChanged(), "変更だ");


// バナナ


string? bananaInitail = null;
FruitsModel<string?> banana = new FruitsModel<string?>(bananaInitail);


// ［未設定］を検知するテスト
ps = await ProcessingVariable.SetupAsync<string?>(
    initial: bananaInitail,
    current: banana.Value,
    next: bananaInitail,
    banana.hasValueInitialized,
    onChange: async (args) =>
    {
        System.Console.WriteLine($"{args.OldValue}→{args.NewValue}。 initial:{args.InitialValue}, initialized:{args.HasInitialized}");
        banana.Value = args.NewValue;
        banana.hasValueInitialized = args.HasInitialized;
    });
System.Console.WriteLine($"banana.Value = {banana.Value}, banana.hasValueInitialized = {banana.hasValueInitialized}, ps = {ps}, ps.IsChanged() = {ps.IsChanged()}");
Debug.Assert(banana.Value == bananaInitail, "バナナの名前はヌルだ");
Debug.Assert(!banana.hasValueInitialized, "未設定だ");
Debug.Assert(ps == ProcessingState.NotSet, "未設定だ");
Debug.Assert(!ps.IsChanged(), "変更無し");


// ［初期化］を検知するテスト
ps = await ProcessingVariable.SetupAsync<string?>(
    initial: bananaInitail,
    current: banana.Value,
    next: "Banana",
    banana.hasValueInitialized,
    onChange: async (args) =>
    {
        System.Console.WriteLine($"{args.OldValue}→{args.NewValue}。 initial:{args.InitialValue}, initialized:{args.HasInitialized}");
        banana.Value = args.NewValue;
        banana.hasValueInitialized = args.HasInitialized;
    });
System.Console.WriteLine($"banana.Value = {banana.Value}, banana.hasValueInitialized = {banana.hasValueInitialized}, ps = {ps}, ps.IsChanged() = {ps.IsChanged()}");
Debug.Assert(banana.Value == "Banana", "バナナの名前はバナナだ");
Debug.Assert(banana.hasValueInitialized, "初期化済みだ");
Debug.Assert(ps == ProcessingState.Initialized, "初期化だ");
Debug.Assert(ps.IsChanged(), "変更だ");


// ［変更無し］を検知するテスト
ps = await ProcessingVariable.SetupAsync<string?>(
    initial: bananaInitail,
    current: banana.Value,
    next: "Banana",
    banana.hasValueInitialized,
    onChange: async (args) =>
    {
        System.Console.WriteLine($"{args.OldValue}→{args.NewValue}。 initial:{args.InitialValue}, initialized:{args.HasInitialized}");
        banana.Value = args.NewValue;
        banana.hasValueInitialized = args.HasInitialized;
    });
System.Console.WriteLine($"banana.Value = {banana.Value}, banana.hasValueInitialized = {banana.hasValueInitialized}, ps = {ps}, ps.IsChanged() = {ps.IsChanged()}");
Debug.Assert(banana.Value == "Banana", "バナナの名前はバナナだ");
Debug.Assert(banana.hasValueInitialized, "初期化済みだ");
Debug.Assert(ps == ProcessingState.Unchanged, "変更無し");
Debug.Assert(!ps.IsChanged(), "変更無し");


// ［修正］を検知するテスト
ps = await ProcessingVariable.SetupAsync<string?>(
    initial: bananaInitail,
    current: banana.Value,
    next: "ブーメラン",
    banana.hasValueInitialized,
    onChange: async (args) =>
    {
        System.Console.WriteLine($"{args.OldValue}→{args.NewValue}。 initial:{args.InitialValue}, initialized:{args.HasInitialized}");
        banana.Value = args.NewValue;
        banana.hasValueInitialized = args.HasInitialized;
    });
System.Console.WriteLine($"banana.Value = {banana.Value}, banana.hasValueInitialized = {banana.hasValueInitialized}, ps = {ps}, ps.IsChanged() = {ps.IsChanged()}");
Debug.Assert(banana.Value == "ブーメラン", "バナナの名前はブーメランだ");
Debug.Assert(banana.hasValueInitialized, "初期化済みだ");
Debug.Assert(ps == ProcessingState.Modified, "修正だ");
Debug.Assert(ps.IsChanged(), "変更だ");


// 未設定値に戻しても［修正］と判定されるテスト
ps = await ProcessingVariable.SetupAsync<string?>(
    initial: bananaInitail,
    current: banana.Value,
    next: bananaInitail,
    banana.hasValueInitialized,
    onChange: async (args) =>
    {
        System.Console.WriteLine($"{args.OldValue}→{args.NewValue}。 initial:{args.InitialValue}, initialized:{args.HasInitialized}");
        banana.Value = args.NewValue;
        banana.hasValueInitialized = args.HasInitialized;
    });
System.Console.WriteLine($"banana.Value = {banana.Value}, banana.hasValueInitialized = {banana.hasValueInitialized}, ps = {ps}, ps.IsChanged() = {ps.IsChanged()}");
Debug.Assert(banana.Value == bananaInitail, "バナナの名前はヌルだ");
Debug.Assert(banana.hasValueInitialized, "初期化済みだ");
Debug.Assert(ps == ProcessingState.Modified, "修正だ");
Debug.Assert(ps.IsChanged(), "変更だ");


// 未設定値から設定しても［修正］と判定されるテスト
ps = await ProcessingVariable.SetupAsync<string?>(
    initial: bananaInitail,
    current: banana.Value,
    next: "モンキーバナナ",
    banana.hasValueInitialized,
    onChange: async (args) =>
    {
        System.Console.WriteLine($"{args.OldValue}→{args.NewValue}。 initial:{args.InitialValue}, initialized:{args.HasInitialized}");
        banana.Value = args.NewValue;
        banana.hasValueInitialized = args.HasInitialized;
    });
System.Console.WriteLine($"banana.Value = {banana.Value}, banana.hasValueInitialized = {banana.hasValueInitialized}, ps = {ps}, ps.IsChanged() = {ps.IsChanged()}");
Debug.Assert(banana.Value == "モンキーバナナ", "バナナの名前はモンキーバナナだ");
Debug.Assert(banana.hasValueInitialized, "初期化済みだ");
Debug.Assert(ps == ProcessingState.Modified, "修正だ");    // 初期化ではない
Debug.Assert(ps.IsChanged(), "変更だ");




// チェリー


double? cherryInitail = 0.0d;
FruitsModel<double?> cherry = new FruitsModel<double?>(cherryInitail);


// ［未設定］を検知するテスト
ps = await ProcessingVariable.SetupAsync<double?>(
    initial: cherryInitail,
    current: cherry.Value,
    next: cherryInitail,
    cherry.hasValueInitialized,
    onChange: async (args) =>
    {
        System.Console.WriteLine($"{args.OldValue}→{args.NewValue}。 initial:{args.InitialValue}, initialized:{args.HasInitialized}");
        cherry.Value = args.NewValue;
        cherry.hasValueInitialized = args.HasInitialized;
    });
System.Console.WriteLine($"cherry.Value = {cherry.Value}, cherry.hasValueInitialized = {cherry.hasValueInitialized}, ps = {ps}, ps.IsChanged() = {ps.IsChanged()}");
Debug.Assert(cherry.Value == cherryInitail, "チェリーは 0.0d だ");
Debug.Assert(!cherry.hasValueInitialized, "未設定だ");
Debug.Assert(ps == ProcessingState.NotSet, "未設定だ");
Debug.Assert(!ps.IsChanged(), "変更無し");


// ［初期化］を検知するテスト
ps = await ProcessingVariable.SetupAsync<double?>(
    initial: cherryInitail,
    current: cherry.Value,
    next: 1.0d,
    cherry.hasValueInitialized,
    onChange: async (args) =>
    {
        System.Console.WriteLine($"{args.OldValue}→{args.NewValue}。 initial:{args.InitialValue}, initialized:{args.HasInitialized}");
        cherry.Value = args.NewValue;
        cherry.hasValueInitialized = args.HasInitialized;
    });
System.Console.WriteLine($"cherry.Value = {cherry.Value}, cherry.hasValueInitialized = {cherry.hasValueInitialized}, ps = {ps}, ps.IsChanged() = {ps.IsChanged()}");
Debug.Assert(cherry.Value == 1.0d, "チェリーは 1.0d だ");
Debug.Assert(cherry.hasValueInitialized, "初期化済みだ");
Debug.Assert(ps == ProcessingState.Initialized, "初期化だ");
Debug.Assert(ps.IsChanged(), "変更だ");


// ［変更無し］を検知するテスト
ps = await ProcessingVariable.SetupAsync<double?>(
    initial: cherryInitail,
    current: cherry.Value,
    next: 1.0d,
    cherry.hasValueInitialized,
    onChange: async (args) =>
    {
        System.Console.WriteLine($"{args.OldValue}→{args.NewValue}。 initial:{args.InitialValue}, initialized:{args.HasInitialized}");
        cherry.Value = args.NewValue;
        cherry.hasValueInitialized = args.HasInitialized;
    });
System.Console.WriteLine($"cherry.Value = {cherry.Value}, cherry.hasValueInitialized = {cherry.hasValueInitialized}, ps = {ps}, ps.IsChanged() = {ps.IsChanged()}");
Debug.Assert(cherry.Value == 1.0d, "チェリーは 1.0d だ");
Debug.Assert(cherry.hasValueInitialized, "初期化済みだ");
Debug.Assert(ps == ProcessingState.Unchanged, "変更無し");
Debug.Assert(!ps.IsChanged(), "変更無し");


// ［修正］を検知するテスト
ps = await ProcessingVariable.SetupAsync<double?>(
    initial: cherryInitail,
    current: cherry.Value,
    next: 2.5d,
    cherry.hasValueInitialized,
    onChange: async (args) =>
    {
        System.Console.WriteLine($"{args.OldValue}→{args.NewValue}。 initial:{args.InitialValue}, initialized:{args.HasInitialized}");
        cherry.Value = args.NewValue;
        cherry.hasValueInitialized = args.HasInitialized;
    });
System.Console.WriteLine($"cherry.Value = {cherry.Value}, cherry.hasValueInitialized = {cherry.hasValueInitialized}, ps = {ps}, ps.IsChanged() = {ps.IsChanged()}");
Debug.Assert(cherry.Value == 2.5d, "チェリーは 2.5d だ");
Debug.Assert(cherry.hasValueInitialized, "初期化済みだ");
Debug.Assert(ps == ProcessingState.Modified, "修正だ");
Debug.Assert(ps.IsChanged(), "変更だ");


// 未設定値に戻しても［修正］と判定されるテスト
ps = await ProcessingVariable.SetupAsync<double?>(
    initial: cherryInitail,
    current: cherry.Value,
    next: cherryInitail,
    cherry.hasValueInitialized,
    onChange: async (args) =>
    {
        System.Console.WriteLine($"{args.OldValue}→{args.NewValue}。 initial:{args.InitialValue}, initialized:{args.HasInitialized}");
        cherry.Value = args.NewValue;
        cherry.hasValueInitialized = args.HasInitialized;
    });
System.Console.WriteLine($"cherry.Value = {cherry.Value}, cherry.hasValueInitialized = {cherry.hasValueInitialized}, ps = {ps}, ps.IsChanged() = {ps.IsChanged()}");
Debug.Assert(cherry.Value == cherryInitail, "チェリーは 0.0d だ");
Debug.Assert(cherry.hasValueInitialized, "初期化済みだ");
Debug.Assert(ps == ProcessingState.Modified, "修正だ");
Debug.Assert(ps.IsChanged(), "変更だ");


// 未設定値から設定しても［修正］と判定されるテスト
ps = await ProcessingVariable.SetupAsync<double?>(
    initial: cherryInitail,
    current: cherry.Value,
    next: 5.1d,
    cherry.hasValueInitialized,
    onChange: async (args) =>
    {
        System.Console.WriteLine($"{args.OldValue}→{args.NewValue}。 initial:{args.InitialValue}, initialized:{args.HasInitialized}");
        cherry.Value = args.NewValue;
        cherry.hasValueInitialized = args.HasInitialized;
    });
System.Console.WriteLine($"cherry.Value = {cherry.Value}, cherry.hasValueInitialized = {cherry.hasValueInitialized}, ps = {ps}, ps.IsChanged() = {ps.IsChanged()}");
Debug.Assert(cherry.Value == 5.1d, "チェリーは 5.1d だ");
Debug.Assert(cherry.hasValueInitialized, "初期化済みだ");
Debug.Assert(ps == ProcessingState.Modified, "修正だ");    // 初期化ではない
Debug.Assert(ps.IsChanged(), "変更だ");


// おわり


System.Console.WriteLine($"テスト完了！");


class FruitsModel<T>
{
    public FruitsModel(T? name)
    {
        this.value = name;
    }

    public T? Value
    {
        get { return value; }
        set { this.value = value; }
    }
    T? value = default;
    public bool hasValueInitialized = false;
}
