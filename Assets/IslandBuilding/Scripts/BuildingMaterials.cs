using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Construction.Building
{
    public class BuildingMaterials : MonoBehaviour
    {
        [SerializeField] private Renderer mainRenderer;
        [SerializeField] private MeshFilter meshFilter;

        private static int _fillProgressID = Shader.PropertyToID("_Fill_Progress");
        private static int _heightID = Shader.PropertyToID("_Height");

        private int _amountMaterials;

        [ContextMenu(nameof(GetElements))]
        private void GetElements()
        {
            mainRenderer = GetComponent<Renderer>();
            meshFilter = GetComponent<MeshFilter>();
        }

        [ContextMenu(nameof(Setup))]
        public void Setup()
        {
            _amountMaterials = mainRenderer.materials.Length;
            UpdateHeightMaterials(GetHeightMesh());
        }

        public float GetHeightMesh()
        {
            if (meshFilter == null)
                return 0f;

            return meshFilter.mesh.bounds.center.y * 2;
        }

        public void UpdateFillMaterials(float fillPercent)
        {
            for (int i = 0; i < _amountMaterials; i++)
            {
                mainRenderer.materials[i].SetFloat(_fillProgressID, fillPercent);
            }
        }

        public void UpdateHeightMaterials(float height)
        {
            for (int i = 0; i < _amountMaterials; i++)
            {
                mainRenderer.materials[i].SetFloat(_heightID, height);
            }
        }
    }
}
