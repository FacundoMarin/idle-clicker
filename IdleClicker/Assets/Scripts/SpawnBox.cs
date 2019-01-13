﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBox : MonoBehaviour {
	
	public GameObject[] boxes = new GameObject[20];
	public float spawnTime = 3f;
	private int maxSimultaneousSpawns = 5;
	//public Transform spawningArea;
	public RectTransform spawningArea;
	public GameObject box;
	public GameObject forDebug;


	// Start is called before the first frame update
	void Start() {
		InvokeRepeating("Spawn", spawnTime, spawnTime);
	}

	void Spawn() {

		int amountSpawns = 1; //Random.Range(1, maxSimultaneousSpawns);
		
		for (int i = 0, s = 0; s < amountSpawns && i < boxes.Length; i++)
			if (boxes[i] == null) {
				
				float x = Random.Range(spawningArea.rect.xMin, spawningArea.rect.xMax);
				float y = Random.Range(spawningArea.rect.yMin, spawningArea.rect.yMax);
				GameObject clone = Instantiate(box, spawningArea);
				clone.transform.position = new Vector2(x, y);
				boxes[i] = clone;

				s++;
			}

	}
}
