namespace AIBot.Core.Dto
{
    public class KeyValuePareInfo<TKey,TValue>
    {
        public TKey Key { get; protected set; }
        public TValue Value { get; protected set; }

        public KeyValuePareInfo(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }
    }
}
