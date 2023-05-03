using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultCardData : MonoBehaviour
{
    [SerializeField] private Texture DefaultCardBackTexture = null;

    public Texture GetDefaultCardBackTexture()
    {
        return DefaultCardBackTexture;
    }
}
