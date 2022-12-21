using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public sealed class InertiaScrollRect : ScrollRect
{
    private readonly float _decelerationRate = 2;
    private float _scrollVelocity;
    private bool _isInertiaActive = true;

    public override void OnInitializePotentialDrag(PointerEventData eventData)
    {
        StopInertia();
    }

    public override void OnScroll(PointerEventData eventData)
    {
        float scrollDelta = eventData.scrollDelta.y * (scrollSensitivity * 0.001f);

        if (_isInertiaActive)
        {
            StopInertia();
        }

        float normalizedPosition = verticalNormalizedPosition;

        normalizedPosition += scrollDelta;
        SetNormalizedPosition(normalizedPosition, 1);
        StartInertia(scrollDelta / Time.deltaTime);
    }

    private void Update()
    {
        if (_isInertiaActive)
        {
            float scrollDelta = _scrollVelocity * Time.deltaTime;
            float normalizedPosition = verticalNormalizedPosition;
            normalizedPosition += scrollDelta;

            if (normalizedPosition <= 0 || normalizedPosition >= 1)
            {
                StopInertia();
            }
            else
            {
                SetNormalizedPosition(normalizedPosition, 1);
                _scrollVelocity -= _scrollVelocity * _decelerationRate * Time.deltaTime;

                if (Mathf.Abs(_scrollVelocity) <= 0)
                {
                    StopInertia();
                }
            }
        }
    }

    private void StartInertia(float velocity)
    {
        _scrollVelocity = velocity;
        _isInertiaActive = true;
    }

    private void StopInertia()
    {
        _scrollVelocity = 0;
        _isInertiaActive = false;
    }
}