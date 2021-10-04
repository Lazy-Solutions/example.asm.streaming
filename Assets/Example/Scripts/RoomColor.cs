using AdvancedSceneManager;
using UnityEngine;

public class RoomColor : MonoBehaviour
{

    public Renderer[] RoomParts;
    public Light lamp;

    public Color _color;
    public float Speed = 1, Offset;


    private MaterialPropertyBlock _propBlock;

    void Start()
    {
        _propBlock = new MaterialPropertyBlock();

        _color = new Color(
        Random.Range(0f, 1f),
        Random.Range(0f, 1f),
        Random.Range(0f, 1f));

        ApplyColor();
    }

    void ApplyColor()
    {
        foreach (var rend in RoomParts)
        {
            rend.GetPropertyBlock(_propBlock);
            _propBlock.SetColor("_Color", _color);
            _propBlock.SetColor("_EmissionColor", _color);
            rend.SetPropertyBlock(_propBlock);
        }
        lamp.color = _color;
    }

}
