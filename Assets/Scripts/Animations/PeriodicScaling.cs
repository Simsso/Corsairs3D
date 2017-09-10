using UnityEngine;

public class PeriodicScaling : MonoBehaviour {
    public Vector3 scalingFactor;
    public float speed;

    private Vector3 initialScale;
    private float time;

	void Start () {
        initialScale = transform.localScale;
	}
	
	void Update () {
        time += (Time.deltaTime * speed) % (Mathf.PI * 2);
        transform.localScale = this.initialScale + scalingFactor * (Mathf.Sin(time) + 1) / 2;
	}
}
