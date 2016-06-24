using UnityEngine;
using System.Collections;

public class ShopMenuScript : MonoBehaviour {

	[SerializeField]
	private Canvas buyMenu;

	public PlayerInventory playerInventory;

	void Start()
	{
		if(GameObject.FindGameObjectWithTag ("Playerinventory") == null)
		{
			Instantiate (playerInventory);
		}
	}
	void Awake () {
	
		buyMenu = buyMenu.GetComponent <Canvas> ();

		buyMenu.enabled = true;
	}

	public void SelectBuyMenu()
	{
		buyMenu.enabled = true;
	}

	public void QuitShop()
	{
		buyMenu.enabled = false;
	}
}
