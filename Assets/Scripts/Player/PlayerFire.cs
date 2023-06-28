using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArcticBlast.Player
{
		/// <summary>
		/// PlayerFire.cs
		///
    /// Manages the player's firing actions
		/// </summary>
    public class PlayerFire : Character
    {

				public float Range = 5f;		
	
				// LayerMask of objects that can be fired on
				public LayerMask layerMask;
	
				public GameObject fartLarge, fartSmall, fartTiny;
	
				public Transform fartPointL;
				public Transform fartPointR;
	
				public AmmoManager AmmoManager;
				public PlayerSound sound;
	
				void OnEnable()
				{
						Events.OnFire += Fire;
						Events.OnConsumeBeanCan += ConsumeBeanCan;
						Events.OnConsumeBeanBarrel += ConsumeBeanBarrel;
						Events.OnKillPlayer += RemoveAmmo;
						Events.OnCompleteLevel += RemoveAmmo;
				}
	
				void OnDisable()
				{
						Events.OnFire -= Fire;
						Events.OnConsumeBeanCan -= ConsumeBeanCan;
						Events.OnConsumeBeanBarrel -= ConsumeBeanBarrel;
						Events.OnKillPlayer -= RemoveAmmo;
						Events.OnCompleteLevel -= RemoveAmmo;
				}
	
				void Awake()
				{
						AmmoManager = new AmmoManager();

						sound = GetComponentInChildren<PlayerSound>();
				}
	
				void RemoveAmmo()
				{
						// Debug.Log("Killed player or completed level; removing all ammo.");
						AmmoManager.RemoveAllAmmo();
						Events.UpdateAmmo(0);
				}
	
				void ConsumeBeanCan()
				{
						// Debug.Log("Consumed a bean can");			
						// Increment player's ammo			
						AmmoManager.Add();
						Events.UpdateAmmo(AmmoManager.Amount);
				}
	
				void ConsumeBeanBarrel()
				{
						// Debug.Log("Consumed a bean barrel");
						AmmoManager.Fill();
						Events.UpdateAmmo(AmmoManager.Amount);
				}
	
        // Handles firing the flamethrower
        void Fire()
				{				   	
						if (AmmoManager.HasMegaFartAmmo())
						{
								MegaFart();
						}
						else if (AmmoManager.HasAmmo())
						{
								SingleFart();
						}
						else
						{
								NoFart();
						}
						Events.UpdateAmmo(AmmoManager.Amount);
				}
	
				void MegaFart()
				{			

						sound.MegaFart();
	    
						StartCoroutine(PlayFireAnimation(fartLarge));
	    
						AmmoManager.RemoveAllAmmo();
						Events.MegaFart();
	    
						IEnemy target = GetTarget();
						if (target != null)
						{
								target.MegaFartOn();
						}
				}
		
				void SingleFart()
				{

						// Sound Effect
						sound.Fart();
	    
						StartCoroutine(PlayFireAnimation(fartSmall));
	    
						AmmoManager.Remove();		  
	    
						Events.Fart();
	    
						IEnemy target = GetTarget();
						if (target != null)
						{
								target.FartOn();
						}			
				}
	
				void NoFart()
				{
						// The player clicks the fire button, but has no ammo
	    
						// SFX
						sound.Poof();
	    
						StartCoroutine(PlayFireAnimation(fartTiny));
				}

				// Play a farting animation
				IEnumerator PlayFireAnimation(GameObject fartPrefab)
				{
						// Debug.Log("Firing");
	    
						animator.SetBool("IsFiring", true);
	    
						Transform fartPoint = GetFireDirection() == Direction.Left ? fartPointL : fartPointR;
	    
						GameObject fart = Instantiate(fartPrefab, fartPoint);
	    
						// TODO: Get length of animation clip
						yield return new WaitForSeconds(0.5f);
						animator.SetBool("IsFiring", false);

						// Create and destroy a fart particle effect		   
	    
						yield return new WaitForSeconds(1.0f);
	    
						Destroy(fart);
	    
				}		
	
	
				// Get the direction of fire (opposite facing direction)
				Direction GetFireDirection()
				{
						return sr.flipX ? Direction.Left : Direction.Right;
				}
	
				IEnemy GetTarget()
				{

						IEnemy result = null;
	    
						Vector2 direction = GetFireDirection() == Direction.Left ? Vector2.left : Vector2.right;
	    
						RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, Range, layerMask);
	    
						if (hit.collider != null)
						{
								// Debug.Log("Hitting " + hit.collider.gameObject.name);
								result = hit.collider.gameObject.GetComponent<IEnemy>();		
						}
	    
						return result;
				}
	
    }
    
}
