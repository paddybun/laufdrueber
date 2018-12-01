using UnityEngine;

public class player : MonoBehaviour {

    private Vector3 _deltaMovement;
    private LookDirection _direction;

    public float PlayerSpeed = 0.005f;
    public Animator Animator;

    void Start()
    {
        _direction = LookDirection.Right;
    }

    void FixedUpdate () {
        var movementX = Input.GetAxisRaw("Horizontal");
        var movementY = Input.GetAxisRaw("Vertical");

        var mousePosition = Input.mousePosition;
        var playerPos = Camera.main.WorldToScreenPoint(transform.position);

        // Rotate
        if (mousePosition.x >= playerPos.x && _direction == LookDirection.Left)
        {
            transform.Rotate(0, 180, 0);
            _direction = LookDirection.Right;
        }
        else if (mousePosition.x < playerPos.x && _direction == LookDirection.Right)
        {
            transform.Rotate(0, 180, 0);
            _direction = LookDirection.Left;
        }

        // Animation
        var deltaMovement = Mathf.Abs(movementX) + Mathf.Abs(movementY);
        Animator.SetFloat("speed", deltaMovement);

        // Move
        Vector3 delta;
        if (_direction == LookDirection.Left)
        {
            delta = new Vector3(-movementX, movementY, 0);
        }
        else
        {
            delta = new Vector3(movementX, movementY, 0);
        }

        transform.Translate(delta * (Time.deltaTime + PlayerSpeed));
    }

    private enum LookDirection
    {
        Left,
        Right
    }
}
