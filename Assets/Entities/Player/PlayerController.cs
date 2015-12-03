using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed = 15f;
	public float padding = 1f;
    public GameObject projectile;

	private float xmin;
	private float xmax;
    private float ymin;
    private float ymax;

	// Use this for initialization
	void Start () {
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 bottommost = Camera.main.ViewportToWorldPoint(new Vector3(0f,0f,distance));
		Vector3 topmost = Camera.main.ViewportToWorldPoint(new Vector3(0f,1f,distance));
        Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f, distance));
        Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1f, 0f, distance));
        ymin = bottommost.y + padding;
        ymax = topmost.y - padding;
        xmin = leftmost.x + padding;
		xmax = rightmost.x - padding;
	}
	
	// Update is called once per frame
	void Update () {
		MovePlayer();
        Shoot();
        //cooldown();
    }

	void MovePlayer (){
		if (Input.GetKey(KeyCode.LeftArrow)){
			transform.position += Vector3.left * speed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.RightArrow)){
			transform.position += Vector3.right * speed * Time.deltaTime;
		}
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }

        float newX = Mathf.Clamp(transform.position.x,xmin,xmax);
		transform.position = new Vector3(newX,transform.position.y,transform.position.z);

        float newY = Mathf.Clamp(transform.position.y,ymin,ymax);
        transform.position = new Vector3(transform.position.x,newY, transform.position.z);

    }

    void Shoot()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectile, 
                new Vector3(transform.position.x + 0.2f, transform.position.y + 0.2f, transform.position.z), 
                Quaternion.identity);
        }
    }

    /*void cooldown()
    {

    } */
}
