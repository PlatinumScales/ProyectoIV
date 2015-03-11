using UnityEngine;
using System.Collections;

public class ThirdPersonCamera : MonoBehaviour
{
	public float smooth = 3f;		// a public variable to adjust smoothing of camera motion
	private float fpssmooth = 30f;
	Transform standardPos;			// the usual position for the camera, specified by a transform in the game
	public Transform ThirdPersonCam;		//third person cam
	public Transform OriginalCam;			// original	
	public Transform FirstPersonCam;		// first person cam

	public float normalDistance = 2.5f;

	private bool camReady = false;

	private float _x = 0.0f;
	private float _y = 0.0f;


	private float _targetDistance;

	private bool lockScreen = false;

	public float Y { get { return _y; } }
	public float X { get { return _x; } }
	
	void Start()
	{
		// initialising references
		standardPos = ThirdPersonCam.transform;



		Cursor.visible = false;
		Screen.lockCursor = true;
		

		Vector3 angles = standardPos.eulerAngles;
		
		_x = angles.y;
		_y = angles.x;


	}
	
	void FixedUpdate ()
	{

		// return the camera to standard position and direction
		//if (!camReady) {
			transform.position = Vector3.Lerp (transform.position, standardPos.position, Time.deltaTime * smooth);	
			transform.forward = Vector3.Lerp (transform.forward, standardPos.forward, Time.deltaTime * smooth);
			camReady = true;
		//}

		if (Input.GetButtonDown ("Cancel")) {
			lockScreen = !lockScreen;
		}

		if (lockScreen) {
			Cursor.visible = !Cursor.visible;
			//Screen.lockCursor = !Screen.lockCursor;
		}

	}
	
}
