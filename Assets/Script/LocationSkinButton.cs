using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public struct LocationSkinButton
{
    [field: SerializeField] public Material SkinLocation { get; private set; }

    [field: SerializeField] public Button Button { get; private set; }
}