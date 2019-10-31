namespace SortingStrategies
{
    public class Bubble
    {
        public void Sort(int[] data)
        {
            int i, j;
            int N = data.Length;

            for (j = N - 1; j > 0; j--)
            {
                for (i = 0; i < j; i++)
                {
                    if (data[i] > data[i + 1])
                        exchange(data, i, i + 1);
                }
            }

        }

        public static void exchange (int[] data, int m, int n)
        {
            int temporary;

            temporary = data [m];
            data [m] = data [n];
            data [n] = temporary;
        }
    }
}
