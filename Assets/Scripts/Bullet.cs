using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour {
	public float speed, damage;
	[HideInInspector]
	public Transform shooter;

	Rigidbody rigidbody;

	void Start () {
		rigidbody = GetComponent<Rigidbody> ();
		rigidbody.constraints = RigidbodyConstraints.FreezePositionY;

		Invoke ("DestroyFunction", 5f);
	}

	void Update () {
		transform.Translate (Vector3.forward * speed * Time.deltaTime);
	}

	void OnTriggerEnter(Collider other) {
		if (other.transform == shooter || other.transform.tag == "Boss" && shooter.tag == "Enemy")
			return;
		
		if (other.transform.tag == "Player") {
			other.transform.GetComponent<PlayerHealth> ().doDamage (damage);
			DestroyFunction ();
		}

		if (other.transform.tag == "Enemy") {
			other.transform.GetComponent<EnemyHealth> ().doDamage (damage);
			DestroyFunction ();
		}

		if (other.transform.tag == "Boss") {
			other.transform.GetComponent<EnemyHealth> ().doDamage (damage);
			DestroyFunction ();
		}

		if(other.transform.tag == "Comet")
		{
			DestroyFunction ();
			other.gameObject.GetComponent <Comet> ().split();
		}

		SoundManager.current.PlaySound ("Explosie");
	}

	void DestroyFunction(){
		PoolingScript.current.Destroy (gameObject);
	}

	void OnDisable(){
		CancelInvoke ();
	}
}
