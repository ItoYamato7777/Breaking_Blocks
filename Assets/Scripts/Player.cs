using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    public float speed = 1.0f;
    public bool isAcceleratable = true;
    void start()
    {
        Debug.Log("Player script attached to: " + gameObject.name);
        isAcceleratable = true;
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
        //中村
        if (Input.GetKey(KeyCode.F))
        {
            if (isAcceleratable == true)
            {
                isAcceleratable = false;
                StartCoroutine("SpeedUp");
            }
        }
    }

    IEnumerator SpeedUp()
    {
        speed *= 3;
        yield return new WaitForSeconds(3.0f);
        speed /= 3;
        StartCoroutine("CoolTime");
    }
    IEnumerator CoolTime()
    {
        yield return new WaitForSeconds(1.0f);
        isAcceleratable = true;
    }
}
