using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BattleArena
{
    abstract class Enemy : Character
    {
        private string _name = "Enemy";
        private float _maxHealth = 10;
        private float _health = 10;
        private float _attackPower = 1;
        private float _defensePower = 1;



        public Enemy(string name, float maxHealth, float attackPower, float defensePower) : base(name, maxHealth, attackPower, defensePower)
        {
            _name = name;
            _maxHealth = maxHealth;
            _health = maxHealth;
            _attackPower = attackPower;
            _defensePower = defensePower;
        }
    }
}