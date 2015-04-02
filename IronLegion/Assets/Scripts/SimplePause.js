#pragma strict


private var pauseGame : boolean = false;
private var showGUI : boolean = false;
public var pausedGui : GameObject;


function Update()
{
	if(Input.GetKeyDown("p")|| Input.GetButtonDown ("Cancel"))
	{
		pauseGame = !pauseGame;
		
    	if(pauseGame == true)
    	{
    		Time.timeScale = 0;
    		pauseGame = true;
    		//GameObject.Find("Main Camera").GetComponent(MouseLook).enabled = false;
    		//GameObject.Find("First Person Controller").GetComponent(MouseLook).enabled = false;
    		//GameObject.Find("3rd Person Controller").GetComponent(MouseLook).enabled = false;
    		
    		showGUI = true;
    		
    		
    	}
    }
    
    if(pauseGame == false)
    {
    	Time.timeScale = 1;
    	pauseGame = false;
    	//GameObject.Find("Main Camera").GetComponent(MouseLook).enabled = true;
    	//dGameObject.Find("First Person Controller").GetComponent(MouseLook).enabled = true;
    	//GameObject.Find("3rd Person Controller").GetComponent(MouseLook).enabled = false;
    		
    	showGUI = false;
    }
    
    
    if(showGUI == true)
    {
    	//InstantGui[] guis = GameObject.Find("PausedGUI").getComponents<InstantGui>();
    	
    	//gameObject.GetComponent("PausedGUI").active = true;
    	//  GameObject.Find("PausedGUI").GetComponent(Canvas).enabled = true;  
    	
    	pausedGui.SetActive(true);
    }
    
    else
    {

    	//GetComponent("PausedGUI").gameObject.SetActive(false);
    	//GameObject.Find("PausedGUI").GetComponent(Canvas).enabled = false;  
    	
    	pausedGui.SetActive(false);
    }
}