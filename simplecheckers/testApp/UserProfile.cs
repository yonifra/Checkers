using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace testApp
{
    class UserProfile
    {
        #region Private Vars

        private int name;
        private int selectedColor;  // 0 = White, 1 = Black
        private int difficulty;     // 0 = Easy, 1 = Medium, 2 = Hard

        #endregion Private Vars

        public string Name { get; set; }
        public int SelectedColor { get; set; }
        public int Difficulty { get; set; }

    }
}
