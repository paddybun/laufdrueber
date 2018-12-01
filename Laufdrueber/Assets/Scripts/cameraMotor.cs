using UnityEngine;

public class cameraMotor : MonoBehaviour {

    public Transform EntityToFollow;
    public float BoundaryX = 0.15f;
    public float BoundaryY = 0.05f;

    private void LateUpdate()
    {
        // Camera zoom level
        if (Input.GetAxis("Mouse ScrollWheel") < 0) // zoom out
        {
            if (Camera.main.orthographicSize <= 2f)
            {
                Camera.main.orthographicSize += .1f;
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0) // zoom in
        {
            if (Camera.main.orthographicSize >= .5f)
            {
                Camera.main.orthographicSize -= .1f;
            }
        }


    var delta = Vector3.zero;
        var deltaX = EntityToFollow.position.x - transform.position.x;
        var deltaY = EntityToFollow.position.y - transform.position.y;

        // if entity position is outside of the camera position + buffer;
        if (deltaX > BoundaryX || deltaX < -BoundaryX)
        {
            // if entity is right of the cameras middle point
            if (transform.position.x < EntityToFollow.position.x)
            {
                delta.x = deltaX - BoundaryX;
            }
            else
            {
                delta.x = deltaX + BoundaryX;
            }
        }

        // if entity position is outside of the camera position + buffer;
        if (deltaY > BoundaryY || deltaY < -BoundaryY)
        {
            // if entity is right of the cameras middle point
            if (transform.position.y < EntityToFollow.position.y)
            {
                delta.y = deltaY - BoundaryY;
            }
            else
            {
                delta.y = deltaY + BoundaryY;
            }
        }

        transform.position += new Vector3(delta.x, deltaY, 0);
    }
}
