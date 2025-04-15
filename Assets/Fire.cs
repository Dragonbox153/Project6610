using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    // Start is called before the first frame update
    public void FireBullet()
    {
        Vector2 start = gameObject.transform.position;
        Vector2 end = Input.mousePosition;
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Quaternion quaternion = Quaternion.Euler(0, 0, Mathf.Atan2(transform.position.y - mousePos.y, transform.position.x - mousePos.x) * Mathf.Rad2Deg - 90);
        float angle = MathF.Atan2(mousePos.y - start.y, mousePos.x - start.x) + 180;
        Debug.Log(mousePos);
        Debug.Log(start);

        float bulDirX = start.x + Mathf.Sin((Mathf.Deg2Rad * angle));
        float bulDirY = start.y + Mathf.Cos((Mathf.Deg2Rad * angle));

        Vector2 bulDir = (new Vector2(bulDirX, bulDirY) - start).normalized;


        
        GameObject bul = BulletPool.bulletPoolInstance.GetBullet();
        bul.transform.position = start;
        bul.transform.rotation = quaternion;
        bul.GetComponent<Bullet>().moveDirection = bulDir;
        bul.SetActive(true);
    }
}
