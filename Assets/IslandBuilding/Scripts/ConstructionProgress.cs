using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Construction
{
    public class ConstructionProgress : MonoBehaviour
    {
        [SerializeField] private ConstructionArea constructionArea;

        private BuildingProgress _currentBuiding;

        public bool IsDoneCurrentBuilding => _currentBuiding.IsDone;

        public bool IsDone() => constructionArea.IsDone();

        public void LoadAllBuildingProgress(float[] datas) => constructionArea.LoadAllBuildingProgress(datas);

        public void SelectBuilding(int index)
        {
            _currentBuiding = constructionArea.GetBuildingProgress(index);
        }

        public void Build(float progress)
        {
            if (_currentBuiding == null)
            {
                Debug.Log("current Building is null");
                return;
            }

            _currentBuiding.Fill(progress);
        }
    }
}