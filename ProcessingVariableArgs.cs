namespace ConsoleApp1;
/// <summary>
/// onChange フックの引数の型
/// </summary>
/// <typeparam name="T"></typeparam>
internal class ProcessingVariableArgs<T>
{
    public T? InitialValue { get; set; }
    public T? OldValue { get; set; }
    public T? NewValue { get; set; }
    public bool HasInitialized { get; set; }

    public ProcessingVariableArgs(
        T? initialValue,
        T? oldValue,
        T? newValue,
        bool hasInitialized)
    {
        this.InitialValue = initialValue;
        this.OldValue = oldValue;
        this.NewValue = newValue;
        this.HasInitialized = hasInitialized;
    }
}
