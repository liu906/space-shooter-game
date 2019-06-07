using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xmin, xmax, ymin, ymax;
}

public class PlayerController : MonoBehaviour {
    public float speed;
    public Boundary boundary;
    public float tilt;
    public Transform ShotSpawn;
    public GameObject Shot;
    private float nextFire = 0f;
    public float deltaTime;


    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0f);
        GetComponent<Rigidbody>().velocity = movement * speed;

        GetComponent<Rigidbody>().position = new Vector3(Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xmin, boundary.xmax),
        Mathf.Clamp(GetComponent<Rigidbody>().position.y, boundary.ymin, boundary.ymax),
        GetComponent<Rigidbody>().position.z);
        GetComponent<Rigidbody>().rotation = Quaternion.Euler(-90f, GetComponent<Rigidbody>().velocity.x*-tilt, 0);


    }
    private void Update()
    {


        if(Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + deltaTime;
            //GameObject clone = 
            Instantiate(Shot, ShotSpawn.position, ShotSpawn.rotation);//as GameObject;
            GetComponent<AudioSource>().Play();
        }
        

    }

}

