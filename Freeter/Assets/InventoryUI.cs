using UnityEngine;

public class InventoryUI : MonoBehaviour {

    Inventory inventory;

	// Use this for initialization
	void Start () {
        inventory = Inventory.instance;
        //inventory.onITemChangedCallBack += UpdateUI();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void UpdateUI()
    {
        Debug.Log("Updating UI");
    }
}
