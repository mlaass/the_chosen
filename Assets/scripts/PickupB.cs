using UnityEngine;
using System.Collections;

public class PickupB : MonoBehaviour {
	
	bool fresh = true;
	// Use this for initialization
	void Start () {
		fresh = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnSelect(){
		Debug.Log("selected"+ this.name);
		if(fresh){
			Inventory.GetInstance().Add(gameObject);
		}
	}
	void Trigger(){
		fresh = false;
	}
}
