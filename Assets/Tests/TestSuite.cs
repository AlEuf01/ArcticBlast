using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using ArcticBlast;

public class TestSuite
{
	
	private GameController gameController;
	
	[SetUp]
	void Setup() {
		
		GameObject gc = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Start/@GameController"));
		gameController = gc.GetComponent<GameController>();
		
	}

	[TearDown]
	void Cleanup() {
		Object.Destroy(gameController);
	}
	
	[UnityTest]
	public IEnumerator Pause()
	{
   		
		gameController.Pause();
		
		yield return new WaitForSeconds(0.5f);
		
		Assert.AreEqual(Time.timeScale, 0.0f);

		gameController.Unpause();

		yield return new WaitForSeconds(0.5f);
		
		Assert.AreEqual(Time.timeScale, 1.0f);		
	}
	
}
