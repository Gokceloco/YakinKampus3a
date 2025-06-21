using UnityEngine;

public class EnemyEventHandler : MonoBehaviour
{
    public Enemy enemy;
    public void AttackCompleted()
    {
        enemy.AttackCompleted();
    }
    public void ContinueWalking()
    {
        enemy.ContinueWalkingAfterAttack();
    }
}
