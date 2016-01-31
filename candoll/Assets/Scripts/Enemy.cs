using UnityEngine;
using System.Collections;

public class Enemy : Actor {

    int viewDist;
    int viewAngle;
    Vector2 lookat;


	// Use this for initialization
	void Start () {
        viewDist = 5;
        viewAngle = 30;
	}
	


	// Update is called once per frame
	void Update () {
	
	}
}
