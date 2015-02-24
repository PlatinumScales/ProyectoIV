using UnityEngine;
using System.Collections;

// Require these components when using this script
[RequireComponent(typeof (Animator))]
[RequireComponent(typeof (Rigidbody))]
public class MechControlScript : MonoBehaviour
{
	public float animSpeed = 1.5f;				// a public setting for overall animator animation speed
	public float lookSmoother = 3f;				// a smoothing setting for camera motion
	public bool useCurves;						// a setting for teaching purposes to show use of curves
	public float lightsmooth = 3f;              //light lerp smoothness

	
	private Animator anim;							// a reference to the animator on the character
	private AnimatorStateInfo currentBaseState;			// a reference to the current state of the animator, used for base layer
	private AnimatorStateInfo layer2CurrentState;	// a reference to the current state of the animator, used for layer 2
	private AnimatorStateInfo layer3CurrentState;	// a reference to the current state of the animator, used for layer 3r					
	private bool startLights = false;				//reference for starting up lights
	private bool inAir = false;
	private float dustTime = 0.0f;

	
	static int runState = Animator.StringToHash("Base Layer.Run");
	static int strafeLState = Animator.StringToHash("Base Layer.StrafeL");
	static int strafeRState = Animator.StringToHash("Base Layer.StrafeR");
	static int offState = Animator.StringToHash("Base Layer.Off");
	static int walkState = Animator.StringToHash("Base Layer.Walk");			// these integers are references to our animator's states
	static int walkbckState = Animator.StringToHash("Base Layer.WalkBck");
	static int death1State = Animator.StringToHash("Layer 2.Death_Front");	
	static int death2State = Animator.StringToHash("Layer 2.Death_Back");
	static int shootState = Animator.StringToHash("Layer 2.Shoot");	
	static int jumpState = Animator.StringToHash("Base Layer.Jump");
	static int jumpfwdState = Animator.StringToHash("Base Layer.jumpfwd");
	static int hitFState = Animator.StringToHash("Layer 2.Hit_Front");	
	static int hitRState = Animator.StringToHash("Layer 2.Hit_Right");	
	static int landState = Animator.StringToHash("Base Layer.Landing");	
	static int landfwdState = Animator.StringToHash("Base Layer.Landingfwd");	
	static int hoverState = Animator.StringToHash("Base Layer.Hover");	
	static int hoverfwdState = Animator.StringToHash("Base Layer.Hoverfwd");


	// reference particle system game objects & lights here

	public Transform dustStart;
	public Transform mechChest;
	public Transform mechSpine;

	public GameObject mainEngine;					
	public GameObject mainEngineInner;
	public GameObject mainEngineSmallBits;
	public GameObject mainEngineLight;

	public GameObject backheadLightL;
	public GameObject backheadLightR;
	public GameObject frontheadLight;
	public GameObject mouthLightL;
	public GameObject mouthLightR;

	public GameObject backEngineL;
	public GameObject backEngineR;
	public GameObject backEngineLightL;
	public GameObject backEngineLightR;
	public GameObject backEngineInnerL;
	public GameObject backEngineInnerR;
	public GameObject backEngineSmokeDownL;
	public GameObject backEngineSmokeOutL;
	public GameObject backEngineSmokeDownR;
	public GameObject backEngineSmokeOutR;

	//reference particle materials and colours

