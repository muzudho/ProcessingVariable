namespace ConsoleApp1;

using System;

internal class ProcessingVariableArgs<T>
{
    public T? NewValue { get; set; }
    public bool HasInitialized { get; set; }

    public ProcessingVariableArgs(T? value, bool hasInitialized)
    {
        this.NewValue = value;
        this.HasInitialized = hasInitialized;
    }
}

internal class ProcessingVariable
{
    public static async Task<ProcessingState> SetupAsync<T>(
        T? initial,                         // 初期値
        T? current,                         // 現在地
        T? next,                            // 新しい値
        bool hasInitialized,                // 初期化済みかの記録
        bool ignore = false,
        Func<ProcessingVariableArgs<T>, Task> onChange = null)   // オプションのまま
        where T : class
    {
        // `ps` - ProcessingState（状態管理用 enum）
        ProcessingState ps = ProcessingState.Unchanged;  // 変更無し
        bool newInitialized = hasInitialized;            // 修正: 出力用フラグ（入力からコピー）

        if (ignore)
        {
            return ps;  // 早期return
        }

        if (!hasInitialized && current == initial)
        {
            if (next == initial)
            {
                ps = ProcessingState.NotSet;  // 未設定
            }
            else
            {
                ps = ProcessingState.Initialized;  // 初回設定
                newInitialized = true;  // ここで更新（出力用）
            }
        }
        else if (next != current)
        {
            ps = ProcessingState.Modified;  // 変更
        }

        if (ps == ProcessingState.Initialized || ps == ProcessingState.Modified)
        {
            if (onChange != null)
            {
                await onChange(new ProcessingVariableArgs<T>(
                    value: next,
                    hasInitialized: newInitialized));  // next null渡しOK
            }
        }

        return ps;
    }
}
