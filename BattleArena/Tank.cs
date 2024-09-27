using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleArena
{
    internal class Tank : Enemy
    {
        private string _name = "Tank";
        private float _maxHealth = 200;
        private float _health = 200;
        private float _attackPower = 5;
        private float _defensePower = 5;

        public Tank(string name, float maxHealth, float attackPower, float defensePower) : base(name, maxHealth, attackPower, defensePower)
        {
            _name = name;
            _maxHealth = maxHealth;
            _health = maxHealth;
            _attackPower = attackPower;
            _defensePower = defensePower;
        }
    }
}
