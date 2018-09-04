using System;
using System.Diagnostics;

namespace TrueSortBubble
{
    class Program
    {
        static int n = -1;
        static void Main(string[] args)
        {
            Stopwatch watch = new Stopwatch();
            int[] arrforbubble = {8, 9, 1, 3, 4, 4, 4, 10, 4, 5, 6, 7, 3, 2, 1, 10}, arrforHoare = { 8, 9, 1, 3, 4, 4, 4, 10, 4, 5, 6, 7, 3, 2, 1, 10 };
            Console.WriteLine("Исходный массив");
            foreach (int res in arrforbubble) Console.Write($"{res} ");
            Console.WriteLine();

            watch.Start();
            SortBubble(arrforbubble);
            watch.Stop();

            Console.WriteLine("\nСортировка пузырьком(правильная):");
            foreach (int res in arrforbubble) Console.Write($"{res} ");
            Console.WriteLine($"\n{watch.Elapsed}");

            watch.Reset();

            watch.Start();
            SortHoare(arrforHoare);
            watch.Stop();

            Console.WriteLine("\nБыстрая сортировка(Хоара):");
            foreach (int res in arrforHoare) Console.Write($"{res} ");
            Console.WriteLine($"\n{watch.Elapsed}");

            Console.ReadKey();
        }
        static void SortBubble(int[] array)
        {
            bool f = false; //создание датчика "была ли перестановка"
            if (n < 0) n = array.Length; //при первом вкл записывает длину массива
            for (int i = 0; i < n - 1; i++) //цикл который доходит до конца НЕ ОБРАБОТАННОЙ части массива
            {
                if (array[i] > array[i + 1]) //условие при котором "всплывает" наибольшее число
                {
                    Swap(ref array[i], ref array[i + 1]); //перестановка эл-ов

                    f = true; //О датчик отметился
                }
                //Console.Write(array[i] + " ");
            }
            //Console.WriteLine();
            n--; //отсекаем всплытые числа от обработки
            if (f) SortBubble(array); //если сработал датчик - идем в рекурсию
        }
        static void SortHoare(int[] array, int firstIndex = 0, int lastIndex = -1)
        {
            if (lastIndex < 0) lastIndex = array.Length - 1; //создание последнего элемента массива
            if (firstIndex >= lastIndex) return; //если элементы кончились и сравнивать больше нечего - завершение рекурсии
            int middleIndex = (lastIndex - firstIndex) / 2 + firstIndex, workingIndex = firstIndex; 
            //создание "центральной" переменной и рабочей
            Swap(ref array[firstIndex], ref array[middleIndex]); //переставление для корректного сравнивания
            for (int i = firstIndex + 1; i <= lastIndex; ++i) //цикл от второтого эл-а до последнего включительно
            {
                if (array[i] <= array[firstIndex]) //сравнение центральной со всеми эл-ми - нахождение меньших
                {
                    Swap(ref array[++workingIndex], ref array[i]); //перестановка эл-а на следующий
                }
            }
            Swap(ref array[firstIndex], ref array[workingIndex]); //перестановка возвращающая последовательность
            SortHoare(array, firstIndex, workingIndex - 1); //рекурсия массива меньших эл-от от центрального
            SortHoare(array, workingIndex + 1, lastIndex);//рекурсия массива больших эл-от от центрального
        }
        static void Swap(ref int a, ref int b)
        {
            int tmp = a;
            a = b;
            b = tmp;
        }
    }
}
