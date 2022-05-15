using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ballMove : MonoBehaviour
{
    public float dx = 0f;
    public float dy = -0.04f;
    public float speed = 2f;

    public GameObject Panel_Win; 
    public AudioSource Soundball;
   // public AudioSource DestroyBrick;
    void Start()
    {
        
    }

   
    void Update()
    {
        transform.position = new Vector3(transform.position.x + (dx * speed),transform.position.y +(dy * speed),1);
        
        if (transform.position.y < GameObject.FindGameObjectWithTag("Player").transform.position.y)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }

        GameObject[] bricks = GameObject.FindGameObjectsWithTag("brick");
        if (bricks.Length == 0)
        {
            Panel_Win.SetActive(true);
            //alternarLevel();
        }
    }

   public void alternarLevel()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            float angle = 0f;

            if (Random.Range(0,100f) < 50f)
            {
               angle = Random.Range(20f, 45f);
            }
            else
            {
                angle = Random.Range(180f+20f, 180f+45f);
            }
          
            dx = Mathf.Cos(Mathf.Deg2Rad * angle);
            dy = Mathf.Sin(Mathf.Deg2Rad * angle);

            if (dy < 0)
            {
                dy *= -1;
            }
            speed = 0.1f;
        }
        else if (collision.gameObject.tag == "Wall_Right" || collision.gameObject.tag == "Wall_Left")
        {
            dx *= -1;
        }
        else if (collision.gameObject.tag == "brick")
        {
            Soundball.Play();
            dy *= -1;
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "brick_inquebravel")
        {
            dy *= -1;
            
        }

    }
}
