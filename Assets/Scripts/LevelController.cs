using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ArcticBlast.Utils;

namespace ArcticBlast
{
		/// <summary>
		/// LevelController.cs
		/// Controller for individual levels
		/// </summary>
		public class LevelController : Singleton<LevelController>
		{

				public GameObject[] backgrounds;
				
				// Start is called before the first frame update
				void Start()
				{
						int bgIndex = GameController.Instance.levelNum % backgrounds.Length;
						Instantiate(backgrounds[bgIndex]);
				}

		}

}
