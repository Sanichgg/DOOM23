using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager 
{

    static HashSet<DamagebleComponent> damagebleComponents = new HashSet<DamagebleComponent>();

    public static IReadOnlyCollection<DamagebleComponent> Enemies => damagebleComponents;

    public static void RegisterEnemy(DamagebleComponent damageble)
    {
        damagebleComponents.Add(damageble);
    }

    public static void UnregisterEnemy(DamagebleComponent damageble)
    {
        damagebleComponents.Remove(damageble);
    }
}
