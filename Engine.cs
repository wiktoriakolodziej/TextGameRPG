using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextGameRPG
{
    internal class Engine
    {
        public GameFilePersistence FilePersistence { get; set; }
        public IGame CurrentGame { get; set; }
        public IState CurrentState { get; set; }
        public Engine() 
        {
            FilePersistence = new GameFilePersistence();
        }
        

    }
}
