﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
public class CardRenderer : MonoBehaviour {

    public Card card;
    public Text nameArea;
    public Text textArea;

    public Vector3 targetPosition;
    public float speed = 1.0f;
    public float snapDistance = 5.0f;

    private RectTransform rectTransform;
    private float elapsedTime = 0;

	// Use this for initialization
	void Start () {
        nameArea.text = card.name;
        textArea.text = card.text;
        rectTransform = GetComponent<RectTransform>();
        rectTransform.anchoredPosition3D = new Vector3(0, 0, 0);
        rectTransform.localScale = new Vector3(1, 1, 1);
	}

    void Update() {
        if (Vector3.Distance(rectTransform.anchoredPosition3D, targetPosition) < snapDistance)
        {
            elapsedTime = 0;
            rectTransform.anchoredPosition3D = targetPosition;
        }
        else
        {
            elapsedTime += Time.deltaTime;
            rectTransform.anchoredPosition3D = Vector3.Lerp(rectTransform.anchoredPosition3D, targetPosition, speed * elapsedTime);
        }
	}
}
