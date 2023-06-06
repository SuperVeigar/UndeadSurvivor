using UnityEngine;

public class EnemyTimer
{
    private float elapsedTime;
    private float coolTime;
    private bool isUpdate;

    public void StartTimer(float coolTime)
    {
        this.coolTime = coolTime;
        isUpdate = true;

        Reset();
    }

    private void Reset()
    {
        elapsedTime = 0;
    }

    public void Update()
    {
        if (isUpdate == true)
        {
            elapsedTime += Time.deltaTime;
        }
    }

    public bool IsOverCoolTime()
    {
        if (elapsedTime >= coolTime)
        {
            elapsedTime = 0;
            return true;
        }

        return false;
    }

    public void SetCoolTime(float coolTime)
    {
        this.coolTime = coolTime;
    }

    public void AddCoolTime(float coolTime)
    {
        this.coolTime += coolTime;
    }

    public void Pause()
    {
        isUpdate = false;
    }

    public void Resume()
    {
        isUpdate = true;
    }
}
