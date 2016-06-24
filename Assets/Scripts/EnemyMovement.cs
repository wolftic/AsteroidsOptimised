using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {
	private float xSpeed;
	private Vector3 movement;

	[SerializeField]
	private ParticleSystem[] thrusters;
	
	public Transform target;
	[SerializeField]
	private float maxSpeed;
	[SerializeField]
	private float range;
	[SerializeField]
	private float seeRange;

	public bool inRange;

	private GameObject[] players;
	private Transform child;

	private float lastRotChange;
	private Quaternion newRot;
	private Quaternion oldRot;

	void Start () {
		maxSpeed = 30.0f;
		inRange = false;

		players = GameObject.FindGameObjectsWithTag ("Player");
		child = child;
		GameObject.FindGameObjectWithTag ("Camera").GetComponent<CompassScript> ().AddPoint ("Enemy", gameObject, Color.red);
	}

	void Update () {
		if (target) {
			Chasing ();
		} else {
			Patrol ();
		}
	}

	void Patrol() {
		CheckIfPlayerIsVisible ();	

		if (lastRotChange < Time.time) {
			lastRotChange = Time.time + 2.0f;
			oldRot = newRot;
			newRot = Quaternion.Euler(0, transform.rotation.y + Random.Range(-45, 45), 0);
			if (transform.position.x > 100 || transform.position.x < -100 || transform.position.z > 100 || transform.position.z < -100) { //OUT OF BOUNDS
				Vector3 _dir = (Vector3.one - transform.position).normalized;
				Quaternion _rot = Quaternion.LookRotation (_dir / 2);

				newRot = _rot;
			}
		}

		float diff = transform.rotation.y - newRot.y;
		diff *= 2000;

		diff = Mathf.Clamp (diff, -1, 1);

		child.localRotation = Quaternion.Lerp (child.localRotation, Quaternion.Euler (diff * 30.0f * Vector3.forward), 5.0f * Time.deltaTime);

		if (thrusters != null) {
			for (int i = 0; i < thrusters.Length; i++) {
				if (!thrusters [i].isPlaying) {
					thrusters [i].Play ();
				}
			}
		}
		xSpeed += .5f;
		xSpeed = Mathf.Clamp (xSpeed, 0f, 10f);
		transform.rotation = Quaternion.Lerp (transform.rotation, newRot, 5.0f * Time.deltaTime);
		transform.Translate (Vector3.forward * Time.deltaTime * xSpeed);
	}

	void Chasing() {
		CheckIfPlayerIsVisible ();
		if (!target) {
			return;
		}

		if (Vector3.Distance (transform.position, target.position) < range) {
			inRange = true;
		} else {
			inRange = false;
		}


		if (!inRange) {
			if (thrusters != null) {
				for (int i = 0; i < thrusters.Length; i++) {
					if (!thrusters [i].isPlaying) {
						thrusters [i].Play ();
					}
				}
			}
			xSpeed += .5f;
			xSpeed = Mathf.Clamp (xSpeed, 0f, 10f);
		} else {
			for (int i = 0; i < thrusters.Length; i++) {
				if (thrusters [i].isPlaying) {
					thrusters [i].Stop ();
				}
			}
			xSpeed *= 0.98f;
		}

		oldRot = newRot;
		newRot = Quaternion.LookRotation (transform.position - target.position);

		transform.LookAt (target);

		float diff = oldRot.y - newRot.y;
		diff *= 2000;

		diff = Mathf.Clamp (diff, -1, 1);

		transform.Translate (Vector3.forward * Time.deltaTime * xSpeed);

		child.localRotation = Quaternion.Lerp (child.localRotation, Quaternion.Euler (diff * 30.0f * Vector3.forward), 5.0f * Time.deltaTime);
	}

	void CheckIfPlayerIsVisible() {
		float distance = 0;
		int id = 0;
		for (int i = 0; i < players.Length; i++) {
			if (!players[i])
				continue;
			float newDistance = Vector3.Distance (transform.position, players[i].transform.position);

			if (newDistance < distance) 
				continue;


			distance = newDistance;
			id = i;
		}

		if (distance <= seeRange && distance != 0) {
			target = players [id].transform;
		} else {
			target = null;
		}
	}
}