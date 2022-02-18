using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {
	
	public string state = "start";
	public Texture splash, map, playerpoint;
	public GUIStyle style, imgstyle;
	public GUISkin skin;
	
	public GameObject flyer_prefab;
	
	int toolbarInt =0;
	string []toolbarStrings= {"Map", "Help", "Play", "Quit"};
	
	GameObject player;
	
	static Controller instance;
	
	void Awake(){
		instance = this;
	}
	public static Controller GetInstance(){
		return instance;
	}
	// Use this for initialization
	void Start () {
		if(!Application.isEditor){
			Screen.showCursor=false;
		}
		state = "start";
		Time.timeScale = 0;
		player = GameObject.Find("/!Player");
	
	}	
	// Update is called once per frame
	void Update () {
		if(state == "start"){
			if(Input.anyKey){
				SwitchState("play");
			}
		}
		if(state == "play"){
			if(Input.GetKeyDown("q")||Input.GetKeyDown("escape")||Input.GetKeyDown("m")){
				SwitchState("menu");
			}
		}
		if(state == "menu"){
			if(Input.GetKeyDown("e")){
				SwitchState("play");
			}
		}
		if(state == "end"){
			if(Input.anyKey){
				Application.Quit();
			}
		}
	}	
	void OnGUI(){
		GUI.skin = skin;
		if(state == "start"){
			GUI.Box (new Rect (0,0,Screen.width,Screen.height), "", style);
			GUI.Box(new Rect (Screen.width/2-400,Screen.height/2-400, 800, 800), splash, style);
			GUI.Label(new Rect (Screen.width/2-400,Screen.height/2+100, 800, 250), "I woke up by the shore, determined to fulfill my destiny.\n" +
				"I was the chosen.\n\n" +
				"Press any key to start");		
		}
		if(state == "end"){
			GUI.Box (new Rect (0,0,Screen.width,Screen.height), "", style);
			GUI.Box(new Rect (Screen.width/2-400,-150, 800, 800), splash, style);
			GUI.Label(new Rect (Screen.width/2-400,350, 800, 350), "This was an Entry for Ludumdare #22 theme: Alone.\n" +
				"Thanks for playing.. the journey continues.\n" +
				"made by Moritz LaassPress aka Balooga03 in december 2011.\n" +
				"..in 48 hours.. stay tuned.\n\n" +
				"Any key to quit.");		
		}
		if(state=="menu"){
			GUI.Box (new Rect (0,0,Screen.width,Screen.height), "", style);
			//Map
			if(toolbarInt==0){
				Vector2 p = new Vector2(player.transform.position.x,player.transform.position.z);
				p.y = (2481-p.y)*0.20153f -8;
				p.x = p.x*0.20153f -8;
				GUI.Box(new Rect (Screen.width/2-250,Screen.height/2-250, 500, 500), map, style);
				GUI.Box(new Rect (Screen.width/2-250+ p.x,Screen.height/2-250 +p.y, 17, 17), playerpoint, imgstyle);
				
				GUI.Label(new Rect (Screen.width/2-100,Screen.height-100, 200, 50), "map");

				
			}
			//help
			if(toolbarInt==1){
				GUI.Label(new Rect (0,100,Screen.width, 200), "use wasd and mouse to move around, space to jump\n " +
					"click on objects to add them to your inventory\n " +
					"click again to drop them");
			}
			//switch
			if(toolbarInt==2){
				SwitchState("play");
			}
			//close
			if(toolbarInt==3){
				Application.Quit();
			}
			toolbarInt = GUI.Toolbar (new Rect (0, 25,Screen.width, 30), toolbarInt, toolbarStrings);
		}
	}
	public void SwitchState(string st){
		if(st == "play"){
			if(state == "start"){
				audio.Play();
				for(int i= 0; i< 200; i++){
					GameObject obj  = (GameObject) GameObject.Instantiate(flyer_prefab);
					obj.transform.parent = transform;
				}
			}
			
			Time.timeScale = 1;
		}
		if(st == "menu"){
			Time.timeScale = 0;
			toolbarInt = 0;			
		}
		
		state = st;
	}
}
