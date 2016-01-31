using UnityEngine;
using System.Collections;

public class AI1 : MonoBehaviour {

	public Transform target;
	public float speed;
	public float chaseRadius;
	private float distance;
	Animator anim;

	void Start () {
		//gets animator object
		anim = GetComponent<Animator>();
		anim.SetInteger ("Direction", 0);
	}
	
	// Update is called once per frame
	void Update () {
		distance = Vector3.Distance (transform.position, target.transform.position);
		if (distance < chaseRadius) {
			float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards (transform.position, target.position, step);

			//animate dog
			if (transform.position.x > target.position.x)
				anim.SetInteger ("Direction", 3);
			else
				anim.SetInteger ("Direction", 1);
		}

//		anim.SetInteger ("Direction", 0);
	}
//
//	void OnCollisionEnter2D (Collision2D obj)
//	{
//	}
//

}
