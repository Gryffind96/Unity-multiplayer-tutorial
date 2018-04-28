using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	void OnCollisionEnter(Collision other){

		GameObject hit = other.gameObject;
		Health health = hit.GetComponent<Health> ();

		if (health !=null) {
			health.TakeDamage (10);
		}
		Destroy (gameObject);
	}
}
