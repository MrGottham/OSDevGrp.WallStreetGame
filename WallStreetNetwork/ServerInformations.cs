using System;
using System.Collections.Generic;
using System.Text;
using OSDevGrp.WallStreetGame;

namespace OSDevGrp.WallStreetGame
{
    public class ServerInformations : System.Collections.Generic.List<ServerInformation>, ISelectables
    {
        public ServerInformations() : base()
        {
        }

        public System.Collections.Generic.List<ISelectable> GetSelectables()
        {
            try
            {
                System.Collections.Generic.List<ISelectable> selectables = new System.Collections.Generic.List<ISelectable>();
                foreach (ISelectable selectable in this)
                    selectables.Add(selectable);
                return selectables;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}
