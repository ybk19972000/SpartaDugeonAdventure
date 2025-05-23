using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class InvincibleIndicator : MonoBehaviour
{
    public Image image;
    public float flashSpeed;

    private Coroutine coroutine;

    public void InvincibleFlash(float duration)
    {
        if(coroutine != null)
        {
            StopCoroutine(coroutine);
        }
        coroutine = StartCoroutine(InvinFlashLoop(duration));
    }

    private IEnumerator InvinFlashLoop(float duration)
    {
        float time = 0f;

        while(time < duration)
        {
            yield return StartCoroutine(InvinFlash());
            time += flashSpeed;
        }

        image.enabled = false;
    }
    private IEnumerator InvinFlash()
    {
        image.enabled = true;
        image.color = new Color(223f / 255f, 200f / 255f, 107f / 255f);

        float startAlpha = 0.2f;
        float a = startAlpha;

        while(a > 0.0f)
        {
            a -= (startAlpha / flashSpeed) * Time.deltaTime;
            image.color = new Color(220f / 255f, 195f / 255f, 105f / 255f, a);
            yield return null;
        }

        image.enabled = false;
    }
}
