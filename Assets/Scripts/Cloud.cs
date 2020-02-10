using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArcticBlast {
    
    public class Cloud : MonoBehaviour
    {

	public float Speed = 0.5f;
	const int MAX_POSITION = 20;

	void Update() {
	    Move();
	    DestroyIfOffScreen();
	}

	void Move() {
	    transform.Translate(Speed * Time.deltaTime, 0, 0);
	}
	
	void DestroyIfOffScreen() {
	    if (transform.position.x > MAX_POSITION) {
		Destroy(gameObject);
	    }
	}
    }
}
