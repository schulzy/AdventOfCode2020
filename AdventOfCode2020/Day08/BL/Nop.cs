namespace Day08.BL
{
    internal class Nop: ICommand
    {
        public int Value { get; }

        public int Called { get; set; } = 0;

        public Nop(int value)
        {
            Value = value;
        }

        public void Invoke(Program program)
        {
            Called++;
            program.Pointer++;
        }
    }
}
