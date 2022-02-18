using UnityEngine;
using System.Collections;

public class PlayerB : MonoBehaviour {
	
	Camera cam;
	Inventory inv;
	
	static PlayerB inst;
	public static PlayerB GetInstance(){
		return inst;
	}
	
	void Awake(){
		inst = this;
	}
	// Use this for initialization
	void Start () {
		inv = Inventory.GetInstance();
		cam = GameObject.Find("Main Camera").camera;
	}
	public void Trigger(){
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)){
			Ray  ray = cam.ScreenPointToRay(new Vector3(Screen.width/2,Screen.height/2, 0.0f));
			RaycastHit hit = new RaycastHit();
			int layerMask = 1 << 9;
			Debug.DrawRay(ray.origin, ray.direction);
	
			if (Physics.Raycast(ray, out hit, 100.0f, layerMask)) {
				Debug.Log ("Hit something: "+hit.collider.name);
				hit.collider.SendMessage("OnSelect");
			}else{
				GameObject drop =inv.Drop(ray.origin+(ray.direction*2));
				if(drop != null){
					drop.rigidbody.AddForce(ray.direction*10);
				}
			}	 
		}
	}
}
