using System;
using System.Collections.Generic;

namespace Day08.BL
{
    internal class Program
    {
        public int Accumlator { get; set; } = 0;
        public List<ICommand> Commands { get; set; } = new List<ICommand>();
        public List<ICommand> CommandsReference { get; private set; }
        public int Pointer { get; set; } = 0;

        public void Init()
        {
            foreach (var line in new DataProcessor().GetData())
            {
                var command = line.Split(" ");
                switch (command[0])
                {
                    case "nop":
                        Commands.Add(new Nop(int.Parse(command[1])));
                        break;
                    case "acc":
                        Commands.Add(new Acc(int.Parse(command[1])));
                        break;
                    case "jmp":
                        Commands.Add(new Jmp(int.Parse(command[1])));
                        break;
                    default:
                        break;
                }
            }

            CommandsReference = new List<ICommand>(Commands);
        }

        public int RunUntilFirstRepeat()
        {
            while (true)
            {
                var actualPointer = Pointer;
                if (Commands[actualPointer].Called > 0)
                    return Accumlator;
                Commands[actualPointer].Invoke(this);
                
            }
        }

        public int FixNopJmp()
        {
            for (int i = 0; i < CommandsReference.Count; i++)
            {
                if(CommandsReference[i] is Nop)
                    Commands[i] = new Jmp(CommandsReference[i].Value);
                else if(CommandsReference[i] is Jmp)
                    Commands[i] = new Nop(CommandsReference[i].Value);

                if (FinishedProgram())
                    return Accumlator;

                Reset();
            }

            throw new Exception("No result");
        }

        private bool FinishedProgram()
        {
            while (true)
            {
                var actualPointer = Pointer;
                if (Commands[actualPointer].Called > 0)
                    return false;
                Commands[actualPointer].Invoke(this);
                if (Pointer >= CommandsReference.Count)
                    return true;
            }
        }

        private void Reset()
        {
            Accumlator = 0;
            Pointer = 0;
            Commands = new List<ICommand>(CommandsReference);
            foreach (var item in Commands)
            {
                item.Called = 0;
            }
        }
    }
}
