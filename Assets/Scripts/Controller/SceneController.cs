using UnityEngine;
using UnityEngine.UI;

public class SceneController : MonoBehaviour {
    public GameObject pirateShip, island;
    public Text levelText, coinCountText;

    private ShipController shipController;
    private AttackController attackController;

    uint level = 0;

	void Start () {
        shipController = pirateShip.GetComponent<ShipController>();
        attackController = island.GetComponent<AttackController>();
        NextLevel();
	}
	
	void Update () {
        UpdateOverlay();

        // level completed
        if (shipController.CoinsCollected == 100)
        {
            NextLevel();
        }

        // close on escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private void NextLevel()
    {
        shipController.ResetCoinsCollected();
        level++;

        if (level > 1)
        {
            attackController.IncreaseAggression();
            shipController.speed *= 1.2f;
        }

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

    private void UpdateOverlay()
    {
        levelText.text = "Level #" + level.ToString();
        coinCountText.text = shipController.CoinsCollected.ToString();
    }
}
