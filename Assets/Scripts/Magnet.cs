using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
public float jumpForce = 1f;

	public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
      
     
    if (Input.GetMouseButtonDown(0))
		{
	
      Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
      Vector2 lookDirection = (mousePos - rb.position);
      float distance =  Vector2.Distance(mousePos, rb.position);
      float factor = 3.5f;
      float repelForce = (12 - distance)/factor;
      rb.velocity = lookDirection.normalized * repelForce * -1f;
     
		}
    
  }

  
  void OnTriggerEnter2D (Collider2D col)
	{
		if (col.tag == "Bullet")
		{
      GameManager.instance.restart();
		}
		
	}

}
