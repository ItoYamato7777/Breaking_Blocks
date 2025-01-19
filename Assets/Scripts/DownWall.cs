using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class DownWall : MonoBehaviour
{
    private GameObject PostProcessObject;
    private Volume volume;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PostProcessObject = GameObject.Find("PostProcess");
        volume = PostProcessObject.GetComponent<Volume>();
        volume.profile.TryGet(out ChromaticAberration chromaticAberration);
        chromaticAberration.active = true;
        chromaticAberration.intensity.overrideState = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("OnTriggerEnter");
        if (collision.gameObject.name == "Ball")
        {
            StartCoroutine(ChromaticAberrationEffect());
        }
    }
    private IEnumerator ChromaticAberrationEffect()
    {
        Debug.Log("ChromaticAberrationEffect");
        volume.profile.TryGet(out ChromaticAberration chromaticAberration);
        chromaticAberration.active = true;
        chromaticAberration.intensity.overrideState = true;
        chromaticAberration.intensity.value = 1.0f;
        yield return new WaitForSeconds(1.0f);
        chromaticAberration.intensity.value = 0.0f;
    }
}
