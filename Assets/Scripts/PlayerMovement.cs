using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public int speed = 10;
    public float xRange = 9.0f;
    public float yRange = 3.7f;
    public GameObject Puck;
    public GameObject Blocky;
    public int Score = 0;
    public GameObject scoreText;
    public GameObject gameOverText;

    // Start is called before the first frame update
    void Start()
    {
        SpawnPuck();
        SpawnBlocky();
    }

    void SpawnPuck()
    {
        //Debug.Log(Random.Range(1.0f,10.0f));
        Instantiate(Puck, new Vector2(Random.Range(-6.0f, 6.0f), Random.Range(-3.7f, 3.7f)), Quaternion.identity);
    }

    void SpawnBlocky()
    {
        Instantiate(Blocky, new Vector2(Random.Range(-xRange, xRange), Random.Range(-yRange, yRange)), Quaternion.identity);
    }
    // Update is called once per frame
    void Update()
    {
        //SpawnPuck();

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        transform.Translate(movement * speed * Time.deltaTime);
        //if (Input.GetKeyDown(KeyCode.D))
        //{
        //    Debug.Log("D was pressed");
        //    transform.Translate(Vector2.right * speed * Time.deltaTime);
        //}
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //if it's tagged as "Blocky"...
        if (collision.gameObject.tag == "Blocky")
        {
            //add 5 to score
            Debug.Log(Score);
            Destroy(collision.gameObject);
            SpawnBlocky();
            SpawnPuck();
            scoreText.GetComponent<ScoreKeeper>().UpdateScore();
        }

        if (collision.gameObject.tag == "Puck")
        {
            //if it's tagged as "Puck"...
            gameOverText.SetActive(true);
            Time.timeScale = 0;
        }


    }

    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    private void LateUpdate()
    {
        //Keep player in bounds of xRange and yRange
        if(transform.position.x > xRange)
        {
            transform.position = new Vector2(xRange, transform.position.y);
        }

        if (transform.position.x < -xRange)
        {
            transform.position = new Vector2(-xRange, transform.position.y);
        }

        if (transform.position.y > yRange)
        {
            transform.position = new Vector2(transform.position.x, yRange);
        }

        if (transform.position.y < -yRange)
        {
            transform.position = new Vector2(transform.position.x, -yRange);
        }
    }
}
