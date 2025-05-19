using static System.Console;

namespace PrimeFactors {
    class Factors {
        //Function to factor number
        static string PrimeFactors(int numToFactor) {
            
            int a = numToFactor;
            int b = 2;
            string finalNum = string.Empty;
            
            do {
                if(((double)a/b) - (a/b) == 0 ) {
                    a = a / b;                
                    finalNum = finalNum + " " + b;
                    b = 2;
                }
                
                else {
                    ++b;   
                }
            }
            while (b < a);
            
            finalNum = finalNum + " " + a;
            
            return finalNum;
        }
        
        //Function to take input and pass input to PrimeFactors
        static void RunPrimeFactors() {
            bool checkNumber;
            do {
                Write("Enter a number: ");
                
                checkNumber = int.TryParse(ReadLine(), out int number);
                
                if (checkNumber) {
                    WriteLine($"{number:N0} = {PrimeFactors(number):N0}");
                }
                
                else {
                    WriteLine("You didn't enter a valid number.");
                }
            }
            while (checkNumber);
        }
        
        //Main function
        static void Main() {
            RunPrimeFactors();
        }
    }
}