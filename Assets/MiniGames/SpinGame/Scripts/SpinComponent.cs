using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using System;
using SpinGame.Data;
using SpinGame.Utilities;

public class SpinComponent : MonoBehaviour
{
    [SerializeField] private Transform wheel;
    
    private Tween _spinTween;
    
    private const string TweenId = "WheelSpin";
    
    public async UniTask PlayTween(WheelSpinSettingsData wheelSpinSettingsData, int targetSlotIndex, int slotCount = 8, Action beginCallback = null, Action endCallback = null)
    {
        Debug.Log("Spin Started: " + targetSlotIndex);

        beginCallback?.Invoke();
        
        var unitAngle = 360f / slotCount;
        var endValue = Vector3.back * (360f * wheelSpinSettingsData.WarmupCycleCount + targetSlotIndex * unitAngle);
        var duration = (wheelSpinSettingsData.WarmupCycleCount + targetSlotIndex) * wheelSpinSettingsData.WarmupCycleDuration;
        
        _spinTween?.Kill();
        _spinTween = wheel.DOLocalRotate(endValue, duration, RotateMode.WorldAxisAdd).SetEase(Ease.OutSine).SetId(TweenId);
        
        await _spinTween;
        
        
        Debug.Log("Spin Finished");
        _spinTween = null;
        endCallback?.Invoke();
    }

    public void Reset()
    {
        wheel.DOLocalRotate(Vector3.zero, Constants.WheelResetDuration);
    }
}