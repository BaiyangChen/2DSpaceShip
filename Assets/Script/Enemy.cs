using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform player;
    private Animator animator;
    public float speed;
    private AudioSource audioSource;
    
    [SerializeField]private int score;

    public int rangeMin;
    public int rangeMax;

    public delegate void ExplodingDelegate(int score);
    public static ExplodingDelegate ExplodingEvent;

    public int getScore(){
        return score;
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
        Vector3 target = player.position - transform.position;
        target.Normalize();
        GetComponent<Rigidbody2D>().AddForce(target * speed);
        audioSource = GetComponent<AudioSource>();

    }

    private void PlayEffect(){
        animator.SetTrigger("Explosion");
        audioSource.Play();
    }

    private void OnTriggerEnter2D(Collider2D collision){

        if(collision.tag == "recycle"){
            ResetEnemy();
        }
        if(collision.tag == "bullet"){
            PlayEffect();
            GetComponent<Collider2D>().enabled = false;
            if(ExplodingEvent != null){
                ExplodingEvent(getScore());
            }
        }
    }

    public void ResetEnemy(){
        Destroy(gameObject);
    }

    public Vector3 SpawnPosition(){
        float xRange = Random.Range(rangeMin,rangeMax+1);
        Vector3 spawnPosition = new Vector3(xRange, 6);
        return spawnPosition;
    }

    
}
