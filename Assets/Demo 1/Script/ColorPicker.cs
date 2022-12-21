using UnityEngine;
using UnityEngine.UI;


public class ColorPicker : MonoBehaviour
{
    [SerializeField] RectTransform _texture;
    [SerializeField] GameObject _objectChangeColor;
    [SerializeField] Texture2D _refSprite;
    [SerializeField] bool _isMesh;
    public void OnClickPickerColor()
    {
        SetColor();
    }
    private void SetColor()
    {
        Vector3 imagePos = _texture.position;
        float globalPosX = Input.mousePosition.x - imagePos.x;
        float globalPosY = Input.mousePosition.y - imagePos.y;

        int localPosX = (int)(globalPosX * (_refSprite.width / _texture.rect.width));
        int localPosY = (int)(globalPosY * (_refSprite.height / _texture.rect.height));

        Color _color = _refSprite.GetPixel(localPosX, localPosY);

        SetActualColor(_color);

    }
    void SetActualColor(Color color)
    {
        if (_isMesh)
            _objectChangeColor.GetComponent<MeshRenderer>().material.color = color;
        else
            _objectChangeColor.GetComponent<Image>().color = color;
    }
}
