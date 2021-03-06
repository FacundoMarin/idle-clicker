﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBox : MonoBehaviour {
	
	public Box[] boxes = new Box[20];
	public float spawnTime = 3f;
	private int maxSimultaneousSpawns = 1;
	public RectTransform spawningArea;
	public Box box;
	public LittleGuy littleGuy;


	void Start() {
		InvokeRepeating("Spawn", spawnTime, spawnTime);
	}

	void Spawn() {

		int amountSpawns = Random.Range(1, maxSimultaneousSpawns);
		
		for (int i = 0, s = 0; s < amountSpawns && i < boxes.Length; i++)
			if (boxes[i] == null) {
				
				float x = Random.Range(spawningArea.rect.xMin + 10, spawningArea.rect.xMax - 10);
				float y = Random.Range(spawningArea.rect.yMin + 10, spawningArea.rect.yMax - 10);
				
				Box clone = Instantiate(box, spawningArea);
				clone.transform.localPosition = new Vector2(x,y);
				boxes[i] = clone;

				littleGuy.AddDestination(clone);
			
				s++;
			}

	}
}
