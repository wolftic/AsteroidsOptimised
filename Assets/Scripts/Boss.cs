using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class Boss : MonoBehaviour {
	[Header("Boss information")]
	private float health;
	[Range(1, 50)][SerializeField]
	private float range;
	[SerializeField]
	private float abilityCooldown;
	[SerializeField]
	private float speed;
	public Bullet bullet;//
	public Bullet specialBullet;// 
	public GameObject minion;//
	public Transform muzzle;//
	[SerializeField]
	private EnemyHealth em;
	[SerializeField]
	private int level;
	[SerializeField]
	private SpriteRenderer icon;
		
	[Header("Attacks")][SerializeField]
	private UnityEvent[] Attacks = new UnityEvent[1];

	[Header("Events")][SerializeField]
	private UnityEvent OnInRange;
	[SerializeField]
	private UnityEvent OnOutOfRange;
	[SerializeField]
	private UnityEvent OnHit;
	[SerializeField]
	private UnityEvent OnSpawn;
	[SerializeField]
	private UnityEvent OnDeath;

	private bool inRange = true;
	private bool alive;
	private Transform target;
	private StatusEffect.StatusType statusType;
	private float cooldown;


	void Start () {
		target = GameObject.FindGameObjectWithTag ("Player").transform;
		em = GetComponent<EnemyHealth> ();
		GameObject.FindGameObjectWithTag ("Camera").GetComponent<CompassScript> ().AddPoint ("Comet", gameObject, Color.white, icon);

		alive = true;
		statusType = StatusEffect.StatusType.NONE;
		cooldown = Time.time + abilityCooldown;
	}

	void Update () {
		health = em.health;
		if (!target)
			return;
		
		if (Vector3.Distance (transform.position, target.position) <= range) {
			if (!inRange) {
				inRange = true;
				OnInRange.Invoke ();
			}
			transform.LookAt (target, transform.up);
			if (Vector3.Distance (transform.position, target.position) >= range/3) {
				transform.Translate (Vector3.forward * speed * Time.deltaTime);
			}
		} else {
			if (inRange) {
				inRange = false;
				OnOutOfRange.Invoke ();
			}
		}

		if (health <= 0) {
			if (alive) {
				alive = false;
				OnDeath.Invoke ();
				PlayerPrefs.SetInt ("unlocked", level);
			}
		} else {
			if (!alive) {
				alive = true;
				OnSpawn.Invoke ();
			}
		}

		if (inRange && cooldown <= Time.time) {
			cooldown = Time.time + abilityCooldown;

			int performAttack = Mathf.RoundToInt (Random.Range (0, Attacks.Length));
			Attacks [performAttack].Invoke ();
		}
	}

	void OnTriggerEnter (Collider other) {
		if (other.tag == "Bullet") {
			OnHit.Invoke ();
		}

		if (other.tag == "StatusEffect") {
			StatusEffect effect = other.GetComponent<StatusEffect> ();
			statusType = effect.statusType;
			Invoke ("ResetStatusEffect", effect.Duration);
		}
	}
	
	void ResetStatusEffect() {
		statusType = StatusEffect.StatusType.NONE;
	}
}