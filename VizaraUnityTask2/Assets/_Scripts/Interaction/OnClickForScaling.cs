using UnityEngine;
using System.Collections;

public class OnClickForScaling : MonoBehaviour {
	void OnMouseDown() {
		ScaleObjectOnTouch.ScaleTransform = transform;
	}
}