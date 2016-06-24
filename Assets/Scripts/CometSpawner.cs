using UnityEngine;
using System.Collections;

public class CometSpawner : MonoBehaviour {
	public GameObject comet;
	public float spawnDelay;
	public float radius;
	private float spawnTime;
	private InputHandler inputHandler;

	void Start () {
		inputHandler = GameObject.FindObjectOfType <InputHandler> ();
	}

	void Update () {
		if (spawnTime < Time.time) {
			spawnTime = Time.time + spawnDelay;

			Vector3 random = Random.insideUnitSphere;
			random.y = 0;
			Vector3 position = random * radius;

			Quaternion rotation = Quaternion.Euler (0, Random.Range (0, 359), 0);

			SpawnComet(position, rotation);
		}
	}

	public void SpawnComet(Vector3 position, Quaternion rotation) {
		SpawnComet (position, rotation, comet.transform.localScale);
	}

	public void SpawnComet (Vector3 position, Quaternion rotation, Vector3 scale) {
		GameObject obj = PoolingScript.current.GetPooledObject (comet);

		if (obj == null)
			return;

		obj.transform.position = position;
		obj.transform.rotation = rotation;
		obj.transform.localScale = scale;
		obj.SetActive (true);

		transform.position = position;
		transform.rotation = rotation;
		transform.localScale = scale;
	}
}