using UnityEngine;
using System.Collections;

public class StatusEffect : MonoBehaviour {
	public enum StatusType
	{
		NONE,
		STUN,
		SLOW
	}

	public StatusType statusType;
	public float Duration;

	void Start () {
	
	}

	void Update () {
	
	}
}
