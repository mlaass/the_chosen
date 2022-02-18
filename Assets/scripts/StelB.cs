using UnityEngine;
using System.Collections;

public class StelB : MonoBehaviour {
	
	int count =0;
	public AudioClip accept;
	GameObject pyramid, plight;
	// Use this for initialization
	void Start () {
		pyramid = GameObject.Find("/pyramid");
		plight = GameObject.Find("/pyramid/light");
	}
	
	// Update is called once per frame
	void Update () {
		if(Application.isEditor && Input.GetKeyDown("t")){
			Trigger();
		}
	}
	
	public void Trigger(){
		count +=1;
		Debug.Log("steltrigger");
		light.intensity = light.intensity+0.3f;
		audio.PlayOneShot(accept);
		if(count == 6){
			
			pyramid.light.enabled = true;
			plight.light.enabled=true;
			pyramid.SendMessage("MakeReady");
			
			
		}
	}
}
