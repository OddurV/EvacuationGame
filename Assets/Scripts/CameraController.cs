using UnityEngine;
using System.Collections;


public class CameraController : MonoBehaviour {

    public GameObject player;
    public Vector3 offset;

	static private float zoomParameterMax = 0.9f;//25.0f;
	static private float zoomParamYmin;
	static private float zoomParamYmax;
	static private float zoomParamZmin;
	static private float zoomParamZmax;
	static private Vector3 origin;
	static private Vector3 zoomMax = new Vector3(0.9f,0.0f,0.0f); //Vector3(20.0f,0.0f,0.0f);
	static private bool zoomOut = false;

    // Use this for initialization
    void Start () {
        Time.timeScale = 1;
		zoomParamYmin = 0.0f;
		zoomParamYmax = 0.0f;
		zoomParamZmin = 0.0f;
		zoomParamZmax = 0.0f;
        offset = transform.position - player.transform.position;
		origin = player.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate ()
    {
		if(Input.GetKeyDown(KeyCode.Z)){
			if (zoomOut) {
				zoomParameterMax = 0.9f;//25.0f;
				zoomMax = new Vector3 (0.9f, 0.0f, 0.0f); //Vector3(20.0f,0.0f,0.0f);
				zoomOut = !zoomOut;
			} else {
				zoomParameterMax = 25.0f;
				zoomMax = new Vector3(20.0f,0.0f,0.0f);
				zoomOut = !zoomOut;
			}
		}
		Vector3 zoom = TrackPlayer (player.transform.position);
		transform.position = Restrict (player.transform.position, player.transform.position + offset + zoom);
    }

	//Use:  offset = TrackPlayer(player.transform.position);
	//Pre:  player.transform.position is a Vector3 object
	//Post: offset is a Vector3 object, representing the zoom level 
	//      of the camera based on how much the player has moved
	static private Vector3 TrackPlayer(Vector3 pos){
		//Debug.Log (pos.z-origin.z);
		if (pos.y-origin.y < zoomParamYmin) {
			zoomParamYmin = pos.y-origin.y;
		}
		if (pos.y-origin.y > zoomParamYmax) {
			zoomParamYmax = pos.y-origin.y;
		}
		if (pos.z-origin.z < zoomParamZmin) {
			zoomParamZmin = pos.z-origin.z;
		}
		if (pos.z-origin.z > zoomParamZmax) {
			zoomParamZmax = pos.z-origin.z;
		}
		float y = Mathf.Max (Mathf.Abs (zoomParamYmax), Mathf.Abs (zoomParamYmin));
		float z = Mathf.Max (Mathf.Abs (zoomParamZmax), Mathf.Abs (zoomParamZmin))/5.0f;
		float max = Mathf.Max (y, z);
		//Debug.Log (zoomParamZmax);
		//Debug.Log ("max = " + max);
		float ratio = max / zoomParameterMax;
		if (ratio > 1.0f) {
			ratio = 1.0f;
		}

		return Vector3.Scale(zoomMax,new Vector3(ratio, ratio, ratio));
	}

	// Use: position = Restrict (player, cam);
	// Pre: player and cam are Vector3 objects
	// Post: cam has been restricted so that it lies within specified bounds
	// This function makes sure that the camera is always looking at the building
	static private Vector3 Restrict (Vector3 player, Vector3 cam){
		//Running the game and moving the player gets 
		//the following desired values of the camera's position
		if (zoomOut) {
			//When zoom is allowed
			//if x=5.75 then y=3.05
			//if x=26 then y=23
			//simplify to x=y+3
			if (cam.y < cam.x - 3f && zoomOut) {
				cam.y = cam.x - 3f;
			}
		} else {//zoom is not allowed
			if (player.x>0.3f || player.x<-3.5f){
				if(cam.x>5.3f){cam.x = 5.3f;}
				if(cam.x<1.0f){cam.x = 1.0f;}
			}
		}
		return cam;
	}
}
