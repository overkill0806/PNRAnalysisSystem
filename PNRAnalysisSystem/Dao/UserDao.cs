using System.Collections.Generic;
using Utility;
using PNRAnalysisSystem.Models;
using PNRAnalysisSystem.Service;

namespace PNRAnalysisSystem.Dao
{
    public class UserDao
    {
        public DBUtility _DBUtility { get; set; }

        public UserDao() 
        {
            _DBUtility = new DBUtility();
        }

        public bool CreateNewUser(UserInfo model)
        {
            return _DBUtility.ExecProc("SP_User_I", model);
        }
        public List<UserAuthFuncList> GetFunctionList(long userid)
        {
            var parm = new Dictionary<string, object>() {
                {"UserId", userid }
            };
            var res = _DBUtility.QueryProcWithObject("SP_Auth_FuncList_S", parm);


            List<UserAuthFuncList>  lres = new List<UserAuthFuncList>();

            if (res.Tables.Count>0 && res.Tables[0].Rows.Count>0)
            {
                var t = new UserAuthFuncList();
                var tc = new UserAuthFuncListChid();
                var ltc = new List<UserAuthFuncListChid>();

                var root = 0;
                var tt = res.Tables[0];
               for (int i = 0; i < tt.Rows.Count;i++)
                {
                    if(root != (int)tt.Rows[i]["FuncId"])
                    {
                        t = new UserAuthFuncList();
                      
                        t.FuncId = (int)tt.Rows[i]["FuncId"];
                        t.FuncRName = (string)tt.Rows[i]["FuncRName"];
                        root = (int)tt.Rows[i]["FuncId"]; ;
                    }

                    tc = new UserAuthFuncListChid();
                    tc.FuncCId = (int)tt.Rows[i]["FuncCId"];                   
                    tc.FuncCName = (string)tt.Rows[i]["FuncCName"];
                    tc.FuncRoute = (string)tt.Rows[i]["FuncRoute"];
                    ltc.Add(tc);

                    if (i+1< tt.Rows.Count && root != (int)tt.Rows[i+1]["FuncId"])
                    {
                        t.FuncChid = ltc;
                        lres.Add(t);
                        ltc = new List<UserAuthFuncListChid>();
                    }
                    if (i == tt.Rows.Count - 1)
                    {
                        t.FuncChid = ltc;
                        lres.Add(t);
                    }
                }
            }

            return lres;
        }
        public bool IsValidLogin(string accountid, string pwd)
        {
            var param = new Dictionary<string, object>
                {
                    {"UserAccount", accountid},
                    {"UserPwd", pwd}
                };
            var IsValid = _DBUtility.QueryProcWithObject("SP_User_S", param);

            if (IsValid.Tables[0].Rows.Count>0)
            {
                return true;
            }

            return false;
        }

        public bool AddDepartment(string groupId, string groupName)
        {
            var parm = new Dictionary<string, object>() {
                {"GroupId", groupId },
                {"GroupName", groupName },
                {"Type","I" }
            };

            return _DBUtility.ExecProcWithObject("SP_Group_IU", parm);
        }

        public bool AddFunc(string funcId, string funcCId, string funcRName, string funcCName, string funcRoute)
        {
            var parm = new Dictionary<string, object>() {
                {"FuncId", funcId },
                {"FuncCId", funcCId },
                {"FuncRName", funcRName },
                {"FuncCName", funcCName },
                {"FuncRoute", funcRoute },
                {"Type","I" }
            };

            return _DBUtility.ExecProcWithObject("SP_FuncList_IUS", parm);
        }

        public List<UserFuncList> GetAllFuncList(string groupid)
        {
            var parm = new Dictionary<string, object>() {
                {"GroupId", groupid }
            };

            var res = _DBUtility.QueryProcWithObject("SP_Group_Auth_Func_S", parm);

            var _ServiceAuth = new ServiceAuth();

            var _UserFuncList = new UserFuncList();
            var _LUserFuncList = new List<UserFuncList>();

            if (res.Tables.Count>0 && res.Tables[0].Rows.Count>0)
            {
                var tt = res.Tables[0];
                for (int i = 0; i < tt.Rows.Count; i++)
                {
                    _UserFuncList = new UserFuncList();
                    _UserFuncList.GroupId = (string)tt.Rows[i]["GroupId"];
                    _UserFuncList.FuncId = (int)tt.Rows[i]["FuncId"];
                    _UserFuncList.FuncRName = (string)tt.Rows[i]["FuncRName"];
                    _UserFuncList.FuncCId = (int)tt.Rows[i]["FuncCId"];
                    _UserFuncList.FuncCName = (string)tt.Rows[i]["FuncCName"];
                    _UserFuncList.FuncSum = (int)tt.Rows[i]["FuncSum"];
                    if (_UserFuncList.FuncSum > 0)
                    {
                        _UserFuncList.AuthAct = _ServiceAuth.AuthAct(_UserFuncList.FuncSum);
                    }
                    else
                        _UserFuncList.AuthAct = new UserAuthAct();

                    _LUserFuncList.Add(_UserFuncList);
                }
            }

            return _LUserFuncList;
        }
        public bool UpdateFuncSum(string groupId, string[] chkfuncCId)
        {
            string funcCId = string.Empty;
            string chkflag = string.Empty;
            int funcsum = 0;
            try
            {
                for (int i = 0; i < chkfuncCId.Length; i++)
                {
                    funcCId = chkfuncCId[i].Split('_')[0];
                    chkflag = chkfuncCId[i].Split('_')[2];
                    funcsum += (chkflag=="c"? Convert.ToInt16(chkfuncCId[i].Split('_')[1]):0);                    

                    if (i == chkfuncCId.Length - 1 || funcCId != chkfuncCId[i + 1].Split('_')[0])
                    {
                        var dic = new Dictionary<string, object>()
                            {
                                {"GroupId", groupId},
                                {"FuncCId", funcCId},
                                {"FuncSum", funcsum},
                                {"Type", "U"},
                            };

                        _DBUtility.ExecProcWithObject("SP_Group_Auth_Func_U", dic);

                        funcsum = 0;
                    }
                }
            }
            catch (Exception e)
            {
                return false;
            }         

            return true;
        }
    }
}
