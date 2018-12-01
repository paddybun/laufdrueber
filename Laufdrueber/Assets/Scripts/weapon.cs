using UnityEngine;

public class weapon : MonoBehaviour {

    private GameObject[] _bulletBuffer;
    private float _ellapsedTime = 0;

    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 1f;
    public int maxBullets = 200;
    void Start()
    {
        _bulletBuffer = new GameObject[maxBullets];
        // Queue all bullets
        for (int i = 0; i < maxBullets; i++)
        {
            var bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false);
            _bulletBuffer[i] = bullet;
        }
    }

	void Update () {
        _ellapsedTime += Time.deltaTime;
		if (Input.GetMouseButton(0) && _ellapsedTime >= .05f)
        {
            Shoot();
            _ellapsedTime = 0;
        }
	}

    private void Shoot()
    {
        var worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var direction = (Vector2)(worldMousePos - transform.position);
        direction.Normalize();

        // Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        GameObject shot = GetBullet(); 
        if (shot == null)
        {
            return;
        }

        shot.transform.position = firePoint.position;
        shot.transform.rotation = Quaternion.identity;
        shot.SetActive(true);

        var shotPhysics = shot.GetComponent<Rigidbody2D>();
        shotPhysics.velocity = direction * bulletSpeed;
        // Rotate Bullet
        var rotation = Mathf.Atan2(
                worldMousePos.y - transform.position.y,
                worldMousePos.x - transform.position.x
            ) * Mathf.Rad2Deg - 90;
        shotPhysics.rotation = rotation;
    }

    private GameObject GetBullet()
    {
        foreach (var item in _bulletBuffer)
        {
            if (!item.activeInHierarchy)
            {
                return item;
            }
        }
        return null;
    }
}
