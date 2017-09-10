using UnityEngine;

public class ShipController : MonoBehaviour {
    public bool directionForward; // true = forward, false = backward
    public float speed;
    public float position; // position in rad
    public float radius; // radius in game units
    public bool hit;

	void Start () {
		
	}
	
	void FixedUpdate() {
		if (hit)
        {
            // ship has been hit
            return;
        }

        // direction change
        if (DirectionChangeRequested())
        {
            directionForward = !directionForward;
        }

        UpdateLocation(Time.deltaTime);
	}

    private bool DirectionChangeRequested()
    {
        // may be extended for touch devices
        return Input.GetKeyDown(KeyCode.Space);
    }

    /// <summary>
    /// Updates the position of the ship depending on direction and passed time.
    /// </summary>
    /// <param name="deltaTime">Time since last update</param>
    private void UpdateLocation(float deltaTime)
    {
        float deltaRad = deltaTime * speed;
        position += deltaRad * (directionForward ? 1 : -1); // add or subtract depending on the direction
        position %= (float)(2 * Mathf.PI); // crop position to maximum circumferece of two pi

        // update position and rotation
        transform.position = radius * new Vector3(Mathf.Sin(position), 0, Mathf.Cos(position)) + new Vector3(0, transform.position.y, 0);
        transform.eulerAngles = new Vector3(0, position / 2 / Mathf.PI * 360 + (directionForward ? 180 : 0), 0) + new Vector3(transform.eulerAngles.x, 90, transform.eulerAngles.z);
    }
}
