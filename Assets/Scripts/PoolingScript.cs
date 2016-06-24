using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PoolingScript : MonoBehaviour {

	public static PoolingScript current;
	[SerializeField]
	private GameObject[] pooledObject;
	private int pooledAmount = 10;
	private int specialPooledAmount = 2;
	[SerializeField]
	private bool willGrow = true;
	//[HideInInspector]
	//public GameObject bulletsAndComets;
	List<List<GameObject>> pooledObjects;

	void Awake(){
		current = this;
		//bulletsAndComets = new GameObject ("Bullets and Comets");
	}

	void Start(){
		pooledObjects = new List<List<GameObject>> ();
		for (int x = 0; x < pooledObject.Length; x++) {
			pooledObjects.Add (new List<GameObject> ());
			Debug.Log ("Made list of GameObject: " + pooledObject [x]);
			if (x > 3) {
				for (int i = 0; i < pooledAmount; i++) {
					GameObject obj = (GameObject)Instantiate (pooledObject [x]);
					obj.SetActive (false);
					//obj.transform.SetParent (bulletsAndComets.transform);
					pooledObjects [x].Add (obj);
				}
			} else {
				for (int i = 0; i < specialPooledAmount; i++) {
					GameObject obj = (GameObject)Instantiate (pooledObject [x]);
					obj.SetActive (false);
					//obj.transform.SetParent (bulletsAndComets.transform);
					pooledObjects [x].Add (obj);
				}
			}
		}
	}

	public GameObject GetPooledObject(GameObject type, bool active = false){
		for (int x = 0; x < pooledObject.Length; x++) {
			if(pooledObject[x] != type) {
				continue; 
			}

			for (int i = 0; i < pooledObjects[x].Count; i++) {
				if (!pooledObjects [x] [i].activeSelf) {
					pooledObjects [x] [i].SetActive (active);
					return pooledObjects [x] [i];
				}
			}

			if(willGrow){
				GameObject obj = (GameObject)Instantiate ((pooledObject[x]));
				//obj.transform.SetParent (bulletsAndComets.transform);
				obj.SetActive (active);
				pooledObjects [x].Add (obj);
				return obj;
			}
		}

		return null;
	}
	public void Destroy(GameObject obj){
		obj.SetActive (false);
	}
}