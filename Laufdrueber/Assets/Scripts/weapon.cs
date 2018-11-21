using UnityEngine;

public class weapon : MonoBehaviour {

    public Transform FirePoint;
    public GameObject BulletPrefab;

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
	}

    private void Shoot()
    {
        Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
    }
}
