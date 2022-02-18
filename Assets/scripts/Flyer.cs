using UnityEngine;
using System.Collections;

public class Flyer : MonoBehaviour {
	
	public float speed = 5;
	
	public Vector3 moveTarget;
	
	LensFlare flare;
	
	// Use this for initialization
	void Start () {
		flare = (LensFlare) this.transform.FindChild("flare").GetComponent<LensFlare>();
		
		flare.brightness = 0.5f;
		rigidbody.MovePosition(getNewTarget());
		moveTarget = getNewTarget();
		
	}
	Vector3 getNewTarget(){

		return new Vector3(Random.Range(200,2000), Random.Range(100,300),Random.Range(0,2200));
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 dis = (moveTarget- transform.position);
		if(dis.magnitude < 5 ){
			moveTarget = getNewTarget();
		}
		
		
		rigidbody.AddForce(dis.normalized*speed*speed);
	}
	
	public void highlight(float val){
		flare.brightness = val;
	}
}
