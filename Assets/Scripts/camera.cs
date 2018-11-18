using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour {
    public Transform PlayerPosition;
    public float OuterBoundX = 0.15f;
    public float OuterBoundY = 0.10f;

    private void LateUpdate()
    {
        var delta = Vector3.zero;
        var deltaX = PlayerPosition.position.x - transform.position.x;
        var deltaY = PlayerPosition.position.y - transform.position.y;

        if (deltaX > OuterBoundX || deltaX < -OuterBoundX)
        {
            if (transform.position.x < PlayerPosition.position.x)
            {
                delta.x = deltaX - OuterBoundX;
            }
            else
            {
                delta.x = deltaX + OuterBoundX;
            }
        }

        if (deltaY > OuterBoundY || deltaY < -OuterBoundY)
        {
            if (transform.position.y < PlayerPosition.position.y)
            {
                delta.y = deltaY - OuterBoundY;
            }
            else
            {
                delta.y = deltaY + OuterBoundY;
            }
        }

        transform.position += delta;
    }
}
