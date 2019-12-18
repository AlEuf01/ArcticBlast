using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArcticBlast {
	
	public interface IAmmoManager 
	{

		void Add();
		void Remove();
		void Fill();
		void RemoveAllAmmo();		
		
		bool HasAmmo();
		bool HasMegaFartAmmo();

	}

}
