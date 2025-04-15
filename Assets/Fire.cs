using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    // Start is called before the first frame update
    public void FireBullet(Vector2 start, Vector2 end, byte bulID)
    {
        Quaternion quaternion = Quaternion.Euler(0, 0, Mathf.Atan2(transform.position.y - end.y, transform.position.x - end.x) * Mathf.Rad2Deg - 90);
        float angle = MathF.Atan2(end.y - start.y, end.x - start.x) + 180;
        // Debug.Log(end);
        // Debug.Log(start);

        float bulDirX = start.x + Mathf.Sin((Mathf.Deg2Rad * angle));
        float bulDirY = start.y + Mathf.Cos((Mathf.Deg2Rad * angle));

        Vector2 bulDir = (new Vector2(bulDirX, bulDirY) - start).normalized;


        
        GameObject bul = BulletPool.bulletPoolInstance.GetBullet();
        bul.transform.position = start;
        bul.transform.rotation = quaternion;
        bul.GetComponent<Bullet>().SetMoveDirection(bulDir);
        bul.GetComponent<Bullet>().SetBulletID(bulID);
        bul.SetActive(true);
    }
}
