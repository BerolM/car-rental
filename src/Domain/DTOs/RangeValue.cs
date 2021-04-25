namespace Domain.DTOs
{
    public sealed class RangeValue<T>
    {
        public T Start { get; }
        public T End { get; }

        private RangeValue(T start, T end)
        {
            Start = start;
            End = end;
        }

        public static RangeValue<T> Create(T start, T end)
        {
            return new RangeValue<T>(start, end);
        }
    }
}
