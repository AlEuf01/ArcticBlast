using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArcticBlast {
    
    public class GlacierTarget : MonoBehaviour, IEnemy
    {
	
	private float PushBackForce = -120;
	
	private Rigidbody2D rb;
	
	void Start() {
	    rb = GetComponentInParent<Rigidbody2D>();
	}
	
	public void FartOn() {						
	    Debug.Log("Farting on " + gameObject.name);
	    Melt();
	    
		}
	
	public void MegaFartOn() {
	    Debug.Log("Mega farting on " + gameObject.name);
	    Melt(2f);
	}
	
	void Melt(float scalar = 1f) {
	    rb.isKinematic = false;
	    
	    Vector2 force = new Vector2(PushBackForce * scalar, 0);
	    rb.AddForce(force, ForceMode2D.Impulse);
	    
	    rb.isKinematic = true;
	}
	
    }
    
}
