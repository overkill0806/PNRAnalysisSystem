using PNRAnalysisSystem.Models;

namespace PNRAnalysisSystem.Service
{
    public class ServiceAuth
    {
        public UserAuthAct AuthAct(int chksum)
        {
            UserAuthAct res = new UserAuthAct();

            if ((chksum & 1) == 1)
                res.ActView = true;

            if ((chksum & 2) == 2)
                res.ActAdd = true;

            if ((chksum & 4) == 4)
                res.ActDelete = true;

            if ((chksum & 8) == 8)
                res.ActUpdate = true;

            if ((chksum & 16) == 16)
                res.ActExport = true;

            if ((chksum & 32) == 32)
                res.ActImport = true;

            return res;
        }
    }
}
