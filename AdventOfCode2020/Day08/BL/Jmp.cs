namespace Day08.BL
{
    internal class Jmp : ICommand
    {
        public int Value { get; } 

        public int Called { get; set; } = 0;

        public Jmp(int value)
        {
            Value = value;
        }

        public void Invoke(Program program)
        {
            Called++;
            program.Pointer += Value;
        }
    }
}
