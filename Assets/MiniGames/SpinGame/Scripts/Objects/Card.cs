using System;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using SpinGame.Data;
using SpinGame.Utilities;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SpinGame.Gameplay.Object
{
    public class Card : MonoBehaviour
    {
        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] private Image defaultItemImage;
        [SerializeField] private Image deathImage;
        [SerializeField] private TextMeshProUGUI amountText;
        [SerializeField] private Image shine;
        
        public async UniTask Show(SlotData slotData, Action startCallback = null, Action delayCallback = null, Action completeCallback = null)
        {
            startCallback?.Invoke();
            await UniTask.Delay((int)(Constants.CardDelayDuration / 2f * 1000));
            SetVisuals(slotData);
            SpinShine();
            gameObject.SetActive(true);
            await canvasGroup.DOFade(1f, Constants.CardFadeInDuration).From(0f);
            delayCallback?.Invoke();
            await UniTask.Delay((int)(Constants.CardDelayDuration * 1000));
            FadeOutShine();
            await canvasGroup.DOFade(0f, Constants.CardFadeOutDuration);
            Reset();
            completeCallback?.Invoke();
        }

        private void SetVisuals(SlotData slotData)
        {
            defaultItemImage.sprite = slotData.ItemData.Sprite;
            amountText.text = slotData.Amount.ToString();
        }

        private void Reset()
        {
            gameObject.SetActive(false);
            defaultItemImage.sprite = null;
            amountText.text = "";
            shine.DOKill();
            shine.transform.localRotation = Quaternion.identity;
        }

        private void SpinShine()
        {
            shine.color = Color.white;
            shine.DOKill();
            shine.transform
                .DOLocalRotate(360f * Vector3.back, Constants.CardShineRotationDuration, RotateMode.FastBeyond360)
                .SetRelative(true).SetEase(Ease.Linear).SetLoops(-1);
        }

        private void FadeOutShine()
        {
            shine.DOKill();
            shine.DOFade(0f, Constants.CardFadeOutDuration);
        }
    }
}