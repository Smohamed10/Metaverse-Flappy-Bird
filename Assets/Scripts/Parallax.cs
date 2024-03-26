using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallax : MonoBehaviour
{
    public float speed;
    public float imagewidth;
    void Start()
    {
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        imagewidth = sprite.texture.width / sprite.pixelsPerUnit;
        imagewidth = 1920.0f;

    }
    // Update is called once per frame
    void Update()
    {
        checkrewind();
        Scroll();


        
    }

    void Scroll()
    {
        Vector3 newPos = transform.position;
        newPos.x += speed * Time.deltaTime;
        transform.position = newPos;
    }
    void checkrewind()
    {
        if (transform.position.x < 0)
        {
            transform.position = new Vector3(1000, transform.position.y, transform.position.z);
        }
    }
}
