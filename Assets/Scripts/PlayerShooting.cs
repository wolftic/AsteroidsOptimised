using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerShooting : MonoBehaviour 
{

	public Bullet projectile;
	public Transform muzzle;
	public float shootDelay;
	public float bulletSpeed;
	public float fireRate = 0.4F;
	[SerializeField]
	private Image ammoBar;
	[SerializeField]
	private string ShootSound;
	private Movement movement;

	private float nextFire = 0.0F;
	private float bullets = 12;
	private float maxBullets = 12;
	private float reloadTime = 1.5F;
	private InputHandler inputHandler;

	void Awake(){
		movement = GetComponent <Movement> ();
		inputHandler = GameObject.FindObjectOfType <InputHandler> ();
	}

	void Update()
	{
		if(bullets > 0 && movement.frozen == false && Time.time > nextFire && Input.GetKey (inputHandler.inputs["shootKnop"]))
		{
			Shoot();
		}
		else if(bullets < 10 && Input.GetKey (inputHandler.inputs["reloadKnop"]))
		{
			Reload();
		}

		ammoBar.fillAmount = bullets / maxBullets;
	}

	private void Shoot ()
	{
		GameObject obj = PoolingScript.current.GetPooledObject (projectile.gameObject);

		if (obj == null)
			return;

		obj.transform.position = transform.position;
		obj.transform.rotation = transform.rotation;
		obj.SetActive (true);

		Bullet bullet = obj.GetComponent <Bullet>();
		bullet.shooter = transform;

		bullets -= 1;
		nextFire = Time.time + fireRate;
		SoundManager.current.PlaySound (ShootSound);

	}

	private void Reload()
	{
		bullets = 12;
		nextFire = Time.time + reloadTime;
	}
}
