using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGenerator : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject player;
    public float respawnTime = 1.0f;
    private Vector2 screenBounds;
    public Rigidbody2D rb;
    bool gameStarted;
    bool spawn;


    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(bulletWave());
    }

    void spawnBullet(){
        GameObject bullet = Instantiate(bulletPrefab) as GameObject;
        rb = bullet.GetComponent<Rigidbody2D>();
        int score = GameManager.instance.getScore();
        int range = 0;
        float velocity = 0f;
        if(score <= 10) { range = 1;}
        else if(score <= 20) { range = 2;}
        else if(score <= 30) { range = 3;}
        else if(score <= 40) { range = 4;}
        else { range = 5;}

        if(score>50){
            velocity = (score-50)/100;
        }
        int side = (int) Random.Range(0, range);
        switch(side){
            case 0: bullet.transform.position = new Vector2(Random.Range(-screenBounds.x, screenBounds.x), screenBounds.y * -1.1f); rb.velocity = Vector2.up * (1f + velocity); break;
            case 1: bullet.transform.position = new Vector2(Random.Range(-screenBounds.x, screenBounds.x), -screenBounds.y * -1.1f); rb.velocity = Vector2.down * (1f + velocity); break;
            case 2: bullet.transform.position = new Vector2(screenBounds.x * -1.1f, Random.Range(-screenBounds.y, screenBounds.y)); rb.velocity = Vector2.right * (0.7f + velocity); break;
            case 3: bullet.transform.position = new Vector2(-screenBounds.x * -1.1f, Random.Range(-screenBounds.y, screenBounds.y)); rb.velocity = Vector2.left * (0.7f + velocity); break;
            case 4: {
                int onPlayer = (int) Random.Range(0, 4);
                switch(onPlayer) {
                    case 0 : bullet.transform.position = new Vector2(player.transform.position.x , screenBounds.y * -1.1f); rb.velocity = Vector2.up * (1f + velocity); break;
                    case 1 : bullet.transform.position = new Vector2(player.transform.position.x, -screenBounds.y * -1.1f); rb.velocity = Vector2.down * (1f + velocity); break;
                    case 2 : bullet.transform.position = new Vector2(screenBounds.x * -1.1f, player.transform.position.y); rb.velocity = Vector2.right * (0.7f + velocity); break;
                    case 3 : bullet.transform.position = new Vector2(-screenBounds.x * -1.1f, player.transform.position.y); rb.velocity = Vector2.left * (0.7f + velocity); break;
                }
                break;         
            }
        }
    }

    IEnumerator bulletWave(){
        while(true){
            yield return new WaitForSeconds(respawnTime);
            spawnBullet();
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
