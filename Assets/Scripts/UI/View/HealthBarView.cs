using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.View
{
    public sealed class HealthBarView : MonoBehaviour
    {
        [SerializeField] private TMP_Text health;
        [SerializeField] private Image fillImage;
        [SerializeField] private float timeFill;
        [SerializeField] private Ease ease;

        public void SetHealthLabel(int value) => health.text = $"Health: {value}";
        public void SetFillImage(int currentFill)
        {
            var target = (float)currentFill / 100f;
            fillImage.DOFillAmount( target, timeFill).SetEase(ease).SetUpdate(true);
        }
    }
}