using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace AOC2.Viewmodel
{
    internal class MainViewmodel : ObservableObject
    {
        private string _output;
        public string Output
        {
            get => _output;
            set => SetProperty(ref _output, value);
        }

        private List<GameViewmodel> _games;
        public IRelayCommand FindFileExecute { get; }
        public MainViewmodel()
        {
            FindFileExecute = new RelayCommand(FindFile);
            _games = new List<GameViewmodel>();
        }

        private void FindFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text documents (.txt)|*.txt";
            string line;
            if (openFileDialog.ShowDialog() == true)
            {
                StreamReader streamReader = new StreamReader(openFileDialog.FileName);
                while ((line = streamReader.ReadLine()) != null)
                {
                    string[] LineSplit = line.Split(":");
                    _games.Add(new GameViewmodel(LineSplit[0], LineSplit[1]));
                }
            }
            Output = CountIDs(12, 14, 13).ToString();
        }

        private int CountIDs(int GoalRed, int GoalBlue, int GoalGreen)
        {
            int countedIDs = 0;
            int countedPowers = 0;
            foreach (GameViewmodel game in _games)
            {
                bool possible = true;
                int RedHigh = 0;
                int BlueHigh = 0;
                int GreenHigh = 0;
                foreach (RoundViewmodel round in game.Rounds)
                {
                    if(round.red > GoalRed)
                    {
                        possible = false;                        
                    }
                    if (round.blue > GoalBlue)
                    {
                        possible = false;

                    }
                    if (round.green > GoalGreen)
                    {
                        possible = false;

                    }

                    if (round.red > RedHigh)
                    {
                        RedHigh = round.red;
                    }
                    if (round.blue > BlueHigh)
                    {
                        BlueHigh = round.blue;
                    }
                    if (round.green > GreenHigh)
                    {
                        GreenHigh = round.green;
                    }
                }
                if(possible)
                {
                    countedIDs += game.Id;
                }
                countedPowers += (RedHigh * BlueHigh * GreenHigh);
            }

            return countedPowers;
        }
    }
}
