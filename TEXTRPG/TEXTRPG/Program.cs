using System;

namespace TEXTRPG
{
    class Program
    {
        enum ClassType
        {
            None = 0,
            Knight = 1,
            Archer = 2,
            Mage = 3
        }

        static ClassType ChooseClass()
        {
            Console.WriteLine("직업을 선택하세요!");
            Console.WriteLine("[1] 기사\n[2] 궁수 \n[3] 법사");

            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    return ClassType.Knight;
                case "2":
                    return ClassType.Archer;
                case "3":
                    return ClassType.Mage;
                default:
                    return ClassType.None;
            }
        }
        static void Main(string[] args)
        {
            ClassType choice = ClassType.None;

            while(choice == ClassType.None)
            {
                choice = ChooseClass();
            }
            
        }
    }
}