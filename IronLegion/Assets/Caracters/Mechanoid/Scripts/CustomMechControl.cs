using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof (Animator))]
[RequireComponent(typeof (Rigidbody))]
public class CustomMechControl : MonoBehaviour {

	public float animSpeed = 3f;				// a public setting for overall animator animation speed
	public float lookSmoother = 6f;				// a smoothing setting for camera motion
	public bool useCurves;						// a setting for teaching purposes to show use of curves
	public float lightsmooth = 4f;              //light lerp smoothness
	public bool aim;
	public float shootDistance = 3000f;
	public float shootDamage = 40f;

	
	private Animator anim;							// a reference to the animator on the character
	private AnimatorStateInfo currentBaseState;			// a reference to the current state of the animator, used for base layer
	private AnimatorStateInfo layer2CurrentState;	// a reference to the current state of the animator, used for layer 2
	private AnimatorStateInfo layer3CurrentState;	// a reference to the current state of the animator, used for layer 3r					
	private bool startLights = false;				//reference for starting up lights
	private bool inAir = false;
	private float dustTime = 0.0f;
	private float muzzleTimer = 0.11f;
	
	
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
	public Camera playCam;
	public Transform gun;

	public ParticleEmitter muzzleFlash;
	public GameObject muzzleLightA;
	public GameObject muzzleLightB;

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



