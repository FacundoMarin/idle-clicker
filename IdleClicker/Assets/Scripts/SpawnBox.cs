using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBox : MonoBehaviour {
	
	public GameObject[] boxes = new GameObject[20];
	public float spawnTime = 3f;
	private int maxSimultaneousSpawns = 5;
	public Transform spawningArea;
	public GameObject box;


	// Start is called before the first frame update
	void Start() {
		InvokeRepeating("Spawn", spawnTime, spawnTime);
	}

	void Spawn() {
		Debug.Log("Spawneado");

		int amountSpawns = Random.Range(1, maxSimultaneousSpawns);
		
		for (int i = 0, s = 0; s < amountSpawns && i < boxes.Length; i++) {
			if (boxes[i] == null) {
				Vector3 position = new Vector3(Random.Range(10, spawningArea.position.x-10), Random.Range(10, spawningArea.position.y-10), 0);
				boxes[i] = Instantiate(box, position, new Quaternion(0, 0, 0, 0));
				Debug.Log("Instanciando");
				s++;
			}
		}

	}
}
