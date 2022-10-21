using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveShip : MonoBehaviour {
    public string left;
    public string right;
    public string up;
    public string fire;
    public GameObject bullet;

    private float lastFired;

    Rigidbody2D myRigid;
    GameObject myEngine;
    ParticleSystem myPart;

    void Start()
    {
        myRigid = this.GetComponent<Rigidbody2D>();
        myEngine = GameObject.Find("Engine");

        myPart = myEngine.GetComponent<ParticleSystem>();
    }

    void Update()
    {
        GameObject tmpBullet;

        if (Input.GetKey(left))
        {
            this.transform.Rotate(new Vector3(0f, 0f, 200f)
* Time.deltaTime);
        }

        if (Input.GetKey(right))
        {
            this.transform.Rotate(new Vector3(0f, 0f,
-200f) * Time.deltaTime);
        }

        if (Input.GetKey (fire))
        {

            if (Time.time > lastFired + 1)
            {
                tmpBullet = Instantiate(
                               bullet,
                               this.transform.position + this.transform.up * 1,
                                this.transform.rotation
                            );

                lastFired = Time.time;
            }

        }
    }

    void FixedUpdate()
    {
        if (Input.GetKey(up))
        {
            myPart.Play();
            myRigid.AddForce(this.transform.up * 500);
        }
        else
        {

            myPart.Stop();
        }
    }


}
