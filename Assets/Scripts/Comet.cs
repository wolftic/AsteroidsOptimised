using UnityEngine;
using System.Collections;

public class Comet : MonoBehaviour {
	float time;
	private CometSpawner cometSpawner;
	[SerializeField]
	private SpriteRenderer icon;
	[SerializeField]
	private float damage;

	private Transform child;
	private Transform camera;

	void Start () {
		cometSpawner = GameObject.Find ("CometSpawner").GetComponent <CometSpawner> ();
		child = transform.GetChild (0);
		camera = Camera.main.transform;
	}

	void OnEnable () {
		time = Time.time + 10;
		GameObject.FindGameObjectWithTag ("Camera").GetComponent<CompassScript> ().AddPoint ("Comet", gameObject, Color.white, icon);
	}

	void Update () {
		transform.Translate (Vector3.forward * 10.0f * Time.deltaTime);
		child.LookAt (camera.position);
		if (time < Time.time) {
			split ();
		}
	}	

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			other.GetComponent<PlayerHealth> ().doDamage (damage);
			split ();
		}
		if (other.tag == "Enemy") {
			other.GetComponent<EnemyHealth> ().doDamage (damage);
			split ();
		}
	}

	public void split() {
		Vector3 scale = Vector3.one * (transform.localScale.x - 1);
		if (scale.x != 0) {
			for (int i = 0; i < 2; i++) {
				Quaternion rot = transform.rotation;
				rot.y *= Random.Range(-45, 45);
				cometSpawner.SpawnComet(transform.position, rot, scale);
			}
		}

		GameObject explosion = Instantiate (Resources.Load ("FX_Bolletjes_trail 1", typeof(GameObject))) as GameObject; 
		explosion.transform.position = transform.position;
		explosion.transform.localScale = transform.localScale * .1f;
		Destroy (explosion, 9f);

		PoolingScript.current.Destroy (gameObject);
	}
}
