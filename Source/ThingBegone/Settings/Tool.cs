using System.Collections.Generic;
using UnityEngine;

namespace ThingBegone.Settings
{
    // Token: 0x02000003 RID: 3
    public static class Tool
    {
        // Token: 0x06000004 RID: 4 RVA: 0x000022F0 File Offset: 0x000004F0
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

        // Token: 0x06000005 RID: 5 RVA: 0x00002364 File Offset: 0x00000564
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
}