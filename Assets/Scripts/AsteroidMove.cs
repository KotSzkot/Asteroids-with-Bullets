using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMove : MonoBehaviour
{
    public int rotz;
    public int mx, my;
    public Rigidbody2D myRigid;
    public ParticleSystem myPart;

    // Use this for initialization
    void Start()
    {
        myRigid = this.GetComponent<Rigidbody2D>();
        myPart = this.GetComponent<ParticleSystem>();

        myRigid.AddForce(Vector3.up * mx);
        myRigid.AddForce(Vector3.right * mx);

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(new Vector3(0, 0, rotz));

    }

    private void OnCollisionEnter2D(Collision2D collision) {
        myPart.Play();
    }

    private void OnCollisionExit2D(Collision2D collision) {
        myPart.Stop();
    }
}
