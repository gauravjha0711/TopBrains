using System;
using System.Data;
using System.Reflection;
using System.Reflection.Metadata;
public class Program
{
    public static void Main()
    {
        Console.WriteLine("Enter sorted Array space separated: ");
        string a = Console.ReadLine();
        Console.WriteLine("Enter sorted Array space saparated: ");
        string b = Console.ReadLine();
        string[] arr1 = a.Split(' ');
        string[] arr2 = b.Split(' ');
        int[] array1 = new int[arr1.Length];
        int[] array2 = new int[arr2.Length];
        for(int i = 0; i < arr1.Length; i++)
        {
            array1[i] = int.Parse(arr1[i]);
        }
        for(int i = 0; i < arr2.Length; i++)
        {
            array2[i] = int.Parse(arr2[i]);
        }
        int[] result = MergeArray(array1,array2);
        Console.WriteLine(string.Join(" ",result));
    }
    public static T[] MergeArray<T>(T[] a, T[] b) where T : IComparable<T>
    {
        int n = a.Length;
        int m = b.Length;
        T[] merge = new T[m+n];
        int i=0,j=0,k=0;
        while(i<n && j < m)
        {
            if (a[i].CompareTo(b[j]) <= 0)
            {
                merge[k++] = a[i++];
            }
            else
            {
                merge[k++] = b[j++];
            }
        }
        while (i < n)
        {
            merge[k++] = a[i++];
        }
        while (j < m)
        {
            merge[k++] = b[j++];
        }
        return merge;
    }
}