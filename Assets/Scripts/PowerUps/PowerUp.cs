using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{

	public int RotationSpeed = 0;
	
	protected SpriteRenderer spriteRenderer;

	// "Lifecycle" of consumables
	protected enum PowerUpState {
		InAttractMode,
		IsCollected,
		IsExpiring
	}

	// Current state of the powerup
	protected PowerUpState powerUpState;

	void Awake() {
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	void Start() {
		powerUpState = PowerUpState.InAttractMode;
	}

	void Update() {
		transform.Rotate(0, 0, RotationSpeed * Time.deltaTime);
	}

	void OnCollisionEnter2D(Collision2D coll) {
		PowerUpCollected(coll.gameObject);
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		PowerUpCollected(other.gameObject);
	}

	void PowerUpCollected(GameObject collectedBy) {
		
		// Debug.Log("Collecting powerup.");

		// We only care if this is the player
		if (collectedBy.tag != "Player") {
			return;
		}

		// We only care if the power up has not been collected before
		if (powerUpState != PowerUpState.InAttractMode) {
			return;
		}

		// Collection effects
		PowerUpEffects();

		// Payload
		PowerUpPayload();

		// Sprite can be invisible now
		spriteRenderer.enabled = false;
	}

	protected virtual void PowerUpEffects() {
		// Sound and visual effects
	}

	protected virtual void PowerUpPayload() {
		// Debug.Log("Power up collected; issuing payload for " + gameObject.name);

		DestroySelfAfterDelay();
	}

	void DestroySelfAfterDelay() {
		Destroy(gameObject, 0);
	}

}
