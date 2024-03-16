int number = 336;
int sum = 0;
int first = number / 100;
int second = number % 100 / 10;
int third = number % 10;
if (first % 3 == 0) sum += first;
if (second % 3 == 0) sum += second;
if (third % 3 == 0) sum += third;
Console.WriteLine(sum);