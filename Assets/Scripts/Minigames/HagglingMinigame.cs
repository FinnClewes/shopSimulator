using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class HagglingMinigame : MonoBehaviour
{
    [SerializeField] GameObject panel;        // whole minigame UI (starts disabled)
    [SerializeField] RectTransform viewport;  // has a RectMask2D; the scan line is a child of this
    [SerializeField] RectTransform strip;     // child of viewport; holds the generated bars
    [SerializeField] TMP_Text resultText;     // "Perfect!", "Scan failed", etc.

    [Header("Tuning")]
    [SerializeField] float scrollSpeed = 400f;    // pixels per second
    [SerializeField] int barCount = 30;
    [SerializeField] int targetIndex = 22;        // which bar is the price bar
    [SerializeField] float perfectWindow = 10f;   // pixels either side of the line that give 2.5x
    [SerializeField] float maxMiss = 160f;        // pixels away that give 0.5x
    [SerializeField] Color barColor = Color.black;
    [SerializeField] Color targetColor = new Color(0.85f, 0.1f, 0.1f);

    public bool IsOpen { get; private set; }

    Action<float> onFinished;
    float targetLocalX;     // centre of the price bar, in strip space
    bool finished;

    public void Begin(Action<float> callback)
    {
        onFinished = callback;
        finished = false;
        IsOpen = true;
        resultText.text = "";
        BuildBarcode();
        strip.anchoredPosition = new Vector2(viewport.rect.width * 0.5f, 0f);   // start off the right edge
        panel.SetActive(true);
    }

    void BuildBarcode()
    {
        foreach (Transform child in strip) Destroy(child.gameObject);

        float height = viewport.rect.height * 0.8f;
        float x = 0f;

        int target = UnityEngine.Random.Range(6, barCount - 6);

        for (int i = 0; i < barCount; i++)
        {
            bool isTarget = i == target;
            float width = isTarget ? 14f : UnityEngine.Random.Range(4f, 16f);

            var go = new GameObject(isTarget ? "PriceBar" : "Bar", typeof(RectTransform), typeof(Image));
            go.transform.SetParent(strip, false);

            var rt = (RectTransform)go.transform;
            rt.anchorMin = rt.anchorMax = new Vector2(0f, 0.5f);
            rt.pivot = new Vector2(0f, 0.5f);
            rt.sizeDelta = new Vector2(width, height);
            rt.anchoredPosition = new Vector2(x, 0f);

            go.GetComponent<Image>().color = isTarget ? targetColor : barColor;

            if (isTarget) targetLocalX = x + width * 0.5f;

            x += width + UnityEngine.Random.Range(6f, 18f);
        }
    }

    void Update()
    {
        if (!IsOpen || finished) return;

        strip.anchoredPosition += Vector2.left * scrollSpeed * Time.deltaTime;

        float offset = strip.anchoredPosition.x + targetLocalX;   // 0 = price bar on the scan line

        if (Keyboard.current.eKey.wasPressedThisFrame)
            Finish(CalculateMultiplier(Mathf.Abs(offset)));
        else if (offset < -maxMiss)
            Finish(0.5f);                                           // let it go past: failed scan
    }

    float CalculateMultiplier(float distance)
    {
        float t = Mathf.Clamp01((distance - perfectWindow) / (maxMiss - perfectWindow));
        return Mathf.Lerp(2.5f, 0.5f, t);
    }

    void Finish(float multiplier)
    {
        finished = true;
        resultText.text = multiplier >= 2.2f ? "Perfect scan!"
                        : multiplier >= 1.4f ? "Good scan"
                        : multiplier > 0.6f ? "Shaky scan"
                        : "Scan failed";
        Debug.Log($"Haggle result: x{multiplier:0.00}");
        StartCoroutine(Close(multiplier));
    }

    IEnumerator Close(float multiplier)
    {
        yield return new WaitForSeconds(0.5f);   // show the result text briefly
        panel.SetActive(false);
        IsOpen = false;
        onFinished?.Invoke(multiplier);
    }
}