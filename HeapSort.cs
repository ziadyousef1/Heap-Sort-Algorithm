using System;

class Program
{
    static void Main()
    {
        int[] array = { 12, 11, 13, 5, 6, 7 };
        Console.WriteLine("Original array:");
        Console.WriteLine(string.Join(" ", array));

        Heapsort.Sort(array);

        Console.WriteLine("Sorted array:");
        Console.WriteLine(string.Join(" ", array));
    }
}
public class Heapsort
{
    public static void Sort(int[] array)
    {
        int n = array.Length;

        for (int i = n / 2 - 1; i >= 0; i--)
        {
            Heapify(array, n, i);
        }

        for (int i = n - 1; i > 0; i--)
        {
            int temp = array[0];
            array[0] = array[i];
            array[i] = temp;

            Heapify(array, i, 0);
        }
    }

    private static void Heapify(int[] array, int n, int i)
    {
        int largest = i; 
        int left = 2 * i + 1; 
        int right = 2 * i + 2; 


        if (left < n && array[left] > array[largest])
        {
            largest = left;
        }

        if (right < n && array[right] > array[largest])
        {
            largest = right;
        }

        if (largest != i)
        {
            int swap = array[i];
            array[i] = array[largest];
            array[largest] = swap;

            Heapify(array, n, largest);
        }
    }
}