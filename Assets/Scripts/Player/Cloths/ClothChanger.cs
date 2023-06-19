using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
public class ClothChanger : MonoBehaviour
{
    public SkinnedMeshRenderer skinnedMeshRenderer;
    public Texture2D texture2D;
    private string _shadeIdName = "_EmissionMap";

    [Button]
    private void ChangeTexture()
    {
        skinnedMeshRenderer.sharedMaterials[0].SetTexture(_shadeIdName,texture2D);
    }
}
