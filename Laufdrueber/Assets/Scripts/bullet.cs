using UnityEngine;

public class bullet : MonoBehaviour {

    private float ellapsedTime = 0f;

    public float lifetime;
    public ParticleSystem particleSystem;

	void Update()
    {
        ellapsedTime += Time.deltaTime;
        if (ellapsedTime >= lifetime)
        {
            var ps = Instantiate(particleSystem);
            ps.transform.position = transform.position;
            ps.Play();
            gameObject.SetActive(false);
            ellapsedTime = 0;
        }
    }
}
