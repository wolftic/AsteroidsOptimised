using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {
	public float Health;


	public void doDamage(float damage) {
		Health -= damage;
	}

	void Update()
	{
		if(Health <= 0)
		{
			GameObject explosion = Instantiate (Resources.Load ("FX_Particle", typeof(GameObject)), transform.position, Quaternion.identity) as GameObject; 
			Destroy (explosion, 4.9f);
			if(tag == "Enemy")
			Destroy (gameObject);
		}
	}
}