using System;
using System.Collections;
using UnityEngine;

namespace Gameplay.DayNight
{
    public class DayNightCycler : MonoBehaviour
    {
        [SerializeField] private float time = 20f;
        [SerializeField] private float preparationTime = 10f;
        private float _currentTime;
        private float _deltaAngle;
        private YieldInstruction instr;

        public Action CycleStarted;
        public Action CycleEnded;
        public Action PrepareStarted;
        
        public void StartCycle()
        {
            _deltaAngle = 360 / time;
            
            instr = new WaitForSeconds(1f);
            
            StartCoroutine(PreparationCoroutine());
        }
        

        private IEnumerator PreparationCoroutine()
        {
            _currentTime = preparationTime-1;
            PrepareStarted?.Invoke();
            while (_currentTime >= 0)
            {
                _currentTime -= 1f;
                
                transform.Rotate(Vector3.forward, 90 / preparationTime);

                yield return instr;
            }
            
            yield return CycleCoroutine();
        }
        
        private IEnumerator CycleCoroutine()
        {
            _currentTime = time;
            CycleStarted?.Invoke();
            while (_currentTime >= 0)
            {
                _currentTime -= 1f;

                transform.Rotate(Vector3.forward, _deltaAngle);
                
                yield return instr;
            }
            CycleEnded?.Invoke();
        }
    }
}