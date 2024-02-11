using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform player;
    private Animator animator;
    public float speed;
    
    [SerializeField]private int score;

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
        

    }

    private void PlayEffect(){
        animator.SetTrigger("Explosion");
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag == "bullet"){
            PlayEffect();
            if(ExplodingEvent != null){
                ExplodingEvent(getScore());
            }
        }
    }

    public void ResetEnemy(){
        Destroy(gameObject);
    }

    
}
