using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {
	float xSpeed;
	Vector3 movement;

	public ParticleSystem[] thrusters;
	public Transform target;
	public float maxSpeed;
	public float RANGE;
	public float SEERANGE;
	public bool inRange;

	private GameObject[] players;

	void Start () {
		maxSpeed = 30.0f;
		inRange = false;

		players = GameObject.FindGameObjectsWithTag ("Player");
		GameObject.FindGameObjectWithTag ("Camera").GetComponent<CompassScript> ().AddPoint ("Enemy", gameObject, Color.red);
	}

	Quaternion newRot;
	Quaternion oldRot;

	void Update () {
		if (target) {
			Chasing ();
		} else {
			Patrol ();
		}
	}

	float lastRotChange;

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

		transform.GetChild (0).localRotation = Quaternion.Lerp (transform.GetChild (0).localRotation, Quaternion.Euler (diff * 30.0f * Vector3.forward), 5.0f * Time.deltaTime);

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

		if (Vector3.Distance (transform.position, target.position) < RANGE) {
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

		transform.GetChild (0).localRotation = Quaternion.Lerp (transform.GetChild (0).localRotation, Quaternion.Euler (diff * 30.0f * Vector3.forward), 5.0f * Time.deltaTime);
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

		if (distance <= SEERANGE && distance != 0) {
			target = players [id].transform;
		} else {
			target = null;
		}
	}
}