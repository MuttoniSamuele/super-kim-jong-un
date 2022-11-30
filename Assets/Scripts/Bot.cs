using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot : MonoBehaviour
{
    [SerializeField] private GameObject Kim;
    [SerializeField] private float Velocity;
    [SerializeField] private float Velocity1;
    [SerializeField] private float Velocity2;
    [SerializeField] private Transform bulletSpawn;
    [SerializeField] private GameObject bulletPrefab;
    private Rigidbody2D rbody;
    bool KimIsEntered = false;
    private float timeRemaining = 2;

	// Start is called before the first frame update
	void Start()
    {
        rbody = gameObject.GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void FixedUpdate()
    {
        Vector2 newVel = rbody.velocity;
        if (KimIsEntered)
        {
            if (Mathf.Abs(Mathf.Abs(Kim.transform.position.x) - Mathf.Abs(transform.position.x)) < 0.1 && Mathf.Abs(Mathf.Abs(Kim.transform.position.x) - Mathf.Abs(transform.position.x)) > -0.1)
            {
                newVel.x = 0;
                Velocity1 = 0;
            }
            else if (Kim.transform.position.x > transform.position.x)
            {
                newVel.x = +Velocity;
                Velocity1 = Velocity + 2;
            }
            else if (Kim.transform.position.x < transform.position.x)
            {
                newVel.x = -Velocity;
                Velocity1 = -Velocity - 2;
            }
            if (timeRemaining > 0)
            {

                timeRemaining -= Time.deltaTime;
            }
            else
            {
                Fire();
                timeRemaining = 2;
            }
        }
        else 
        {
            newVel.x = 0;
            Velocity1 = 0;
        }
        rbody.velocity = newVel;
    }

    void Fire()
    {
		Vector3 scale = transform.localScale;
		float time;
        if (Mathf.Abs(Mathf.Abs(Kim.transform.position.x) - Mathf.Abs(transform.position.x)) < 0.1 && Mathf.Abs(Mathf.Abs(Kim.transform.position.x) - Mathf.Abs(transform.position.x)) > -0.1) 
        {
            Velocity1 = 0;
            time = 1;
        }
        else if (Kim.transform.position.x > transform.position.x)
        {
			scale.x = Mathf.Abs(scale.x) * -1;
			transform.localScale = scale;
			Velocity1 = Velocity + 2;
            if(Kim.transform.position.x - transform.position.x>0)
            {
                time = (Kim.transform.position.x - transform.position.x) / 4;
            }
            else time = -(Kim.transform.position.x - transform.position.x) / 4;
        }
        else if (Kim.transform.position.x < transform.position.x)
        {
			scale.x = Mathf.Abs(scale.x);
			transform.localScale = scale;
			Velocity1 = -Velocity - 2;
            if (transform.position.x - Kim.transform.position.x > 0)
            {
                time = (transform.position.x - Kim.transform.position.x) / 4;
            }
            else time = -(transform.position.x - Kim.transform.position.x) / 4;
        }
        else
        {
            Velocity1 = 0;
            time = 0;
        }
        time = time+1;
        if (Kim.transform.position.y != transform.position.y)
        {
            Velocity2 = (Kim.transform.position.y - transform.position.y) / time;
        }
        else Velocity2 = 0;
		// Create the Bullet from the Bullet Prefab
        var bullet = (GameObject)Instantiate(
        bulletPrefab,
        bulletSpawn.position,
        bulletSpawn.rotation);

        // Add velocity to the bullet
        Vector2 newVel1 = new Vector2(0,0);
        newVel1.x = +Velocity1;
        newVel1.y = Velocity2;
        bullet.GetComponent<Rigidbody2D>().velocity = newVel1;
        bullet.GetComponent<SpriteRenderer>().flipX = newVel1.x > 0;

		// Destroy the bullet after 2 seconds
		Destroy(bullet, 5);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject == Kim)
        {
            KimIsEntered = true;
            timeRemaining = -1;
        } 
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject == Kim)
        {
            KimIsEntered = false;
        }
    }
}
