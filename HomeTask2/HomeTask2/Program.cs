int number = 1234;
int sumOfDigits = 0;
int firstDigit,secondDigit,thirdDigit,fourthDigit;
bool isPrime=false;
firstDigit = number / 1000;
secondDigit = number % 1000 / 100;
thirdDigit = number % 100 / 10;
fourthDigit = number % 10;
sumOfDigits=firstDigit+secondDigit+thirdDigit+fourthDigit;

Console.WriteLine("The given number is: "+number);
Console.WriteLine("The sum of the digits of this number: "+sumOfDigits);

if (sumOfDigits==0 || sumOfDigits==1)
{
    Console.WriteLine(sumOfDigits + "is neither simple or complex.");
}
else
{
    for (int i = 2; i <= Math.Sqrt(sumOfDigits); i++)
    {
        if (sumOfDigits % i == 0) isPrime = true;
    }
}

if (isPrime) Console.WriteLine(sumOfDigits + " is a complex number");
else Console.WriteLine(sumOfDigits+" is simple number");