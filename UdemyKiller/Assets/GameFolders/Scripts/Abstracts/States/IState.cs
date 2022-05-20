using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UdemyKiller.Abstracts.States
{
    public interface IState
    {
        void Tick();
        void OnExit();
        void OnEnter();
    }

}
