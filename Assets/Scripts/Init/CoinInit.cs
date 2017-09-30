using UnityEngine;

/// <summary>
/// Places many coins in a circle around the island.
/// </summary>
public class CoinInit : MonoBehaviour {
    public uint count;
    public GameObject element;
    public float radius;
    public float height;
    public Vector3 rotation;

	void Start () {
        if (count == 0) return;

        for (float rad = 0; rad < Mathf.PI * 2; rad += Mathf.PI * 2 / count)
        {
            Vector3 position = new Vector3(radius * Mathf.Sin(rad), height, radius * Mathf.Cos(rad));
            GameObject newCoin = Instantiate(element, position, Quaternion.identity);
            newCoin.transform.eulerAngles = rotation;
            newCoin.transform.parent = this.gameObject.transform;
        }
	}
}
