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

				// Blast range for firing on something
				// public float Range = 5f;		
	
				// LayerMask of objects that can be fired on
				public LayerMask layerMask;

				// Prefabs for fart sound effects
				public GameObject fartLarge, fartSmall, fartTiny;

				// Positions to spawn fart
				public Transform fartPointL, fartPointR, firePoint;

				// Reference to the ammo manager				
				private AmmoManager AmmoManager;

				// Reference to the sound system
				private PlayerSound Sound;
	
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
						Sound = GetComponentInChildren<PlayerSound>();
				}

				/// <summary>
				/// Remove all ammo from the player
				/// </summary>
				void RemoveAmmo()
				{
						// Debug.Log("Killed player or completed level; removing all ammo.");
						AmmoManager.RemoveAllAmmo();
						Events.UpdateAmmo(0);
				}

				/// <summary>
				/// Consume one bean can, incrementing fart gauge
				/// </summary>
				void ConsumeBeanCan()
				{
						// Debug.Log("Consumed a bean can");			
						AmmoManager.Add();
						Events.UpdateAmmo(AmmoManager.Amount);
				}

				/// <summary>
				/// Consume one bean barrel, filling fart gauge
				/// </summary>
				void ConsumeBeanBarrel()
				{
						// Debug.Log("Consumed a bean barrel");
						AmmoManager.Fill();
						Events.UpdateAmmo(AmmoManager.Amount);
				}

				/// <summary>
        /// Handles firing
				/// </summary>
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

				/// <summary>
				/// Farts with a full ammo bar
				/// </summary>
				void MegaFart()
				{			

						Sound.MegaFart();
	    
						StartCoroutine(PlayFireAnimation(fartLarge));
	    
						AmmoManager.RemoveAllAmmo();
						Events.MegaFart();
	    
						IEnemy target = GetTarget();
						if (target != null)
						{
								target.MegaFartOn();
						}
				}

				/// <summary>
				/// Farts with one ammo
				/// </summary>
				void SingleFart()
				{

						// Sound Effect
						Sound.Fart();
	    
						StartCoroutine(PlayFireAnimation(fartSmall));
	    
						AmmoManager.Remove();		  
	    
						Events.Fart();
	    
						IEnemy target = GetTarget();
						if (target != null)
						{
								target.FartOn();
						}			
				}

				/// <summary>
				/// No fart. The player clicks the fire button, but has no ammo
				/// </summary>
				void NoFart()
				{
	    
						// SFX
						Sound.Poof();
	    
						StartCoroutine(PlayFireAnimation(fartTiny));
				}

				/// <summary>
				/// Play a farting animation
				/// <param name="fartPrefab">The prefab for the fart</param>
				/// </summary>
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
	

				/// <summary>
				// Get the direction of fire (opposite facing direction)
				/// <return>The Direction to fire</return>
				/// </summary>
				Direction GetFireDirection()
				{
						return sr.flipX ? Direction.Left : Direction.Right;
				}

				/// <summary>
				/// Get the target of the fire
				/// <return>The Enemy being fired on</return>
				/// </summary>
				IEnemy GetTarget()
				{

						IEnemy result = null;

						Vector2 direction = GetFireDirection() == Direction.Left ? Vector2.left : Vector2.right;

						Debug.Log($"Firing in direction: {direction}");

						Ray2D hitRay = new Ray2D(firePoint.transform.position, direction);
						// Debug.DrawRay(hitRay.origin, hitRay.direction * Range, Color.red, 2f);
						RaycastHit2D hit = Physics2D.Raycast(firePoint.transform.position, direction, GameParameters.Instance.PlayerFireRange, layerMask);
						
						if (hit.collider != null)
						{
								Debug.Log("Hitting " + hit.collider.gameObject.name);
								result = hit.collider.gameObject.GetComponent<IEnemy>();		
						}
						else
						{
								Debug.Log("Nothing in range to hit.");
						}
								
	    
						return result;
				}
	
    }
    
}
