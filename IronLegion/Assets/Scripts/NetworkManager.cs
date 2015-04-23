using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {

	public Camera StandByCamera;
	SpawnSpot [] spawnSpots;
	// Use this for initialization
	void Start () {
		Debug.Log ("Starting");
		spawnSpots = GameObject.FindObjectsOfType<SpawnSpot> ();
		Connect ();
	}
	

	void Connect (){
		Debug.Log ("Connect");
		PhotonNetwork.ConnectUsingSettings("0.0.1");
	}	

	void OnGUI (){
		GUILayout.Label (PhotonNetwork.connectionStateDetailed.ToString());
	}

	void OnJoinedLobby (){
		Debug.Log ("OnJoinedLobby");
		PhotonNetwork.JoinRandomRoom();
	}

	void OnPhotonRandomJoinFailed(){
		Debug.Log ("OnPhotonRandomJoinFailed");
		PhotonNetwork.CreateRoom (null);
	}

	void OnJoinedRoom (){
		Debug.Log ("OnJoinedRoom");
		SpawnMyPlayer ();
	}

	void SpawnMyPlayer(){
		if (spawnSpots == null) {
			Debug.LogError ("Spawning error");
			return;
		}
		SpawnSpot mySpawnSpot = spawnSpots [Random.Range (0, spawnSpots.Length)];
		GameObject myCamera = (GameObject)PhotonNetwork.Instantiate ("PlayerCam", mySpawnSpot.transform.position, mySpawnSpot.transform.rotation, 0);
		GameObject myPlayer = (GameObject) PhotonNetwork.Instantiate ("OnlinePlayer", mySpawnSpot.transform.position, mySpawnSpot.transform.rotation, 0);
		myPlayer.GetComponent<CustomMechControl> ().enabled = true;
		//myPlayer.GetComponent<AudioSource> ().enabled = true;
		myCamera.GetComponent<Camera> ().enabled = true;
		myCamera.GetComponent<AudioSource> ().enabled = true;
		StandByCamera.enabled = false;
	}
}
