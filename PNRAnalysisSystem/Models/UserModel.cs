namespace PNRAnalysisSystem.Models
{
    public class UserInfo
    {
        public string UserAccount { get; set; }
        public string UserPwd { get; set; }
        public string UserName { get; set; }
        public string UserPhone { get; set; }
        public string UserEMail { get; set; }
        public string UserToken { get; set; }
        public string IP { get; set; }
    }

    public class UserAuthFuncList
    {
        public int FuncId { get; set; }
        public string FuncRName { get; set; }
        public List<UserAuthFuncListChid> FuncChid { get; set; }
    }
    public class UserAuthFuncListChid
    {
        public int FuncCId { get; set; }
        public string FuncCName { get; set; }
        public string FuncRoute { get; set; }
        public int FuncSum { get; set; }
    }

    public class UserFuncList
    {
        public string GroupId { get; set; }
        public int FuncId { get; set; }
        public string FuncRName { get; set; }
        public int FuncCId { get; set; }
        public string FuncCName { get; set; }
        public string FuncRoute { get; set; }
        public int FuncSum { get; set; }

        public UserAuthAct AuthAct { get; set; }
    }

    public class UserAuthAct
    {
        public bool ActView { get; set; }
        public bool ActAdd { get; set; }
        public bool ActDelete { get; set; }
        public bool ActUpdate { get; set; }
        public bool ActExport { get; set; }
        public bool ActImport { get; set; }
    }

}
