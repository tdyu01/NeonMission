using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zgrav : MonoBehaviour {

    public float vert;
    public bool isPlayingFoil;
    private int contObjects;
    float temp;

	void Start () {
        contObjects = 0;
        isPlayingFoil = false;
	}
	
	// Update is called once per frame
	void Update () {
        temp = GetComponentInParent<GeneradorB>().speed;
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            contObjects++;
            if (!isPlayingFoil)
                isPlayingFoil = true;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if ((other.tag == "Player" || other.tag == "Pushable"))
        {
            //if (GetComponentInParent<GeneradorB>().limit)
            //{
            //    vert = 1f;
            //}

            other.GetComponent<Rigidbody2D>().velocity = new Vector2(other.GetComponent<Rigidbody2D>().velocity.x, vert);
            
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if ((other.tag == "Player" || other.tag == "Pushable"))
        {
            vert = temp;
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(other.GetComponent<Rigidbody2D>().velocity.x, vert);
            if (other.transform.tag == "Player")
            {
                contObjects--;
            }
        }
        if (contObjects == 0)
            isPlayingFoil = false;
    }
}
