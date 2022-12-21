
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[System.Serializable]
public class ColorEvent : UnityEvent<Color> { }
public class S2ColorPicker : MonoBehaviour
{
    RectTransform _rect;
    Texture2D _colorTexture;
    public ColorEvent OnColorPreview;
    public ColorEvent OnColorSelect;
    private void Start()
    {
        _rect = GetComponent<RectTransform>();
        _colorTexture = GetComponent<Image>().mainTexture as Texture2D;
    }
    private void Update()
    {
        if (RectTransformUtility.RectangleContainsScreenPoint(_rect, Input.mousePosition))
        {
            Vector2 delta;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(_rect, Input.mousePosition, null, out delta);

            float width = _rect.rect.width;
            float height = _rect.rect.height;
            delta += new Vector2(width * .5f, height * .5f);

            float x = Mathf.Clamp(delta.x / width, 0, 1f);
            float y = Mathf.Clamp(delta.y / height, 0, 1f);

            int texX = Mathf.RoundToInt(x * _colorTexture.width);
            int texY = Mathf.RoundToInt(y * _colorTexture.height);

            Color color = _colorTexture.GetPixel(texX, texY);

            OnColorPreview?.Invoke(color);

            if (Input.GetMouseButtonDown(0))
            {
                OnColorSelect?.Invoke(color);
            }
        }
    }
}
