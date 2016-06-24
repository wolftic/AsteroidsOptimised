using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TutorialScreen : MonoBehaviour {
	[SerializeField]
	private Text Movements;
	[SerializeField]
	private Text MovementsDesc;
	[SerializeField]
	private Text Shooting;
	[SerializeField]
	private Text ShootingDesc;
	[SerializeField]
	private Text Camera;
	[SerializeField]
	private Text CameraDesc;
	[SerializeField]
	private InputHandler input;

	void Update () {
		UpdateText();
	}

	void UpdateText () {
		Movements.text = "[" + input.inputs["forwardKnop"] + "]" +
			"\n" +
			"[" + input.inputs["leftKnop"] + "]" +
			"[" + input.inputs["breakKnop"] + "]" +
			"[" + input.inputs["rightKnop"] + "]";

		Shooting.text = "[" + input.inputs["shootKnop"] + "] " +
			"[" + input.inputs["reloadKnop"] + "]";
		
		Camera.text = "[" + input.inputs["watchBehindKnop"] + "]";

		MovementsDesc.text = "Use " + "[" + input.inputs["forwardKnop"] + "] " + "[" + input.inputs["leftKnop"] + "] " + "[" + input.inputs["rightKnop"] + "] " +
			"to move around and " + "[" + input.inputs["breakKnop"] + "] " + "to slow down";

		MovementsDesc.text = "Use " + "[" + input.inputs["forwardKnop"] + "] " + "[" + input.inputs["leftKnop"] + "] " + "[" + input.inputs["rightKnop"] + "] " +
			"to move around and " + "[" + input.inputs["breakKnop"] + "] " + "to slow down";

		ShootingDesc.text = "Use " + "[" + input.inputs["shootKnop"] + "] " + "to shoot and " + "[" + input.inputs["reloadKnop"] + "] " + "to reload";

		CameraDesc.text = "Use " + "[" + input.inputs["watchBehindKnop"] + "] " + "to look behind";
	}
}
