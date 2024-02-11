using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    private Animator anim;
    private float timer = 0;
    private float shootingTime = 0.08f;
    public delegate void shootDelegate(Vector3 position);
    public static shootDelegate shootEvent;
    public float speed = 5;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }


    private void Moving(){
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector2 temp = transform.position;
        temp.x += h * Time.deltaTime * speed;
        temp.y += v * Time.deltaTime * speed;
        

        if(temp.x >= -8 && temp.x <= 8 && temp.y >= -4 && temp.y <= 4){
            transform.position = temp;
        }
    }

    private void Shooting(){
        if(Input.GetButton("Fire1") && timer >= shootingTime){
            anim.SetTrigger("shooting");
            if(shootEvent != null){
                shootEvent(transform.position);
            }
            timer = 0;
        }
        timer += Time.deltaTime * 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        Moving();
        Shooting();
    }
}
