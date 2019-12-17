using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlacierTarget : MonoBehaviour, IEnemy
{

	private float PushBackForce = -120;
	
	private Rigidbody2D rb;
   
	void Start() {
		rb = GetComponentInParent<Rigidbody2D>();
	}
	
	public void FartOn() {						
		Debug.Log("Farting on me.");
		Melt();
		
	}
	
	public void MegaFartOn() {
		Debug.Log("Mega farting on me.");
		Melt(2f);
	}
	
	void Melt(float scalar = 1f) {
		Vector2 force = new Vector2(PushBackForce * scalar, 0);
		rb.AddForce(force, ForceMode2D.Impulse);
	}

}
