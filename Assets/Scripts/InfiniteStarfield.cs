using UnityEngine;
using System.Collections;

public class InfiniteStarfield : MonoBehaviour {


	private Transform tx;
	private ParticleSystem.Particle[] points;
	private ParticleSystem particleSystem;

	[SerializeField]
	private int starsMax = 100;
	[SerializeField]
	private float starSize = 1;
	[SerializeField]
	private float starDistance = 10;
	[SerializeField]
	private float starClipDistance = 1;
	private float starDistanceSqr;
	private float starClipDistanceSqr;

	void Start () {
		tx = transform;
		starDistanceSqr = starDistance * starDistance;
		starClipDistanceSqr = starClipDistance * starClipDistance;
		particleSystem = GetComponent<ParticleSystem> ();
	}

	private void CreateStars() {
		points = new ParticleSystem.Particle[starsMax];

		for (int i = 0; i < starsMax; i++) {
			points[i].position = Random.insideUnitSphere * starDistance + tx.position;
			points[i].startColor = new Color(1,1,1, 1);
			points[i].startSize = starSize;
		}
	}

	void Update () {
		if ( points == null ) CreateStars();

		for (int i = 0; i < starsMax; i++) {

			if ((points[i].position - tx.position).sqrMagnitude > starDistanceSqr) {
				points[i].position = Random.insideUnitSphere.normalized * starDistance + tx.position;
			}

			if ((points[i].position - tx.position).sqrMagnitude <= starClipDistanceSqr) {
				float percent = (points[i].position - tx.position).sqrMagnitude / starClipDistanceSqr;
				points[i].color = new Color(1,1,1, percent);
				points[i].size = percent * starSize;
			}
		}
		particleSystem.SetParticles ( points, points.Length );
	}
}