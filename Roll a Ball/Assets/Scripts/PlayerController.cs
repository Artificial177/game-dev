using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;
    private Rigidbody rb;

    private int score;
    public Text countText;
    public Text winText;
    public Text timeText;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        score = 0;
        winText.text = "";
        timeText.text = "";
        SetScoreText();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectable"))
        {
            other.gameObject.SetActive(false);
            score++;
            SetScoreText();

        }
    }

    void SetScoreText()
    {
        countText.text = "Score: " + score.ToString();
        if (score >= 12)
        {
            winText.text = "You Win!";
            timeText.text = "Your Time: " + Time.realtimeSinceStartup.ToString() + "s";
        }
    }

}