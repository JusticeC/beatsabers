﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerProgressHolder : MonoBehaviour {


		public bool GameLoaded { get; private set; }

		


		private string dataPath = string.Empty;

		void Awake()
		{

			dataPath = "Assets/Resources/Game_Data_"  + SaveData.playerData.playerName + ".csv";
			// to keep game data and this game object live througout the life cycle of the game
			DontDestroyOnLoad(gameObject);
		}
		// Use this for initialization
		void Start () {

			   Save();
			// Load();
			GameLoaded = true;
		}

		void Save()
		{
			SaveData.Save(dataPath);
			Debug.Log("Game Saved");
		}

		void Load()
		{
			SaveData.Load();
			Debug.Log("Game Loaded");
		}





	}

