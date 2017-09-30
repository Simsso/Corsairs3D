using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour {

    uint level = 0;

	void Start () {
        NextLevel();
	}
	
	void Update () {
		
	}

    private void NextLevel()
    {
        level++;

        // spawn coins

        GameObject coinInitEmpty = new GameObject();
        coinInitEmpty.name = "CoinInitEmpty";
        CoinInit coinInit = coinInitEmpty.AddComponent<CoinInit>();
        coinInit.count = 100;
        coinInit.element = Resources.Load<GameObject>("Coin");
        coinInit.radius = 30;
        coinInit.height = 1;
        coinInit.rotation = new Vector3(90, 0, 0);
    }
}
