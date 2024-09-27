using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BattleArena
{
    internal class Swordsman : Enemy
    {
        private string _name = "Swordsman";
        private float _maxHealth = 100;
        private float _health = 100;
        private float _attackPower = 20;
        private float _defensePower = 2;

        public Swordsman(string name, float maxHealth, float attackPower, float defensePower) : base(name, maxHealth, attackPower, defensePower)
        {
            _name = name;
            _maxHealth = maxHealth;
            _health = maxHealth;
            _attackPower = attackPower;
            _defensePower = defensePower;
        }
    }
}
