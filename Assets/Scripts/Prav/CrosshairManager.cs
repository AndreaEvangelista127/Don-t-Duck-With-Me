using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class CrosshairManager : MonoBehaviour
{
    [SerializeField]
    private RectTransform crosshair;

    [SerializeField]
    private RectTransform killCrosshair;

    [SerializeField]
    private AudioClip killAudio;

    private Tween tween;

    private static CrosshairManager instance;
    public static CrosshairManager Instance { get { return instance; } }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        Cursor.visible = false;
    }
    private void Update()
    {
        Vector2 screenPos = Mouse.current.position.ReadValue();

        SetCrosshairLocation(new Vector3(screenPos.x, screenPos.y, 0.0f));
    }
    public void SetCrosshairLocation(Vector3 location)
    {
        crosshair.position = location;
    }

    public void OnShoot()
    {
        crosshair.DOScale(2f, .05f).OnComplete(() =>
        {
            crosshair.DOScale(1f, .25f);
        });

    }

    public void OnDamage()
    {
        killCrosshair.gameObject.SetActive(true);
        killCrosshair.DOKill();

        killCrosshair.DOPunchScale(Vector3.one, .25f).OnComplete(() =>
        {
            killCrosshair.gameObject.SetActive(false);

        });
    }

}