	Color EngineLow = new Color (0,0,0,0);
	Color EngineHigh = new Color (0,0,0,0);
	Color EngineHover = new Color (0,0,0,0);


	
	void Start ()
	{
		// initialising reference variables
		anim = GetComponent<Animator>();					  				
		if(anim.layerCount ==2)
			anim.SetLayerWeight(1, 1);

		//initialising engine colours
		EngineLow.r = 0;
		EngineLow.g = 0.015f;
		EngineLow.b = 0.055f;
		EngineLow.a = 0.3f;

		EngineHigh.r = 0f;
		EngineHigh.g = 0.05f;
		EngineHigh.b = 0.7f;
		EngineHigh.a = 0.6f;

		EngineHover.r = 0.5f;
		EngineHover.g = 0.5f;
		EngineHover.b = 0f;
		EngineHover.a = 1f;

		//Particle Systems OFF!

		mainEngine.particleSystem.enableEmission = false;
		mainEngineInner.particleSystem.enableEmission = false;
		mainEngineSmallBits.particleSystem.enableEmission = false;
		mainEngineLight.light.intensity = 0;

		backheadLightL.light.intensity = 0;
		backheadLightR.light.intensity = 0;
		frontheadLight.light.intensity = 0;
		mouthLightL.light.intensity = 0;
		mouthLightR.light.intensity = 0;

		backEngineL.particleSystem.enableEmission = false;
		backEngineR.particleSystem.enableEmission = false;
		backEngineLightL.light.intensity = 0;
		backEngineLightR.light.intensity = 0;
		backEngineInnerL.particleSystem.enableEmission = false;
		backEngineInnerR.particleSystem.enableEmission = false;
		backEngineSmokeDownL.particleSystem.enableEmission = false;
		backEngineSmokeOutL.particleSystem.enableEmission = false;
		backEngineSmokeDownR.particleSystem.enableEmission = false;
		backEngineSmokeOutR.particleSystem.enableEmission = false;

	}
	
	
	void FixedUpdate ()
	{
		float h = Input.GetAxis("Horizontal");				// setup h variable as our horizontal input axis
		float v = Input.GetAxis("Vertical");				// setup v variables as our vertical input axis
		float q = Input.GetAxis ("Shift2");					// setup q variable for strafe axis
		anim.SetFloat("Speed", v);							// set our animator's float parameter 'Speed' equal to the vertical input axis				
		anim.SetFloat("Direction", h); 						// set our animator's float parameter 'Direction' equal to the horizontal input axis
		anim.SetFloat ("Strafe", q);						// dito for strafe	
		anim.speed = animSpeed;								// set the speed of our animator to the public variable 'animSpeed'
		currentBaseState = anim.GetCurrentAnimatorStateInfo(0);	// set our currentState variable to the current state of the Base Layer (0) of animation
		
		if(anim.layerCount ==2)		
			layer2CurrentState = anim.GetCurrentAnimatorStateInfo(1);	// set our layer2CurrentState variable to the current state of the second Layer (1) of animation


		//STARTUP

		if (currentBaseState.nameHash == offState && Input.GetButton("Fire2"))
		{
			anim.SetBool("StartUp", true);
			startLights = true;
			Instantiate(dustStart, transform.position, transform.rotation);
			anim.SetBool ("Death1", false);
			anim.SetBool ("Death2", false);
		}

		if(startLights == true)
		{
			mainEngineLight.light.intensity = Mathf.Lerp(mainEngineLight.light.intensity, 3 ,3 * Time.deltaTime);
			backheadLightL.light.intensity = Mathf.Lerp(backheadLightL.light.intensity, 2 ,3 * Time.deltaTime);
			backheadLightR.light.intensity = Mathf.Lerp(backheadLightR.light.intensity, 2 ,3 * Time.deltaTime);
			backEngineLightL.light.intensity = Mathf.Lerp(backEngineLightL.light.intensity, 2 ,3 * Time.deltaTime);
			backEngineLightR.light.intensity = Mathf.Lerp(backEngineLightR.light.intensity, 2 ,3 * Time.deltaTime);

			mainEngine.particleSystem.enableEmission = true;
			mainEngine.particleSystem.renderer.material.SetColor("_TintColor", EngineLow);
			//mainEngineInner.particleSystem.enableEmission = true;
			//mainEngineInner.particleSystem.renderer.material.SetColor("_TintColor", EngineLow);
			mainEngineSmallBits.particleSystem.enableEmission = true;
			backEngineL.particleSystem.enableEmission = true;
			backEngineL.particleSystem.renderer.material.SetColor("_TintColor", EngineLow);
			backEngineR.particleSystem.enableEmission = true;
			backEngineR.particleSystem.renderer.material.SetColor("_TintColor", EngineLow);

			frontheadLight.light.intensity = Mathf.Lerp(frontheadLight.light.intensity, 5 ,3 * Time.deltaTime);
			mouthLightL.light.intensity = Mathf.Lerp(mouthLightL.light.intensity, 4 ,3 * Time.deltaTime);
			mouthLightR.light.intensity = Mathf.Lerp(mouthLightR.light.intensity, 4 ,3 * Time.deltaTime);

		}

		//SHUTDOWN

		if (currentBaseState.nameHash == walkState && Input.GetButton("Fire2"))
		{
			anim.SetBool("StartUp", false);
			startLights = false;
			Instantiate(dustStart, transform.position, transform.rotation);
		}

		if(startLights == false)
		{
			mainEngineLight.light.intensity = Mathf.Lerp(mainEngineLight.light.intensity, 0 ,3 * Time.deltaTime);
			backheadLightL.light.intensity = Mathf.Lerp(backheadLightL.light.intensity, 0 ,3 * Time.deltaTime);
			backheadLightR.light.intensity = Mathf.Lerp(backheadLightR.light.intensity, 0 ,3 * Time.deltaTime);
			backEngineLightL.light.intensity = Mathf.Lerp(backEngineLightL.light.intensity, 0 ,3 * Time.deltaTime);
			backEngineLightR.light.intensity = Mathf.Lerp(backEngineLightR.light.intensity, 0 ,3 * Time.deltaTime);

			mainEngine.particleSystem.enableEmission = false;
			mainEngineInner.particleSystem.enableEmission = false;
			mainEngineSmallBits.particleSystem.enableEmission = false;
			backEngineL.particleSystem.enableEmission = false;
			backEngineR.particleSystem.enableEmission = false;

			frontheadLight.light.intensity = Mathf.Lerp(frontheadLight.light.intensity, 0 ,3 * Time.deltaTime);
			mouthLightL.light.intensity = Mathf.Lerp(mouthLightL.light.intensity, 0 ,3 * Time.deltaTime);
			mouthLightR.light.intensity = Mathf.Lerp(mouthLightR.light.intensity, 0 ,3 * Time.deltaTime);
		}

		//RUN

		if (currentBaseState.nameHash == walkState && Input.GetButtonDown("Shift"))
		{
			anim.SetBool("Run", true);
		}

		if (currentBaseState.nameHash == runState)
		{
			backEngineLightL.light.intensity = Mathf.Lerp(backEngineLightL.light.intensity, 8 ,3 * Time.deltaTime);
			backEngineLightR.light.intensity = Mathf.Lerp(backEngineLightR.light.intensity, 8 ,3 * Time.deltaTime);
			mainEngineLight.light.intensity = Mathf.Lerp(mainEngineLight.light.intensity, 8 ,3 * Time.deltaTime);
			mouthLightL.light.intensity = Mathf.Lerp(mouthLightL.light.intensity, 8 ,3 * Time.deltaTime);
			mouthLightR.light.intensity = Mathf.Lerp(mouthLightR.light.intensity, 8 ,3 * Time.deltaTime);
			mainEngineInner.particleSystem.enableEmission = true;
			mainEngine.particleSystem.renderer.material.SetColor("_TintColor", EngineHigh);
			mainEngineInner.particleSystem.renderer.material.SetColor("_TintColor", EngineHigh);
			if (currentBaseState.nameHash == runState && Input.GetButtonUp("Shift"))
			{
				anim.SetBool("Run", false);
				mainEngine.particleSystem.renderer.material.SetColor("_TintColor", EngineLow);
				mainEngineInner.particleSystem.renderer.material.SetColor("_TintColor", EngineLow);
			}
		}
			
			

		//WALK

		if (currentBaseState.nameHash == walkState)
		{
			mainEngineLight.light.intensity = Mathf.Lerp(mainEngineLight.light.intensity, 6 ,3 * Time.deltaTime);
			mainEngineInner.particleSystem.enableEmission = false;
			mouthLightL.light.intensity = Mathf.Lerp(mouthLightL.light.intensity, 7 ,3 * Time.deltaTime);
			mouthLightR.light.intensity = Mathf.Lerp(mouthLightR.light.intensity, 7 ,3 * Time.deltaTime);
		}


		//REVIVE reset

		if (currentBaseState.nameHash == walkState)
		{
			anim.SetBool ("Revive", false);

		}

		//DEATH 

		if(layer2CurrentState.nameHash == death1State | layer2CurrentState.nameHash == death2State)
		{
			mainEngineLight.light.intensity = Mathf.Lerp(mainEngineLight.light.intensity, 0 ,3 * Time.deltaTime);
			backheadLightL.light.intensity = Mathf.Lerp(backheadLightL.light.intensity, 0 ,3 * Time.deltaTime);
			backheadLightR.light.intensity = Mathf.Lerp(backheadLightR.light.intensity, 0 ,3 * Time.deltaTime);
			backEngineLightL.light.intensity = Mathf.Lerp(backEngineLightL.light.intensity, 0 ,3 * Time.deltaTime);
			backEngineLightR.light.intensity = Mathf.Lerp(backEngineLightR.light.intensity, 0 ,3 * Time.deltaTime);
			
			mainEngine.particleSystem.enableEmission = false;
			mainEngineInner.particleSystem.enableEmission = false;
			mainEngineSmallBits.particleSystem.enableEmission = false;
			backEngineL.particleSystem.enableEmission = false;
			backEngineR.particleSystem.enableEmission = false;
			
			frontheadLight.light.intensity = Mathf.Lerp(frontheadLight.light.intensity, 0 ,3 * Time.deltaTime);
			mouthLightL.light.intensity = Mathf.Lerp(mouthLightL.light.intensity, 0 ,3 * Time.deltaTime);
			mouthLightR.light.intensity = Mathf.Lerp(mouthLightR.light.intensity, 0 ,3 * Time.deltaTime);
		}

		//SHOOT and shoot reset

		else if (currentBaseState.nameHash == walkState | currentBaseState.nameHash == strafeLState | currentBaseState.nameHash == strafeRState | currentBaseState.nameHash == walkbckState)
		{
			if(Input.GetButtonUp("Fire1"))
			{
				anim.SetBool("Shoot", true);
			}
		}
		// if we enter the shooting state, reset the bool to let us shoot again in future
		if(layer2CurrentState.nameHash == shootState)
		{
			anim.SetBool("Shoot", false);
		}
		//JUMP

		if (currentBaseState.nameHash == walkState | currentBaseState.nameHash == runState)
		{
			if (Input.GetButtonDown("Jump"))
			{
				anim.SetBool ("Jump", true);
				inAir = true;
			}
		}

		// HOVER
		if (currentBaseState.nameHash == jumpState && Input.GetButtonDown("Jump"))
		{
			anim.SetBool ("Jump",true);
		}
		if (Input.GetButtonUp("Jump"))
		{
			anim.SetBool ("Jump",false);
		}
		if (inAir == true)
		{
			//mainEngine.particleSystem.renderer.material.SetColor("_TintColor", EngineHigh);
			//mainEngineInner.particleSystem.renderer.material.SetColor("_TintColor", EngineHigh);
			backEngineL.particleSystem.renderer.material.SetColor("_TintColor", EngineHigh);
			backEngineR.particleSystem.renderer.material.SetColor("_TintColor", EngineHigh);
		}

		if (currentBaseState.nameHash == hoverState | currentBaseState.nameHash == hoverfwdState)
		{
			backEngineL.particleSystem.renderer.material.SetColor("_TintColor", EngineHigh);
			backEngineR.particleSystem.renderer.material.SetColor("_TintColor", EngineHigh);
			backEngineInnerL.particleSystem.enableEmission = true;
			backEngineInnerR.particleSystem.enableEmission = true;
			backEngineInnerL.particleSystem.renderer.material.SetColor("_TintColor", EngineHover);
			backEngineInnerR.particleSystem.renderer.material.SetColor("_TintColor", EngineHover);
			backEngineSmokeDownL.particleSystem.enableEmission = true;
			backEngineSmokeOutL.particleSystem.enableEmission = true;
			backEngineSmokeDownR.particleSystem.enableEmission = true;
			backEngineSmokeOutR.particleSystem.enableEmission = true;
		}

		if (currentBaseState.nameHash == landState | currentBaseState.nameHash == landfwdState)
		{
			mainEngine.particleSystem.renderer.material.SetColor("_TintColor", EngineLow);
			mainEngineInner.particleSystem.renderer.material.SetColor("_TintColor", EngineLow);
			inAir = false;
			backEngineInnerL.particleSystem.enableEmission = false;
			backEngineInnerR.particleSystem.enableEmission = false;
			if (Time.time >= dustTime)
			{
				Instantiate(dustStart, transform.position, transform.rotation);
				Instantiate(dustStart, transform.position, transform.rotation);
				Instantiate(dustStart, transform.position, transform.rotation);
				Instantiate(dustStart, transform.position, transform.rotation);
				Instantiate(dustStart, transform.position, transform.rotation);
				dustTime = Time.time + 1;
			}
		}

		//HITS

		// if we enter the hitF state, reset the bool to let us be hitf again in future
		if(layer2CurrentState.nameHash == hitFState)
		{
			anim.SetBool("HitF", false);
		}
		// if we enter the hitR state, reset the bool to let us be hitr again in future
		if(layer2CurrentState.nameHash == hitRState)
		{
			anim.SetBool("HitR", false);
		}

		//DOUBLE CHECKS

		if(Input.GetButtonUp("Shift"))
		{
			anim.SetBool("Run", false);
		}

		//HOVER PARTICLE SYSTEM

		if (currentBaseState.nameHash == jumpState | currentBaseState.nameHash == jumpfwdState)
		{
			backEngineSmokeDownL.particleSystem.enableEmission = true;
			backEngineSmokeDownR.particleSystem.enableEmission = true;
		}

		if (currentBaseState.nameHash == hoverState | currentBaseState.nameHash == hoverfwdState)
		{
			backEngineSmokeOutR.particleSystem.enableEmission = true;
			backEngineSmokeOutL.particleSystem.enableEmission = true;
		}

		else
		{
			backEngineSmokeDownL.particleSystem.enableEmission = false;
			backEngineSmokeOutL.particleSystem.enableEmission = false;
			backEngineSmokeDownR.particleSystem.enableEmission = false;
			backEngineSmokeOutR.particleSystem.enableEmission = false;
		}


	}
	
