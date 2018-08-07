using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;

    public GameObject playerExplosion;

    public int scoreValue;

    private GameController gameController;
	// Use this for initialization
	void Start () {
		GameObject go = GameObject.FindWithTag("GameController");
	    if (go!=null)
	    {
	        gameController = go.GetComponent<GameController>();
	    }
	    else
	    {
	        Debug.Log("找不到tag为GameControllerz的对象");
	    }

	    if (gameController==null)
	    {
	        Debug.Log("找不到基本GameController.cs");
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        Destroy(gameObject);
        Instantiate(explosion, transform.position,transform.rotation);
        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver();
        }
        
        gameController.AddSource(scoreValue);
    }
}
