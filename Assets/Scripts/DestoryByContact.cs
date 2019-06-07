using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryByContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject PlayerExplosion;
    public int scoreValue;
    private GameController gameController;
    private void Start()
    {
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        if(gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if(gameController == null)
        {
            Debug.Log("cannot find game controller");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary")
        {
            return;
        }
        if(other.tag == "Player")
        {
            Instantiate(PlayerExplosion, transform.position, transform.rotation);
            gameController.GameOver();

        }
        else
        {
            Instantiate(explosion, gameObject.transform.position, gameObject.transform.rotation);
        }
        gameController.AddScore(scoreValue);

        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}


