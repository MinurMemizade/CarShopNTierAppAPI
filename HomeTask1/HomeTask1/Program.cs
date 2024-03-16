int number = 54565;
Console.WriteLine("The given number is:"+number);
int result = 1;
int firstDigit, secondDigit ,thirdDigit ,fourthDigit ,fifthDigit;
firstDigit = number / 10000;
secondDigit = number % 10000 / 1000;
thirdDigit = number % 1000/100;
fourthDigit = number % 100/10;
fifthDigit = number % 10;
if (firstDigit % 5 == 0) result *= firstDigit;
if (secondDigit % 5 == 0) result *= secondDigit;
if (thirdDigit % 5 == 0) result *= thirdDigit;
if (fourthDigit % 5 == 0) result *= fourthDigit;
if (fifthDigit % 5 == 0) result *= fifthDigit;
Console.WriteLine("The result is:"+result);

