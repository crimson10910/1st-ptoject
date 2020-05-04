using System;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public UiController uiController;
    public Transform ball;
    public float power;
    
    private int _bonus;
    
    private void Start()
    {
        var blocks = FindObjectsOfType<Block>();
        foreach (var block in blocks)
        {
            block.onCollision += OnCollision;
        }

        var rigidbody = ball.GetComponent<Rigidbody2D>();
        rigidbody.AddForce(new Vector3(0.5f, 1.2f) * power);
    }

    private void Update()
    {
        string str = "Error";
        bool allow = false;
        
        if (ball.position.y <= -5.5f)
        {
            str = "I lose. Press 's' to restart";
            allow = true;
        }

        if (_bonus >= 150)
        {
            str = "YOU WIN! PRESS S TO START";
            allow = true;
        }

        if (allow)
        {
            Time.timeScale = 0;
            uiController.UpdateUI(str);
            if (Input.GetKeyDown("s"))
            {

                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                Time.timeScale = 1;
            }
        }
    }

    private void OnCollision(int point)
    {
        _bonus += point;
        string str;
        if (_bonus >= 150)
        {
            str = "YOU WIN! PRESS S TO START";
        }
        else
        {
            str = $"Points: {_bonus.ToString()}";
        }
        uiController.UpdateUI(str);
    }
}
