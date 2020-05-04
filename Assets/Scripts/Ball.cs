using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{




    public GameObject text;
    public GameObject text2;

    public int bonus;
    Rigidbody2D rig;
    public float power;

    private int live1 = 3;
    private int live2 = 3;
    private int live3 = 3;
    private int live4 = 3;


    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        rig.AddForce(new Vector3(0.5f, 1.2f) * Time.deltaTime * power);

    }



    void Update()
    {
        text2.gameObject.GetComponent<Text>().text = ("Points: " + bonus);


        if (gameObject.transform.position.y <= -5.5f)
        {
            Time.timeScale = 0;
            text.gameObject.GetComponent<Text>().text = ("I lose. Press 's' to restart");
            if (Input.GetKeyDown("s"))
            {

                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                Time.timeScale = 1;
            }
        }

        if (bonus == 150)
        {
            Time.timeScale = 0;
            text.gameObject.GetComponent<Text>().text = ("YOU WIN! PRESS S TO START");
            if (Input.GetKeyDown("s"))
            {

                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                Time.timeScale = 1;
            }


        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "stone")
        {
            Destroy(collision.gameObject);
            bonus += 10;
        }

        if (collision.gameObject.name == "block1")
        {
            live1--;
            if(live1==0)
            {
                Destroy(collision.gameObject);
                bonus += 20;
            }
        }

        if (collision.gameObject.name == "block2")
        {
            live2--;
            if (live2 == 0)
            {
                Destroy(collision.gameObject);
                bonus += 20;
            }
        }


        if (collision.gameObject.name == "block3")
        {
            live3--;
            if (live3 == 0)
            {
                Destroy(collision.gameObject);
                bonus += 20;
            }
        }


        if (collision.gameObject.name == "block4")
        {
            live4--;
            if (live4 == 0)
            {
                Destroy(collision.gameObject);
                bonus += 20;
            }
        }
    }
}
