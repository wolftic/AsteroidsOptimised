using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour 
{
	//[HideInInspector]
	public float Health;
	public Image healthBar;
	private float regenDelay = 1.0F;
	private float regenTime = 0.0F;
	public bool poisoned = false;
	private bool invokingPoison = false;

	public void doDamage(float damage) 
	{
		Health -= damage;
		Debug.Log (Camera.main);
		Camera.main.transform.GetComponent<CameraShake> ().ShakeCamera (10f, .5f);
	}

	void Update()
	{
		if(Time.time > regenTime && Health < 100)
		{
			Regeneration ();
		}

		if(poisoned && invokingPoison == false){
			InvokeRepeating ("Poisoning", 1, 1);
			invokingPoison = true;
		}

		healthBar.fillAmount = Health / 100;

		if (gameObject) {
			if (Health <= 0) {
				GameObject explosion = Instantiate (Resources.Load ("FX_Particle", typeof(GameObject)), transform.position, Quaternion.identity) as GameObject; 
				Destroy (explosion, 4.9f);
				Destroy (gameObject);
			}	
		}
	}

	private void Poisoning(){
		if(poisoned == false){
			invokingPoison = false;
			CancelInvoke ();
		}
		Health -= 3;
	}

	private void Regeneration()
	{
		Health++;
		regenTime = Time.time + regenDelay;
	}
}
