using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartScreen : MonoBehaviour
{
    [SerializeField]
    private Image _startScreen;
    [Min(0)]
    public float FadeTime = 1f;

    public void StartFade()
    {
        StartCoroutine(FadeStartScreen());
    }

    private IEnumerator FadeStartScreen()
    {
        float time = 1f;
        while(time > 0)
        {
            time -= Time.deltaTime / FadeTime;
            var color = _startScreen.color;
            color.a = Mathf.Lerp(0, 1, time);
            _startScreen.color = color;
            yield return null;
        }
        _startScreen.gameObject.SetActive(false);
        yield return null;
    }
}
