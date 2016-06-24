using UnityEngine;
using System.Collections;
using ItemType = PlayerInventory.ItemType;

public class BuyScript : MonoBehaviour {

	private PlayerInventory playerInventory;
	private int hUP = 10; //health Upgrade Price
	private int fPUP = 20; //firePower Upgrade Price
	private int sUP = 50; // speed Upgrade Price


	void Awake()
	{
		playerInventory = GameObject.FindGameObjectWithTag ("Playerinventory").GetComponent <PlayerInventory>();
	}

	//shop functie aanmaken
	public void ShopInteraction(GameObject knop)
	{
		switch (knop.tag) {

		case "Buyknop1":
			//als item niet in inventory zit kan jij code uitvoeren
			if(playerInventory.InInventory (ItemType.BCAvalon) == false)
			{
				//als jij zoveel coins heeft kan jij code uitvoeren
				if(playerInventory.DeductCoins (50))
				{
					//Item in inventory toevoegen
					playerInventory.AddItem (ItemType.BCAvalon);
					//aangeven dat speler item gekocht heeft.
					Debug.Log ("Bought BC Avalon");
				}
				//als speler te weinig geld heeft
				else
				{
					//aangeven dat speler te weinig geld heeft.
					Debug.Log ("Get More moneyz");
				}
			}
			//als je item al hebt.
			else
				//aangeven dat speler het item al heeft.
				Debug.Log ("Already got it!");

			break;

		case "Buyknop2":
			if (playerInventory.InInventory (ItemType.SSEngalica) == false)
			if (playerInventory.DeductCoins (50)) {
				playerInventory.AddItem (ItemType.SSEngalica);
			} else
				Debug.Log ("Get More Moneyz");
			else
				Debug.Log ("Already got it");

			break;

		case "Buyknop3":
			//als item niet in inventory zit kan jij code uitvoeren
			if(playerInventory.InInventory (ItemType.SCStriker) == false)
			{
				//als jij zoveel coins heeft kan jij code uitvoeren
				if(playerInventory.DeductCoins (50))
				{
					//Item in inventory toevoegen
					playerInventory.AddItem (ItemType.SCStriker);
					//aangeven dat speler item gekocht heeft.
					Debug.Log ("Bought SC Striker");
				}
				//als speler te weinig geld heeft
				else
				{
					//aangeven dat speler te weinig geld heeft.
					Debug.Log ("Get More moneyz");
				}
			}
			//als je item al hebt.
			else
				//aangeven dat speler het item al heeft.
				Debug.Log ("Already got it!");

			break;


		/*case "Buyknop1":
			if (playerInventory.DeductCoins (10)) {
				playerInventory.AddItem (ItemType.AmmoGun1);
				Debug.Log ("bought ammo");
			} else
				Debug.Log ("get more money");

			break;*/

		case "Buyknop4":
			//als item niet in inventory zit kan jij code uitvoeren
			if(playerInventory.InInventory (ItemType.LWSSFrumentum) == false)
			{
				//als jij zoveel coins heeft kan jij code uitvoeren
				if(playerInventory.DeductCoins (50))
				{
					//Item in inventory toevoegen
					playerInventory.AddItem (ItemType.LWSSFrumentum);
					//aangeven dat speler item gekocht heeft.
					Debug.Log ("Bought LWSS Frumentum");
				}
				//als speler te weinig geld heeft
				else
				{
					//aangeven dat speler te weinig geld heeft.
					Debug.Log ("Get More moneyz");
				}
			}
			//als je item al hebt.
			else
				//aangeven dat speler het item al heeft.
				Debug.Log ("Already got it!");

			break;

		case "Buyknop5":
			if(playerInventory.InInventory (ItemType.HMSConchylium) == false)
			{
				//als jij zoveel coins heeft kan jij code uitvoeren
				if(playerInventory.DeductCoins (50))
				{
					//Item in inventory toevoegen
					playerInventory.AddItem (ItemType.HMSConchylium);
					//aangeven dat speler item gekocht heeft.
					Debug.Log ("Bought HMS Conchylium");
				}
				//als speler te weinig geld heeft
				else
				{
					//aangeven dat speler te weinig geld heeft.
					Debug.Log ("Get More moneyz");
				}
			}
			//als je item al hebt.
			else
				//aangeven dat speler het item al heeft.
				Debug.Log ("Already got it!");

			break;

		case "Buyknop6":
			if(playerInventory.InInventory (ItemType.BSContortor) == false)
			{
				//als jij zoveel coins heeft kan jij code uitvoeren
				if(playerInventory.DeductCoins (50))
				{
					//Item in inventory toevoegen
					playerInventory.AddItem (ItemType.BSContortor);
					//aangeven dat speler item gekocht heeft.
					Debug.Log ("Bought BS Contortor");
				}
				//als speler te weinig geld heeft
				else
				{
					//aangeven dat speler te weinig geld heeft.
					Debug.Log ("Get More moneyz");
				}
			}
			//als je item al hebt.
			else
				//aangeven dat speler het item al heeft.
				Debug.Log ("Already got it!");

			break;

		case "Buyknop7":
			if(playerInventory.InInventory (ItemType.HWSSGeminus) == false)
			{
				//als jij zoveel coins heeft kan jij code uitvoeren
				if(playerInventory.DeductCoins (50))
				{
					//Item in inventory toevoegen
					playerInventory.AddItem (ItemType.HWSSGeminus);
					//aangeven dat speler item gekocht heeft.
					Debug.Log ("Bought HWSS Geminus");
				}
				//als speler te weinig geld heeft
				else
				{
					//aangeven dat speler te weinig geld heeft.
					Debug.Log ("Get More moneyz");
				}
			}
			//als je item al hebt.
			else
				//aangeven dat speler het item al heeft.
				Debug.Log ("Already got it!");

			break;

		case "Buyknop8":
			if(playerInventory.InInventory (ItemType.HealthUpgrade) == false)
			{
				if(playerInventory.DeductCoins (hUP))
				{
					hUP = hUP * 2;
					playerInventory.AddItem (ItemType.HealthUpgrade);
					Debug.Log ("Bought health upgrade");
				}
				else
				{
					Debug.Log ("Get More moneyz");
				}
			}
			else
				Debug.Log ("Already got it!");

			break;

		case "Buyknop9":
			if(playerInventory.InInventory (ItemType.FirePowerUpgrade) == false)
			{
				if(playerInventory.DeductCoins (fPUP))
				{
					fPUP = fPUP * 2;
					playerInventory.AddItem (ItemType.FirePowerUpgrade);
					Debug.Log ("Bought firepower upgrade");
				}
				else
				{
					Debug.Log ("Get More moneyz");
				}
			}
			else
				Debug.Log ("Already got it!");

			break;

		case "Buyknop10":
			//als speler nog geen upgrade heeft gekocht voer code uit
			if(playerInventory.InInventory (ItemType.SpeedUpgrade) == false)
			{
				//test of de speler genoeg coins heb en haal het geld weg, voer daarna code uit
				if(playerInventory.DeductCoins (sUP))
				{
					//double the price of the upgrade
					sUP = sUP * 2;
					//add upgrade aan inventory
					playerInventory.AddItem (ItemType.SpeedUpgrade);
					//aangeven dat de speler upgrade gekocht heeft
					Debug.Log ("Bought speed upgrade");
				}
				//als speler te weinig geld heeft voer code uit
				else
				{
					//aangeven dat speler te weinig geld heeft
					Debug.Log ("Get More moneyz");
				}
			}
			//als speler upgrade al heeft
			else
				//aangeven dat speler upgrade al heeft
				Debug.Log ("Already got it!");

			break;
		}
	}
}