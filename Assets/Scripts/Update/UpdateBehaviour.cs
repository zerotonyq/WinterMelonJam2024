using System;
using System.Collections.Generic;
using Gameplay.Base;
using UnityEngine;

namespace Gameplay
{
    public class UpdateBehaviour : MonoBehaviour
    {
        public readonly HashSet<IExecutable> Executables = new();
        private void FixedUpdate()
        {
            foreach (var ex in Executables) ex.Execute();
        }
    }
}