using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using ArcticBlast;

public class TestSuite
{
	
	private GameController gameController;
	
	[UnityTest]
	public IEnumerator Pause()
	{
		Setup();
		
		gameController.Pause();
		
		yield return new WaitForSeconds(0.5f);
		
		Assert.AreEqual(Time.timeScale, 0.0f);
		
		Cleanup();
	}
	
	void Setup() {
		
		GameObject gc = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Start/@GameController"));
		gameController = gc.GetComponent<GameController>();
		
	}
	
	void Cleanup() {
		Object.Destroy(gameController);
	}
	
}
