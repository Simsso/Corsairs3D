using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public GameObject shipObject; // pirate ship game object
    public float radiusOffset; // radius that will be added to the ships radius

    private ShipController ship;

	void Start () {
        if (shipObject != null) {
            ship = shipObject.GetComponent<ShipController>();
        }
    }
	
	void FixedUpdate () {
        UpdateLocation(Time.deltaTime);
	}

    void UpdateLocation (float deltaTime)
    {
        if (ship == null) return;

        // update position and rotation depending on the ship object
        transform.position = (ship.radius + radiusOffset) * new Vector3(Mathf.Sin(ship.position), 0, Mathf.Cos(ship.position)) + new Vector3(0, transform.position.y, 0);
        transform.eulerAngles = new Vector3(0, ship.position / 2 / Mathf.PI * 360, 0) + new Vector3(transform.eulerAngles.x, 180, transform.eulerAngles.z);
    }
}
