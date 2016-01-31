using UnityEngine;
using System.Collections;

public class AI1 : MonoBehaviour {

	public Transform target;
	public float speed;
	
	// Update is called once per frame
	void Update () {
		float step = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards (transform.position, target.position, step);
	}
}
