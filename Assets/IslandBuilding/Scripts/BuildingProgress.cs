using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingProgress : MonoBehaviour
{
    [SerializeField] private BuildingMaterials buildingMaterials;
    [SerializeField] private BuildingEffect buildingEffect;
    [SerializeField][Range(0, 1)] private float fillPercent;

    private void OnValidate()
    {
        Fill();
    }

    [ContextMenu(nameof(Init))]
    public void Init()
    {
        buildingMaterials.Setup();
    }

    public void Fill()
    {
        buildingMaterials.UpdateFillMaterials(fillPercent);

        buildingEffect.PlayBounce();
    }
}
