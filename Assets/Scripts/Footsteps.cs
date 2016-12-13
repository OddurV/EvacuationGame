using UnityEngine;
using System.Collections;

public class Footsteps : MonoBehaviour {

	public AudioSource footstepSource;
	public AudioClip[] footsteps;

	void PlayFootstep(){if(footsteps.Length > 0 && !footstepSource.isPlaying)footstepSource.PlayOneShot(footsteps[Random.Range(0,footsteps.Length)]);}


}
