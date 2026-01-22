namespace ConsoleApp1;

using System;

internal class ProcessingVariable
{
    public static async Task<(ProcessingState State, bool HasInitialized)> SetupAsync<T>(
        T? current,                       // 修正: in → 普通のパラメータ（asyncでin NG。コピー渡しでOK）
        T? next,                          // 新しい値
        bool hasInitialized,              // 修正: ref → 入力コピー（判定用）
        bool ignore = false,
        Func<T?, Task> onChange = null)   // オプションのまま
        where T : class
    {
        // `ps` - ProcessingState（状態管理用 enum）
        ProcessingState ps = ProcessingState.Unchanged;  // 変更無し
        bool newInitialized = hasInitialized;            // 修正: 出力用フラグ（入力からコピー）

        if (ignore)
        {
            return (ps, newInitialized);  // 早期return（Task.FromResultいらずでTuple）
        }

        if (!hasInitialized && current == null)
        {
            if (next == null)
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
                await onChange(next);  // next null渡しOK
            }
        }

        return (ps, newInitialized);  // 修正: TupleでStateとHasInitialized返却
    }
}
