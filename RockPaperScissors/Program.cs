
using RockPaperScissors.Generators;

var res = args;

//for(int i =  0; i < res.Length; i++)
//{
//    for(int j = 0; j < 3; j++)
//        Console.Write(res[i] + "   ");
//    Console.Write("\n");
//    Console.WriteLine();
//}

var table = new TableGenerator(res);
table.GenerateHelpTable();


