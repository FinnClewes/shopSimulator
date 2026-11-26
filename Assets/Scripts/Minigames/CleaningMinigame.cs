using TMPro;
using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class CleaningMinigame : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] RectTransform area;
    [SerializeField] TMP_Text timerText;
    [SerializeField] Sprite dirtSprite;

    [Header("Tuning")]
    [SerializeField] int minSpots = 5;
    [SerializeField] int maxSpots = 8;
    [SerializeField] float timeLimit = 9f;
    [SerializeField] float spotSize = 90f;
    [SerializeField] float scrubTime = 0.7f;

    public bool IsOpen {  get; private set; }

    readonly List<Image> spots = new();
    Action<float> onFinished;
    float timeLeft;
    bool finished;

    public void Begin(Action<float> callback)
    {
        onFinished = callback;
        finished = false;
        IsOpen = true;
        timeLeft = timeLimit;
        BuildSpots();
        panel.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void BuildSpots()
    {
        foreach (var s in spots) if (s != null) Destroy(s.gameObject);
        spots.Clear();

        int count = UnityEngine.Random.Range(minSpots, maxSpots + 1);
        var positions = new List<Vector2>();
        Rect r = area.rect;
        float hx = r.width * 0.5f - spotSize * 0.5f;
        float hy = r.height * 0.5f - spotSize * 0.5f;

        for (int i = 0; i < count; i++)
        {
            Vector2 pos = Vector2.zero;
            for (int tries = 0; tries < 30; tries++)           // avoid overlapping spots
            {
                pos = new Vector2(UnityEngine.Random.Range(-hx, hx), UnityEngine.Random.Range(-hy, hy));
                bool overlaps = false;
                foreach (var p in positions)
                    if (Vector2.Distance(p, pos) < spotSize) { overlaps = true; break; }
                if (!overlaps) break;
            }
            positions.Add(pos);

            var go = new GameObject("DirtSpot", typeof(RectTransform), typeof(Image));
            go.transform.SetParent(area, false);

            var rt = (RectTransform)go.transform;
            rt.anchorMin = rt.anchorMax = rt.pivot = new Vector2(0.5f, 0.5f);
            rt.sizeDelta = new Vector2(spotSize, spotSize);
            rt.anchoredPosition = pos;

            var img = go.GetComponent<Image>();
            img.sprite = dirtSprite;
            img.color = new Color(0.35f, 0.22f, 0.1f, 0.9f);   // brown; fades out as you scrub
            spots.Add(img);
        }
    }

    void Update()
    {
        if (!IsOpen || finished) return;

        timeLeft -= Time.deltaTime;
        timerText.text = Mathf.CeilToInt(Mathf.Max(0f, timeLeft)).ToString();

        var mouse = Mouse.current;
        bool scrubbing = mouse.leftButton.isPressed && mouse.delta.ReadValue().sqrMagnitude > 1f;

        if (scrubbing)
        {
            Vector2 pointer = mouse.position.ReadValue();
            foreach (var s in spots)
            {
                if (s.color.a <= 0f) continue;
                if (RectTransformUtility.RectangleContainsScreenPoint(s.rectTransform, pointer, null))
                {
                    var c = s.color;
                    c.a = Mathf.Max(0f, c.a - Time.deltaTime / scrubTime);
                    s.color = c;
                }
            }
        }

        int cleaned = spots.FindAll(s => s.color.a <= 0f).Count;
        if (cleaned == spots.Count || timeLeft <= 0f)
            Finish(cleaned);
    }

    void Finish(int cleaned)
    {
        finished = true;
        float score = 1f + (float)cleaned / spots.Count;       // 1.0 to 2.0
        Debug.Log($"Cleaning score: {score:0.00} ({cleaned}/{spots.Count} spots)");

        panel.SetActive(false);
        IsOpen = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        onFinished?.Invoke(score);
    }
}

