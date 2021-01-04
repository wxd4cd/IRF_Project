using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trending_Visualisation.Entities
{
    public sealed class Settings
    {
        private static Settings instance = null;
        private static readonly object padlock = new object();
        private bool Empty = true;

        Settings()
        {

        }

        public static Settings Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Settings();
                    }
                    return instance;
                }
            }
        }

        public bool GetEmpty()
        {
            return Empty;
        }

        public void SetEmpty(bool state)
        {
            Empty = state;
        }
    }


}
