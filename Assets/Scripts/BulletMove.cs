using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour {
    private Rigidbody2D myRigid;
    public GameObject explosion;
    GameStateManager gsm;


	// Use this for initialization
	void Start () {
        myRigid = this.GetComponent<Rigidbody2D>();

        gsm = GameObject.Find("GameState").GetComponent<GameStateManager>();
    }
	
	// Update is called once per frame
	void Update () {
        myRigid.AddForce(this.transform.up * 250);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject gob = collision.gameObject;
        GameObject boom;

        if (gob.tag == "Asteroid") {
            boom = Instantiate(
                              explosion,
                              gob.transform.position,
                               gob.transform.rotation
                           );
            Destroy(gob);
            gsm.adjustScore(1);
        }

        Destroy (this.gameObject);
    }

}
