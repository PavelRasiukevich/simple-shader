using System.Collections;
using UnityEngine;

public class ShaderController : MonoBehaviour
{
    public float glitchChance = 0.01f;

    private Renderer rend;

    private void Awake()
    {
        rend = GetComponent<Renderer>();
    }

    IEnumerator Start()
    {
        while (true)
        {
            float glitchTest = Random.Range(0, 0.5f);

            if (glitchTest < glitchChance)
            {
                StartCoroutine(Glitche());
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator Glitche()
    {
        float glitchDuration = Random.Range(0.1f, 0.25f);
        rend.material.SetFloat("_Amount", 0.1f);
        rend.material.SetFloat("_CutoutThresh", 1);
        rend.material.SetFloat("_Amplitude", Random.Range(1.5f, 3.5f));
        rend.material.SetFloat("_Speed", Random.Range(3, 5));
        yield return new WaitForSeconds(0.1f);
        rend.material.SetFloat("_Amount", 0);
        rend.material.SetFloat("_CutoutThresh", 0);
    }
}
