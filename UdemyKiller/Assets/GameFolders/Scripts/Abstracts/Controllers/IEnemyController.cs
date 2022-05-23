using UdemyKiller.Abstracts.Combats;
using UdemyKiller.Abstracts.Movements;
using UdemyKiller.Animations;
using UdemyKiller.Controllers;
using UnityEngine;
using UnityEngine.AI;

namespace UdemyKiller.Abstracts.Controllers
{
    public interface IEnemyController : IEntityController
    {
        IMover Mover { get; }
        InventoryController Inventory { get; }
        CharacterAnimation Animation { get; }
        float Magnitude { get; }
        Transform Target { get; set; }
        
    }
}

