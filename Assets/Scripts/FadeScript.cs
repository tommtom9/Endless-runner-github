using UnityEngine;
using System.Collections;

public class FadeScript : MonoBehaviour {

    public enum FadeMode
    {
        FadeIn,
        FadeOut
    }

    private MeshRenderer meshRenderer;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        StartFade(FadeMode.FadeIn, 1);
    }

    public void StartFade(FadeMode fadeMode, float fadeTimer)
    {
        StopCoroutine("Fade");
        StartCoroutine(Fade(fadeMode, fadeTimer));
    }

    private IEnumerator Fade(FadeMode fadeMode, float fadeTimer)
    {
        float timer = 0;
        float _fadeTimer = fadeTimer;

        while (timer < _fadeTimer)
        {
            switch (fadeMode)
            {
                case FadeMode.FadeIn:
                    FadeIn(_fadeTimer);
                    break;

                case FadeMode.FadeOut:
                    FadeOut(_fadeTimer);
                    break;
            }
            timer += Time.deltaTime;
            yield return new WaitForSeconds(0);
        }
    }

    private void FadeIn(float fadeTimer)
    {
        Color color = meshRenderer.material.color;
        meshRenderer.material.color = Color.Lerp(color, Color.clear, fadeTimer * Time.deltaTime);
    }

    private void FadeOut(float fadeTimer)
    {
        Color color = meshRenderer.material.color;
        meshRenderer.material.color = Color.Lerp(color, Color.black, fadeTimer * Time.deltaTime);
    }
}
