using UnityEngine;
using System.Collections;


public class CameraController : MonoBehaviour {

    public GameObject player;
    public Vector3 offset;

	static private float zoomParameterMax = 40.0f;
	static private float zoomParamYmin = 0.0f;
	static private float zoomParamYmax = 0.0f;
	static private float zoomParamZmin = 0.0f;
	static private float zoomParamZmax = 0.0f;
	static private Vector3 origin;
	static private Vector3 zoomMax = new Vector3(20.0f,0.0f,0.0f);

    // Use this for initialization
    void Start () {
		offset = transform.position - player.transform.position;
		origin = player.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate ()
    {
		Vector3 zoom = TrackPlayer (player.transform.position);
		transform.position = player.transform.position + offset + zoom;
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
		float z = Mathf.Max (Mathf.Abs (zoomParamZmax), Mathf.Abs (zoomParamZmin));
		float max = Mathf.Max (y, z);
		//Debug.Log (zoomParamZmax);
		//Debug.Log ("max = " + max);
		float ratio = max / zoomParameterMax;
		if (ratio > 1.0f) {
			ratio = 1.0f;
		}

		return Vector3.Scale(zoomMax,new Vector3(ratio, ratio, ratio));
	}
}
