namespace Day08.BL
{
    internal class Acc : ICommand
    {
        public int Value { get; }

        public int Called { get; set; } = 0;
        public Acc(int value)
        {
            Value = value;
        }

        public void Invoke(Program program)
        {
            Called++;
            program.Accumlator += Value;
            program.Pointer++;
        }
    }
}
