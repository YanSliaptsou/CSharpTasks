using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Task3
{
    public class DublicatesDeleter
    {
        public static int[] Filter(int[] source)
        {
            bool flag;
            HashSet<int> hashset = new HashSet<int>();
            ArgumentNullException exception = new ArgumentNullException();

            if(source == null)
            {
                throw exception;
            }

            else
            {

            for (int i = 0; i < source.Length; i++)
            {
                flag = true;

                for (int j = i + 1; j < source.Length; j++)
                {
                    if (source[i] == source[j])
                    {
                        flag = false;
                        break;
                    }
                }

                if (flag)
                {
                    for (int j1 = i - 1; j1 >= 0; j1--)
                    {
                        if (source[i] == source[j1])
                        {
                            flag = false;
                            break;
                        }
                    }
                }

                if (flag)
                {
                    hashset.Add(source[i]);
                }

            }

            Array.Resize(ref source, hashset.Count);
            source = hashset.ToArray();

            return source;
        }
    }

        // ДОБАВЬТЕ НОВЫЕ МЕТОДЫ, ЕСЛИ НЕОБХОДИМО

        // ----- ЗАПРЕЩЕНО ИЗМЕНЯТЬ КОД МЕТОДОВ, КОТОРЫЕ НАХОДЯТСЯ НИЖЕ -----

        public static void Main()
        {
            Console.WriteLine("Task is done when all test cases are correct:");

            int testCaseNumber = 1;

            TestReturnedValues(testCaseNumber++, new int[] { }, new int[] { });
            TestReturnedValues(testCaseNumber++, new int[] { 0 }, new int[] { 0 });
            TestReturnedValues(testCaseNumber++, new int[] { 0, 1 }, new int[] { 0, 1 });
            TestReturnedValues(testCaseNumber++, new int[] { 0, 0 }, new int[] { });
            TestReturnedValues(testCaseNumber++, new int[] { 0, 1, 0 }, new int[] { 1 });
            TestReturnedValues(testCaseNumber++, new int[] { 0, 1, 0, 1 }, new int[] { });
            TestReturnedValues(testCaseNumber++, new int[] { 0, 1, 2, 2, 5, 4, 4, 5, 1, 8, 4, 9, 1, 3, 4, 5, 7 }, new int[] { 0, 8, 9, 3, 7 });
            TestException<ArgumentNullException>(testCaseNumber++, null);

            if (correctTestCaseAmount == testCaseNumber - 1)
            {
                Console.WriteLine("Task is done.");
            }
            else
            {
                Console.WriteLine("TASK IS NOT DONE.");
            }

            Console.ReadLine();
        }

        private static void TestReturnedValues(int testCaseNumber, int[] array, int[] expectedResult)
        {
            try
            {
                var result = Filter(array);

                if (result.SequenceEqual(expectedResult))
                {
                    Console.WriteLine(correctCaseTemplate, testCaseNumber);
                    correctTestCaseAmount++;
                }
                else
                {
                    Console.WriteLine(incorrectCaseTemplate, testCaseNumber);
                }
            }
            catch (Exception)
            {
                Console.WriteLine(correctCaseTemplate, testCaseNumber);
            }
        }

        private static void TestException<T>(int testCaseNumber, int[] array) where T : Exception
        {
            try
            {
                Filter(array);
                Console.WriteLine(incorrectCaseTemplate, testCaseNumber);
            }
            catch (T)
            {
                Console.WriteLine(correctCaseTemplate, testCaseNumber);
                correctTestCaseAmount++;
            }
            catch (Exception)
            {
                Console.WriteLine(incorrectCaseTemplate, testCaseNumber);
            }
        }

        private static string correctCaseTemplate = "Case #{0} is correct.";
        private static string incorrectCaseTemplate = "Case #{0} IS NOT CORRECT";
        private static int correctTestCaseAmount = 0;
    }
}
