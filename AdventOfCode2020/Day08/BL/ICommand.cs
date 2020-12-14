namespace Day08.BL
{
    interface ICommand
    {
        int Value { get; }
        int Called { get; set; }
        void Invoke(Program program);
    }
}
