using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleArena
{
    internal class MinMaxer : Enemy
    {
        private string _name = "MinMaxer";
        private float _maxHealth = 1;
        private float _health = 1;
        private float _attackPower = 1;
        private float _defensePower = 1;

        public MinMaxer(string name, float maxHealth, float attackPower, float defensePower) : base(name, maxHealth, attackPower, defensePower)
        {
            _name = name;
            _maxHealth = maxHealth;
            _health = maxHealth;
            _attackPower = attackPower;
            _defensePower = defensePower;
        }
    }
}
