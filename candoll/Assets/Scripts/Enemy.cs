﻿using UnityEngine;
using System.Collections;

public class Enemy : Actor {

	public Player script;

	void OnTriggerEnter2D(Collider2D obj){
		if (obj.gameObject.tag == "Player") {
			script.Invoke ("GetDamage", 0f);
		}
	}
}
