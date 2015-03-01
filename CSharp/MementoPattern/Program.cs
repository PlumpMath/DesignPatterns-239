using System;
using System.Collections.Generic;
using System.Text;

namespace MementoPattern
{
    class GameRole
    {
        private int vitality;
        public int Vitality
        {
            get { return vitality; }
            set { vitality = value; }
        }
        private int attack;
        public int Attack
        {
            get { return attack; }
            set { attack = value; }
        }
        private int defence;
        public int Defence
        {
            get { return defence; }
            set { defence = value; }
        }
        public void StateDisplay()
        {
            Console.WriteLine("角色当前状态：");
            Console.WriteLine("体力：{0}", vitality);
            Console.WriteLine("攻击力：{0}", attack);
            Console.WriteLine("防御力：{0}", defence);
            Console.WriteLine("");
        }
        public RoleStateMemento CreateMemento()
        {
            return (new RoleStateMemento(vitality, attack, defence));
        }
        public void SetMemento(RoleStateMemento memento)
        {
            vitality = memento.Vitality;
            attack = memento.Attack;
            defence = memento.Defence;
        }
    }
    class RoleStateMemento
    {
        private int vitality;
        public int Vitality
        {
            get { return vitality; }
        }
        private int attack;
        public int Attack
        {
            get { return attack; }
        }
        private int defence;
        public int Defence
        {
            get { return defence; }
        }
        public RoleStateMemento(int vitality, int attack, int defence)
        {
            this.vitality = vitality;
            this.attack = attack;
            this.defence = defence;
        }
    }
    class RoleStateCaretaker
    {
        RoleStateMemento memento;
        public MementoPattern.RoleStateMemento Memento
        {
            get { return memento; }
            set { memento = value; }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            GameRole lixiaoyao = new GameRole();
            lixiaoyao.Vitality = 100;
            lixiaoyao.Attack = 100;
            lixiaoyao.Defence = 100;
            lixiaoyao.StateDisplay();

            RoleStateCaretaker caretaker = new RoleStateCaretaker();
            caretaker.Memento = lixiaoyao.CreateMemento();

            lixiaoyao.Vitality = 0;
            lixiaoyao.Attack = 0;
            lixiaoyao.Defence = 0;
            lixiaoyao.StateDisplay();

            lixiaoyao.SetMemento(caretaker.Memento);
            lixiaoyao.StateDisplay();
        }
    }
}
