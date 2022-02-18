using UnityEngine;
using System.Collections;

public class Inventory: MonoBehaviour {
	
	GameObject []items;
	int itemcount;
	public Texture item;
	public GUIStyle style;
	
	static Inventory inst;
	public static  Inventory GetInstance(){
		return inst;
	}
	void Awake(){
		inst = this;
		items = new GameObject[32];
		itemcount=0;
	}
	
	public void Add(GameObject obj){
		obj.SetActiveRecursively(false);
		items[itemcount] = obj;
		itemcount +=1;
		Debug.Log("added: "+obj.name+" is no:"+ itemcount);
	}
	public GameObject Drop(Vector3 pos){
		if(itemcount > 0){
			int id = itemcount-1;
			itemcount -=1;
			
			GameObject obj = items[id];
			
			obj.transform.position = pos;
			
			obj.SetActiveRecursively(true);		 
			return obj;
		}
		return null;
	}
	void OnGUI(){
		for(int i =0; i< itemcount; i++){
			GUI.Box(new Rect(32+ i*96,Screen.height-64, 64, 64), item, style);
		}
	}
}
