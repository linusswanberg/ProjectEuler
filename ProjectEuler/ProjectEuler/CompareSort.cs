namespace ProjectEuler
{
    using System.Collections;

    public class CompareSort : IComparer
    {
        public int Compare(object x, object y)
        {
            var str1 = x.ToString();
            var str2 = y.ToString();
            var i = 0;

            while (i < str1.Length && i < str2.Length)
            {
                if (str1[i] == str2[i])
                {
                    i++;
                }
                else
                {
                    if (str1[i] < str2[i])
                    {
                        return -1;
                    }
                    return 1;
                }
            }
            return str1.Length - str2.Length;
        }
    }
}
