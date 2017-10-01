using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipController : MonoBehaviour {
    public bool directionForward; // true = forward, false = backward
    public float speed;
    public float position; // position in rad
    public float radius; // radius in game units
    public bool hit;

    private uint coinsCollected = 0; // coins collected in the current level

    public uint CoinsCollected
    {
        get
        {
            return coinsCollected;
        }
    }

    public void ResetCoinsCollected()
    {
        coinsCollected = 0;
    }

	void Update() {
		if (hit && DirectionChangeRequested())
        {
            // restart
            SceneManager.LoadScene("MainScene");
        }

        // direction change
        if (DirectionChangeRequested())
        {
            directionForward = !directionForward;
        }
	}

    void FixedUpdate()
    {
        if (!hit)
        {
            UpdateLocation(Time.deltaTime);
        }
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
        position %= 2 * Mathf.PI; // crop position to maximum circumferece of two pi
        if (position < 0)
        {
            position += 2 * Mathf.PI;
        }

        // update position and rotation
        transform.position = radius * new Vector3(Mathf.Sin(position), 0, Mathf.Cos(position)) + new Vector3(0, transform.position.y, 0);
        transform.eulerAngles = new Vector3(0, position / 2 / Mathf.PI * 360 + (directionForward ? 180 : 0), 0) + new Vector3(transform.eulerAngles.x, 90, transform.eulerAngles.z);
    }

    void OnTriggerEnter(Collider collider)
    {
        switch (collider.tag)
        {
            case "Cannonball":
                Destroy(collider.gameObject);
                hit = true;
                SinkShip();
                break;

            case "Coin":
                Destroy(collider.gameObject);
                coinsCollected++;
                break;
        }
    }

    void SinkShip()
    {
        this.GetComponent<Rigidbody>().useGravity = true;
    }
}
