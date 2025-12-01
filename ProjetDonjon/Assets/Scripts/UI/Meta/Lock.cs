using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Lock : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] private Sprite unlockedSprite;

    [Header("References")]
    [SerializeField] private Image _lockImage;

    
    public void Unlock(bool instant)
    {
        if (instant)
        {
            Destroy(gameObject);
            return;
        }

        StartCoroutine(UnlockCoroutine());
    }

    private IEnumerator UnlockCoroutine()
    {
        _lockImage.rectTransform.DOShakePosition(0.5f, 1f, 10, 90, false, true);

        yield return new WaitForSeconds(0.6f);

        _lockImage.DOFade(0, 0.5f).SetEase(Ease.OutBack);
        _lockImage.rectTransform.DOMove(_lockImage.rectTransform.position + Vector3.up * 0.5f, 0.5f).SetEase(Ease.OutBack);
        _lockImage.sprite = unlockedSprite;

        yield return new WaitForSeconds(0.6f);

        Destroy(gameObject);
    }
}
