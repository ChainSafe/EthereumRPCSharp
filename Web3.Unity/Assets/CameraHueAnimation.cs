using UnityEngine;

public class CameraHueAnimation : MonoBehaviour
{
  public Camera Camera;
  public float Speed = 0.5f;

  private float _hue;

  private void Update()
  {
    _hue = Mathf.Repeat(_hue + Time.deltaTime * Speed, 1f);
    Camera.backgroundColor = Color.HSVToRGB(_hue, 1f, 1f);
  }
}