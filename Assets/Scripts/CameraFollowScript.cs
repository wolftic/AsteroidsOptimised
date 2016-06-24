using UnityEngine;
using System.Collections;

public class CameraFollowScript : MonoBehaviour {
	[SerializeField]
	public Transform player;
	private Vector3 offset;
	private bool BackCam = false;

	private float yRotation;
	[SerializeField]
	private float ySpeed;
	private InputHandler inputHandler;
	private KeyCode behindKnop;

	void Awake(){
		inputHandler = GameObject.FindObjectOfType <InputHandler> ();
	}

	void Start () {
		transform.GetChild(0).localPosition = offset;
		behindKnop = inputHandler.inputs ["watchBehindKnop"];
	}

	void Update () {
		if(player)
		{
			yRotation = player.eulerAngles.y;

			if (Input.GetKey(behindKnop)) {
				yRotation += 180;
			}

			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler (0, yRotation, 0), 5.0f * Time.deltaTime);
			transform.position = player.position;
		}
	}
}