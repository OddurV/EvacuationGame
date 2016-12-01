using UnityEngine;
using System.Collections;

public class simple_character_movement : MonoBehaviour {

    public Animator animator;
    public float speed = 10f;

    // Update called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            animator.SetBool("walking", true);
            //transform.Translate(Vector3).right * Time.deltaTime * speed);
            if (Input.GetAxis("Horizontal") < 0)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            if (Input.GetAxis("Horizontal") > 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
        else
        {
            animator.SetBool("walking", false);
        }

    }
}