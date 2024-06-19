using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D (Collider2D col)
	{
		if (col.tag == "Bullet")
		{
			Destroy(col.gameObject);
            GameManager.instance.ScoreUp();
            //Debug.Log("Score: " + score);
            //GameManager.instance.scoreUp();
			return;
		}
		
	}
}
