using System;
using UnityEngine;

[Serializable, CreateAssetMenu(fileName = "WheelSpinSettingsData", menuName = "Data/WheelSpinSettingsData")]
public class WheelSpinSettingsData : ScriptableObject
{
    [SerializeField] private float warmupCycleDuration;
    [SerializeField] private int warmupCycleCount;

    public float WarmupCycleDuration => warmupCycleDuration;
    public int WarmupCycleCount => warmupCycleCount;
}