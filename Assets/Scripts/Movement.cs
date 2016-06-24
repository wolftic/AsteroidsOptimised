using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	[SerializeField]
	private float maxSpeed = 30.0f;
	private float xSpeed;
	[HideInInspector]
	public bool frozen;
	[HideInInspector]
	public bool reversed;

	private Vector3 movement;
	[SerializeField]
	private ParticleSystem[] thrusters;
	[SerializeField]
	private Transform target;

	private InputHandler IH;
	private Transform child;

	void Start () {
		IH = GameObject.FindGameObjectWithTag ("Playerinventory").GetComponent<InputHandler> ();
		child = transform.GetChild (0);
	}

	private Quaternion newRot;

	void Update () {
		if(IH.GetAxis("vertical") != 0) {
			for (int i = 0; i < thrusters.Length; i++) {
				if (!thrusters [i].isPlaying && IH.GetAxis("vertical") > 0.5f) {
					thrusters [i].Play ();
				}
			}
			xSpeed += IH.GetAxis("vertical");
			xSpeed = Mathf.Clamp (xSpeed, 0f, maxSpeed);
		} else {
			for (int i = 0; i < thrusters.Length; i++) {
				if (thrusters [i].isPlaying) {
					thrusters [i].Stop ();
				}
			}
			xSpeed *= 0.99f;
		}

		float horizontal = IH.GetAxis("horizontal");
		if (reversed) {
			horizontal = -horizontal;
			xSpeed = -xSpeed;
		}
		if(frozen){
			horizontal = 0;
			xSpeed = 0;
		}
		newRot = Quaternion.Euler(-horizontal * 30.0f * Vector3.forward);;

		transform.Translate (Vector3.forward * Time.deltaTime * xSpeed);
 		transform.Rotate (horizontal * 1.0f * Vector3.up);
		child.localRotation = Quaternion.Lerp (child.localRotation, newRot, 5.0f * Time.deltaTime);
	}
}
