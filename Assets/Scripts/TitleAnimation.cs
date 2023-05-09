using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;// �� �������� �������������

// ������ ����� ������� � �����
public enum CardState
{
    Front,
    Back
}
public class CardTurnOver : MonoBehaviour
{
    public GameObject mFront;// �������� ����� �����
    public GameObject mBack;// ��������� ������� �����
    public CardState mCardState = CardState.Front;// ������� ��������� �����: ������� ��� ���������?
    public float mTime = 0.3f;
    private bool isActive = false;// ������ ��������, ��� �������� ����������� � ��� ������ ���������

    /// <summary>
    /// �������������� ���� �����, �������� mCardState
    /// </summary>
    public void Init()
    {
        if (mCardState == CardState.Front)
        {
            // ���� �� ��������� �������, ��������� ����� �� 90 ��������, ����� ����� �� ���� �����
            mFront.transform.eulerAngles = Vector3.zero;
            mBack.transform.eulerAngles = new Vector3(0, 90, 0);
        }
        else
        {
            // ������ �� �����, �� �� �����
            mFront.transform.eulerAngles = new Vector3(0, 90, 0);
            mBack.transform.eulerAngles = Vector3.zero;
        }
    }
    private void Start()
    {
        Init();
    }

    /// <summary>
    /// ��������� �������������� ��� ������� �������
    /// </summary>
    public void StartBack()
    {
        if (isActive)
            return;
        StartCoroutine(ToBack());
    }
    /// <summary>
    /// ��������� �������������� ��� ������� �������
    /// </summary>
    public void StartFront()
    {
        if (isActive)
            return;
        StartCoroutine(ToFront());
    }
    /// <summary>
    /// ����������� �� �����
    /// </summary>
	IEnumerator ToBack()
    {
        isActive = true;
        mFront.transform.DORotate(new Vector3(0, 90, 0), mTime);
        for (float i = mTime; i >= 0; i -= Time.deltaTime)
            yield return 0;
        mBack.transform.DORotate(new Vector3(0, 0, 0), mTime);
        isActive = false;

    }
    /// <summary>
    /// ����������� �� �������� ����
    /// </summary>
    IEnumerator ToFront()
    {
        isActive = true;
        mBack.transform.DORotate(new Vector3(0, 90, 0), mTime);
        for (float i = mTime; i >= 0; i -= Time.deltaTime)
            yield return 0;
        mFront.transform.DORotate(new Vector3(0, 0, 0), mTime);
        isActive = false;
    }
}

