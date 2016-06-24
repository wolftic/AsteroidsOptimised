///Daniel Moore (Firedan1176) - Firedan1176.webs.com/
///26 Dec 2015
///
///Shakes camera parent object

using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour {

	public bool debugMode = false;//Test-run/Call ShakeCamera() on start

	public float shakeAmount;//The amount to shake this frame.
	public float shakeDuration;//The duration this frame.

	//Readonly values...
	float shakePercentage;//A percentage (0-1) representing the amount of shake to be applied when setting rotation.
	float startAmount;//The initial shake amount (to determine percentage), set when ShakeCamera is called.
	float startDuration;//The initial shake duration, set when ShakeCamera is called.

	[SerializeField]
	bool isRunning = false;	//Is the coroutine running right now?

	public bool smooth;//Smooth rotation?
	public float smoothAmount = 5f;//Amount to smooth
	private Vector3 oldAngle;

	void Start () {

		if(debugMode) ShakeCamera ();
	}

	void LateUpdate() {
		if (isRunning) {
			//oldAngle = transform.eulerAngles;
			Vector3 rotationAmount = Random.insideUnitSphere * shakeAmount;//A Vector3 to add to the Local Rotation
			rotationAmount.z = 0;//Don't change the Z; it looks funny.
			rotationAmount += oldAngle;

			shakePercentage = shakeDuration / startDuration;//Used to set the amount of shake (% * startAmount).

			shakeAmount = startAmount * shakePercentage;//Set the amount of shake (% * startAmount).
			//shakeDuration = Mathf.Lerp(shakeDuration, 0, Time.deltaTime);//Lerp the time, so it is less and tapers off towards the end.
			shakeDuration -= Time.deltaTime;

			if (smooth)
				transform.localRotation = Quaternion.Lerp (transform.localRotation, Quaternion.Euler (rotationAmount), Time.deltaTime * smoothAmount);
			else
				transform.localRotation = Quaternion.Euler (rotationAmount);//Set the local rotation the be the rotation amount.

			Debug.Log ("running");
		} else {
			Reset ();
		}

		if (shakeDuration < 0.01f) {
			isRunning = false;
		}
	}

	void Reset() {
		if (oldAngle != Vector3.zero) {
			transform.localEulerAngles= oldAngle;
		}
	}

	void ShakeCamera() {

		startAmount = shakeAmount;//Set default (start) values
		startDuration = shakeDuration;//Set default (start) values

		oldAngle = transform.eulerAngles;
		isRunning = true;

		//if (!isRunning) StartCoroutine (Shake());//Only call the coroutine if it isn't currently running. Otherwise, just set the variables.
	}

	public void ShakeCamera(float amount, float duration) {

		shakeAmount += amount;//Add to the current amount.
		startAmount = shakeAmount;//Reset the start amount, to determine percentage.
		shakeDuration += duration;//Add to the current time.
		startDuration = shakeDuration;//Reset the start time.

		oldAngle = transform.localEulerAngles; 	
		Debug.Log (oldAngle);
		isRunning = true;

		//if(!isRunning) StartCoroutine (Shake());//Only call the coroutine if it isn't currently running. Otherwise, just set the variables.
	}

}