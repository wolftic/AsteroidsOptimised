using UnityEngine;
using System.Collections;

public class EnemyShooting : MonoBehaviour 
{

	public Bullet projectile;
	public Transform muzzle;
	public float shootDelay;
	public float bulletSpeed;
	public float fireRate = 0.4F;
	[SerializeField]
	private string ShootSound;

	private float nextFire = 0.0F;
	private float bullets = 20;
	private float reloadTime = 1.8F;
	private EnemyMovement enemyMovement;
	private InputHandler inputHandler;
	[SerializeField]
	private float damage;

	void Awake()
	{
		enemyMovement = GetComponent <EnemyMovement>();
		inputHandler = GameObject.FindObjectOfType <InputHandler> ();
	}

	void Update()
	{
		

		if(bullets > 0 && Time.time > nextFire && enemyMovement.inRange && enemyMovement.target )
		{
			Shoot();
		}
		else if(bullets <= 0)
		{
			Reload();
		}
	}

	private void Shoot ()
	{
		
		Quaternion rot = muzzle.rotation * Quaternion.Euler(0, Random.Range(-15, 15), 0);

		GameObject obj = PoolingScript.current.GetPooledObject (projectile.gameObject);

		if (obj == null)
			return;

		obj.transform.position = transform.position;
		obj.transform.rotation = rot;
		obj.SetActive (true);

		Bullet bullet = obj.GetComponent <Bullet> ();
		bullet.shooter = transform;
		bullet.damage = damage;
		bullets -= 1;
		nextFire = Time.time + fireRate;
		SoundManager.current.PlaySound (ShootSound);
	}

	private void Reload()
	{
		bullets = 20;
		nextFire = Time.time + reloadTime;
	}
}