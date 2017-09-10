using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonballDestructor : MonoBehaviour {

	void Start () {
		
	}
	
	void Update () {
		
	}

    void OnTriggerEnter(Collider collider)
    {
        switch (collider.tag)
        {
            case "Cannonball":
                Destroy(collider.gameObject);
                break;
        }
    }
}
