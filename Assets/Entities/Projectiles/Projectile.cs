using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    public float speed;
    public float padding;

    private float xmin;
    private float xmax;

    // Use this for initialization
    void Start () {

        speed = 10f;
        padding = 1f;

        transform.rotation = Quaternion.Euler( 0,0,-90 );
        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f, distance));
        Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1f, 0f, distance));
        xmin = leftmost.x - padding;
        xmax = rightmost.x + padding;
    }
	
	// Update is called once per frame
	void Update () {
        MoveProjectile();
	}

    void MoveProjectile()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;
        float newX = Mathf.Clamp(transform.position.x, xmin, xmax);
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
        if (transform.position.x >= xmax - padding)
        {
            Destroy(this.gameObject);
        }
    }
}
