using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private bool isActive;
    private Rigidbody2D rig;
    public float power = 2; 
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        rig.bodyType = RigidbodyType2D.Static;
    }

    public bool _isActive{
        get{
            return isActive;
        }
        set{
            isActive = value;
            rig.bodyType = isActive ? RigidbodyType2D.Dynamic : RigidbodyType2D.Static;
            if(!isActive){
                transform.position = transform.parent.position;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag == "recycle"){
            this._isActive = false;
        }
    }
}
