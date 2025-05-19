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

        //Main function
        static void Main() {
            
            //Loop to run many tests
            for(int i=4; i<1000; i++) {
                string result=PrimeFactors(i);
                WriteLine($"Factor(s) of {i} are {result}");
                Write($"All factors prime: {allPrime(result)} | ");
                Write($"Factors match original: {multiAll(result,i)} | ");
                WriteLine($"Unit Test of {i} = {testPrimeFactorsFunction(i)}");
                WriteLine();
                i*=2;
            }
        }
        
        /*function to check that all numbers are prime and
          result in starting number when mutiplied togather*/
        static string testPrimeFactorsFunction(int num) {
            string result=PrimeFactors(num);
            
            bool check1 = allPrime(result);
            bool check2 = multiAll(result,num);
            
            if(check1 && check2) {
                return "pass";
            }
            else {
                return "fail";
            }
        }

        /*Function to check that resulting numbers result in
          starting number when mutiplied togather*/
        static bool multiAll(string factored, int prefactor) {
            string[] list=factored.Split(" ");
            
            int num2=1;

            foreach(string t in list) {
                //See if it's a number, if not skip it
                if(int.TryParse(t, out int num1)) {
                    num2*=num1;
                }
            }
            
            if(num2 == prefactor) {
                return true;
            }
            else {
                return false;
            }
        }
        
        
        
        
        //Function to check that all resulting numbers are prime
        static bool isPrime(int In) {
            //Run through all numbers from 2 to In
            for(int i=2;i<In;i++) {
                /*
                In is already an integer cast it to a decimal
                to allow for non-integer division then comapre
                that to the interger verson. If they are ever
                equal then we know the number is not prime.
                */
                if((double)In/i == In/i) {
                    return false;
                }
            }
            //If we get this far then it must be prime
            return true;
        }
        
        /*Function to parse and pass resulting numbers to
          isPrime to check that they are prime*/
        static bool allPrime(string In) {
            string[] list=In.Split(" ");
            // Loop through each number in the string
            //to make sure it is prime.
            foreach(string s in list) {
                //See if it's a number, if not skip it
                if(int.TryParse(s, out int num)) {
                    if(!isPrime(num)) {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}