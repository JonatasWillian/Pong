using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utility
{
    public static Rect GetScreenPositionFromRect(RectTransform rt, Camera camera)
    {
        Vector3[] worldCorners = new Vector3[4];
        rt.GetWorldCorners(worldCorners);

        for (var i = 0; i < worldCorners.Length; i++)
        {
            worldCorners[i] = Camera.main.WorldToScreenPoint(worldCorners[i]);
        }

        var position = (Vector2)worldCorners[1];
        position.y = Screen.height - position.y;
        var size = worldCorners[2] - worldCorners[0];

        return new Rect(position, size);
    }
}