	// Use this for initialization
	void Start () {
 


		muzzleFlash.emit = false;
		muzzleLightA.SetActive (false);
		muzzleLightB.SetActive (false);

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
		
		mainEngine.GetComponent<ParticleSystem>().enableEmission = false;
		mainEngineInner.GetComponent<ParticleSystem>().enableEmission = false;
		mainEngineSmallBits.GetComponent<ParticleSystem>().enableEmission = false;
		mainEngineLight.GetComponent<Light>().intensity = 0;
		
		backheadLightL.GetComponent<Light>().intensity = 0;
		backheadLightR.GetComponent<Light>().intensity = 0;
		frontheadLight.GetComponent<Light>().intensity = 0;
		mouthLightL.GetComponent<Light>().intensity = 0;
		mouthLightR.GetComponent<Light>().intensity = 0;
		
		backEngineL.GetComponent<ParticleSystem>().enableEmission = false;
		backEngineR.GetComponent<ParticleSystem>().enableEmission = false;
		backEngineLightL.GetComponent<Light>().intensity = 0;
		backEngineLightR.GetComponent<Light>().intensity = 0;
		backEngineInnerL.GetComponent<ParticleSystem>().enableEmission = false;
		backEngineInnerR.GetComponent<ParticleSystem>().enableEmission = false;
		backEngineSmokeDownL.GetComponent<ParticleSystem>().enableEmission = false;
		backEngineSmokeOutL.GetComponent<ParticleSystem>().enableEmission = false;
		backEngineSmokeDownR.GetComponent<ParticleSystem>().enableEmission = false;
		backEngineSmokeOutR.GetComponent<ParticleSystem>().enableEmission = false;

		
		anim.SetBool("StartUp", true);

		startLights = true;
		Instantiate(dustStart, transform.position, transform.rotation);
		anim.SetBool ("Death1", false);
		anim.SetBool ("Death2", false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate ()
	{
		aim = Input.GetButton ("Fire2");
		float h = Input.GetAxis("Horizontal");				// setup h variable as our horizontal input axis
		float v = Input.GetAxis("Vertical");				// setup v variables as our vertical input axis
		float q = Input.GetAxis ("Strafe");					// setup q variable for strafe axis
		anim.SetFloat("Speed", v);							// set our animator's float parameter 'Speed' equal to the vertical input axis				
		anim.SetFloat("Direction", h); 						// set our animator's float parameter 'Direction' equal to the horizontal input axis
		anim.SetFloat ("Strafe", q);						// dito for strafe	
		anim.speed = animSpeed;								// set the speed of our animator to the public variable 'animSpeed'
		currentBaseState = anim.GetCurrentAnimatorStateInfo(0);	// set our currentState variable to the current state of the Base Layer (0) of animation
		
		if(anim.layerCount ==2)		
			layer2CurrentState = anim.GetCurrentAnimatorStateInfo(1);	// set our layer2CurrentState variable to the current state of the second Layer (1) of animation
		
		if (muzzleTimer > 0.1f) {
						muzzleLightA.SetActive (false);		
						muzzleLightB.SetActive (false);
		} else {
			muzzleTimer += Time.deltaTime;	

		}

		//STARTUP

		if(startLights == true)
		{
			mainEngineLight.GetComponent<Light>().intensity = Mathf.Lerp(mainEngineLight.GetComponent<Light>().intensity, 3 ,3 * Time.deltaTime);
			backheadLightL.GetComponent<Light>().intensity = Mathf.Lerp(backheadLightL.GetComponent<Light>().intensity, 2 ,3 * Time.deltaTime);
			backheadLightR.GetComponent<Light>().intensity = Mathf.Lerp(backheadLightR.GetComponent<Light>().intensity, 2 ,3 * Time.deltaTime);
			backEngineLightL.GetComponent<Light>().intensity = Mathf.Lerp(backEngineLightL.GetComponent<Light>().intensity, 2 ,3 * Time.deltaTime);
			backEngineLightR.GetComponent<Light>().intensity = Mathf.Lerp(backEngineLightR.GetComponent<Light>().intensity, 2 ,3 * Time.deltaTime);
			
			mainEngine.GetComponent<ParticleSystem>().enableEmission = true;
			mainEngine.GetComponent<ParticleSystem>().GetComponent<Renderer>().material.SetColor("_TintColor", EngineLow);
			//mainEngineInner.particleSystem.enableEmission = true;
			//mainEngineInner.particleSystem.renderer.material.SetColor("_TintColor", EngineLow);
			mainEngineSmallBits.GetComponent<ParticleSystem>().enableEmission = true;
			backEngineL.GetComponent<ParticleSystem>().enableEmission = true;
			backEngineL.GetComponent<ParticleSystem>().GetComponent<Renderer>().material.SetColor("_TintColor", EngineLow);
			backEngineR.GetComponent<ParticleSystem>().enableEmission = true;
			backEngineR.GetComponent<ParticleSystem>().GetComponent<Renderer>().material.SetColor("_TintColor", EngineLow);
			
			frontheadLight.GetComponent<Light>().intensity = Mathf.Lerp(frontheadLight.GetComponent<Light>().intensity, 5 ,3 * Time.deltaTime);
			mouthLightL.GetComponent<Light>().intensity = Mathf.Lerp(mouthLightL.GetComponent<Light>().intensity, 4 ,3 * Time.deltaTime);
			mouthLightR.GetComponent<Light>().intensity = Mathf.Lerp(mouthLightR.GetComponent<Light>().intensity, 4 ,3 * Time.deltaTime);
			
		}
		
		//SHUTDOWN
		/*
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
		*/
		//RUN
		
		if (currentBaseState.nameHash == walkState && Input.GetButtonDown("Shift"))
		{
			anim.SetBool("Run", true);
		}
		
		if (currentBaseState.nameHash == runState)
		{
			backEngineLightL.GetComponent<Light>().intensity = Mathf.Lerp(backEngineLightL.GetComponent<Light>().intensity, 8 ,3 * Time.deltaTime);
			backEngineLightR.GetComponent<Light>().intensity = Mathf.Lerp(backEngineLightR.GetComponent<Light>().intensity, 8 ,3 * Time.deltaTime);
			mainEngineLight.GetComponent<Light>().intensity = Mathf.Lerp(mainEngineLight.GetComponent<Light>().intensity, 8 ,3 * Time.deltaTime);
			mouthLightL.GetComponent<Light>().intensity = Mathf.Lerp(mouthLightL.GetComponent<Light>().intensity, 8 ,3 * Time.deltaTime);
			mouthLightR.GetComponent<Light>().intensity = Mathf.Lerp(mouthLightR.GetComponent<Light>().intensity, 8 ,3 * Time.deltaTime);
			mainEngineInner.GetComponent<ParticleSystem>().enableEmission = true;
			mainEngine.GetComponent<ParticleSystem>().GetComponent<Renderer>().material.SetColor("_TintColor", EngineHigh);
			mainEngineInner.GetComponent<ParticleSystem>().GetComponent<Renderer>().material.SetColor("_TintColor", EngineHigh);
			if (currentBaseState.nameHash == runState && Input.GetButtonUp("Shift"))
			{
				anim.SetBool("Run", false);
				mainEngine.GetComponent<ParticleSystem>().GetComponent<Renderer>().material.SetColor("_TintColor", EngineLow);
				mainEngineInner.GetComponent<ParticleSystem>().GetComponent<Renderer>().material.SetColor("_TintColor", EngineLow);
			}
		}
		
		
		
		//WALK
		
		if (currentBaseState.nameHash == walkState)
		{
			mainEngineLight.GetComponent<Light>().intensity = Mathf.Lerp(mainEngineLight.GetComponent<Light>().intensity, 6 ,3 * Time.deltaTime);
			mainEngineInner.GetComponent<ParticleSystem>().enableEmission = false;
			mouthLightL.GetComponent<Light>().intensity = Mathf.Lerp(mouthLightL.GetComponent<Light>().intensity, 7 ,3 * Time.deltaTime);
			mouthLightR.GetComponent<Light>().intensity = Mathf.Lerp(mouthLightR.GetComponent<Light>().intensity, 7 ,3 * Time.deltaTime);
		}
		
		
		//REVIVE reset
		
		if (currentBaseState.nameHash == walkState)
		{
			anim.SetBool ("Revive", false);
			
		}
		
		//DEATH 
		
		if(layer2CurrentState.nameHash == death1State | layer2CurrentState.nameHash == death2State)
		{
			mainEngineLight.GetComponent<Light>().intensity = Mathf.Lerp(mainEngineLight.GetComponent<Light>().intensity, 0 ,3 * Time.deltaTime);
			backheadLightL.GetComponent<Light>().intensity = Mathf.Lerp(backheadLightL.GetComponent<Light>().intensity, 0 ,3 * Time.deltaTime);
			backheadLightR.GetComponent<Light>().intensity = Mathf.Lerp(backheadLightR.GetComponent<Light>().intensity, 0 ,3 * Time.deltaTime);
			backEngineLightL.GetComponent<Light>().intensity = Mathf.Lerp(backEngineLightL.GetComponent<Light>().intensity, 0 ,3 * Time.deltaTime);
			backEngineLightR.GetComponent<Light>().intensity = Mathf.Lerp(backEngineLightR.GetComponent<Light>().intensity, 0 ,3 * Time.deltaTime);
			
			mainEngine.GetComponent<ParticleSystem>().enableEmission = false;
			mainEngineInner.GetComponent<ParticleSystem>().enableEmission = false;
			mainEngineSmallBits.GetComponent<ParticleSystem>().enableEmission = false;
			backEngineL.GetComponent<ParticleSystem>().enableEmission = false;
			backEngineR.GetComponent<ParticleSystem>().enableEmission = false;
			
			frontheadLight.GetComponent<Light>().intensity = Mathf.Lerp(frontheadLight.GetComponent<Light>().intensity, 0 ,3 * Time.deltaTime);
			mouthLightL.GetComponent<Light>().intensity = Mathf.Lerp(mouthLightL.GetComponent<Light>().intensity, 0 ,3 * Time.deltaTime);
			mouthLightR.GetComponent<Light>().intensity = Mathf.Lerp(mouthLightR.GetComponent<Light>().intensity, 0 ,3 * Time.deltaTime);
		}
		
		//SHOOT and shoot reset
		
		else if (currentBaseState.nameHash == walkState | currentBaseState.nameHash == strafeLState | currentBaseState.nameHash == strafeRState | currentBaseState.nameHash == walkbckState)
		{

			if(Input.GetButtonUp("Fire1"))
			{
				Ray crosshair = playCam.ScreenPointToRay(new Vector3(Screen.width*0.5f, Screen.height*0.5f,0f));
				RaycastHit impactPoint;
				// Bit shift the index of the layer (8) to get a bit mask
				int layerMask = 1 << 8;
				
				// This would cast rays only against colliders in layer 8, so we just inverse the mask.
				layerMask = ~layerMask;
				
				if (Physics.Raycast(crosshair.origin ,crosshair.direction, out impactPoint ,shootDistance, layerMask)) {
					 
					gun.LookAt(impactPoint.transform.position);
					
					Vector3 gunPosition = gun.transform.position;
					if(impactPoint.collider.gameObject.tag == "Enemy"){
						Debug.Log("ENEMIGO!!!");
						//if(Physics.Raycast(gunPosition, gun.TransformDirection(Vector3.forward),out  impactPoint, shootDistance,  layerMask)){
							impactPoint.transform.SendMessage("RestEnemyLife", shootDamage, SendMessageOptions.DontRequireReceiver);
						//}
					}
				}

				anim.SetBool("Shoot", true);
				muzzleFlash.Emit();
				muzzleTimer = 0f;
				muzzleLightA.SetActive(true);
				muzzleLightB.SetActive(true);
				muzzleLightA.GetComponent<Light>().intensity = Random.Range(1f,3f);
				muzzleLightB.GetComponent<Light>().intensity = Random.Range(1f,3f);
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
			backEngineL.GetComponent<ParticleSystem>().GetComponent<Renderer>().material.SetColor("_TintColor", EngineHigh);
			backEngineR.GetComponent<ParticleSystem>().GetComponent<Renderer>().material.SetColor("_TintColor", EngineHigh);
		}
		
		if (currentBaseState.nameHash == hoverState | currentBaseState.nameHash == hoverfwdState)
		{
			backEngineL.GetComponent<ParticleSystem>().GetComponent<Renderer>().material.SetColor("_TintColor", EngineHigh);
			backEngineR.GetComponent<ParticleSystem>().GetComponent<Renderer>().material.SetColor("_TintColor", EngineHigh);
			backEngineInnerL.GetComponent<ParticleSystem>().enableEmission = true;
			backEngineInnerR.GetComponent<ParticleSystem>().enableEmission = true;
			backEngineInnerL.GetComponent<ParticleSystem>().GetComponent<Renderer>().material.SetColor("_TintColor", EngineHover);
			backEngineInnerR.GetComponent<ParticleSystem>().GetComponent<Renderer>().material.SetColor("_TintColor", EngineHover);
			backEngineSmokeDownL.GetComponent<ParticleSystem>().enableEmission = true;
			backEngineSmokeOutL.GetComponent<ParticleSystem>().enableEmission = true;
			backEngineSmokeDownR.GetComponent<ParticleSystem>().enableEmission = true;
			backEngineSmokeOutR.GetComponent<ParticleSystem>().enableEmission = true;
		}
		
		if (currentBaseState.nameHash == landState | currentBaseState.nameHash == landfwdState)
		{
			mainEngine.GetComponent<ParticleSystem>().GetComponent<Renderer>().material.SetColor("_TintColor", EngineLow);
			mainEngineInner.GetComponent<ParticleSystem>().GetComponent<Renderer>().material.SetColor("_TintColor", EngineLow);
			inAir = false;
			backEngineInnerL.GetComponent<ParticleSystem>().enableEmission = false;
			backEngineInnerR.GetComponent<ParticleSystem>().enableEmission = false;
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
			backEngineSmokeDownL.GetComponent<ParticleSystem>().enableEmission = true;
			backEngineSmokeDownR.GetComponent<ParticleSystem>().enableEmission = true;
		}
		
		if (currentBaseState.nameHash == hoverState | currentBaseState.nameHash == hoverfwdState)
		{
			backEngineSmokeOutR.GetComponent<ParticleSystem>().enableEmission = true;
			backEngineSmokeOutL.GetComponent<ParticleSystem>().enableEmission = true;
		}
		
		else
		{
			backEngineSmokeDownL.GetComponent<ParticleSystem>().enableEmission = false;
			backEngineSmokeOutL.GetComponent<ParticleSystem>().enableEmission = false;
			backEngineSmokeDownR.GetComponent<ParticleSystem>().enableEmission = false;
			backEngineSmokeOutR.GetComponent<ParticleSystem>().enableEmission = false;
		}
		
		
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
