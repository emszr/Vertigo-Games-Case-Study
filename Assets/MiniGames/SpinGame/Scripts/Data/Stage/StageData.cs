using System;
using System.Collections.Generic;
using UnityEngine;

namespace SpinGame.Data
{
    [Serializable, CreateAssetMenu(fileName = "StageData", menuName = "Data/StageData")]
    public class StageData : ScriptableObject
    {
        [SerializeField] List<WheelData> wheels;
        
        public int WheelCount => wheels.Count;
        public List<WheelData> Wheels => wheels;
    }
}