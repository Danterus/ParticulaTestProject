using UnityEngine;

[CreateAssetMenu(fileName = "Damage Action",menuName = "Create Castle Action/Damage action")]
public class DamageAction : CastleAction
{
    public override void TriggerAction(Castle target, int val)
    {
        var armorController = target.GetComponent<ArmorController>();
        if (armorController != null && armorController.GetCurrentArmor()>0)
        {
            armorController.TakeArmorDamage(val);
        }
        else
        {
            target.GetComponent<HealthController>().TakeDamage(val);
        }
    }
}
