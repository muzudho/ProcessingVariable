namespace ConsoleApp1;

internal static class ProcessingStateExtensions
{
    public static bool IsChanged(this ProcessingState source)
    {
        return source is ProcessingState.Initialized or ProcessingState.Modified;
    }


    public static string GetChangeDescription(this ProcessingState source)
    {
        return source switch
        {
            ProcessingState.Unchanged => "変更なし",
            ProcessingState.NotSet => "未設定",
            ProcessingState.Initialized => "初回設定完了",
            ProcessingState.Modified => "値が変更された",
            _ => "不明な状態"  // デフォルトで安全
        };
    }
}


internal enum ProcessingState
{
    Unchanged,
    NotSet,
    Initialized,
    Modified
}
