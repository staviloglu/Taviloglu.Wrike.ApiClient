using System;

namespace Taviloglu.Wrike.ApiClient
{
    public partial class WrikeClient : IWrikeInvitationsClient
    {
        public IWrikeInvitationsClient Invitations
        {
            get
            {
                //return (IWrikeInvitationsClient)this;
                throw new NotImplementedException("Invitations not implemented yet!");
            }
        }

        //todo: implement methods
    }
}
