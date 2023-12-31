﻿namespace Problem1_cs;

public static class Helpers
{
    public static String FindStem(String[] arr)
    {
        int n = arr.Length;

        String s = arr[0];
        int len = s.Length;

        String res = "";

        for (int i = 0; i < len; i++)
        {
            for (int j = i + 1; j <= len; j++)
            {
                String stem = s.Substring(i, j - i);
                int k = 1;
                for (k = 1; k < n; k++)
                    if (!arr[k].Contains(stem))
                        break;

                if (k == n && res.Length < stem.Length)
                    res = stem;
            }
        }

        return res;
    }
}
