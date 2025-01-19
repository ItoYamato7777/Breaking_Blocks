using System.Collections;
using UnityEngine;

public class Block : MonoBehaviour
{
    bool destroy = false;
    Vector3 scale;
    Vector3 firstScale;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scale = transform.localScale;
        firstScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (destroy) {
            scale.x -= firstScale.x * Time.deltaTime;
            scale.z -= firstScale.z * Time.deltaTime;
            this.transform.localScale = scale;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!destroy) {
            StartCoroutine("Effecter");
        }
    }

    IEnumerator Effecter() {
        destroy = true;
        this.GetComponent<BoxCollider>().isTrigger = true;
        this.GetComponent<ParticleSystem>().Play();
        yield return new WaitForSeconds(1.0f);
        Destroy(this.gameObject);
    }
}
