using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    //create a line that accelerates the player

    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject bulletSpawn;
    [SerializeField] private GameObject[] anim;
    [SerializeField] private TMP_Text score;
    [SerializeField] private TMP_Text multiplier;
    [SerializeField] private TMP_Text highestScoreText;
    private int scoreInt;
    private Animator playerAnimation;
    private int multiplierInt;
    private Rigidbody2D playerRigidbody;
    private float rotationInput;
    private float movementInput;
    private float horizontalInput;
    private float verticalInput;
    private int lives;
    private int lives2;
    private float count;
    private int multiplierCount;
    public static int highestScore;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<Animator>();
        lives = 3;
        lives2 = 3;
        for (int i = 0; i < anim.Length; i++) {
            anim[i].GetComponent<Animator>().SetInteger("Lives", lives);
            anim[i].GetComponent<Animator>().SetInteger("Lives2", lives2);
        }
        if (highestScore == 0) {
            highestScore = 0;
        }
        highestScoreText.text = "Highest Score: " + highestScore.ToString();
    }

    void Update()
    {
        rotationInput = Input.GetAxis("Horizontal");
        if (Input.GetKey(KeyCode.W))
        {
            movementInput = 1;
            playerAnimation.SetBool("isForward", true);
        } else {
            movementInput = 0;
            playerAnimation.SetBool("isForward", false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject newBullet = Instantiate(bulletPrefab, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
        }
        
        if (lives <= 0) {
            SceneManager.LoadScene("DeathScreen");
        }
        count += Time.deltaTime;
        if (count >= 1) {
            scoreInt += multiplierCount;
            score.text = "Score: " + scoreInt.ToString();
            count = 0;
        }

        if (scoreInt > highestScore) {
            highestScore = scoreInt;
            highestScoreText.text = "Highest Score: " + highestScore.ToString();
        }

        multiplierCount = lives;
        multiplier.text = "Multiplier: " + multiplierCount.ToString();
    }

    void FixedUpdate()
    {
        playerRigidbody.AddForce(transform.up * movementInput * speed);
        playerRigidbody.angularVelocity = -rotationInput * rotationSpeed;
    }

    IEnumerator OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Asteroid") {
            lives--;
            anim[lives].GetComponent<Animator>().SetInteger("Lives", lives);
            lives2--;
            anim[lives2].GetComponent<Animator>().SetInteger("Lives2", lives2);
            transform.position = Vector2.zero;
            yield return new WaitForSeconds(1);
            Destroy(anim[lives]);
        }
    }
}
