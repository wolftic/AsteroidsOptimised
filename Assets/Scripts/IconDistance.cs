using UnityEngine;
using System.Collections;

public class IconDistance : MonoBehaviour {
	[SerializeField]
	private float maxRange;
	[SerializeField]
	private float minRange;

	private SpriteRenderer renderer;
	private float percentage;
	private Color trans;
	private Transform camera;

	void Start () {
		renderer = GetComponent<SpriteRenderer> ();
		camera = Camera.main.transform;
		trans = Color.white;
		trans.a = 0;
	}

	void Update () {
		transform.LookAt (camera.position);

		float dist = Vector3.Distance (camera.position, transform.position);

		if (dist < maxRange && dist > minRange) {
			percentage += Time.deltaTime;
		} else {
			percentage -= Time.deltaTime;
		}

		percentage = Mathf.Clamp (percentage, 0, 1);
		renderer.color = Color.Lerp(trans, Color.white, percentage);
	}
}
