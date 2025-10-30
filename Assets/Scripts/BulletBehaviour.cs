using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public float speed;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Animator>().SetTrigger("boom");
            gameObject.SetActive(false);
            Score.score += 5;
        }
        if (collision.CompareTag("Gold"))
        {
            collision.gameObject.GetComponent<Animator>().SetTrigger("boom");
            gameObject.SetActive(false);
            Score.score += 10;
        }
        if (collision.CompareTag("Respawn"))
        {
            gameObject.SetActive(false);
            Player.GetComponent<PlayerTankBehaviour>().OnTriggerEnter2D(collision);
        }

    }
}
