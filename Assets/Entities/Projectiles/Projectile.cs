using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        transform.rotation = Quaternion.Euler(0, 0, -90);
	}
	
	// Update is called once per frame
	void Update ()
    {
        Transform.position = new Vector3(transform.position.x + 0.1f, transform.position.y, transform.position.z);
    }
}
