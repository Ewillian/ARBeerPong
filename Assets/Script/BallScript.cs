using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{

    private Rigidbody rigibody;

    // Start is called before the first frame update
    void Start()
    {
        rigibody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {

        rigibody.mass = 0.9f;

        //if (collision.collider.CompareTag("Floor"))
        //{

        //}
    }
}
