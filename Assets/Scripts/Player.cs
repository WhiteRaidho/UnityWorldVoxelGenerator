using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

	public float digSpeed = 1f;
	public int item = 0;
	public float currentItemW = 0f;
	public float maxItemW = 100f;
	public List<GameObject> inventory = new List<GameObject>();
	public List<int> noItems = new List<int>();
	public int listSize = 4;
	public List<int> items = new List<int>();
	public List<float> weight = new List<float>();
	public List<GameObject> miniBlock = new List<GameObject>();
	public List<GameObject> allItems = new List<GameObject>();
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		#region lockState
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		#endregion
		#region Dig
		Block block;
		if(Input.GetKey(KeyCode.Mouse0)){
			RaycastHit hit;
			if(Physics.Raycast(transform.position, transform.forward, out hit, 5)){
				block = EditTerrain.GetBlock(hit);
				/*EditTerrain.SetBlock(hit, new BlockAir());
				int blockIdd = block.blockId;
				if(currentItemW + weight[blockIdd] <= maxItemW){
					items[blockIdd] += 1;
				}else{
					noSpace(blockIdd, hit.point);
				}
				*/
				block.currentDmg += Time.deltaTime * digSpeed;
			//	block.currentTemp += Time.deltaTime * digSpeed * 10;
			//	Debug.Log(block.currentTemp + "   " + block.blockHp + block.molten + block.moltenTemp);
				if(block.currentDmg > block.blockHp){
					EditTerrain.SetBlock(hit, new BlockAir());
					int blockIdd = block.blockId;
					if(currentItemW + weight[blockIdd] <= maxItemW){
						items[blockIdd] += 1;
					}else{
						noSpace(blockIdd, hit.point);
					}
				}
			}
		}
		#endregion
		#region Pleace
		//if(Input.GetKeyDown(KeyCode.Mouse1)){
		//	RaycastHit hit;
		//	if(Physics.Raycast(transform.position, transform.forward, out hit, 5)){
		//		block = EditTerrain.GetBlock(hit);
		//
		//		switch(item){
		//		case 1:
		//
		//			break;
		//		case 2:
		//
		//			break;
		//
		//		case 3:
		//
		//			break;
		//
		//		default:
		//
		//			break;
		//		}
		//	}
		//}
		#endregion
		#region Eq
		currentItemW = 0f;
		for(int i = 1; i <= listSize; i++){
			currentItemW += items[i] * weight[i];
		}
		#endregion
		if(Input.GetKeyDown(KeyCode.P)){
			RaycastHit hit;
			if(Physics.Raycast(transform.position, transform.forward, out hit, 10)){
				Instantiate(inventory[0], hit.point, Quaternion.Euler(Vector3.zero));
			}
		}
	}
	void noSpace(int blockId, Vector3 where){
		GameObject mini = Instantiate(miniBlock[blockId], where, Quaternion.Euler(Vector3.zero)) as GameObject;
		Mini miniS = mini.GetComponent<Mini>();
		miniS.itemId = blockId;
	}
}

