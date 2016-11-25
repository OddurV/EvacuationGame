using UnityEngine;
using System.Collections;

public class FireSpread : MonoBehaviour {

    public float maxSize;
    public float growFactor;
    public float waitTime;

    // Use this for initialization
    void Start () {
        StartCoroutine(Scale());
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Fire")
        {
            //InvokeRepeating("Damage", 1.0f, 1.0f);
        }
    }

    IEnumerator Scale()
    {
        float timer = 0;
        while (true)
        {
            while (maxSize > transform.localScale.x)
            {
                timer += Time.deltaTime;
                transform.localScale += new Vector3(1, 1, 1) * Time.deltaTime * growFactor;
                yield return null;
            }

            yield return new WaitForSeconds(waitTime);
        }
    }
}
