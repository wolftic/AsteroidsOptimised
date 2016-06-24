using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BossEvents : MonoBehaviour {
	private Boss boss;
	[SerializeField]private Canvas blindCanvas;
	private GameObject ren;
	[SerializeField]
	private GameObject[] visible;
	[SerializeField]
	private Transform player;
	private PlayerHealth playerHealth;
	private float bossAlpha = 0.1f;
	private Movement movement;
	[SerializeField]
	private Bullet thunderBolt;
	[SerializeField]
	private Bullet iceBullet;
	[SerializeField]
	private Bullet needle;
	[SerializeField]
	private Canvas frozenCanvas;
	[SerializeField]
	private Canvas poisonCanvas;



	void Start(){
		playerHealth = player.GetComponent <PlayerHealth> ();
		movement = player.GetComponent <Movement> ();
		blindCanvas.enabled = false;
		frozenCanvas.enabled = false;
		poisonCanvas.enabled = false;
		boss = GetComponent <Boss> ();
	}

	void Update(){
		if (playerHealth.Health <= 1) {
			poisonCanvas.enabled = false;
			frozenCanvas.enabled = false;
		}
	}

	/*
	- boss events
			default
				shoot, spawn minions, 
			Ice boss
				Big Ice Shot, player bevriezen,
			Dessert Boss
				Needle Rain, Invisible,
			Jungle Boss
				Poison, Reversed Controlls,
			dark boss
				thunder, blindness,
			Ultimate Boss
				Ultimate Rain,
	 */

	//default power ups
	[ContextMenu ("Shoot")]
	public void Shoot()
	{
		GameObject obj = PoolingScript.current.GetPooledObject (boss.bullet.gameObject);

		if (obj == null)
			return;

		obj.transform.position = transform.position;
		obj.transform.rotation = boss.muzzle.rotation;
		Bullet bullet = obj.GetComponent <Bullet> ();
		bullet.shooter = transform;

		obj.SetActive (true);
	}

	//default power ups
	[ContextMenu ("SpawnMinnion")]
	public void SpawnMinions()
	{
		Instantiate (boss.minion, transform.position, Quaternion.identity);
	}

	//Ice power ups
	[ContextMenu ("IceShot")]
	public void IceShot()
	{
		GameObject obj = PoolingScript.current.GetPooledObject (iceBullet.gameObject);

		if (obj == null)
			return;

		obj.transform.position = transform.position;
		obj.transform.rotation = boss.muzzle.rotation;
		obj.SetActive (true);
	}

	//Ice power ups
	public void Freeze()
	{
		movement.frozen = true;
		frozenCanvas.enabled = true;
		Invoke ("Unfreeze",2);
	}

	private void Unfreeze(){
		movement.frozen = false;
		frozenCanvas.enabled = false;
	}

	//Dessert power ups
	[ContextMenu ("NeedleRain")]
	public void NeedleRain()
	{
		for (int i = 0; i < 7; i++) {
			NeedleShot ();
		}

	}

	private void NeedleShot(){

		GameObject obj = PoolingScript.current.GetPooledObject (needle.gameObject);
		Vector3 spawnPosition = boss.muzzle.forward + boss.muzzle.right.normalized * Random.Range (-1, 1);

		if (obj == null)
			return;
		
		obj.transform.position = spawnPosition;
		obj.transform.rotation = boss.muzzle.rotation;
		obj.SetActive (true);

		//Instantiate (boss.specialBullet, spawnPosition, boss.muzzle.rotation);
	}

	//Dessert power ups
	public void Invisible()
	{
		for (int i = 0; i < visible.Length; i++) 
		{
			visible [i].GetComponent <SpriteRenderer> ().enabled = false;
			Invoke ("VisibleBoss", 2);
		}
	}

	private void VisibleBoss()
	{
		for (int i = 0; i < visible.Length; i++) {
			visible [i].GetComponent <SpriteRenderer> ().enabled = true;
		}
	}

	//Jungle power ups
	public void Poison()
	{
		if (playerHealth.poisoned == false) {
			playerHealth.poisoned = true;
			poisonCanvas.enabled = true;
		}
	}

	public void PoisonHeal(){
		playerHealth.poisoned = false;
		poisonCanvas.enabled = false;
	}

	//Jungle power ups
	public void Reversed()
	{
		movement.reversed = true;
		Invoke ("Unreversed", 3);
		Debug.Log ("reverse");
	}

	private void Unreversed(){
		movement.reversed = false;
	}

	//Dark power ups
	//klein donderschot die 70 damage op de player doet als het raakt.
	[ContextMenu ("Thunder")]
	public void Thunder()
	{
		GameObject obj = PoolingScript.current.GetPooledObject (thunderBolt.gameObject);

		if (obj == null)
			return;

		obj.transform.position = transform.position;
		obj.transform.rotation = boss.muzzle.rotation;
		obj.SetActive (true);
	}

	//Dark power ups
	public void Blindness()
	{
		blindCanvas.enabled = false;
		Invoke ("BlindFix", 2);
	}

	private void BlindFix(){
		blindCanvas.enabled = true;
	}

	public void BossDeath(){
		Debug.Log ("appel");
		Invoke ("BackToMenu", 3);
	}

	private void BackToMenu(){
		SceneManager.LoadScene ("MainMenu");
	}

}