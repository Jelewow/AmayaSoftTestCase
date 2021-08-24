using System.Collections.Generic;
using System;

namespace Extensions
{
    public static class ListExtensions
    {
        private static readonly Random s_Random = new Random();

        public static void Shuffle<T>(this IList<T> list)
        {
            int currentIndex = list.Count;
            while (currentIndex > 1)
            {
                currentIndex--;
                int nextIndex = s_Random.Next(currentIndex + 1);
                T value = list[nextIndex];
                list[nextIndex] = list[currentIndex];
                list[currentIndex] = value;
            }
        }
    }
}