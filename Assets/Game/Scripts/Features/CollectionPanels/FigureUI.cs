using UnityEngine;
using UnityEngine.UI;

namespace Assets.Game.Scripts.Features.CollectionPanels
{
    public class FigureUI : MonoBehaviour
    {
        [SerializeField] private Image _icon;
        [SerializeField] private Image _coloredBackground;
        [SerializeField] private Image _background;

        public void ShowFigure(Sprite iconSprite, Sprite coloredBackgroundSprite, Sprite backgrroundSprite)
        {
            _icon.gameObject.SetActive(true);
            _icon.sprite = iconSprite;

            _coloredBackground.gameObject.SetActive(true);
            _coloredBackground.sprite = coloredBackgroundSprite;

            _background.gameObject.SetActive(true);
            _background.sprite = backgrroundSprite;
        }

        public void HideFigure()
        {
            _icon.gameObject.SetActive(true);
            _background.gameObject.SetActive(true);
            _coloredBackground.gameObject.SetActive(true);

        }
    }
}
