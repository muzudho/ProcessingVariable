namespace ConsoleApp1;

using System;


/// <summary>
/// ［初期設定］なのか［修正］なのか、［未設定］なのか［変更無し］なのか、判別できるもの。
/// イベント発火に利用する。
/// </summary>
internal class ProcessingVariable
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="initial">デフォルト/初期値（例: null）。初回設定かの判定に使う</param>
    /// <param name="current">現在の値</param>
    /// <param name="next">新しい値</param>
    /// <param name="hasInitialized">初期化済みかどうかは、外部で記憶してください</param>
    /// <param name="ignore">何もせず早期returnするなら真</param>
    /// <param name="onChange"></param>
    /// <returns></returns>
    public static async Task<ProcessingState> SetupAsync<T>(
        T? initial,
        T? current,
        T? next,
        bool hasInitialized,
        bool ignore = false,
        Func<ProcessingVariableArgs<T>, Task>? onChange = null)
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
                ps = ProcessingState.NotSet;  // 未設定（初期値と同じ）
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
                var args = new ProcessingVariableArgs<T>(
                    initialValue: initial,
                    oldValue: current,
                    newValue: next,  // null渡しOK
                    hasInitialized: newInitialized);
                await onChange(args);
            }
        }

        return ps;
    }
}
