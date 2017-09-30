using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour {
    public float averageShotsPerSecond;
    public GameObject target;
    public GameObject cannonball;
    public float firePower, upwardForce, fireArea = .2f, targetPosition;

    private ShipController ship;

    private const int cannonCount = 8;

	void Start ()
    {
        ship = target.GetComponent<ShipController>();
    }
	
	void Update () {
		if (!ship.hit && Random.value < Time.deltaTime * averageShotsPerSecond)
        {
            FireShot();
        }
	}
    
    void FireShot()
    {
        // retrieve target position in rad
        targetPosition = ship.position;
        bool targetForward = ship.directionForward;

        // fire randomly into a region fireArea (e.g. 30%) of a circles circumference
        // in the example 15% in front of and 15% behind the ship
        // The value that is subtracted from the random value defines how many bullets will go behind the ship.
        float direction = Mathf.Abs((targetPosition + (Random.value - .25f) * (targetForward ? 1 : -1) * Mathf.PI * 2 * fireArea) % (2 * Mathf.PI));
        FireShot(direction);
    }

    void FireShot(float directionRad)
    {
        // create new cannon ball
        GameObject newCannonball = Instantiate(cannonball, new Vector3(0, 11.9f, 0), Quaternion.identity);
        // apply force ("fire")
        Vector3 force = new Vector3(firePower * Mathf.Sin(directionRad), firePower * upwardForce, firePower * Mathf.Cos(directionRad));
        newCannonball.GetComponent<Rigidbody>().AddForce(force);
        newCannonball.GetComponent<Rigidbody>().AddTorque(new Vector3(Random.value, Random.value, Random.value));
    }

    public void IncreaseAggression()
    {
        averageShotsPerSecond *= 1.2f;
        fireArea *= 1.1f;
    }
}
