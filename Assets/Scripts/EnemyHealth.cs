using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {
	public float health;

	public void doDamage(float damage) {
		health -= damage;
	}

	void Update()
	{
		if(health <= 0)
		{
			GameObject explosion = Instantiate (Resources.Load ("FX_Particle", typeof(GameObject)), transform.position, Quaternion.identity) as GameObject; 
			Destroy (explosion, 4.9f);
			if(tag == "Enemy")
			Destroy (gameObject);
		}
	}
}