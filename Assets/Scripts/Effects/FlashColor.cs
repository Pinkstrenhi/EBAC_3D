using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using NaughtyAttributes;

public class FlashColor : MonoBehaviour
{
    public MeshRenderer meshRenderer;
    [Header("Setup")]
        public Color color = Color.red;
        public float duration = 0.1f;
    private Color _colorDefault;
    private string _colorProperty = "_EmissionColor";
    private Tween _currentTween;

    private void Start()
    {
        _colorDefault = meshRenderer.material.GetColor(_colorProperty);
    }

    [Button]
    public void Flash()
    {
        if (!_currentTween.IsActive())
        {
            _currentTween = meshRenderer.material.DOColor(color, _colorProperty, duration).
                SetLoops(2, LoopType.Yoyo);
        }
    }
}
