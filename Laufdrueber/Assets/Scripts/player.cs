using UnityEngine;

public class player : MonoBehaviour {

    private delegate void OnRollingEnded();
    private static event OnRollingEnded onRollingEnded;
    private delegate void OnRollingStarted();
    private static event OnRollingStarted onRollingStarted;

    private Vector3 _deltaMovement;
    private float rollingTime;

    public float PlayerSpeed = 0.005f;
    public Animator Animator;

    void Start()
    {
        onRollingEnded += RollingEnded;
        onRollingStarted += RollingStarted;
    }

    private void RollingStarted()
    {
        Animator.SetBool("isRolling", true);
        rollingTime = Time.deltaTime;
    }

    private void RollingEnded()
    {
        Animator.SetBool("isRolling", false);
        rollingTime = Time.deltaTime;
    }

    void FixedUpdate () {
        var movementX = Input.GetAxisRaw("Horizontal");
        var movementY = Input.GetAxisRaw("Vertical");
        var rollingClick = Input.GetMouseButton(1);

        Rotate(movementX);
        Roll(rollingClick);
        Move(movementX, movementY);
    }

    private void Move(float movementX, float movementY)
    {
        var delta = new Vector3(movementX, movementY, 0);
        Animator.SetFloat("speed", Mathf.Abs(movementX) + Mathf.Abs(movementY));
        transform.Translate(delta * (Time.deltaTime + PlayerSpeed));
    }
    private void Rotate(float movementX)
    {
        if (movementX > 0)
        {
            transform.localScale = Vector3.one;
        }
        else if (movementX < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
    private void Roll(bool rollingClick)
    {
        if (rollingClick)
        {
            onRollingStarted();
        }

        if (rollingTime > 0)
        {
            if (rollingTime >= .5f)
            {
                onRollingEnded();
            }
            else
            {
                rollingTime += Time.deltaTime;
            }
        }
    }
    
}
