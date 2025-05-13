using DG.Tweening;
using System;
using UnityEngine;

namespace Assets.Game.Scripts.Features.EndGamePanels
{
    public class EndGamePanel : MonoBehaviour
    {
        [SerializeField] private float animationDuration = 0.5f;
        [SerializeField] private Ease easeType = Ease.OutBack;

        private RectTransform _rectTransform;
        private Vector2 _originalPosition;

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
            _originalPosition = _rectTransform.anchoredPosition;
        }

        public void Show()
        {
            PlaySlideInAnimation();
        }

        private void PlaySlideInAnimation()
        {
            gameObject.SetActive(true);

            var startPosition = new Vector2(
                _originalPosition.x,
                _originalPosition.y - _rectTransform.rect.height
            );

            _rectTransform.anchoredPosition = startPosition;

            _rectTransform.DOAnchorPos(_originalPosition, animationDuration)
                .SetEase(easeType);
        }
    }
}