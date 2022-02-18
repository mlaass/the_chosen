using UnityEngine;
using System.Collections;

public class TriggerB : MonoBehaviour {
	public GameObject receiver;
	public string message = "Trigger";
	public string tag = "Egg";
	public bool once = true;
	bool triggered = false;
	
	void OnTriggerEnter(Collider other){
		Debug.Log("OnTriggerEnter tag: " +other.tag);
		
		if(!once || !triggered){		
			if(other.tag == tag && receiver !=null){
				receiver.SendMessage(message);
				other.SendMessage(message);
				triggered = true;
			}
		}
	}
	
}
