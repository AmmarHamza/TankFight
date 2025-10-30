using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerTankBehaviour : MonoBehaviour
{
    public float speed;
    int direction;
    Animator animator;
    bool isAlive;
    public Hearts hearts;
    public Sprite[] sprites;
    SpriteRenderer spriteRenderer;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        isAlive = true;
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprites[Shop.selectedTank];
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive)
        {
            if (direction > 0)
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
            }
            if (direction < 0)
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime);
            }
        }    
    }
    public void MoveRight()
    {
        direction = 1;
    }
    public void MoveLeft()
    {
        direction = -1;
    }
    public void Stop()
    {
        direction = 0;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Gold"))
        {
            collision.gameObject.GetComponent<Animator>().SetTrigger("boom");
            hearts.MinusHeart();
            if(hearts.numOfHearts <= 0)
            {
                animator.enabled = true;
                isAlive = false;
            }
        }
        if (collision.gameObject.CompareTag("Respawn"))
        {
            hearts.MinusHeart();
            collision.gameObject.GetComponent<AudioSource>().Play();
            if (hearts.numOfHearts <= 0)
            {
                animator.enabled = true;
                audioSource.Play();
                isAlive = false;
            }
        }
    }
    private void Eliminate()
    {
        Score.Save();
        SceneManager.LoadScene("Leaderboard");
    }
}
