using System;

namespace CalcLib;
public struct NavCLI
{
    public string Menu(string N1 = "",string N2 = "", string OP = ""){
        string n1 = N1.Length > 0 ? N1 : "number";
        string n2 = N2.Length > 0 ? N2 : "number";
        string op = OP.Length > 0 ? OP : "operation [ - + * / ]";

        return $"Please enter the following:\n1: {n1} \n2: {op} \n3: {n2}";
    }
    public string ReadLineWithFilteringInstruction(string KeyWordToTerminateLoopAndProgram, Tuple<string,string> KeyWordToBeReplaced){
        // This function will return a blank value if the program is to me terminatded otherwise a filtered response from the user.
        string userInput;
        userInput = Console.ReadLine();

        // Check for EasterEgg
        while (userInput.ToLower() == KeyWordToBeReplaced.Item1.ToLower()){
            Console.WriteLine(KeyWordToBeReplaced.Item2);
            userInput = Console.ReadLine();
        }
        // Check for terminate instruction
        if (userInput.ToLower() == KeyWordToTerminateLoopAndProgram.ToLower()) {return "";}
        // if user inputs a blank response, then replace it with NaN(Not a Number)
        if( userInput.Length < 1)  userInput = "NaN";

        // return the input after it passed all filters and requierments
        return userInput;
        }
        
}
