using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CompassScript : MonoBehaviour {
	[SerializeField]
	private Renderer compass;

	[SerializeField]
	private List<Point> points = new List<Point>();

	[SerializeField]
	private SpriteRenderer[] prefab;

	public struct Point {
		public string name;
		public Color color;
		public SpriteRenderer sprite;
		public GameObject target;

		public Point(string name, GameObject target, Color color, SpriteRenderer sprite) {
			this.name = name;
			this.target = target;
			this.color = color;
			this.sprite = Instantiate(sprite) as SpriteRenderer;
			this.sprite.transform.SetParent(GameObject.FindGameObjectWithTag("Compass").transform, true);
			//this.sprite.transform.localScale = new Vector3(0.02f, .2f, 1f);
		}

		public Point(string name, GameObject target, SpriteRenderer sprite) {
			this.name = name;
			this.target = target;
			this.color = Color.white;
			this.sprite = Instantiate(sprite) as SpriteRenderer;
			this.sprite.transform.SetParent(GameObject.FindGameObjectWithTag("Compass").transform, true);
		}
	}

	private Point nullPoint;

	void Update () {
		float yStep = 1.0f /  360f;
		float yAxis = yStep * transform.eulerAngles.y;
		compass.material.mainTextureOffset = new Vector2 (yAxis, 0);

		for (int i = 0; i < points.Count; i++) {
			if (points [i].target == null || !points [i].target.activeInHierarchy) {
				Destroy (points [i].sprite.gameObject);
				points.Remove (points [i]);
				return;
			}
			float angle = Vector3.Angle(transform.forward, points [i].target.transform.position);
			float sign = Mathf.Sign(Vector3.Dot(transform.position, Vector3.Cross(transform.forward, points[i].target.transform.position)));
			float signed_angle = angle * sign;
			float axis = yStep * (signed_angle + 180);

			float xPosition = Mathf.Lerp (-.5f, .5f, axis);
			points [i].sprite.color = points [i].color;
			points [i].sprite.transform.localPosition = new Vector3 (xPosition, 0, 0);
		}
	}

	public void AddPoint(string name, GameObject target, Color color, SpriteRenderer _prefab) {
		points.Add (new Point (name, target, color, _prefab));
	}

	public void AddPoint(string name, GameObject target, Color color) {
		AddPoint (name, target, color, prefab[0]);
	}

	public Point GetPoint(GameObject target) {
		for (int i = 0; i < points.Count; i++) {
			if (points [i].target == target) {
				return points [i];
			}
		}

		return nullPoint;	
	}
}
