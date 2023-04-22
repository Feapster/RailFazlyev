using System;
using System.Collections.Generic;



Random random = new Random();


int stopkaInt = random.Next(1000,10000000);
string stopkaString = stopkaInt.ToString();
int stopkaLength = stopkaString.Length;



Console.WriteLine($"Number is {stopkaInt}.");



static int CountFlips(int pancakes)
{
    string pancakesString = pancakes.ToString();
    int[] pancakeArray = new int[pancakesString.Length];

    for (int i = 0; i < pancakesString.Length; i++)
    {
        pancakeArray[i] = int.Parse(pancakesString[i].ToString());
    }

    int flips = 0;
    int top = pancakeArray.Length - 1;

    while (top >= 0)
    {
        int largestIndex = 0;
        int largestDiameter = 0;

        for (int i = 0; i <= top; i++)
        {
            if (pancakeArray[i] > largestDiameter)
            {
                largestIndex = i;
                largestDiameter = pancakeArray[i];
            }
        }

        if (largestIndex == top)
        {
            top--;
            continue;
        }

        if (largestIndex != 0)
        {
            for (int i = 0; i <= largestIndex; i++)
            {
                int temp = pancakeArray[i];
                pancakeArray[i] = pancakeArray[largestIndex - i];
                pancakeArray[largestIndex - i] = temp;
            }

            flips++;
        }

        for (int i = 0; i <= top; i++)
        {
            int temp = pancakeArray[i];
            pancakeArray[i] = pancakeArray[top - i];
            pancakeArray[top - i] = temp;
        }

        flips++;

        top--;
    }

    return flips;
}




int flips = CountFlips(stopkaInt);
Console.WriteLine($"Amount of Flips is {flips}.");




List<int> List1 = new List<int>();
List<int> List2 = new List<int>();



for (int i = 0; i < 20; i++)
{
    List1.Add(random.Next(1, 100));
    List2.Add(random.Next(1, 100));
}



List1.Sort();
List2.Sort();



Console.WriteLine("List1: " + string.Join(", ", List1));
Console.WriteLine("List2: " + string.Join(", ", List2));



List<int> mergedList = new List<int>();
int index1 = 0;
int index2 = 0;



while (index1 < List1.Count && index2 < List2.Count)
{
    if (List1[index1] < List2[index2])
    {
        mergedList.Add(List1[index1]);
        index1++;
    }
    else
    {
        mergedList.Add(List2[index2]);
        index2++;
    }
}

while (index1 < List1.Count)
{
    mergedList.Add(List1[index1]);
    index1++;
}

while (index2 < List2.Count)
{
    mergedList.Add(List2[index2]);
    index2++;
}



Console.WriteLine("Merged list: " + string.Join(", ", mergedList));