	//GUI 
	void OnGUI() {
		
		if (GUI.Button(new Rect(10, 10, 100, 50), "Death Forward")){
			Debug.Log("Clicked the button with an image");
			anim.SetBool ("Death1", true);
			anim.SetBool ("Run", false);
			StartCoroutine(MyCoroutineTwo());
		}
		
		if (GUI.Button(new Rect(10, 70, 100, 50), "Death Back")){
			Debug.Log("Clicked the button with an image");
			anim.SetBool ("Death2", true);
			anim.SetBool ("Run", false);
			StartCoroutine(MyCoroutine());
			
		}
		
		if (GUI.Button(new Rect(140, 10, 100, 50), "Hit Front")){
			Debug.Log("Clicked the button with an image");
			anim.SetBool ("HitF", true);
			anim.SetBool ("Run", false);
			Instantiate(dustStart, mechSpine.position, transform.rotation);
		}
		
		if (GUI.Button(new Rect(140, 70, 100, 50), "Hit Right")){
			Debug.Log("Clicked the button with an image");
			anim.SetBool ("HitR", true);
			anim.SetBool ("Run", false);
			Instantiate(dustStart, mechSpine.position, transform.rotation);
		}
		
		if (GUI.Button(new Rect(10, 140, 50, 30), "Revive")){
			Debug.Log("Clicked the button with text");
			anim.SetBool ("Revive", true);
			anim.SetBool ("Death1", false);
			anim.SetBool ("Death2", false);
		}
		
		GUI.Label (new Rect(400, 10, 200, 300), "Controls: ALT to awaken\n\t\tWASD for movement\n\t\tSHIFT to run\n\t\tSPACE to jump\n\t\tHold SPACE to hover\n\t\tCTRL to fire");		
	}

	IEnumerator MyCoroutine()
	{
		yield return new WaitForSeconds(0.8f); 
		Instantiate(dustStart, mechChest.position, transform.rotation);
		Instantiate(dustStart, mechChest.position, transform.rotation);
		Instantiate(dustStart, mechChest.position, transform.rotation);
	}
	IEnumerator MyCoroutineTwo()
	{
		yield return new WaitForSeconds(1.35f); 
		Instantiate(dustStart, mechChest.position, transform.rotation);
		Instantiate(dustStart, mechChest.position, transform.rotation);
		Instantiate(dustStart, mechChest.position, transform.rotation);
	}
}
	