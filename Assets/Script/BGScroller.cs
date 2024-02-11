using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour
{
    public float speed = 0.5f;
    public float rangeMax;
    public float rangeMin;
    public Transform[] bgImages;
    

    // Update is called once per frame
    void Update()
    {
        foreach(Transform tf in bgImages){
            Vector2 temp = tf.position;
            temp.y -= speed * Time.deltaTime;
            tf.position = temp;

            if(temp.y <= rangeMin){
                temp.y = rangeMax;
                tf.position = temp;
            }
        }
    }
}
