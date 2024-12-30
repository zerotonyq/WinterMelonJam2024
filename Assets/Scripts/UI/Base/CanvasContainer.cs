using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace UI.Base
{
    [RequireComponent(typeof(Canvas))]
    public abstract class CanvasContainer : MonoBehaviour
    {
        [SerializeField] private Canvas canvas;
    }
}