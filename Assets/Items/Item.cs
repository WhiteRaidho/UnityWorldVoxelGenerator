using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Item : MonoBehaviour {

	public bool noStack = true;
	public int itemId = 0;
	public List<GameObject> inventory = new List<GameObject>();
	// Use this for initialization
	void OnTriggerEnter(Collider other){
		if(other.transform.tag.Equals("Player")){
			Player player = other.GetComponentInChildren<Player>();
			inventory = player.inventory;
			if(noStack){
				for(int i = 0; i <= 9; i++){
					if(inventory[i] == null){
						player.inventory[i] = player.allItems[itemId];
						player.noItems[i] += 1;
						Destroy(gameObject);
						break;
					}
				}
			} else {
				bool itemExist = false;
				for(int i = 0; i <= 9;  i++){
					if(inventory[i].GetComponent<Item>().itemId == itemId){
						itemExist = true;
						player.noItems[i] += 1;
						Destroy(gameObject);
						break;
					}
				}
				if(!itemExist){
					for(int i = 0; i <= 9;  i++){
						if(inventory[i] == null){
							player.inventory[i] = player.allItems[itemId];
							player.noItems[i] += 1;
							Destroy(gameObject);
							break;
						}
					}
				}
			}
		}
	}

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}
}
