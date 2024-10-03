using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Construction
{
    public class BuildButton : MonoBehaviour
    {
        [Header("Elements")]
        [SerializeField] private ConstructionController constructionController;
        [SerializeField] private float holdTimeThreshold = 0.5f;
        [SerializeField] private bool isUpdating;

        private float _holdTime;
        private Coroutine _updateRoutine;

        public void OnPointerDown()
        {
            Debug.Log("Down");
            _updateRoutine = StartCoroutine(IEUpdate());
        }

        public void OnPointerUp()
        {
            Debug.Log("Up");
            _holdTime = 0f;
            isUpdating = false;
            StopCoroutine(_updateRoutine);
        }

        private IEnumerator IEUpdate()
        {
            isUpdating = true;
            while (isUpdating)
            {
                _holdTime += Time.deltaTime;

                if (_holdTime >= holdTimeThreshold)
                {
                    Debug.Log("Fly");
                    _holdTime = 0f;
                }
                yield return null;
            }
            isUpdating = false;
        }
    }
}
