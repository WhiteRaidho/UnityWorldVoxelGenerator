using UnityEngine;
using System.Collections;

public class Mini : MonoBehaviour {

	public Player play;
	public int itemId;

	void OnTriggerEnter(Collider other){
		if(other.transform.tag.Equals ("Player")){
			if(play.currentItemW + play.weight[itemId] <= play.maxItemW){
				play.items[itemId] += 1;
				Destroy(gameObject);
			}
		}
	}
	// Use this for initialization
	void Start () {
		play = GameObject.Find("FirstPersonCharacter").GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
