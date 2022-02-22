using CalcLib;

// initialisation
MathOperation operation = new MathOperation();
NavCLI Nav = new NavCLI();

string userMethod = "";
char[] validOperators = { '+', '-', '*', '/' };
string terminateProgram = "quit";
Tuple<string,string> EasterEgg = new Tuple<string, string> ("xyzzy", "Nothing happens");
bool MiniCalcProgramRunning = true;

// Programs starts and runs inside this loop.
// insteed of Console.ReadLine it uses a filtered function from NavCLI. [Nav.ReadLineWithFilteringInstruction()]
while (MiniCalcProgramRunning){
    Console.Clear();
    Console.WriteLine(Nav.Menu(N1: "__ (number)", OP:"Operation [+ - * /]"));

    // first input from user assigned to Input 1
    // + CLI clear and update
    string userInput = "";
    userInput = Nav.ReadLineWithFilteringInstruction(terminateProgram,EasterEgg);
    if (userInput == "") {break;}
    operation.Inputs[0] = userInput;
    Console.Clear();
    Console.WriteLine(Nav.Menu(operation.Inputs[0], OP:"_ (Operation [+ - * /])"));


    // Get Operation type from user. [+ - * /]
    // and keep user inside a loop until a char with correct operation type is given.
    bool loop = true;
    while (loop){
        userMethod = Nav.ReadLineWithFilteringInstruction(terminateProgram, EasterEgg);
        if (userMethod.Length == 1){
            foreach (var item in validOperators)
            {
                if ( userMethod.Contains(item) ) {loop = false;}
            }
        }
        Console.Clear();
        Console.WriteLine(Nav.Menu(operation.Inputs[0], OP:userMethod +" (Enter a valid Operation [+ - * /])"));
    }

    // second input from user assigned to Input 2
    // + CLI clear and update
    Console.Clear();
    Console.WriteLine(Nav.Menu(N1: operation.Inputs[0], OP:userMethod, N2: "__ (number)"));
    
    // Check for termination and EasterEgg
    userInput = Nav.ReadLineWithFilteringInstruction(terminateProgram,EasterEgg);
    if (userInput == "") {break;}
    
    // Link input to MathOperation
    operation.Inputs[1] = userInput;
    Console.Clear();
    Console.WriteLine(Nav.Menu(operation.Inputs[0], operation.Inputs[1], userMethod));

    // User Promt to display result
    Console.WriteLine("[Press enter to Calculate]");
    userInput = Nav.ReadLineWithFilteringInstruction(terminateProgram,EasterEgg);
    if (userInput == "") {break;}

    // Calculate result
    // [first input] + [operation type] + [second input] = result.
    string result = "";
    if (userMethod.Contains(validOperators[0])) result = operation.Add();
    if (userMethod.Contains(validOperators[1])) result = operation.Subtract();
    if (userMethod.Contains(validOperators[2])) result = operation.Multiply();
    if (userMethod.Contains(validOperators[3])) result = operation.Divide(); 
    // Print result
    Console.Clear();
    Console.WriteLine(Nav.Menu(operation.Inputs[0], operation.Inputs[1], userMethod));
    Console.WriteLine("RESULT: " + result);

    // Clear data for new calc..
    result = "";
    int x = 0;
    foreach (var item in operation.Inputs)
    {
        operation.Inputs[x] = "";
        x++;
    }
    userInput = Nav.ReadLineWithFilteringInstruction(terminateProgram,EasterEgg);
    if (userInput == "") {break;}

}

Console.WriteLine("Program Terminated. press any key to quit");
Console.ReadLine();
Environment.Exit(0);