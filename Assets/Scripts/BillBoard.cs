using UnityEngine;
using System.Collections;

public class BillBoard : MonoBehaviour {
	private Transform camera;

	void Start() {
		camera = Camera.main.transform;
	}

	void Update () {
		transform.LookAt (camera);
	}
}
