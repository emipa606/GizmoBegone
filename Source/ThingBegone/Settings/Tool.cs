using System.Collections.Generic;
using UnityEngine;

namespace ThingBegone.Settings;

public static class Tool
{
    public static IList<Vector2> SetVectorCount(int maxNum)
    {
        IList<Vector2> list = new List<Vector2>();
        var x = 0f;
        var y = 0f;
        while (list.Count <= maxNum - 1)
        {
            list.Add(new Vector2(x, y));
            x += 214.75f;
            if (!(x > 644.25f))
            {
                continue;
            }

            x = 0f;
            y += 29f;
        }

        return list;
    }

    public static IList<Vector2> SetVectorCount(int maxNum, int secondMaxNum)
    {
        var list = new List<Vector2>();
        var x = 0f;
        var y = 0f;
        while (list.Count <= maxNum + secondMaxNum - 1)
        {
            list.Add(new Vector2(x, y));
            x += 214.75f;
            if (!(x > 644.25f))
            {
                continue;
            }

            x = 0f;
            y += 29f;
        }

        list.RemoveRange(0, maxNum);
        return list;
    }
}