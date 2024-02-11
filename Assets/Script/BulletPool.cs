using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public GameObject bullet;
    public int buffetSize = 100;
    private float bulletPositionOffset = 0.5f;
    private Bullet[] bullets;

    private void OnEnable(){
        ShipController.shootEvent += CreateBullet;
    }
    private void OnDisable(){
        ShipController.shootEvent -= CreateBullet;
    }


    private void InitBulletPool(){
        bullets = new Bullet[buffetSize];
        for(int i=0; i < buffetSize; i++){
            bullets[i] = Instantiate(bullet, transform.position, quaternion.identity).GetComponent<Bullet>();
            bullets[i].transform.SetParent(gameObject.transform);
        }
    }

    public void CreateBullet(Vector3 position){
        int count = 0;
        foreach(Bullet bullet in bullets){
            if(bullet._isActive == false){
                bullet.transform.position = position;
                position.x += bulletPositionOffset;
                bullet._isActive = true;
                count++;
            }
            if(count == 3){
                break;
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        InitBulletPool();
    }

    
}
