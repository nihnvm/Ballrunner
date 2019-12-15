using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public Text countText;
    public Text winText;
    public Text winText2;
    public Text scoreText;
    public Text scoreText2;
    public Text scoreTextTotal;
    public Text Instructions;
    public int stageComplete;

    private Rigidbody rb;
    private int count;
    private int score;
    private int score2;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        score = 10000;
        score2 = 10000;
        SetCountText();
        winText.text = "";
        winText2.text = "";
        Instructions.text = "";
        scoreText.text = "Count : " + score.ToString();
        scoreText2.text = "Count : " + score2.ToString();
        stageComplete = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (count == 0) { Instructions.text = "Touch the boxes to win!"; }
        else { Instructions.text = ""; }




        if (stageComplete == 0)
        {
            ScoreCounter1();
        }
        else
        {
            ScoreCounter2();
        }
      
       
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
 
    }

    void ScoreCounter1() {

        if (count <= 30) {
        score -= 1;
        scoreText.text = "Score: " + score.ToString();
        }
        else
        {
            winText.text = "1 Complete!";
            stageComplete = 1;
        }
    }
    void ScoreCounter2()
    {

        if (count <= 60)
        {
            score2 -= 1;
            scoreText2.text = "Score: " + score2.ToString();
        }
        if (count == 60)
        {
            winText2.text = "2 Complete!";
        }
    }
}
