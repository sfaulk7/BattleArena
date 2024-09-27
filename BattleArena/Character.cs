﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace BattleArena
{
    internal class Character
    {
        private string _name = "Character";
        private float _maxHealth = 10;
        private float _health = 10;
        private float _attackPower = 1;
        private float _defensePower = 1;

        public Random randomNumber = new Random();

        public string Name
        {
            get { return _name; }
        }
        public float MaxHealth
        {
            get { return _maxHealth; }
        }
        public float Health
        {
            get { return _health; }
            private set { _health = Math.Clamp(value, 0, _maxHealth); }
        }

        public float AttackPower
        {
            get { return _attackPower; }
            private set { _attackPower = Math.Clamp(value, 0, _attackPower); }
        }
        public float DefensePower
        {
            get { return _defensePower; }
            private set { _defensePower = Math.Clamp(value, 0, _defensePower); }
        }

        public Character()
        {

        }

        public Character(string name, float maxHealth, float attackPower, float defensePower)
        {
            _name = name;
            _maxHealth = maxHealth;
            _health = maxHealth;
            _attackPower = attackPower;
            _defensePower = defensePower;
        }

        public float Attack(Character other)
        {
            float damage = MathF.Max(0, _attackPower - other._defensePower);
            Console.WriteLine(Name + " did " + damage + " to " + other.Name + "!");
            other.TakeDamage(damage);
            return damage;
        }

        public void TakeDamage(float damage)
        {
            Health -= damage;
            if (Health == 0)
            {
                Die();
            }
        }

        public void Heal()
        {
            float healAmount = MaxHealth / 4;
            Health += healAmount;
            Console.WriteLine(Name + " healed " + healAmount + " health!");
        }

        public void IncreaseStats(int Increaser)
        {
            Health += Increaser;
            AttackPower += Increaser / 2;
            DefensePower += Increaser / 5;
        }

        private void Die()
        {
            Console.WriteLine(Name + " has died!");
        }

        public void PrintStats()
        {
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Health: " + Health);
            Console.WriteLine("Attack Power: " + AttackPower);
            Console.WriteLine("Defense Power: " + DefensePower);

        }
    }
}