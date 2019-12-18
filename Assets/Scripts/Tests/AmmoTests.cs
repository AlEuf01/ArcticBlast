using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;

namespace ArcticBlast {
	
	public class AmmoTests : IPrebuildSetup
	{

		private AmmoManager AmmoManager;
		
		public void Setup() {
			AmmoManager = new AmmoManager();
		}
		
		[Test]
		public void TestAdd() {

			Assert.AreEqual(AmmoManager.Amount, 0);

			AmmoManager.Add();			
			Assert.AreEqual(AmmoManager.Amount, 1);						
		}
		
		[Test]
		public void TestRemove() {
			AmmoManager.Add();
			Assert.AreEqual(AmmoManager.Amount, 1);
			AmmoManager.Remove();
			Assert.AreEqual(AmmoManager.Amount, 0);
		}

		[Test]
		public void TestFill() {
			Assert.AreEqual(AmmoManager.Amount, 0);
			AmmoManager.Fill();
			Assert.AreEqual(AmmoManager.Amount, AmmoManager.maxAmmo);			
		}

		[Test]
		public void TestRemoveAllAmmo() {
			AmmoManager.Fill();
			AmmoManager.RemoveAllAmmo();
			Assert.AreEqual(AmmoManager.Amount, 0);
		}
		
	}

}
