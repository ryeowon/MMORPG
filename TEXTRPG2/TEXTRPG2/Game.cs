using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEXTRPG2
{
    public enum GameMode
    {
        Lobby,
        Town,
        Field
    }
    internal class Game
    {
        private GameMode _mode = GameMode.Lobby;
        private Player _player = null;
        private Monster _monster = null;
        Random _rand = new Random();
        public void Process()
        {
            switch (_mode)
            {
                case GameMode.Lobby:
                    ProcessLobby();
                    break;
                case GameMode.Town:
                    ProcessTown();
                    break;
                case GameMode.Field:
                    ProcessField();
                    break;
            }
        }

        private void ProcessLobby()
        {
            Console.WriteLine("직업을 선택하세요.");
            Console.WriteLine("[1] 기사");
            Console.WriteLine("[2] 궁수");
            Console.WriteLine("[3] 법사");

            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    _player = new Knight();
                    _mode = GameMode.Town;
                    break;
                case "2":
                    _player = new Archer();
                    _mode = GameMode.Town;
                    break;
                case "3":
                    _player = new Mage();
                    _mode = GameMode.Town;
                    break;
            }
        }

        private void ProcessTown()
        {
            Console.WriteLine("마을에 입장했습니다!");
            Console.WriteLine("[1] 필드로 가기");
            Console.WriteLine("[2] 로비로 돌아가기");

            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    _mode = GameMode.Field;
                    break;
                case "2":
                    _mode = GameMode.Lobby;
                    break;
            }
        }

        private void ProcessField()
        {
            Console.WriteLine("필드에 입장했습니다!");
            Console.WriteLine("[1] 싸우기");
            Console.WriteLine("[2] 일정 확률로 마을로 돌아가기");

            CreateRandomMonster();

            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    ProcessFight();
                    break;
                case "2":
                    TryEscape();
                    break;
            }
        }

        private void TryEscape()
        {
            int randValue = _rand.Next(0, 101);
            if (randValue < 33)
            {
                _mode = GameMode.Town;
                Console.WriteLine("도망치는 데 성공했습니다!");
            }
            else
            {
                Console.WriteLine("도망치는 데 실패했습니다..");
                ProcessFight();
            }
        }
        private void ProcessFight()
        {
            while(true)
            {
                int damage = _player.GetAttack();
                _monster.OnDamaged(damage);
                if (_monster.IsDead())
                {
                    Console.WriteLine("승리했습니다!!");
                    Console.WriteLine($"남은 체력: {_player.GetHp()}\n");
                    break;
                }

                damage = _monster.GetAttack();
                _player.OnDamaged(damage);

                if (_player.IsDead())
                {
                    Console.WriteLine("패배했습니다..");
                    break;
                }
            }
        }

        private void CreateRandomMonster()
        {
            int randValue = _rand.Next(0, 3);
            switch (randValue)
            {
                case 0:
                    _monster = new Slime();
                    Console.WriteLine("슬라임이 생성되었습니다.");
                    break;
                case 1:
                    _monster = new Orc();
                    Console.WriteLine("오크가 생성되었습니다.");
                    break;
                case 2:
                    _monster = new Skeleton();
                    Console.WriteLine("해골이 생성되었습니다.");
                    break;
            }
        }
    }
}
