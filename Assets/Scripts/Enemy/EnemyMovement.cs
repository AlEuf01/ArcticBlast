﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArcticBlast
{
		
		/// <summary>
		/// EnemyMovement.cs
		/// Controls movement of enemies
		/// </summary>
    public class EnemyMovement : Character
    {
				/// <summary>
				/// The movement speed
				/// </summary>
				public float Speed = 1f;

				/// <summary>
				/// Reference to the player
				/// </summary>
				private GameObject _player;

				private Enemy _enemy;
				
				/// <summary>
				/// Checks for whether the enemy can move
				/// </summary>
				bool CanMove
				{
						get
						{
								return !_enemy.isStunned && !_enemy.isAttacking && !_enemy.isDead;
						}
				}

				/// <summary>
				/// Checks to see if the player is alive
				/// </summary>
				bool IsPlayerAlive
				{
						get
						{
								return _player != null && sr != null && _player.GetComponent<PlayerHealth>().isDead == false;
						}
				}

				
				/// <summary>
				/// Returns true if the player is ahead of me, false if behind me
				/// </summary>
				bool IsPlayerAhead
				{
						get {
								return _player.transform.position.x > transform.position.x;
						}
				}
		
				protected override void Start()
				{
						base.Start();
	   
						_player = GameObject.FindWithTag("Player");
						_enemy = GetComponent<Enemy>();
				}
	
				void FixedUpdate()
				{
						Move();
						Animate();
						UpdateDirection();
				}
				
				/// <summary>
				/// Updates the animations
				/// </summary>
				void Animate()
				{
	    
						if (IsPlayerAlive && CanMove)
						{
								animator.SetBool("IsWalking", true);
						}
						else
						{
								// Player is dead; be still
								animator.SetBool("IsWalking", false);
						}
		
				}

				
				/// <summary>
				/// Moves the enemy
				/// </summary>
				void Move()
				{
						
						if (IsPlayerAlive && CanMove)
						{
								Vector2 amount = new Vector2(Speed * Time.deltaTime, 0f);								
								transform.Translate(IsPlayerAhead ? amount : -amount);

						}
				}

				/// <summary
				/// Update the enemy's facing direction
				/// </summary>
				void UpdateDirection()
				{
						if (IsPlayerAlive && CanMove)
						{
								
								// Update the facing direction
								if (IsPlayerAhead)
								{
										transform.localScale = new Vector3(1f, 1f, 1f);
								}
								else
								{
										transform.localScale = new Vector3(-1f, 1f, 1f);
								}
						}
				}
	
	
    }
	
}
