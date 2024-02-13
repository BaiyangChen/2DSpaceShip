using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    private Animator anim;
    private float timer = 0;
    private float shootingTime = 0.08f;
    public delegate void GameOverDelegate();
    public static GameOverDelegate GameOverEvent;
    public delegate void shootDelegate(Vector3 position);
    public static shootDelegate shootEvent;
    public float speed = 5;
    private bool isDead;

    private AudioSource audiosouce;
    public AudioClip explosionAudio;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        audiosouce = GetComponent<AudioSource>();
    }


    private void Moving(){

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector2 temp = transform.position;
        temp.x += h * Time.deltaTime * speed;
        temp.y += v * Time.deltaTime * speed;
        

        if(isDead == false && temp.x >= -8 && temp.x <= 8 && temp.y >= -4 && temp.y <= 4){
            transform.position = temp;
        }
    }

    private void Shooting(){
        if(isDead == false && Input.GetButton("Fire1") && timer >= shootingTime){
            anim.SetTrigger("shooting");
            if(shootEvent != null){
                shootEvent(transform.position);
            }
            timer = 0;
            audiosouce.Play();
        }
        timer += Time.deltaTime * 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        Moving();
        Shooting();
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag == "enemy"){
            anim.SetTrigger("Explosion");
            GetComponent<Collider2D>().enabled = false;
            isDead = true;
            if(GameOverEvent != null){
                GameOverEvent();
            }
            audiosouce.PlayOneShot(explosionAudio);
        }
    }

    public void hide(){
        GetComponent<SpriteRenderer>().enabled = false;
    }
}
