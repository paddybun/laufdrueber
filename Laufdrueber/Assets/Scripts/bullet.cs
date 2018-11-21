using UnityEngine;

public class bullet : MonoBehaviour {

    private float _elapsedTravelTime = 0f;

    public float Speed = 4f;
    public Rigidbody2D RigidBody;

	void Start () {

        var bulletOrigin = Camera.main.WorldToScreenPoint(transform.position);
        var sourceVector = new Vector2(bulletOrigin.x, bulletOrigin.y);
        var targetVector = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        var heading = targetVector - sourceVector;
        var distance = heading.magnitude;
        var direction = heading / distance;
        var angle = Vector2.Angle(targetVector, sourceVector);

        RigidBody.velocity = direction * Speed;
        RigidBody.rotation = angle;
    }

    void Update()
    {
        _elapsedTravelTime += Time.deltaTime;
        if (_elapsedTravelTime > 2)
        {
            Destroy(gameObject);
            _elapsedTravelTime = 0;
        }
    }
}
