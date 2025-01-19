using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    public float speed = 1.0f;
    void start()
    {
        Debug.Log("Player script attached to: " + gameObject.name);

    }
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (this.transform.position.x > -4)
            {
                this.transform.position += Vector3.left * speed * Time.deltaTime;
            }

        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (this.transform.position.x < 4)
            {
                this.transform.position += Vector3.right * speed * Time.deltaTime;
            }
        }
    }
}
