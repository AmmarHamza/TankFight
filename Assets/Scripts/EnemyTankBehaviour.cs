using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankBehaviour : MonoBehaviour
{
    GameObject Player;
    public float speed;
    bool isAlive;
    Animator animator;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }
    private void OnEnable()
    {
        isAlive = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive)
        {
            transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);
            transform.up = (transform.position - Player.transform.position).normalized;
        }   
    }
    public void Eliminate()
    {
        animator.ResetTrigger("boom");
        gameObject.SetActive(false);
    }
    public void Die()
    {
        isAlive = false;
        audioSource.Play();
    }
}
