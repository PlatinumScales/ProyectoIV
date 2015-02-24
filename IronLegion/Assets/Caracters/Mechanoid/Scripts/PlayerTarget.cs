using UnityEngine;
using System.Collections;

public class PlayerTarget : MonoBehaviour
{
	
	#region Public Fields & Properties
	public Texture2D target;
	public Texture2D targetOver;
	
	public bool overEnemy;
	public bool aim;
	
	public LayerMask enemyLayer;
	public LayerMask otherLayer;
	
	public float enemyDIstance = 50.0f;
	
	public Camera playerCam;

	public ThirdPersonCamera playCam;
	public CustomMechControl playCon;


	
	#endregion
	
	#region Private Fields & Properties
	private bool _overEnemy;
	private bool _aim;
	
	private GUITexture gui;
	
	#endregion
	
	#region Getters & Setters
	
	#endregion
	
	#region System Methods
	// Use this for initialization
	private void Start()
	{

		gui = guiTexture;
		
		gui.pixelInset = new Rect (-target.width * 0.5f, -target.height * 0.5f, target.width, target.height);
		gui.texture = target;
		gui.color = new Color (0.5f, 0.5f, 0.5f, 0.15f);
		
	}
	
	// Update is called once per frame
	private void Update(){
		/*if(!playCam.gameObject.activeSelf){
			gui.color = new Color (0.5f, 0.5f, 0.5f, 0.15f);
			return;
		}*/
		aim = Input.GetButton ("Fire2");
		
		Ray ray = playerCam.ScreenPointToRay(new Vector3(Screen.width*0.5f, Screen.height*0.5f,0f));
		
		RaycastHit hit1;
		RaycastHit hit2;
		
		overEnemy = Physics.Raycast(ray.origin, ray.direction, out hit1, enemyDIstance, enemyLayer);
		
		if (overEnemy) {
			if(Physics.Raycast(ray.origin, ray.direction, out hit2, enemyDIstance, otherLayer)) {
				overEnemy = hit1.distance < hit2.distance;
			}
		}
		
		float delta = 1.0f - ((playCam.Y + 85) * 0.0058823529f);

		
		if (overEnemy != _overEnemy) {
			_overEnemy = overEnemy;
			if(overEnemy){
				gui.texture = targetOver;
			}else{
				gui.texture = target;
			}
		}

		if(aim != _aim){
			_aim = aim;
			if(aim){
				gui.color = new Color (0.5f, 0.5f, 0.5f, 0.75f);
			}else{
				gui.color = new Color (0.5f, 0.5f, 0.5f, 0.15f);
			}
		}
	}
	#endregion
	
	#region Custom Methods
	
	#endregion
}

