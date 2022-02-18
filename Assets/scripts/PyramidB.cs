using UnityEngine;
using System.Collections;

public class PyramidB : MonoBehaviour {

	bool ready = false;
	GameObject cam, endcam;
	// Use this for initialization
	void Start () {
		endcam= GameObject.Find("/EndCamera").gameObject;
		endcam.camera.enabled = false;
		
		cam= GameObject.Find("/!Player/Main Camera").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if(Application.isEditor && Input.GetKeyDown("z")){
			Trigger();
		}
	}
	public void MakeReady(){
		ready = true;
	}
	public void AnimEnd(){
		Controller.GetInstance().SwitchState("end");
		Debug.Log("End");
	}
	public void AnimStart(){
		cam.camera.enabled =false;
		endcam.camera.enabled = true;
		Controller.GetInstance().SwitchState("takeoff");	

		Debug.Log("takeoff");
		
	}
	public void Trigger(){
		if(ready){
			this.animation.Play();
			
			//		
		}
	}
}
