using System;

namespace CalcLib;
public class MathOperation
{
    public string[] Inputs = {"",""};
    
    private string errorMessage = "Invalid Input, for more advanced calculation use Mathlab @ https://matlab.mathworks.com ";
    private double[] convertedInputs = new double[2];
    
    private string convertDataToDouble (){
        // All the Inputs will be grabbed and converted to convertedInputs, from string to double.
        // Will return an empty string if the convertion is OK, otherwise a Exeption.message 
        int x = 0;
        foreach (var Input in Inputs)
        {
            try{
                convertedInputs[x] = double.Parse(Input);
            }
            catch(Exception e) {
                return e.Message;
            }
            x++;
        }
            
        return "";
    }
    
    public string Add() {
        string e = convertDataToDouble();
        if (e != ""){return errorMessage + "\n" + e;}
        return Convert.ToString(convertedInputs[0] + convertedInputs[1]);
        
    }
    public string Multiply() {
        string e = convertDataToDouble();
        if (e != ""){return errorMessage + "\n" + e;}
        return Convert.ToString(convertedInputs[0] * convertedInputs[1]);
    }
    public string Subtract() {
        string e = convertDataToDouble();
        if (e != ""){return errorMessage + "\n" + e;}
        return Convert.ToString(convertedInputs[0] - convertedInputs[1]);
    }
    public string Divide() {
        string e = convertDataToDouble(); 
        if (e != ""){return errorMessage + "\n" + e;}
        if (convertedInputs[1] == 0) return "Invalid Operation, attemt to divide by zero";
        return Convert.ToString(convertedInputs[0] / convertedInputs[1]);
        
    }

    
}
