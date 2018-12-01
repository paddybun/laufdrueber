using UnityEngine;

public class bullet : MonoBehaviour {
    private float ellapsedTime = 0f;

	void Update()
    {
        ellapsedTime += Time.deltaTime;
        if (ellapsedTime >= 2f)
        {
            gameObject.SetActive(false);
            ellapsedTime = 0;
        }
    }
}
